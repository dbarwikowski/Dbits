namespace Dbits.Table.BorderStyles
{
    public interface IBorderStyle
    {
        internal string[] Top { get; }
        internal string[] Middle { get; }
        internal string[] Bottom { get; }
        internal string Horizontal { get; }
        internal string Vertical { get; }
    }
}
