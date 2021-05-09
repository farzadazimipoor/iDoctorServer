using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AN.Web.Helper
{
    public static class StaticHelpers
    {       
        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list.Where(f => f != null))
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static DataTable ToDataTable<T>(this IList<T> list)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            int excludedCount = 0;
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.Category == "Exclude")
                {
                    excludedCount++;
                    continue;
                }

                var colName = string.IsNullOrWhiteSpace(prop.Description) ? prop.Name : prop.Description;
                table.Columns.Add(colName, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            object[] values = new object[props.Count - excludedCount];
            foreach (T item in list)
            {
                excludedCount = 0;
                for (int i = 0; i < props.Count; i++)
                {
                    if (props[i].Category == "Exclude")
                    {
                        excludedCount++;
                        continue;
                    }
                    values[i - excludedCount] = props[i].GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static byte[] ImageToByteArray(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                using (var image = Image.FromFile(imagePath))
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        return stream.ToArray();
                    }
                }
            }
            return null;
        }
    }
}
