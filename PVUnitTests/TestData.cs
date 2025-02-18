using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVUnitTests
{
    public static class TestData
    {
        public static IEnumerable<TestCaseData> TestCasesForDetermineZone()
        {
            yield return new TestCaseData(0.5, 0.5, "Robust");
            yield return new TestCaseData(0.5, 10, "Stable");
            yield return new TestCaseData(0.5, 30, "Reactive");
            yield return new TestCaseData(0.5, 60, "Overloaded");
            yield return new TestCaseData(5, 0.5, "Stable");
            yield return new TestCaseData(5, 10, "Reactive");
            yield return new TestCaseData(5, 30, "Overloaded");
            yield return new TestCaseData(15, 0.5, "Reactive");
            yield return new TestCaseData(15, 10, "Overloaded");
        }
        public static IEnumerable<TestCaseData> TestCasesForRangeValidation()
        {
            yield return new TestCaseData(51,0);
            yield return new TestCaseData(-0.1, 0);
            yield return new TestCaseData(0, 101);
            yield return new TestCaseData(0, -0.1);
        }
    }
}
