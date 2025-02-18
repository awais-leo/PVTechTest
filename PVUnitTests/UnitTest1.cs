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
                AverageAlarmRate = 1,
                PercentageOutsideTarget = 1
            };

            Assert.That(zoneDeterminerParameters.AverageAlarmRate,Is.EqualTo(1));
            Assert.That(zoneDeterminerParameters.AverageAlarmRate, Is.EqualTo(1));
        }
    }

    internal class ZoneDeterminerParameters
    {
        public int AverageAlarmRate { get; set; }
        public int PercentageOutsideTarget { get; set; }

    }
}