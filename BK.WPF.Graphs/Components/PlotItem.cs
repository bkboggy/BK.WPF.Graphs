using System.Windows;
using System.Windows.Controls;

namespace BK.WPF.Graphs.Components
{
    /// <summary>
    /// Plot item.
    /// </summary>
    public class PlotItem : Control
    {
        /// <summary>
        /// Value dependency property.
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(PlotItem));

        /// <summary>
        /// Identification dependency property.
        /// </summary>
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(PlotItem));

        /// <summary>
        /// Static constructor.
        /// </summary>
        static PlotItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlotItem), 
                new FrameworkPropertyMetadata(typeof(PlotItem)));
        }

        /// <summary>
        /// Value property.
        /// </summary>
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Identification property.
        /// </summary>
        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
    }
}
