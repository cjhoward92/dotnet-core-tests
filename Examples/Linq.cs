using System;
using System.Linq;
using System.Collections.Generic;

namespace Examples
{
    public class TestData {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsTestable { get; set; }

        public override int GetHashCode() {
            const int factor = 103;
            int hash = 19;
            unchecked {
                hash = hash * factor ^ this.Id.GetHashCode();
                hash = hash * factor ^ (this.Name?.GetHashCode() ?? 0);
                hash = hash * factor ^ this.IsTestable.GetHashCode();
            }
            return hash;
        }

        public bool Equals(TestData data) {
            if (data == null) 
                return false;
            
            // I know this isn't always best practice, but for here it is.
            return this.GetHashCode() == data.GetHashCode();
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as TestData);
        }

        public static bool operator ==(TestData x, TestData y) {
            if (x is null && y is null)
                return true;
            else if (!(x is null))
                return x.Equals(y);
            else
                return y.Equals(x);
        }

        public static bool operator !=(TestData x, TestData y) {
            return !(x == y);
        }
    }

    public static class LinqTest
    {
        public static List<TestData> Filter(List<TestData> testDataList, Func<TestData, bool> filter)
            => testDataList?.Where(filter).ToList();

        public static IList<object> Transform(List<TestData> dataList) =>
            dataList?.Select((d) => new { FinalId = d.Id, NewName = new String(d.Name?.ToLower().Reverse().ToArray() ?? new char[0]) } as object)
            .ToList();
    }
}