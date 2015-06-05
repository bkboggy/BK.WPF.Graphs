using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BK.WPF.Graphs.Utility;

namespace BK.WPF.Graphs.Components
{
    public class NumericalAxis : Control
    {
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof (double), typeof (NumericalAxis),
            new PropertyMetadata(0.0));

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof (NumericalAxis),
            new PropertyMetadata(1.0));

        public static readonly DependencyProperty ScaleIntervalProperty =
            DependencyProperty.Register("ScaleInterval", typeof(double), typeof(NumericalAxis),
            new PropertyMetadata(1.0));

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

        public double ScaleInterval
        {
            get { return (double) GetValue(ScaleIntervalProperty); }
            set { SetValue(ScaleIntervalProperty, value); }
        }

        public IEnumerable<double> Scale
        {
            get { return (IEnumerable<double>) GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Loaded += NumericalAxis_Loaded;
            SizeChanged += NumericalAxis_SizeChanged;
        }

        void NumericalAxis_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CalculateScale();
        }

        void NumericalAxis_Loaded(object sender, RoutedEventArgs e)
        {
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
                size = ActualHeight;
            }
            else if (Name.Equals("PART_HorizontalAxis"))
            {
                size = ActualWidth;
            }

            SetValue(MaxValueProperty, (double)MaxValue.RoundUp());

            var interval = 1000000000;
            var flagVal = 0;
            while (flagVal == 0 && interval >= 10)
            {
                flagVal = (int)(MaxValue / interval);
                if (interval >= 10)
                {
                    interval /= 10;
                }
            }

            SetValue(ScaleIntervalProperty, (double)interval);

            var maxScaleCount = (int)(size / 40);
            var scaleCount = (MaxValue/interval);
            while (scaleCount > maxScaleCount)
            {
                interval *= 2;
                scaleCount = (MaxValue / interval);
            }

            var scaleValues = new List<double> { MaxValue };
            for (var i = 1; i < scaleCount; i++)
            {
                scaleValues.Add((int)(MaxValue - i * interval));
            }

            SetValue(ScaleProperty, scaleValues);
        }
    }
}
