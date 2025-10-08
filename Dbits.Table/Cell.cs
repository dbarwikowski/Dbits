namespace Dbits.Table
{
    public class Cell
    {
        public string Value { get; set; }
        public int Width => Value?.Length ?? 0;
    }
}
