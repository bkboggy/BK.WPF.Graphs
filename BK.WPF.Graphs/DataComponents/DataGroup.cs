using System.Collections.Generic;

namespace BK.WPF.Graphs.DataComponents
{
    /// <summary>
    /// Data group used for plotting a group of items.
    /// </summary>
    public class DataGroup
    {
        /// <summary>
        /// Group name.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Group items.
        /// </summary>
        public IEnumerable<DataItem> Items { get; set; }
    }
}
