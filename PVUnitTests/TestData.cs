using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneDeterminer;

namespace PVUnitTests
{
    public static class TestData
    {
        public static IEnumerable<TestCaseData> TestCasesForDetermineZone()
        {
            yield return new TestCaseData(0.5, 0.5, nameof(PerformancePoints.Robust));
            yield return new TestCaseData(0.5, 10, nameof(PerformancePoints.Stable));
            yield return new TestCaseData(0.5, 30, nameof(PerformancePoints.Reactive));
            yield return new TestCaseData(0.5, 60, nameof(PerformancePoints.Overloaded));
            yield return new TestCaseData(5, 0.5, nameof(PerformancePoints.Stable));
            yield return new TestCaseData(5, 10, nameof(PerformancePoints.Reactive));
            yield return new TestCaseData(5, 30, nameof(PerformancePoints.Overloaded));
            yield return new TestCaseData(15, 0.5, nameof(PerformancePoints.Reactive));
            yield return new TestCaseData(15, 10, nameof(PerformancePoints.Overloaded));
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
