using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoStock.Services
{
    public static class DataConverter
    {
        public static string ConvertToCvs<T>(IEnumerable<T> dataList)
        {
            var csv = "";

            foreach (var prop in typeof(T).GetProperties())
            {
                csv += prop.Name + ",";
            }

            csv = csv.Substring(0, csv.Length - 1);
            csv += Environment.NewLine;
            csv += String.Join(Environment.NewLine, dataList.Select(x => x.ToString()).ToArray());

            return csv;
        }
    }
}
