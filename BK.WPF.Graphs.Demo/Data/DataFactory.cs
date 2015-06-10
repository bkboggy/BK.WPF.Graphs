using System.Globalization;
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
                    Category = "Item " + (i+1),
                    Value = rnd.Next(1, 10)
                });
            }
            return data;
        }

        public IEnumerable<DataItem> GenerateSampleDataByYear(int startingYear = 0)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var data = new List<DataItem>();
            if (startingYear == 0)
            {
                startingYear = DateTime.Now.Year - rnd.Next(4, 10);
            }

            for (var year = startingYear; year <= DateTime.Now.Year; year++)
            {
                data.Add(new DataItem
                {
                    Category = year.ToString(CultureInfo.InvariantCulture),
                    Value = rnd.Next(1, 150)
                });
            }

            return data;
        }
    }
}
