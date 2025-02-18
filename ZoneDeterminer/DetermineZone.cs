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
            if (zoneDeterminerParameters.AverageAlarmRate < 1)
            {
                if (zoneDeterminerParameters.PercentageOutsideTarget <= 1)
                    return "Robust";
            }
            return "Stable";
        }
    }
}
