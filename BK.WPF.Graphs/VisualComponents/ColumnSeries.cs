using System.Collections.Generic;
using System.Windows;

namespace BK.WPF.Graphs.VisualComponents
{
    /// <summary>
    /// Column series.
    /// </summary>
    public class ColumnSeries : PlotItem
    {
        /// <summary>
        /// Items dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof (IEnumerable<Column>), typeof (ColumnSeries));

        /// <summary>
        /// Items property.  Holds columns.
        /// </summary>
        public IEnumerable<PlotItem> Items
        {
            get { return (IEnumerable<Column>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static ColumnSeries()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColumnSeries),
                new FrameworkPropertyMetadata(typeof(ColumnSeries)));
        }
    }
}
