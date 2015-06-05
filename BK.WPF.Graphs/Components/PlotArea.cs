using System.Windows;
using System.Windows.Controls;

namespace BK.WPF.Graphs.Components
{

    public class PlotArea : Control
    {
        static PlotArea()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlotArea), 
                new FrameworkPropertyMetadata(typeof(PlotArea)));
        }
    }
}
