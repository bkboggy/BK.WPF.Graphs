using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BK.WPF.Graphs.Components
{
    public class CategorialAxis : Control
    {
        public static readonly DependencyProperty CategoriesProperty =
            DependencyProperty.Register("Categories", typeof (IEnumerable<string>), typeof (CategorialAxis));

        static CategorialAxis()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CategorialAxis), 
                new FrameworkPropertyMetadata(typeof(CategorialAxis)));
        }

        public IEnumerable<string> Categories
        {
            get { return (IEnumerable<string>) GetValue(CategoriesProperty); }
            set
            {
                SetValue(CategoriesProperty, value);
                OnCategoriesChanged();
            }
        }

        private void OnCategoriesChanged()
        {
            
        }
    }
}
