// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Google.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WP8.BingMaps.Data
{
    using System;

    public class Google : BaseTileSource
    {
        public Google()
        {
            MapType = GoogleType.PhysicalHybrid;
            UriFormat = @"http://mt{0}.google.com/vt/lyrs={1}&z={2}&x={3}&y={4}";
        }

        public GoogleType MapType { get; set; }

        public override Uri GetUri(int x, int y, int zoomLevel)
        {
            return new Uri(string.Format(UriFormat, (x%2) + (2*(y%2)), (char) MapType, zoomLevel, x, y));
        }
    }
}