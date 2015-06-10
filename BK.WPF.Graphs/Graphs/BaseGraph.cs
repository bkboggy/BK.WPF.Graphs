using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BK.WPF.Graphs.DataComponents;
using BK.WPF.Graphs.EventArgs;
using BK.WPF.Graphs.VisualComponents;

namespace BK.WPF.Graphs.Graphs
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
            DependencyProperty.Register("Data", typeof(IEnumerable<DataItem>), typeof(BaseGraph));

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
        public IEnumerable<DataItem> Data
        {
            get { return (IEnumerable<DataItem>)GetValue(DataProperty); }
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
        /// Maximum value, based on data. Used for component size calculations.
        /// </summary>
        public double MaximumValue { get; protected set; }

        /// <summary>
        /// Minimum value, based on data. Used for component size calculations.
        /// </summary>
        public double MinimumValue { get; protected set; }

        /// <summary>
        /// Plotting area.
        /// </summary>
        public Canvas PlotArea { get; protected set; }


        /// <summary>
        /// Plot items.
        /// </summary>
        public IEnumerable<Control> PlotItems { get; protected set; }

        /// <summary>
        /// Item selected event registration.
        /// </summary>
        public static readonly RoutedEvent ItemSelectedEvent =
            EventManager.RegisterRoutedEvent("ItemSelected", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(BaseGraph));

        /// <summary>
        /// Item selected event wrapper.
        /// </summary>
        public event RoutedEventHandler ItemSelected
        {
            add { AddHandler(ItemSelectedEvent, value); }
            remove { RemoveHandler(ItemSelectedEvent, value); }
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
            Initialize();
        }

        /// <summary>
        /// Initialize graph.
        /// </summary>
        protected virtual void Initialize()
        {
            // If data is null or empty, we can't initialize anything.
            if (Data == null || !Data.Any())
            {
                return;
            }

            // If can't find the canvas part, we can't plot anything.
            PlotArea = Template.FindName("PART_PlotArea", this) as Canvas;
            if (PlotArea == null)
            {
                return;
            }

            // Setup event handlers.
            PlotArea.Loaded += (o, e) => SetupItems();
            PlotArea.SizeChanged += (o, e) => UpdatePlot();

            // Get the maximum value.
            MaximumValue = Data.Max(x => x.Value);

            // Get the minimum value.
            MinimumValue = Math.Min(Data.Min(x => x.Value), 0);

            #region OLD CODE

            //// Get the type of the IEnumerable elements.
            //var dataType = Data.AsQueryable().ElementType;
            //
            //// If available, get the Category property.
            //var catProp = dataType.GetProperties()
            //    .FirstOrDefault(prop => 
            //        prop.GetCustomAttribute(typeof(DataItemCategoryAttribute)) != null);
            //if (catProp == null)
            //{
            //    return;
            //}
            //// If available, get the Value property.
            //var valProp = dataType.GetProperties()
            //    .FirstOrDefault(prop => 
            //        prop.GetCustomAttribute(typeof(DataItemValueAttribute)) != null);
            //if (valProp == null)
            //{
            //    return;
            //}
            //// If available, get the Group property.  Do not check for null yet,
            //// as group not required.
            //var grpProp = dataType.GetProperties()
            //    .FirstOrDefault(prop =>
            //        prop.GetCustomAttribute(typeof(DataItemGroupNameAttribute)) != null);
            //
            //// Holds all of the categories in the data.
            //var categories = new List<string>();
            //// Holds all of the group values.
            //var groups = new List<string>();
            //// Minimum scale value.
            //var minVal = 0.0;
            //// Maximum scale value.
            //var maxVal = 1.0;
            //// Get all of the categories and the min/max values out of the data.
            //foreach (var element in Data)
            //{
            //    categories.Add((string) catProp.GetValue(element, null));
            //
            //    // Now we check if group property is null.
            //    if (grpProp != null)
            //    {
            //        groups.Add((string)grpProp.GetValue(element, null));
            //    }
            //
            //    var val = Convert.ToDouble(valProp.GetValue(element, null));
            //    if (val < minVal)
            //    {
            //        minVal = val;
            //    }
            //    else if (val > maxVal)
            //    {
            //        maxVal = val;
            //    }
            //}
            //
            //maxVal = maxVal.RoundUp();
            //
            //// Get the X axis.
            //var hAxis = Template.FindName("PART_XAxis", this);
            //// Set the X axis dependencies, if not null.
            //if (hAxis != null)
            //{
            //    SetAxis(hAxis, categories, minVal, maxVal);
            //}
            //// Get the Y axis.
            //var vAxis = Template.FindName("PART_YAxis", this);
            //// Set the Y axis dependencies, if not null.
            //if (vAxis != null)
            //{
            //    SetAxis(vAxis, categories, minVal, maxVal);
            //}
            //
            //// Get plot area.
            //var plot = Template.FindName("PART_PlotArea", this) as PlotArea;
            //// Set the plot area dependencies, if not null.
            //if (plot != null)
            //{
            //    SetPlotArea(catProp, valProp, grpProp, plot, maxVal);
            //}

            #endregion
        }

        /// <summary>
        /// Sets up plot items.
        /// </summary>
        protected virtual void SetupItems()
        {
            InitializeItems();
            AddItemsToCanvas();
        }

        /// <summary>
        /// Initializes plot items.
        /// </summary>
        protected virtual void InitializeItems()
        {

        }

        /// <summary>
        /// Adds items to the plot canvas, if there are any.
        /// </summary>
        protected virtual void AddItemsToCanvas()
        {
            if (PlotItems == null || !PlotItems.Any())
            {
                return;
            }

            foreach (var item in PlotItems)
            {
                item.MouseLeftButtonDown += RaiseItemSelectedEvent;
                PlotArea.Children.Add(item);
            }
            UpdatePlot();
        }

        /// <summary>
        /// Raises the new event of item selection.
        /// </summary>
        /// <param name="sender">PlotItem</param>
        /// <param name="e">MouseButtonEventArgs</param>
        protected virtual void RaiseItemSelectedEvent(object sender, MouseButtonEventArgs e)
        {
            var item = sender as PlotItem;
            if (item == null)
            {
                return;
            }
            RaiseEvent(new ItemSelectedEventArgs(ItemSelectedEvent, item, this));
        }

        /// <summary>
        /// Determines how plot items are displayed on the plot.
        /// </summary>
        protected virtual void UpdatePlot()
        {
            // If there are no plot items and if plot area has any children, clear it.
            if (PlotItems == null && PlotArea.Children != null && PlotArea.Children.Count > 0)
            {
                PlotArea.Children.Clear();
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
