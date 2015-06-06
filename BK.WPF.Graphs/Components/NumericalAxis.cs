using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

        public IEnumerable<double> Scale
        {
            get { return (IEnumerable<double>) GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        /// <summary>
        /// Overridden OnApplyTemplate method.  Adds event handlers
        /// and initialization of components.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Loaded += NumericalAxis_Loaded;
            SizeChanged += NumericalAxis_SizeChanged;
        }

        /// <summary>
        /// Loaded event handler.
        /// </summary>
        /// <param name="sender">Numerical Axis control instance.</param>
        /// <param name="e">Event arguments.</param>
        private void NumericalAxis_Loaded(object sender, RoutedEventArgs e)
        {
            CalculateScale();
        }

        /// <summary>
        /// SizeChanged event handler.
        /// </summary>
        /// <param name="sender">Numerical Axis control instance.</param>
        /// <param name="e">SizeChanged event arguments.</param>
        private void NumericalAxis_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CalculateScale();
        }

        /// <summary>
        /// Calculates the numerical scale.
        /// </summary>
        private void CalculateScale()
        {
            // Get the Scale part.
            var scale = Template.FindName("PART_Scale", this) as FrameworkElement;

            // If scale is null, unable to proceed.
            if (scale == null)
            {
                return;
            }

            // Stores scale size.
            var size = 0.0;
            // If this is a vertical scale, get the height.
            if (Name.Equals("PART_YAxis"))
            {
                size = ActualHeight;
            }
            // However, if this is a horizontal scale, get the width.
            else if (Name.Equals("PART_XAxis"))
            {
                size = ActualWidth;
            }

            // ---------------------- TEST AREA (START) ---------------------- //

            var interval = 1;
            while (interval < 1000000000)
            {
                var factor = MaxValue / interval;
                if (factor <= 10)
                {
                    break;
                }
                interval *= 10;
            }

            var scaleCount = (int)(MaxValue/interval);


            if (scaleCount < 10 && scaleCount < size / 150 && interval != 1)
            {
                var tempInterval = interval / 10;
                var tempScaleCount = (int)(MaxValue / tempInterval);
                if (tempScaleCount > 10)
                {
                    interval /= 5;
                }
                else
                {
                    interval = tempInterval;
                }
            }
            else if (scaleCount > size / 10)
            {
                interval *= 5;
            }

            scaleCount = (int)(MaxValue / interval);

            // Stores scale values.
            var scaleValues = new List<double> { MaxValue };
            // Calculate and store scale values.
            for (var i = 1; i < scaleCount; i++)
            {
                scaleValues.Add((int)(MaxValue - i * interval));
            }

            // ----------------------- TEST AREA (END) ----------------------- //

            // Set the scale property.
            SetValue(ScaleProperty, scaleValues);
        }
    }
}
