using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BK.WPF.Demo
{
    [Graphs.Attritubes.DataItem]
    public class Item
    {
        [Graphs.Attritubes.DataItemCategory]
        public string Name { get; set; }
        [Graphs.Attritubes.DataItemValue]
        public double Value { get; set; }
    }

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Item> _items;
        [Graphs.Attritubes.DataItemCollection]
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeItems();
        }

        private void InitializeItems()
        {
            Items = new ObservableCollection<Item>
            {
                new Item { Name = "Item #2", Value = 22 },
                new Item { Name = "Item #3", Value = 53 },
                new Item { Name = "Item #4", Value = 25 },
                new Item { Name = "Item #5", Value = 12 },
                new Item { Name = "Item #6", Value = 70 },
                new Item { Name = "Item #7", Value = 555 },
                new Item { Name = "Item #8", Value = 12 },
                new Item { Name = "Item #9", Value = 23 },
                new Item { Name = "Item #10", Value = 67 },
                new Item { Name = "Item #11", Value = 28 },
                new Item { Name = "Item #12", Value = 78 },
                new Item { Name = "Item #13", Value = 55 },
                new Item { Name = "Item #14", Value = 45 },
                new Item { Name = "Item #15", Value = 35 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
