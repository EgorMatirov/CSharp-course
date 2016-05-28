using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Files
{
    public class CsvReader
    {
        private const char Separator = ',';
        private const string NullValue = "NA";
        private const char Quotes = '"';

        private static string DequoteString(string str)
        {
            if (str[0] == Quotes && str[str.Length - 1] == Quotes)
                return str.Substring(1, str.Length - 2);
            return str;
        }

        public static IEnumerable<string[]> ReadCsv1(string filename)
        {
            return File.ReadLines(filename)
                .Select(x => x
                    .Split(Separator)
                    .Select(s => s == NullValue ? null : DequoteString(s))
                    .ToArray());
        }

        public static IEnumerable<T> ReadCsv2<T>(string filename) where T : new()
        {
            var csvData = ReadCsv1(filename);

            using (var iter = csvData.GetEnumerator())
            {
                if (!iter.MoveNext()) yield break;

                var columnNames = iter.Current;

                var arg = Expression.Parameter(typeof (Dictionary<string, string>), "values");

                var bindings = typeof (T)
                    .GetProperties()
                    .Select(x => new
                    {
                        Attribute =
                            x.GetCustomAttributes(typeof (CsvColumnAttribute), false).FirstOrDefault() as
                                CsvColumnAttribute,
                        Info = x
                    })
                    .Where(x => x.Attribute != null)
                    .Select(
                        x =>
                        {
                            var name = x.Attribute.ColumnName;
                            var source = Expression.Property(arg, "Item", Expression.Constant(name));
                            var type = x.Info.PropertyType;
                            return GetMemberBinding(type, x.Info, source);
                        }
                    )
                    .ToList();

                var ctor = typeof (T).GetConstructor(new Type[0]);

                Debug.Assert(ctor != null, "ctor != null");

                var body = Expression.MemberInit(Expression.New(ctor), bindings);
                var lambda = Expression.Lambda<Func<Dictionary<string, string>, T>>(body, arg);
                var generator = lambda.Compile();

                while (iter.MoveNext())
                {
                    var values = iter.Current
                        .Select((v, i) => new {Pos = i, Value = v})
                        .ToDictionary(v => columnNames[v.Pos], v => v.Value);
                    yield return generator(values);
                }
            }
        }

        private static MemberBinding GetMemberBinding(Type type, MemberInfo member, Expression source)
        {
            if (type == typeof (string))
            {
                return Expression.Bind(member, source);
            }

            if (type == typeof (int) || type == typeof (double))
            {
                var parse = type.GetMethod("Parse", new[] {typeof (string)});
                var cast = Expression.Call(parse, source);
                return Expression.Bind(member, cast);
            }

            if (type == typeof (double?) || type == typeof (int?))
            {
                var parse = (type == typeof (double?) ? typeof (double) : typeof (int)).GetMethod("Parse",
                    new[] {typeof (string)});
                var cast = Expression.Convert(Expression.Call(parse, source), type);
                var nullConstant = Expression.Constant(null, typeof (object));
                var equality = Expression.Equal(source, nullConstant);
                var condition = Expression.Condition(equality, Expression.Default(type), cast);
                return Expression.Bind(member, condition);
            }
            return null;
        }

        public static IEnumerable<Dictionary<string, object>> ReadCsv3(string filename)
        {
            var csvData = ReadCsv1(filename);

            using (var iter = csvData.GetEnumerator())
            {
                if (!iter.MoveNext()) yield break;

                var columnNames = iter.Current;

                while (iter.MoveNext())
                {
                    yield return iter.Current
                        .Select((v, i) => new {Pos = i, Value = GuessType(v)})
                        .ToDictionary(v => columnNames[v.Pos], v => v.Value);
                }
            }
        }

        private static object GuessType(string value)
        {
            if (value == "NA")
                return null;
            int result;
            if (int.TryParse(value, out result))
                return result;
            double doubleResult;
            if (double.TryParse(value, out doubleResult))
                return doubleResult;
            return value;
        }

        public static IEnumerable<dynamic> ReadCsv4(string filename)
        {
            return ReadCsv3(filename).Select(x => new CsvRecord(x));
        }
    }
}