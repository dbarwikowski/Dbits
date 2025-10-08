using System.Collections.Generic;

namespace Dbits.Table
{
    public class Column : List<Cell>
    {
        public int Width { get; set; }

        public new void Add(Cell item)
        {
            base.Add(item);
            if(item.Width > Width)
                Width = item.Width;
        }
    }
}
