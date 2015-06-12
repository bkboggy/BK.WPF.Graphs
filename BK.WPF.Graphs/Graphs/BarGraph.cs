using System.Linq;
using System.Windows.Controls;
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

        /// <summary>
        /// Initialize items to be added.
        /// </summary>
        protected override void InitializeItems()
        {
            base.InitializeItems();
            PlotItems = Data.Select(item => new Bar
            {
                Category = item.Category,
                Value = item.Value
            }).ToArray();
        }

        /// <summary>
        /// Updates the plot.
        /// </summary>
        protected override void UpdatePlot()
        {
            base.UpdatePlot();

            // If there are no items, can't update.
            // Base clears plot.
            if (PlotItems == null)
            {
                return;
            }

            var itemCount = PlotItems.Count();
            var itemHeight = PlotArea.ActualHeight / itemCount;
            var widthRatio = PlotArea.ActualWidth / MaximumValue;

            for (var i = 0; i < itemCount; i++)
            {
                var item = PlotItems.ElementAt(i) as Bar;
                if (item == null)
                {
                    continue;
                }
                item.Height = itemHeight;
                item.Width = item.Value * widthRatio;
                Canvas.SetLeft(item, 0);
                Canvas.SetBottom(item, itemHeight * i);
            }
        }
    }
}
