using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BK.WPF.Graphs.Components
{
    public class NumericalAxis : Control
    {
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof (double), typeof (NumericalAxis));

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(NumericalAxis));

        public static readonly DependencyProperty IncrementValueProperty =
            DependencyProperty.Register("IncrementValue", typeof(double), typeof(NumericalAxis));

        public static readonly DependencyProperty ScaleProperty =
            DependencyProperty.Register("Scale", typeof (IEnumerable<double>), typeof (NumericalAxis));

        static NumericalAxis()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericalAxis), 
                new FrameworkPropertyMetadata(typeof(NumericalAxis)));
        }

        public double MinValue
        {
            get { return (double) GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public double MaxValue
        {
            get { return (double) GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public double IncrementValue
        {
            get { return (double) GetValue(IncrementValueProperty); }
            set { SetValue(IncrementValueProperty, value); }
        }

        public IEnumerable<double> Scale
        {
            get { return (IEnumerable<double>) GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            CalculateScale();
        }

        private void CalculateScale()
        {
            var scale = Template.FindName("PART_Scale", this) as FrameworkElement;

            if (scale == null)
            {
                return;
            }

            var size = 0.0;
            if (Name.Equals("PART_VerticalAxis"))
            {
                size = scale.ActualHeight;
            }
            else if (Name.Equals("PART_HorizontalAxis"))
            {
                size = scale.ActualWidth;
            }

            SetValue(ScaleProperty, new double[] {8, 7, 6, 5, 4, 3, 2, 1, 0});
        }
    }
}
