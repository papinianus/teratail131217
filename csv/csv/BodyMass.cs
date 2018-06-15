using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csv
{
    public sealed class BodyMass
    {
        public BodyMass(string csvrow)
        {
            var splitttedrow = csvrow.Split(',').Select(x => x.Trim());
            ID = splitttedrow.First();
            Weights = splitttedrow.Skip(1).Select(x => double.Parse(x));
            Diffs = Weights.Zip(Weights.Skip(1), (first, second) => Math.Round(second - first, 1));
        }
        public string ID { get; private set; } = "0000";
        public IEnumerable<double> Weights { get; private set; } = new double[0];
        public IEnumerable<double> Diffs { get; private set; } = new double[0];

        public override string ToString() => $"{ID},{string.Join(",", Weights)},{string.Join(",", Diffs)}";
    }
}
