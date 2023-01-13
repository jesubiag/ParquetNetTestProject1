using System.IO;
using System.Linq;
using Parquet;

namespace ParqueteNetTestProject1.MyParquet
{
    public class ParquetDotnetSerializer
    {
        public void Serialize()
        {
            Stream stream = File.OpenWrite($"{Config.DataBasePath}/test_3.parquet");
            
            var structures = Enumerable
                .Range(0, 1000)
                .Select(i => new SimpleStructure
                {
                    Id = i,
                    Name = $"row {i}",
                })
                .ToArray();
            
            ParquetConvert.SerializeAsync(structures, stream).Wait();
        }
    }

}