namespace PVUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenZoneDeterminerParametersPassedWithValues_ThenCorrectResultreturned()
        {
            var zoneDeterminerParameters = new ZoneDeterminerParameters
            {
                AverageAlarmRate = 0.5,
                PercentageOutsideTarget = 1
            };

            var determineZone = new DetermineZone();
            var result=determineZone.Determine(zoneDeterminerParameters);

            Assert.That(result, Is.EqualTo("Robust"));
            
        }
    }

    internal class ZoneDeterminerParameters
    {
        public double AverageAlarmRate { get; set; }
        public double PercentageOutsideTarget { get; set; }

    }

    internal class DetermineZone
    {
        public string Determine(ZoneDeterminerParameters zoneDeterminerParameters)
        {
            if (zoneDeterminerParameters.AverageAlarmRate <1)
            {
                if (zoneDeterminerParameters.PercentageOutsideTarget <= 1)
                    return "Robust";
            }
            return "Stable";
        }
    }
}