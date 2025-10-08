using Dbits.Table.BorderStyles;
using System.Linq;
using System.Text;

namespace Dbits.Table
{
    public static class TableExtensions
    {
        public static string ToUnicodeTable(this Table table)
        {
            var style = GetBorderStyle(table.BorderStyle);

            var blank = "{0}{3}";
            for ( var i = 0; i < table.Columns.Count; i++)
            {
                if(i < table.Columns.Count - 1)
                    blank += $"{{{i+4},{table.Columns[i].Width}}}{{3}}{{1}}{{3}}";
                else
                    blank += $"{{{i+4},{table.Columns[i].Width}}}{{3}}";

            }
            blank += "{2}";

            var sb = new StringBuilder();
            string[] f = new string[] { style.Top[0], style.Top[1], style.Top[2], style.Horizontal, new string(style.Horizontal[0], 3), new string(style.Horizontal[0], 5) };
            sb.AppendLine(string.Format(blank, f));

            f[0] = style.Vertical;
            f[1] = style.Vertical;
            f[2] = style.Vertical;
            f[3] = " ";
            foreach (var row in table.Rows.Skip(1))
            {
                for ( var col = 0; col < table.Columns.Count; col++)
                {
                    f[col+4] = row[col].Value;
                }
                sb.AppendLine(string.Format(blank, f));
            }

            f[0] = style.Bottom[0];
            f[1] = style.Bottom[1];
            f[2] = style.Bottom[2];
            f[3] = style.Horizontal;
            f[4] = new string(style.Horizontal[0], 3);
            f[5] = new string(style.Horizontal[0], 5);
            sb.AppendLine(string.Format(blank, f));

            return sb.ToString();
        }

        public static IBorderStyle GetBorderStyle(BorderStyle style)
        {
            return style switch
            {
                BorderStyle.Single => new SingleBorderStyle(),
                _ => new SingleBorderStyle(),
            };
        }
    }
}
