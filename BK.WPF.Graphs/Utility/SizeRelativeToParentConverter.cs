using System;
using System.Windows.Data;

namespace BK.WPF.Graphs.Utility
{
    /// <summary>
    /// Child size converter relative to the parent.
    /// </summary>
    public class SizeRelativeToParentConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts child's size (height or width) to the value relative
        /// to the parent.
        /// </summary>
        /// <param name="values">Index 0 and 1 must be filled with the 
        /// child and its parent. By default, index 0 is the child and 
        /// index 1 is the parent. If the positions are switched, then 
        /// an optional converter parameter must be passed, specifying 
        /// the parent index. Index 2 must be the maximum value allowed 
        /// for the child based on its current value.  Parent size will 
        /// be divided by the maximum value and multiplied by the child 
        /// size to obtain its relative height.
        /// </param>
        /// <param name="targetType">Maybe left blank.  Not used.</param>
        /// <param name="parameter">If the parent is passed in index 0, 0 
        /// must be passed, specifying this.</param>
        /// <param name="culture">Maybe left blank.  Not used.</param>
        /// <returns>The new value.</returns>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var parentIndex = 1;
            if (parameter != null)
            {
                Int32.TryParse(parameter.ToString(), out parentIndex);
            }
            var childIndex = parentIndex == 1 ? 0 : 1;
            var parentSize = (double)values[parentIndex];
            var childSize = (double)values[childIndex];
            var maxVal = (double)values[2];

            return parentSize / maxVal * childSize;
        }

        /// <summary>
        /// Not implemented.  Not used.
        /// </summary>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
