using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using BK.WPF.Graphs.Attritubes;

namespace BK.WPF.Graphs.Components
{
    public class Graph : Control
    {
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(IEnumerable), typeof(Graph));

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(Graph));

        public static readonly DependencyProperty SubtitleProperty =
            DependencyProperty.Register("Subtitle", typeof(string), typeof(Graph));

        public static readonly DependencyProperty YAxisTitleProperty =
            DependencyProperty.Register("YAxisTitle", typeof(string), typeof(Graph));

        public static readonly DependencyProperty YAxisSubtitleProperty =
            DependencyProperty.Register("YAxisSubtitle", typeof(string), typeof(Graph));

        public static readonly DependencyProperty XAxisTitleProperty =
            DependencyProperty.Register("XAxisTitle", typeof(string), typeof(Graph));

        public static readonly DependencyProperty XAxisSubtitleProperty =
            DependencyProperty.Register("XAxisSubtitle", typeof(string), typeof(Graph));

        static Graph()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Graph), 
                new FrameworkPropertyMetadata(typeof(Graph)));
        }

        public IEnumerable Data
        {
            get { return (IEnumerable)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string Subtitle
        {
            get { return (string)GetValue(SubtitleProperty); }
            set { SetValue(SubtitleProperty, value); }
        }

        public string YAxisTitle
        {
            get { return (string)GetValue(YAxisTitleProperty); }
            set { SetValue(YAxisTitleProperty, value); }
        }

        public string YAxisSubtitle
        {
            get { return (string)GetValue(YAxisSubtitleProperty); }
            set { SetValue(YAxisSubtitleProperty, value); }
        }

        public string XAxisTitle
        {
            get { return (string)GetValue(XAxisTitleProperty); }
            set { SetValue(XAxisTitleProperty, value); }
        }

        public string XAxisSubtitle
        {
            get { return (string)GetValue(XAxisSubtitleProperty); }
            set { SetValue(XAxisSubtitleProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            SetComponents();
        }

        private void SetComponents()
        {
            if (Data == null)
            {
                return;
            }

            var dataType = Data.AsQueryable().ElementType;

            var catProp = dataType.GetProperties()
                .FirstOrDefault(prop => prop.GetCustomAttribute(typeof(DataItemCategoryAttribute)) != null);

            if (catProp == null)
            {
                return;
            }

            var valProp = dataType.GetProperties()
                .FirstOrDefault(prop => prop.GetCustomAttribute(typeof(DataItemValueAttribute)) != null);

            if (valProp == null)
            {
                return;
            }

            var categories = new List<string>();
            var minVal = 0.0;
            var maxVal = 0.0;

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

            var hAxis = Template.FindName("PART_HorizontalAxis", this);
            SetAxis(hAxis, categories, minVal, maxVal);
            var vAxis = Template.FindName("PART_VerticalAxis", this);
            SetAxis(vAxis, categories, minVal, maxVal);
        }

        private void SetAxis(object axis, IEnumerable categories, double minVal, double maxVal)
        {
            if (axis == null)
            {
                return;
            }

            var axisType = axis.GetType();
            if (axisType == typeof(CategorialAxis))
            {
                var prop = axisType.GetProperty("Categories");
                prop.SetValue(axis, categories);
            }
            else if (axisType == typeof(NumericalAxis))
            {
                var minProp = axisType.GetProperty("MinValue");
                var maxProp = axisType.GetProperty("MaxValue");
                minProp.SetValue(axis, minVal);
                maxProp.SetValue(axis, maxVal);
            }
        }
    }
}
