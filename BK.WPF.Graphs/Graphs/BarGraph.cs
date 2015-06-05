using BK.WPF.Graphs.Common;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace BK.WPF.Graphs.Graphs
{
    public class BarGraph : BaseGraph
    {
        static BarGraph()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BarGraph),
                new FrameworkPropertyMetadata(typeof(BarGraph)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            SetupItemsPresenter();
        }

        private void SetupItemsPresenter()
        {
            var itemsPresenter = Template.FindName("PART_ItemsPresenter", this) as ItemsControl;
            if (itemsPresenter != null)
            {
                itemsPresenter.Loaded += CalculateBarHeight;
                itemsPresenter.SizeChanged += CalculateBarHeight;
            }
        }

        private void CalculateBarHeight(object sender, EventArgs e)
        {
            var itemsPresenter = sender as ItemsControl;

            if (itemsPresenter == null) return;

            var dataItems = itemsPresenter.Items;
            if (dataItems == null || dataItems.Count < 1) return;

            var dataType = dataItems[0].GetType();
            var property = dataType.GetProperty(ValuePropertyName);
            if (property == null) return;

            var presenterHeight = itemsPresenter.ActualHeight;
            var maxBarHeight = (from object dataItem in dataItems
                             select (int)property.GetValue(dataItem, null))
                             .Concat(new[] { 0 })
                             .Max();

            foreach (var dataItem in dataItems)
            {
                var visualItem = itemsPresenter.ItemContainerGenerator.ContainerFromItem(dataItem) as ContentPresenter;
                var bar = VisualTreeUtil.FindVisualChild<Rectangle>(visualItem);
                if (bar == null || !bar.Name.Equals("PART_Bar")) continue;

                var value = (int)property.GetValue(dataItem, null);
                var height = (value / (double)maxBarHeight) * presenterHeight;
                bar.Height = height;
            }
        }
    }
}
