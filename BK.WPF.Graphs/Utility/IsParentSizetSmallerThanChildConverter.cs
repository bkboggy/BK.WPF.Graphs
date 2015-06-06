using System;
using System.Windows.Data;

namespace BK.WPF.Graphs.Utility
{
    /// <summary>
    /// Checks if parent's size is smaller than its child's size.
    /// </summary>
    public class IsParentSizeSmallerThanChildConverter : IMultiValueConverter
    {
        /// <summary>
        /// Check if parent's size is smaller than its child's size.
        /// </summary>
        /// <param name="values">Child at index 0.  Parent at index 1.</param>
        /// <param name="targetType">Not used.</param>
        /// <param name="parameter">Extra space to take into account towards child's size.</param>
        /// <param name="culture">Not used.</param>
        /// <returns>True if parent is smaller; otherwise, false.</returns>
        public object Convert(object[] values, Type targetType, object parameter, 
            System.Globalization.CultureInfo culture)
        {
            var childSize = (double) values[0];
            var parentSize = (double) values[1];
            var extra = 0.0;
            if (parameter != null)
            {
                Double.TryParse(parameter.ToString(), out extra);
            }
            return parentSize <= (childSize + extra);
        }

        /// <summary>
        ///  Not implemented.  Not used.
        /// </summary>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, 
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
