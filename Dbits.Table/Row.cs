using System.Collections.Generic;

namespace Dbits.Table
{
    public class Row : List<Cell>
    {
        public int Width { get; set; }

        public new void Add(Cell item)
        {
            base.Add(item);
            Width += item.Width;
        }
    }
}
