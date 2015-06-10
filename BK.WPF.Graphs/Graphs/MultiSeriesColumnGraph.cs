using BK.WPF.Graphs.VisualComponents;
using System.Windows;

namespace BK.WPF.Graphs.Graphs
{
    /// <summary>
    /// Multi-Series Column Graph control.
    /// </summary>
    public class MultiSeriesColumnGraph : BaseGraph
    {
        /// <summary>
        /// Static constructor.
        /// </summary>
        static MultiSeriesColumnGraph()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MultiSeriesColumnGraph),
                new FrameworkPropertyMetadata(typeof(MultiSeriesColumnGraph)));
        }
    }
}
