using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Parquet;
using ParqueteNetTestProject1.MyParquet;

namespace ParqueteNetTestProject1.tests.MyParquet.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void test_parquetnet_serialization_in_class()
        {
            var serializer = new ParquetDotnetSerializer();
            serializer.Serialize();
        }
        
        [Test]
        public async Task test_parquetnet_serialization()
        {
            Stream stream = File.OpenWrite($"{Config.DataBasePath}/test_1.parquet");
            
            var structures = Enumerable
                .Range(0, 1000)
                .Select(i => new SimpleStructure
                {
                    Id = i,
                    Name = $"row {i}",
                })
                .ToArray();
            
            await ParquetConvert.SerializeAsync(structures, stream);
        }

        // [Test]
        // public void test_choetl_write()
        // {
        //     var objs = new List<ExpandoObject>();
        //     dynamic o1 = new ExpandoObject();
        //     o1.Id = 1;
        //     o1.Name = "Pepe";
        //     dynamic o2 = new ExpandoObject();
        //     o2.Id = 2;
        //     o2.Name = "San";
        //     objs.Add(o1);
        //     objs.Add(o2);
        //
        //     using (var parser = new ChoParquetWriter($"{Config.DataBasePath}/data_2.parquet"))
        //     {
        //         parser.Write(objs);
        //     }
        // }

        // [Test]
        // public void test_choetl_poco_serialization()
        // {
        //     var objs = new List<Employee>();
        //     objs.Add(new Employee() { Id = 1, Name = "Tom" });
        //     objs.Add(new Employee() { Id = 2, Name = "Mark" });
        //
        //     using (var parser = new ChoParquetWriter<Employee>(FilePath(3)))
        //     {
        //         parser.Write(objs);
        //     }
        // }

        // [Test]
        // public void test_microsoft_ml_serialization()
        // {
        //     var columns = new Column[]
        //     {
        //         new Column<DateTime>("Timestamp"),
        //         new Column<int>("ObjectId"),
        //         new Column<float>("Value")
        //     };
        //
        //     using var stream = new FileStream("float_timeseries.parquet", FileMode.Create);
        //     using var writer = new ManagedOutputStream(stream);
        //     using var fileWriter = new ParquetFileWriter(writer, columns);
        // }
        
        private string FilePath(int fileNumber) => $"{Config.DataBasePath}/data_{fileNumber.ToString()}.parquet";
    }
    
}