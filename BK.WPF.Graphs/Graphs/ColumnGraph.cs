using BK.WPF.Graphs.VisualComponents;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BK.WPF.Graphs.Graphs
{
    /// <summary>
    /// Column Graph control.
    /// </summary>
    public class ColumnGraph : BaseGraph
    {
        /// <summary>
        /// Static constructor.
        /// </summary>
        static ColumnGraph()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColumnGraph),
                new FrameworkPropertyMetadata(typeof(ColumnGraph)));
        }

        /// <summary>
        /// Initialize items to be added.
        /// </summary>
        protected override void InitializeItems()
        {
            base.InitializeItems();
            PlotItems = Data.Select(item => new Column
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
            var itemWidth = PlotArea.ActualWidth / itemCount;
            var heightRatio = PlotArea.ActualHeight / MaximumValue;

            for (var i = 0; i < itemCount; i++)
            {
                var item = PlotItems.ElementAt(i) as Column;
                if (item == null)
                {
                    continue;
                }
                item.Height = item.Value*heightRatio;
                item.Width = itemWidth;
                Canvas.SetLeft(item, itemWidth * i);
                Canvas.SetBottom(item, 0);
            }
        }
    }
}
