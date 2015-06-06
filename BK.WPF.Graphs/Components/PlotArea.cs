using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BK.WPF.Graphs.Components
{
    /// <summary>
    /// Graph's plotting area.
    /// </summary>
    public class PlotArea : Control
    {
        /// <summary>
        /// Data dependency property.  Used to calculate data points/items.
        /// </summary>
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(IEnumerable<PlotDataItem>), typeof(PlotArea));

        /// <summary>
        /// Data property.  Used to calculate data points/items.
        /// </summary>
        public IEnumerable Data
        {
            get { return (IEnumerable<PlotDataItem>)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static PlotArea()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlotArea), 
                new FrameworkPropertyMetadata(typeof(PlotArea)));
        }
    }
}
