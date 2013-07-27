// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BingAerial.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WP8.BingMaps.Data
{
    public class BingAerial : BaseBingSource
    {
        public BingAerial()
        {
            UriFormat = "http://h{0}.ortho.tiles.virtualearth.net/tiles/h{1}.jpeg?g=203";
        }
    }
}