using System;

namespace BK.WPF.Graphs.Attritubes
{
    /// <summary>
    /// Used to mark the value property to be used by the graph.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DataItemValueAttribute : Attribute
    {
    }
}
