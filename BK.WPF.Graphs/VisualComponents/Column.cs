using System.Windows;

namespace BK.WPF.Graphs.VisualComponents
{
    /// <summary>
    /// Column.
    /// </summary>
    public class Column : PlotItem
    {
        /// <summary>
        /// Static constructor.
        /// </summary>
        static Column()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Column),
                new FrameworkPropertyMetadata(typeof(Column)));
        }
    }
}
