using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BK.WPF.Graphs.DataComponents;
using BK.WPF.Graphs.Graphs;

namespace BK.WPF.Graphs.VisualComponents
{
    /// <summary>
    /// Plot group items. Used for grouping data items together based
    /// on the GroupName property.
    /// </summary>
    public class PlotGroupItem : Control
    {
        /// <summary>
        /// Group name dependency property.
        /// </summary>
        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.Register("GroupName", typeof(string), typeof(PlotItem));

        /// <summary>
        /// Group dependency property.  Stores grouped data items.
        /// </summary>
        public static readonly DependencyProperty GroupProperty =
            DependencyProperty.Register("Group", typeof(IEnumerable<DataItem>), typeof(BaseGraph));

        /// <summary>
        /// Group name property.
        /// </summary>
        public string GroupName
        {
            get { return (string)GetValue(GroupNameProperty); }
            set { SetValue(GroupNameProperty, value); }
        }

        /// <summary>
        /// Group property.  Stores grouped data items.
        /// </summary>
        public IEnumerable<DataItem> Group
        {
            get { return (IEnumerable<DataItem>)GetValue(GroupProperty); }
            set { SetValue(GroupProperty, value); }
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static PlotGroupItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlotGroupItem), 
                new FrameworkPropertyMetadata(typeof(PlotGroupItem)));
        }
    }
}
