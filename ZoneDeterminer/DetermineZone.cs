namespace ZoneDeterminer
{
    public class ZoneDeterminerParameters
    {
        public double AverageAlarmRate { get; set; }
        public double PercentageOutsideTarget { get; set; }

    }
    public class DetermineZone : IDetermineZone
    {
        public string Determine(ZoneDeterminerParameters zoneDeterminerParameters)
        {
            ValidateInput(zoneDeterminerParameters);

            if (zoneDeterminerParameters.AverageAlarmRate < 1)
            {
                if (zoneDeterminerParameters.PercentageOutsideTarget <= 1) return nameof(PerformancePoints.Robust);
                if (zoneDeterminerParameters.PercentageOutsideTarget <= 25) return nameof(PerformancePoints.Stable);
                if (zoneDeterminerParameters.PercentageOutsideTarget <= 50) return nameof(PerformancePoints.Reactive);
                return nameof(PerformancePoints.Overloaded);
                
            }
            else if (zoneDeterminerParameters.AverageAlarmRate < 10)
            {
                if (zoneDeterminerParameters.PercentageOutsideTarget <= 1) return nameof(PerformancePoints.Stable);
                if (zoneDeterminerParameters.PercentageOutsideTarget <= 25) return nameof(PerformancePoints.Reactive);
                return nameof(PerformancePoints.Overloaded);
            }
            else
            {
                if (zoneDeterminerParameters.PercentageOutsideTarget <= 1) return nameof(PerformancePoints.Reactive);
                return nameof(PerformancePoints.Overloaded);
            }
        }

        private void ValidateInput(ZoneDeterminerParameters zoneDeterminerParameters)
        {

            ArgumentNullException.ThrowIfNull(zoneDeterminerParameters, nameof(zoneDeterminerParameters));

            if (!zoneDeterminerParameters.AverageAlarmRate.IsInRange(0, 50))
            {
                throw new ArgumentOutOfRangeException(nameof(zoneDeterminerParameters.AverageAlarmRate));
            }
            if (!zoneDeterminerParameters.PercentageOutsideTarget.IsInRange(0, 100))
            {
                throw new ArgumentOutOfRangeException(nameof(zoneDeterminerParameters.AverageAlarmRate));
            }

        }
    }
    public static class InRangeExtension
    {
        public static bool IsInRange(this double value, double min, double max)
        {
            return value >= min && value <= max;
        }
    }
}
