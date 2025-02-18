using ZoneDeterminer;

namespace PVUnitTests
{
    public class Tests
    {
        private DetermineZone determineZone;
        [SetUp]
        public void Setup()
        {
            determineZone = new DetermineZone();
        }

        [Test]
        public void WhenNullObjectPassed_ThenItReturnedArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => determineZone.Determine(null));
        }
        [Test]
        [TestCase(51, 0)]
        [TestCase(-0.1, 0)]
        [TestCase(0, 101)]
        [TestCase(0, -0.1)]
        public void WhenOutOfRangeParametersPasssed_ThenItReturnedArgumentOutOfRangeException(double averageAlarmrate,double percentageOutsideTarget)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => 
            determineZone.Determine(new ZoneDeterminerParameters() 
            {
                AverageAlarmRate = averageAlarmrate, PercentageOutsideTarget = percentageOutsideTarget
            }));
        }
        [Test]
        public void WhenZoneDeterminerParametersPassedWithValues_ThenCorrectResultreturned()
        {
            var zoneDeterminerParameters = new ZoneDeterminerParameters
            {
                AverageAlarmRate = 0.5,
                PercentageOutsideTarget = 1
            };
                        
            var result=determineZone.Determine(zoneDeterminerParameters);

            Assert.That(result, Is.EqualTo("Robust"));
            
        }
    }

   

  
}