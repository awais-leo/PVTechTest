using ZoneDeterminer;

namespace PVUnitTests
{
    public class Tests
    {
        private IDetermineZone determineZone;
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
        
        [Test,TestCaseSource(typeof(TestData),nameof(TestData.TestCasesForRangeValidation))]
        public void WhenOutOfRangeParametersPasssed_ThenItReturnedArgumentOutOfRangeException(double averageAlarmrate,double percentageOutsideTarget)
        {
            var zoneDeterminerParameters = new ZoneDeterminerParameters()
            {
                AverageAlarmRate = averageAlarmrate,
                PercentageOutsideTarget = percentageOutsideTarget
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => 
            determineZone.Determine(zoneDeterminerParameters));
        }

        [Test, TestCaseSource(typeof(TestData), nameof(TestData.TestCasesForDetermineZone))]
        public void WhenZoneDeterminerParametersPassedWithValues_ThenCorrectResultreturned(double averageAlarmRate, double percentageOutsideTarget, string expectedZone)
        {
            var zoneDeterminerParameters = new ZoneDeterminerParameters
            {
                AverageAlarmRate = averageAlarmRate,
                PercentageOutsideTarget = percentageOutsideTarget
            };
                        
            var result=determineZone.Determine(zoneDeterminerParameters);

            Assert.That(result, Is.EqualTo(expectedZone));
            
        }
    }

   

  
}