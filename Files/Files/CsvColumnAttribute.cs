using System;

namespace Files
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CsvColumnAttribute : Attribute
    {
        public CsvColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }

        public string ColumnName { get; private set; }
    }
}