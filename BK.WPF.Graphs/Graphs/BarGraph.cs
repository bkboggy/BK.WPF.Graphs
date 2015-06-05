using BK.WPF.Graphs.Components;
using System.Windows;

namespace BK.WPF.Graphs.Graphs
{
    public class BarGraph : Graph
    {
        static BarGraph()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BarGraph), 
                new FrameworkPropertyMetadata(typeof(BarGraph)));
        }
    }
}
