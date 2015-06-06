using BK.WPF.Graphs.Demo.Common;
using BK.WPF.Graphs.Demo.Data;
using BK.WPF.Graphs.Demo.Models;
using System.Collections.ObjectModel;

namespace BK.WPF.Graphs.Demo.ViewModels
{
    public class BarGraphViewModel : NotifyPropertyChangedBase
    {
        private ObservableCollection<DataItem> _data;

        public ObservableCollection<DataItem> Data
        {
            get { return _data; }
            set
            {
                if (_data == value)
                {
                    return;
                }
                _data = value;
                NotifyPropertyChanged();
            }
        }

        public BarGraphViewModel()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            var factory = new DataFactory();
            Data = new ObservableCollection<DataItem>(factory.GenerateSampleData());
        }
    }
}
