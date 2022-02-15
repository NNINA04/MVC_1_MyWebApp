namespace Models
{
    public class SQLVisitInfo : VisitInfo
    {
        private static int _id = 0;

        public SQLVisitInfo() => _id++;

        public int Id { get; private set; } = _id;
    }
}
