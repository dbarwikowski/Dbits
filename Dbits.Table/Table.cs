using System.Collections.Generic;

namespace Dbits.Table
{
    public class Table
    {
        public List<Column> Columns;
        public List<Row> Rows;
        public bool HasHeader { get; set; }
        public BorderStyle BorderStyle { get; set; }

        public void AddRow(Row row)
        {
            Rows.Add(row);
            
            for (var i = 0; i < row.Count; i++)
            {
                Columns[i].Add(row[i]);
            }
        }
    }
}
