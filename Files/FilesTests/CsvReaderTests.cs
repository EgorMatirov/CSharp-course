using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Files;
using NUnit.Framework;

namespace FilesTests
{
    public class CsvReaderTests
    {
        private static string _filePath;

        public static string FilePath
        {
            get
            {
                if (_filePath != null) return _filePath;

                var assembly = Assembly.GetExecutingAssembly();
                var codebase = new Uri(assembly.CodeBase);
                var path = codebase.LocalPath;
                var dirName = new FileInfo(path).Directory?.FullName;
                _filePath = dirName + "/airquality.csv";

                return _filePath;
            }
        }

        [Test]
        public static void ReadCsv1ShouldWorkCorrectly()
        {
            var expected = new[] {"Sensor11", "7", null, "6.9", "74", "5", "11"};

            var actual = CsvReader.ReadCsv1(FilePath).Skip(11).First();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void ReadCsv2ShouldWorkCorrectly()
        {
            var expected = new AirQualityMesaure
            {
                Name = "Sensor11",
                Ozone = 7,
                Solar = null,
                Wind = 6.9,
                Temp = 74,
                Month = 5,
                Day = 11
            };

            var actual = CsvReader.ReadCsv2<AirQualityMesaure>(FilePath).Skip(10).First();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void ReadCsv3ShouldWorkCorrectly()
        {
            var expected = new Dictionary<string, object>
            {
                {"Name", "Sensor11"},
                {"Ozone", 7},
                {"Solar.R", null},
                {"Wind", 6.9},
                {"Temp", 74},
                {"Month", 5},
                {"Day", 11}
            };

            var actual = CsvReader.ReadCsv3(FilePath).Skip(10).First();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public static void ReadCsv4ShouldWorkCorrectly()
        {
            const int expected = 31;
            var actual = CsvReader.ReadCsv4(FilePath).Where(z => z.Ozone > 10).Select(z => z.Day).Max();

            Assert.AreEqual(expected, actual);
        }

        private class AirQualityMesaure : IEquatable<AirQualityMesaure>
        {
            [CsvColumn("Name")]
            public string Name { get; set; }

            [CsvColumn("Ozone")]
            public int? Ozone { get; set; }

            [CsvColumn("Solar.R")]
            public int? Solar { get; set; }

            [CsvColumn("Wind")]
            public double Wind { get; set; }

            [CsvColumn("Temp")]
            public int Temp { get; set; }

            [CsvColumn("Month")]
            public int Month { get; set; }

            [CsvColumn("Day")]
            public int Day { get; set; }

            public bool Equals(AirQualityMesaure other)
            {
                return Name == other.Name
                       && Ozone == other.Ozone
                       && Solar == other.Solar
                       && Math.Abs(Wind - other.Wind) < double.Epsilon
                       && Temp == other.Temp
                       && Month == other.Month
                       && Day == other.Day;
            }
        }
    }
}