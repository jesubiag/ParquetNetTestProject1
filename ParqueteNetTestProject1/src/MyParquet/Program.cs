namespace ParqueteNetTestProject1.MyParquet
{
    public static class Program
    {
        public static void Main()
        {
            var parquetDotnetSerializer = new ParquetDotnetSerializer();
            parquetDotnetSerializer.Serialize();
        }
    }
}