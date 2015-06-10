using BK.WPF.Graphs.VisualComponents;
using System.Windows;

namespace BK.WPF.Graphs.Graphs
{
    /// <summary>
    /// Bar Graph control.
    /// </summary>
    public class BarGraph : BaseGraph
    {
        /// <summary>
        /// Static constructor.
        /// </summary>
        static BarGraph()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (BarGraph),
                new FrameworkPropertyMetadata(typeof (BarGraph)));
        }
    }
}
