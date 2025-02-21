// See https://aka.ms/new-console-template for more information

using ZoneDeterminer;

do
{
    Console.WriteLine("Please Enter Average Alarm Rate");
    double.TryParse(Console.ReadLine(), out double averageAlarmRate);
    Console.WriteLine("Please Enter Percentage Outside Target");
    double.TryParse(Console.ReadLine(), out double percentageOutsideTarget);

    var zoneDeterminerParameters = new ZoneDeterminerParameters
    {
        AverageAlarmRate = averageAlarmRate,
        PercentageOutsideTarget = percentageOutsideTarget
    };

   var determineZone = new DetermineZone();
   Console.WriteLine(determineZone.Determine(zoneDeterminerParameters));
   Console.WriteLine("Do you want to continue? (Y/N)");
   const string continueKey = "Y";
   if (Console.ReadLine()?.ToUpper() != continueKey)
   {
        break;
   }

}
while (true);