using System;
using System.Windows;
using System.Windows.Controls;

namespace BK.WPF.Graphs.Components
{
    public class DataItem : Control
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof (Object), typeof (DataItem));

        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof (Object), typeof (DataItem));

        static DataItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataItem), 
                new FrameworkPropertyMetadata(typeof(DataItem)));
        }

        public Object Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public Object Id
        {
            get { return GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
    }
}
