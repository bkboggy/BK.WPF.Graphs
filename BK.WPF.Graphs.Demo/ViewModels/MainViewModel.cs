using BK.WPF.Graphs.Demo.Common;
using BK.WPF.Graphs.Demo.Views;
using System.Windows.Controls;

namespace BK.WPF.Graphs.Demo.ViewModels
{
    public class MainViewModel : ObservableObject
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

        public void ShowColumnGraph()
        {
            GraphView = new ColumnGraphView();
        }
    }
}
