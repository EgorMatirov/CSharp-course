using System.Collections.Generic;
using System.Dynamic;

namespace Files
{
    public class CsvRecord : DynamicObject
    {
        private readonly Dictionary<string, object> _rows;

        public CsvRecord(Dictionary<string, object> rows)
        {
            _rows = rows;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _rows.TryGetValue(binder.Name, out result);
        }
    }
}