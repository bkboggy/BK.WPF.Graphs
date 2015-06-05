using BK.WPF.Graphs.Attritubes;

namespace BK.WPF.Demo.Models
{
    [DataItem]
    public class DataItem
    {
        [DataItemCategory]
        public string Name { get; set; }
        [DataItemValue]
        public int Value { get; set; }
    }
}
