namespace Automatic_Sheet_BL
{
    public interface IListStringGenerator
    {
        string CreateString(List<string> strings);
        string CreateTable(List<string> row1, List<string> row2, List<string> row3);
    }
}