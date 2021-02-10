﻿using Microsoft.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace AncientMysteries.SourceGenerator
{
    public abstract class _BaseGenerator : ISourceGenerator
    {
        private static string[] _tabLevelsCache = new string[16];

        public abstract string UniqueName { get; }

        public abstract void Execute(GeneratorExecutionContext context);

        public abstract void Initialize(GeneratorInitializationContext context);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string TabLevel(int level) => _tabLevelsCache[level] ??= new string(' ', level * 4);
    }
}