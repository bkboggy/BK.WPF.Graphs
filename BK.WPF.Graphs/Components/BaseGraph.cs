using BK.WPF.Graphs.Attritubes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace BK.WPF.Graphs.Components
{
    /// <summary>
    /// Base Graph control.
    /// </summary>
    public class BaseGraph : Control
    {
        /// <summary>
        /// Data dependency property.  Used to calculate the axes as well as 
        /// the plot data points/items.
        /// </summary>
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(IEnumerable), typeof(BaseGraph));

        /// <summary>
        /// Main title dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(BaseGraph));

        /// <summary>
        /// Main subtitle dependency property.
        /// </summary>
        public static readonly DependencyProperty SubtitleProperty =
            DependencyProperty.Register("Subtitle", typeof(string), typeof(BaseGraph));

        /// <summary>
        /// Y axis title dependency property.
        /// </summary>
        public static readonly DependencyProperty YAxisTitleProperty =
            DependencyProperty.Register("YAxisTitle", typeof(string), typeof(BaseGraph));

        /// <summary>
        /// X axis subtitle dependency property.
        /// </summary>
        public static readonly DependencyProperty YAxisSubtitleProperty =
            DependencyProperty.Register("YAxisSubtitle", typeof(string), typeof(BaseGraph));

        /// <summary>
        /// X axis title dependency property.
        /// </summary>
        public static readonly DependencyProperty XAxisTitleProperty =
            DependencyProperty.Register("XAxisTitle", typeof(string), typeof(BaseGraph));

        /// <summary>
        /// X axis subtitle dependency property.
        /// </summary>
        public static readonly DependencyProperty XAxisSubtitleProperty =
            DependencyProperty.Register("XAxisSubtitle", typeof(string), typeof(BaseGraph));

        /// <summary>
        /// Data property.  Used to calculate the axes as well as the plot data 
        /// points/items.
        /// </summary>
        public IEnumerable Data
        {
            get { return (IEnumerable)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        /// <summary>
        /// Main title property.
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Main subtitle property.
        /// </summary>
        public string Subtitle
        {
            get { return (string)GetValue(SubtitleProperty); }
            set { SetValue(SubtitleProperty, value); }
        }

        /// <summary>
        /// Y axis title property.
        /// </summary>
        public string YAxisTitle
        {
            get { return (string)GetValue(YAxisTitleProperty); }
            set { SetValue(YAxisTitleProperty, value); }
        }

        /// <summary>
        /// Y axis subtitle property.
        /// </summary>
        public string YAxisSubtitle
        {
            get { return (string)GetValue(YAxisSubtitleProperty); }
            set { SetValue(YAxisSubtitleProperty, value); }
        }

        /// <summary>
        /// X axis title property.
        /// </summary>
        public string XAxisTitle
        {
            get { return (string)GetValue(XAxisTitleProperty); }
            set { SetValue(XAxisTitleProperty, value); }
        }

        /// <summary>
        /// X axis subtitle property.
        /// </summary>
        public string XAxisSubtitle
        {
            get { return (string)GetValue(XAxisSubtitleProperty); }
            set { SetValue(XAxisSubtitleProperty, value); }
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static BaseGraph()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseGraph),
                new FrameworkPropertyMetadata(typeof(BaseGraph)));
        }

        /// <summary>
        /// Overridden OnApplyTemplate method.  Adds initialization of 
        /// internal components.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            SetComponents();
        }

        /// <summary>
        /// Sets components based on the provided data.
        /// </summary>
        private void SetComponents()
        {
            // If we have no data, there's nothing to set.
            if (Data == null)
            {
                return;
            }

            // Get the type of the IEnumerable elements.
            var dataType = Data.AsQueryable().ElementType;

            // If available, get the Category property.
            var catProp = dataType.GetProperties()
                .FirstOrDefault(prop => 
                    prop.GetCustomAttribute(typeof(DataItemCategoryAttribute)) != null);
            if (catProp == null)
            {
                return;
            }
            // If available, get the Value property.
            var valProp = dataType.GetProperties()
                .FirstOrDefault(prop => 
                    prop.GetCustomAttribute(typeof(DataItemValueAttribute)) != null);
            if (valProp == null)
            {
                return;
            }

            // Holds all of the categories in the data.
            var categories = new List<string>();
            // Minimum scale value.
            var minVal = 0.0;
            // Maximum scale value.
            var maxVal = 1.0;
            // Get all of the categories and the min/max values out of the data.
            foreach (var element in Data)
            {
                categories.Add((string) catProp.GetValue(element, null));
                var val = Convert.ToDouble(valProp.GetValue(element, null));
                if (val < minVal)
                {
                    minVal = val;
                }
                else if (val > maxVal)
                {
                    maxVal = val;
                }
            }

            // Get the X axis.
            var hAxis = Template.FindName("PART_XAxis", this);
            // Set the X axis dependencies, if not null.
            if (hAxis != null)
            {
                SetAxis(hAxis, categories, minVal, maxVal);
            }
            // Get the Y axis.
            var vAxis = Template.FindName("PART_YAxis", this);
            // Set the Y axis dependencies, if not null.
            if (vAxis != null)
            {
                SetAxis(vAxis, categories, minVal, maxVal);
            }

            // Get plot area.
            var plot = Template.FindName("PART_PlotArea", this) as PlotArea;
            if (plot == null)
            {
                return;
            }
            // Generate plot-area-friendly data.
            var plotData = from object item in Data
                           select new PlotDataItem
                           {
                               Category = (string) catProp.GetValue(item, null),
                               Value = Convert.ToDouble(valProp.GetValue(item, null))
                           };
            // Get the plot area data property.
            var plotDataProp = plot.GetType().GetProperty("Data");
            // If not null, set the data property.
            if (plotDataProp != null)
            {
                plotDataProp.SetValue(plot, plotData);
            }
        }

        /// <summary>
        /// Sets the axis dependencies.  Both categories and the min/max values
        /// are passed, since we don't know which of the axis will be using these values.  
        /// We let the logic decide what the axis is needed.
        /// </summary>
        /// <param name="axis">Target axis.</param>
        /// <param name="categories">Categories of the data.</param>
        /// <param name="minVal">Minimum value of the data.</param>
        /// <param name="maxVal">Maximum value of the data.</param>
        private void SetAxis(object axis, IEnumerable categories, double minVal, double maxVal)
        {
            // If axis is null, nothing needs to be set.
            if (axis == null)
            {
                return;
            }

            // Get axis type.
            var axisType = axis.GetType();
            // If a Categorical Axis, set its Categories property.
            if (axisType == typeof(CategoricalAxis))
            {
                var prop = axisType.GetProperty("Categories");
                prop.SetValue(axis, categories);
            }
            // If a Numerical Axis, set its minimum and maximum values.
            else if (axisType == typeof(NumericalAxis))
            {
                var minProp = axisType.GetProperty("MinValue");
                minProp.SetValue(axis, minVal);
                var maxProp = axisType.GetProperty("MaxValue");
                maxProp.SetValue(axis, maxVal);
            }
        }
    }
}
