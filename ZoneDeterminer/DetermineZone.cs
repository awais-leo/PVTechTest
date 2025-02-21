namespace ZoneDeterminer
{  
    public class DetermineZone : IDetermineZone
    {
        public string Determine(ZoneDeterminerParameters zoneDeterminerParameters)
        {
            ValidateInput(zoneDeterminerParameters);

            #region dead code need to remove
            //if (zoneDeterminerParameters.AverageAlarmRate < 1)
            //{
            //    if (zoneDeterminerParameters.PercentageOutsideTarget <= 1) return nameof(PerformancePoints.Robust);
            //    if (zoneDeterminerParameters.PercentageOutsideTarget <= 25) return nameof(PerformancePoints.Stable);
            //    if (zoneDeterminerParameters.PercentageOutsideTarget <= 50) return nameof(PerformancePoints.Reactive);
            //    return nameof(PerformancePoints.Overloaded);

            //}
            //else if (zoneDeterminerParameters.AverageAlarmRate < 10)
            //{
            //    if (zoneDeterminerParameters.PercentageOutsideTarget <= 1) return nameof(PerformancePoints.Stable);
            //    if (zoneDeterminerParameters.PercentageOutsideTarget <= 25) return nameof(PerformancePoints.Reactive);
            //    return nameof(PerformancePoints.Overloaded);
            //}
            //else
            //{
            //    if (zoneDeterminerParameters.PercentageOutsideTarget <= 1) return nameof(PerformancePoints.Reactive);
            //    return nameof(PerformancePoints.Overloaded);
            //}
            #endregion

            var rate = zoneDeterminerParameters.AverageAlarmRate;
            var percentage = zoneDeterminerParameters.PercentageOutsideTarget;

            if (rate < 1)
            {
                return percentage switch
                {
                    <= 1 => nameof(PerformancePoints.Robust),
                    <= 25 => nameof(PerformancePoints.Stable),
                    <= 50 => nameof(PerformancePoints.Reactive),
                    _ => nameof(PerformancePoints.Overloaded)
                };
            }

            if (rate < 10)
            {
                return percentage switch
                {
                    <= 1 => nameof(PerformancePoints.Stable),
                    <= 25 => nameof(PerformancePoints.Reactive),
                    _ => nameof(PerformancePoints.Overloaded)
                };
            }

            return percentage switch
            {
                <= 1 => nameof(PerformancePoints.Reactive),
                _ => nameof(PerformancePoints.Overloaded)
            };
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
                throw new ArgumentOutOfRangeException(nameof(zoneDeterminerParameters.PercentageOutsideTarget));
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
