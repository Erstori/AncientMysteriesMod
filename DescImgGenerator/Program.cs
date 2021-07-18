﻿using System.Threading.Tasks;

namespace DescImgGenerator
{
    static class Program
    {
        public static Lang[] languages = new[]
        {
            Lang.english,
            Lang.schinese
        };

        static void Main(string[] args)
        {
            string saveTo = args.Length == 0 ? ".\\" : args[0] + Path.DirectorySeparatorChar;
            FontMapper.Default = new CustomFontMapper();
            LoadAssembly("AncientMysteries.dll");
            ScanModItems();
            Parallel.ForEach(languages, lang =>
            {
                var sur = BuildImage(lang, out SKRectI rect);
                sur.Canvas.Flush();
                sur.Flush();
                using var snapshot = sur.Snapshot(rect);
                using var encodedData = snapshot.Encode(SKEncodedImageFormat.Png, 100);
                using var fileStream = File.OpenWrite($"{saveTo}desc_{lang}.png");
                encodedData.SaveTo(fileStream);
            });
        }

        public static SKSurface BuildImage(Lang lang, out SKRectI rect)
        {
            object _lock = new();
            int x = itemMargin, y = 0;
            var surface = SKSurface.Create(new SKImageInfo(canvasMaxWidth, canvasMaxHeight));
            var canvas = surface.Canvas;
            foreach (var item in ModItems)
            {
                #region Move Y if needed
                if ((x + itemWidth + itemMargin) > canvasMaxWidth)
                {
                    x = itemMargin;
                    y += itemHeight + itemMargin + 1;
                }
                #endregion
                var itemRect = new SKRect(x, y, x + itemWidth, y + itemHeight);
                DrawItem(canvas, item, lang, itemRect);
                #region Move X
                x += itemWidth + itemMargin + 1;
                #endregion
            }
            rect = new SKRectI(0, 0, canvasMaxWidth, y + itemHeight + itemMargin);
            return surface;
        }

        public static void DrawItem(SKCanvas canvas, Item item, Lang lang, SKRect rect)
        {
            DrawItemBackground(canvas, rect);
            SKRect padded = new(rect.Left + itemPadding, rect.Top + itemPadding, rect.Right - itemPadding, rect.Bottom - itemPadding);
            float imageHeight = padded.Height * 0.4f;
            float nameHeight = padded.Height * 0.2f;
            float descHeight = padded.Height * 0.4f;
            SKRect imageRect = crect(padded.Left, padded.Top, padded.Width, imageHeight);
            SKRect nameRect = crect(padded.Left, padded.Top + imageHeight, padded.Width, nameHeight);
            SKRect descRect = crect(padded.Left, padded.Top + imageHeight + nameHeight, padded.Width, descHeight);
            using var scaled = ScaleTexTo(item.bitmap, imageRect);
            var imageDestRect = CalculateDisplayRect(imageRect, scaled, BitmapAlignment.Start, BitmapAlignment.Center);
            canvas.DrawBitmap(scaled, imageDestRect.Left + 5, imageDestRect.Top);
            #region Draw Name
            RichString name = new RichString()
            {
                MaxWidth = nameRect.Width,
                DefaultStyle = nameStyle,
            }.Add(item.name.GetText(lang));
            name.MaxLines = 1;
            name.Paint(canvas, new SKPoint(nameRect.Left + 2, nameRect.Top + 5), paintOptions);
            #endregion
            RichString desc = new RichString()
            {
                MaxWidth = nameRect.Width,
                MaxHeight = null,
                DefaultStyle = descStyle,
            }.Add(item.description.GetText(lang));
            desc.MaxLines = 20;
            desc.Paint(canvas, new SKPoint(descRect.Left + 3, descRect.Top + 5), paintOptions);

        }
    }
}
