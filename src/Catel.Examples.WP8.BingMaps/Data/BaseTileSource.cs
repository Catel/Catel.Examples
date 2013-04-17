// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseTileSource.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WP8.BingMaps.Data
{
    using System;

#if WP7
    using Microsoft.Phone.Controls.Maps;
#else
    using Microsoft.Phone.Maps.Controls;
#endif

    public abstract class BaseTileSource : TileSource, IEquatable<BaseTileSource>
    {
        public string Name { get; set; }

        public bool Equals(BaseTileSource other)
        {
            return other != null && other.Name.Equals(Name);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseTileSource);
        }
    }
}