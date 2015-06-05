using BK.WPF.Demo.Common;
using BK.WPF.Demo.Views;
using System.Windows.Controls;

namespace BK.WPF.Demo.ViewModels
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        private UserControl _graphView;

        public UserControl GraphView
        {
            get { return _graphView; }
            set
            {
                if (_graphView == value)
                {
                    return;
                }
                _graphView = value;
                NotifyPropertyChanged();
            }
        }

        public void ShowBarGraph()
        {
            GraphView = new BarGraphView();
        }
    }
}
