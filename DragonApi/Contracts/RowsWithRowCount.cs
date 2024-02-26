namespace Contracts
{
    public class RowsWithRowCount<T>
    {
        public int RowCount { get; set; }
        public IList<T> Items { get; set; }
    }
}
