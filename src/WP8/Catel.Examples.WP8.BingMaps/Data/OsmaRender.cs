// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OsmaRender.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WP8.BingMaps.Data
{
    using System;

    public class OsmaRender : BaseTileSource
    {
        public OsmaRender()
        {
            UriFormat = "http://{0}.tah.openstreetmap.org/Tiles/tile/{1}/{2}/{3}.png";
        }

        private static readonly string[] TilePathPrefixes = new[] {"a", "b", "c", "d", "e", "f"};

        public override Uri GetUri(int x, int y, int zoomLevel)
        {
            if (zoomLevel > 0)
            {
                var url = string.Format(UriFormat, TilePathPrefixes[(y%3) + (3*(x%2))], zoomLevel, x, y);

                return new Uri(url);
            }

            return null;
        }
    }
}