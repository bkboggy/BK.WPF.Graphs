using System.Windows;
using System.Windows.Controls;

namespace BK.WPF.Graphs.VisualComponents
{
    /// <summary>
    /// Plot item.
    /// </summary>
    public class PlotItem : Control
    {
        /// <summary>
        /// Value dependency property.
        /// </summary>
        public static readonly DependencyProperty CategoryProperty =
            DependencyProperty.Register("Category", typeof(string), typeof(PlotItem));

        /// <summary>
        /// Category dependency property.
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(PlotItem));

        /// <summary>
        /// Category property.
        /// </summary>
        public string Category
        {
            get { return (string)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
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
        /// Static constructor.
        /// </summary>
        static PlotItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlotItem),
                new FrameworkPropertyMetadata(typeof(PlotItem)));
        }
    }
}
