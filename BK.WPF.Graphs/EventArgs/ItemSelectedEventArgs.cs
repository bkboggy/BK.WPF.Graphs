using BK.WPF.Graphs.Graphs;
using BK.WPF.Graphs.VisualComponents;
using System.Windows;

namespace BK.WPF.Graphs.EventArgs
{
    public class ItemSelectedEventArgs : RoutedEventArgs
    {
        public PlotItem Item { get; private set; }
        public BaseGraph Graph { get; private set; }

        public ItemSelectedEventArgs(RoutedEvent e, PlotItem item, BaseGraph graph)
        {
            RoutedEvent = e;
            Item = item;
            Graph = graph;
        }
    }
}
