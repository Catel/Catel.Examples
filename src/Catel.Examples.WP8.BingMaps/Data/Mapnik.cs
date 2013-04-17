// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mapnik.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WP8.BingMaps.Data
{
    using System;

    public class Mapnik : BaseTileSource
    {
        public Mapnik()
        {
            UriFormat = "http://{0}.tile.openstreetmap.org/{1}/{2}/{3}.png";
        }

        private static readonly string[] TilePathPrefixes = new[] {"a", "b", "c"};

        public override Uri GetUri(int x, int y, int zoomLevel)
        {
            if (zoomLevel > 0)
            {
                var url = string.Format(UriFormat, TilePathPrefixes[y%3], zoomLevel, x, y);
                return new Uri(url);
            }

            return null;
        }
    }
}