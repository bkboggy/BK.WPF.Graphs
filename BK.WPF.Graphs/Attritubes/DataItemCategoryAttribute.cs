using System;

namespace BK.WPF.Graphs.Attritubes
{
    /// <summary>
    /// Used to mark the category property to be used by the graph.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DataItemCategoryAttribute : Attribute
    {
    }
}
