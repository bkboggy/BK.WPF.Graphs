using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BK.WPF.Graphs.Components
{
    /// <summary>
    /// Categorical Axis control.
    /// </summary>
    public class CategoricalAxis : Control
    {
        /// <summary>
        /// Categories dependency property.
        /// </summary>
        public static readonly DependencyProperty CategoriesProperty =
            DependencyProperty.Register("Categories", typeof (IEnumerable<string>), typeof (CategoricalAxis));

        /// <summary>
        /// Categories property.
        /// </summary>
        public IEnumerable<string> Categories
        {
            get { return (IEnumerable<string>)GetValue(CategoriesProperty); }
            set { SetValue(CategoriesProperty, value); }
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static CategoricalAxis()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CategoricalAxis), 
                new FrameworkPropertyMetadata(typeof(CategoricalAxis)));
        }
    }
}
