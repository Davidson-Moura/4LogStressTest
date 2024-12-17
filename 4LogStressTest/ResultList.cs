namespace _4LogStressTest
{
    internal class ResultList<T> where T : class, new()
    {
        public List<T> List { get; set; }
    }
}
