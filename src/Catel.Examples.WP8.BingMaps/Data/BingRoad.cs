// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BingRoad.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WP8.BingMaps.Data
{
    public class BingRoad : BaseBingSource
    {
        public BingRoad()
        {
            UriFormat = "http://r{0}.ortho.tiles.virtualearth.net/tiles/r{1}.png?g=203";
        }
    }
}