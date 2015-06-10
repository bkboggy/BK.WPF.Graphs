using BK.WPF.Graphs.VisualComponents;
using System.Windows;

namespace BK.WPF.Graphs.Graphs
{
    /// <summary>
    /// Multi-Series Bar Graph control.
    /// </summary>
    public class MultiSeriesBarGraph : BaseGraph
    {
        /// <summary>
        /// Static constructor.
        /// </summary>
        static MultiSeriesBarGraph()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MultiSeriesBarGraph),
                new FrameworkPropertyMetadata(typeof(MultiSeriesBarGraph)));
        }
    }
}
