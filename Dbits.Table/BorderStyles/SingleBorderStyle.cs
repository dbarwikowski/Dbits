namespace Dbits.Table.BorderStyles
{
    public class SingleBorderStyle : IBorderStyle
    {
        string[] IBorderStyle.Top => new string[] { "┌", "┬", "┐" };
        string[] IBorderStyle.Middle => new string[] { "├", "┼", "┤" };
        string[] IBorderStyle.Bottom => new string[] { "└", "┴", "┘" };
        string IBorderStyle.Horizontal => "─";
        string IBorderStyle.Vertical => "│";
    }
}
