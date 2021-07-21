﻿namespace AncientMysteries
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class MetaTypeAttribute : Attribute
    {
        public MetaTypeAttribute(MetaType type) { }
    }

    public enum MetaType
    {
        [Obsolete("As the name", true)]
        Error = 0,
        Gun,
        Magic,
        Melee,
        Equipment,
        Throwable,
        Props,
        Decoration,
        MapTools,
        Developer,
    }
}