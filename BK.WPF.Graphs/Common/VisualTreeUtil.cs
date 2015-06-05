using System.Windows;
using System.Windows.Media;

namespace BK.WPF.Graphs.Common
{
    public static class VisualTreeUtil
    {
        public static T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }

                var childItem = FindVisualChild<T>(child);
                if (childItem != null) return childItem;
            }
            return null;
        }
    }
}
