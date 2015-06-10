using System;

namespace BK.WPF.Graphs.Attritubes
{
    /// <summary>
    /// Used to mark a graph-friendly data item.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Struct)]
    public class DataItemAttribute : Attribute
    {
    }
}
