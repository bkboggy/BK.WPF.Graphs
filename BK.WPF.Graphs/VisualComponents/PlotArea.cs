using System.Windows.Media;
using System.Windows.Shapes;
using BK.WPF.Graphs.DataComponents;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BK.WPF.Graphs.VisualComponents
{
    /// <summary>
    /// Graph's plotting area.
    /// </summary>
    public class PlotArea : Control
    {
        /// <summary>
        /// Data dependency property.  Used to calculate data points/items.
        /// </summary>
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(IEnumerable<DataItem>), typeof(PlotArea));

        /// <summary>
        /// Maximum value dependency property.  Used in calculation of the plot elements' heights.
        /// </summary>
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(PlotArea));

        /// <summary>
        /// Data property.  Used to calculate data points/items.
        /// </summary>
        public IEnumerable<DataItem> Data
        {
            get { return (IEnumerable<DataItem>)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        /// <summary>
        /// Maximum value property.  Used in calculation of the plot elements' heights.
        /// </summary>
        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static PlotArea()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlotArea), 
                new FrameworkPropertyMetadata(typeof(PlotArea)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Initialize();
        }

        private void Initialize()
        {
            Loaded += (o,e) => SetItems();
        }

        private void SetItems()
        {
            if (Data == null || !Data.Any())
            {
                return;
            }

            var canvas = Template.FindName("PART_Canvas", this) as Canvas;
            if (canvas == null)
            {
                return;
            }

            var itemCount = Data.Count();
            var itemWidth = canvas.ActualWidth / itemCount;
            var itemHeight = 40;

            for (var i = 0; i < Data.Count(); i++)
            {
                var rect = new Rectangle
                {
                    Width = itemWidth,
                    Height = itemHeight,
                    Fill = new SolidColorBrush(Colors.Red)
                };

                Canvas.SetLeft(rect, itemWidth*i);
                canvas.Children.Add(rect);
            }

            foreach (var item in Data)
            {
                
            }
        }
    }
}
