using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dbits.Table
{
    public static class CollectionExtensions
    {
        public static Table AsTable<T>(this IEnumerable<T> enumerable, Action<Table> options, params Expression<Func<T, object>>[] columns)
        {
            var table = new Table();
            options(table);

            table.Rows = new List<Row>();
            table.Columns = new List<Column>();
            foreach (var column in columns) table.Columns.Add(new Column());

            if (table.HasHeader)
            {
                var row = GetHeaderRow(columns);
                table.AddRow(row);
            }

            var propertySelectors = columns.Select(x => x.Compile()).ToArray();

            foreach (var dataSource in enumerable)
            {
                var row = GetDataRow(dataSource, propertySelectors); 
                table.AddRow(row);
            }

            return table;
        }

        private static Row GetDataRow<T>(T dataEntry, Func<T, object>[] columns)
        {
            var row = new Row();

            foreach (var column in columns)
            {
                var obj = column(dataEntry);
                var cell = new Cell
                {
                    Value = obj.ToString()
                };
                row.Add(cell);
            }

            return row;
        }

        private static Row GetHeaderRow<T>(Expression<Func<T, object>>[] columns)
        {
            var row = new Row();

            foreach (var column in columns)
            {
                row.Add(new Cell
                {
                    Value = GetMemberName(column)
                });
            }

            return row;
        }

        private static string GetMemberName<T>(this Expression<T> expression) => expression.Body switch
        {
            MemberExpression m => m.Member.Name,
            UnaryExpression u when u.Operand is MemberExpression m => m.Member.Name,
            _ => throw new NotImplementedException(expression.GetType().ToString())
        };
    }
}
