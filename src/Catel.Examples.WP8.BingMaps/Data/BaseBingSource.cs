// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseBingSource.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WP8.BingMaps.Data
{
    using System;
    using System.Text;

    public abstract class BaseBingSource : BaseTileSource
    {
        private static string TileXYToQuadKey(int tileX, int tileY, int levelOfDetail)
        {
            var quadKey = new StringBuilder();
            for (var i = levelOfDetail; i > 0; i--)
            {
                char digit = '0';
                int mask = 1 << (i - 1);

                if ((tileX & mask) != 0)
                {
                    digit++;
                }

                if ((tileY & mask) != 0)
                {
                    digit++;
                    digit++;
                }

                quadKey.Append(digit);
            }

            return quadKey.ToString();
        }

        public override Uri GetUri(int x, int y, int zoomLevel)
        {
            if (zoomLevel > 0)
            {
                string quadKey = TileXYToQuadKey(x, y, zoomLevel);
                string veLink = string.Format(UriFormat, new object[] {quadKey[quadKey.Length - 1], quadKey});

                return new Uri(veLink);
            }

            return null;
        }
    }
}