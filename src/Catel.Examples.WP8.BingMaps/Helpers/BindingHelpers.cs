// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BindingHelpers.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WP8.BingMaps
{
    using System.Windows;

#if WP7
    using Microsoft.Phone.Controls.Maps;
#else
    using Microsoft.Phone.Maps.Controls;
#endif

    public static class BindingHelpers
    {
        // Name, Property type, type of object that hosts the property, method to call when anything changes
        public static readonly DependencyProperty TileSourceProperty =
            DependencyProperty.RegisterAttached("TileSource", typeof (TileSource),
                                                typeof (BindingHelpers), new PropertyMetadata(SetTileSourceCallback));

        // Called when TileSource is retrieved
        public static TileSource GetTileSource(DependencyObject obj)
        {
            return obj.GetValue(TileSourceProperty) as TileSource;
        }

        // Called when TileSource is set
        public static void SetTileSource(DependencyObject obj, TileSource value)
        {
            obj.SetValue(TileSourceProperty, value);
        }

        //Called when TileSource is set
        private static void SetTileSourceCallback(object sender, DependencyPropertyChangedEventArgs args)
        {
            var map = sender as Map;
            var newSource = args.NewValue as TileSource;
            if (newSource == null || map == null)
            {
                return;
            }

            // Remove existing layer(s)
#if WP7
            for (var i = map.Children.Count - 1; i >= 0; i--)
            {
                var tileLayer = map.Children[i] as MapTileLayer;
                if (tileLayer != null)
                {
                    map.Children.RemoveAt(i);
                }
            }

            var newLayer = new MapTileLayer();
            newLayer.TileSources.Add(newSource);
            map.Children.Add(newLayer);
#endif
        }
    }
}