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
        /// Maximum value dependency property.  Used in calculation of the plot elements' heights.
        /// </summary>
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(PlotArea));

        /// <summary>
        /// Maximum value property.  Used in calculation of the plot elements' heights.
        /// </summary>
        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
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
