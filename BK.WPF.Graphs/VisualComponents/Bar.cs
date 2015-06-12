using System.Windows;

namespace BK.WPF.Graphs.VisualComponents
{
    /// <summary>
    /// Bar.
    /// </summary>
    public class Bar : PlotItem
    {
        /// <summary>
        /// Static constructor.
        /// </summary>
        static Bar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Bar),
                new FrameworkPropertyMetadata(typeof(Bar)));
        }
    }
}
