using ZoneDeterminer;

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

   

  
}