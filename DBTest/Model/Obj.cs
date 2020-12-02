using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBTest.Model
{
    public class Obj
    {
        public int Id { get; set; }
        public DateTime DateTimeIndex { get; set; }
        public DateTime DateTimeValue { get; set; }

        public DateTimeOffset DateTime2Index { get; set; }
        public DateTimeOffset DateTime2Value { get; set; }

        public int IntIndex { get; set; }
        public int IntValue { get; set; }
        public long LongIndex { get; set; }
        public long LongValue { get; set; }
        public float FloatIndex { get; set; }
        public float FloatValue { get; set; }

    }
}
