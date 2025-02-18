namespace ZoneDeterminer
{
    public class ZoneDeterminerParameters
    {
        public double AverageAlarmRate { get; set; }
        public double PercentageOutsideTarget { get; set; }

    }
    public class DetermineZone
    {
        public string Determine(ZoneDeterminerParameters zoneDeterminerParameters)
        {
            ValidateInput(zoneDeterminerParameters);

            if (zoneDeterminerParameters.AverageAlarmRate < 1)
            {
                if (zoneDeterminerParameters.PercentageOutsideTarget <= 1)
                    return "Robust";
            }
            return "Stable";
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
