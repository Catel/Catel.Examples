// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WP7.BingMaps.Views
{
    using System.Device.Location;
    using System.Windows;
    using MVVM.Views;
    using Phone.Controls;
    using ViewModels;

    /// <summary>
    /// Interaction logic for MainPage.xaml.
    /// </summary>
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        [ViewToViewModel(MappingType = ViewToViewModelMappingType.ViewModelToView)]
        public GeoCoordinate MapCenter
        {
            get { return (GeoCoordinate) GetValue(MapCenterProperty); }
            set { SetValue(MapCenterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MapCenter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MapCenterProperty = DependencyProperty.Register("MapCenter", typeof (GeoCoordinate),
            typeof (MainPage), new PropertyMetadata(null, (sender, e) => ((MainPage) sender).UpdateMapCenter()));

        private void UpdateMapCenter()
        {
            map.SetView(ViewModel.MapCenter, ViewModel.ZoomLevel);
        }

        public new MainPageViewModel ViewModel
        {
            get { return base.ViewModel as MainPageViewModel; }
        }
    }
}