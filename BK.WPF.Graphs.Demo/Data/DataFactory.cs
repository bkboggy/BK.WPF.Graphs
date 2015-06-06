using BK.WPF.Graphs.Demo.Models;
using System;
using System.Collections.Generic;

namespace BK.WPF.Graphs.Demo.Data
{
    public class DataFactory
    {
        public IEnumerable<DataItem> GenerateSampleData(int count = 10)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var data = new List<DataItem>();
            for (var i = 0; i < count; i++)
            {
                data.Add(new DataItem
                {
                    Name = "Item " + (i+1),
                    Value = rnd.Next(1, 300)
                });
            }
            return data;
        }
    }
}
