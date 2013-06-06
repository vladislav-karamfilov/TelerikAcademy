using System;
using System.Threading;
using System.Globalization;
using JustGsm.CommonPackage;

namespace JustGsm.GsmCallHistoryTest
{
    class GsmCallHistoryTest
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Entering the call history for a mobile phone, modifying and displaying it***");
            Console.Write(decorationLine);

            //#region User-defined input
            //Console.WriteLine("---First enter information about the mobile phone---");
            //Console.Write("Enter model: ");
            //string model = Console.ReadLine();
            //Console.Write("Enter manufacturer: ");
            //string manufacturer = Console.ReadLine();
            //Console.Write("Enter price: ");
            //double price = double.Parse(Console.ReadLine());
            //Console.Write("Enter owner's first name: ");
            //string ownerFirstName = Console.ReadLine();
            //Console.Write("Enter owner's last name: ");
            //string ownerLastName = Console.ReadLine();
            //string owner = ownerFirstName + " " + ownerLastName;
            //Console.WriteLine("---Getting information about the mobile phone's battery---");
            //Console.Write("Enter model: ");
            //string batteryModel = Console.ReadLine();
            //Console.Write("Enter idle hours: ");
            //double batteryIdleHours = double.Parse(Console.ReadLine());
            //Console.Write("Enter talk hours: ");
            //double battertTalkHours = double.Parse(Console.ReadLine());
            //Console.Write("Enter battery type (LiIon/NiMH/NiCd/NiZn): ");
            //BatteryType batteryType;
            //switch (Console.ReadLine().ToLower())
            //{
            //    case "liion":
            //    case "li-ion":
            //        batteryType = BatteryType.LiIon;
            //        break;
            //    case "nimh":
            //        batteryType = BatteryType.NiMH;
            //        break;
            //    case "nicd":
            //        batteryType = BatteryType.NiCd;
            //        break;
            //    case "nizn":
            //        batteryType = BatteryType.NiZn;
            //        break;
            //    default:
            //        batteryType = (BatteryType)int.MinValue;
            //        break;
            //}
            //Battery battery = new Battery(batteryModel, batteryIdleHours, battertTalkHours, batteryType);
            //Console.WriteLine("---Getting information about the mobile phone's display---");
            //Display display = new Display();
            //Console.Write("Enter size in inches: ");
            //display.SizeInInches = double.Parse(Console.ReadLine());
            //Console.Write("Enter number of colors: ");
            //display.NumberOfColors = int.Parse(Console.ReadLine());
            //Gsm mobilePhone = new Gsm(model, manufacturer, price, owner, battery, display);

            //Console.WriteLine("---Now entering some calls in the history---");
            //Console.Write("Enter how many call you want to add: ");
            //int numberfOfCalls = int.Parse(Console.ReadLine());
            //for (int call = 0; call < numberfOfCalls; call++)
            //{
            //    Console.Write("Enter call date in format 'month/day/year': ");
            //    string callDate = Console.ReadLine();
            //    Console.Write("Enter call time in format 'HH:minutes:seconds': ");
            //    string callTime = Console.ReadLine();
            //    DateTime callDateAndTime = DateTime.ParseExact(callDate + " " + callTime, "M/d/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //    Console.Write("Enter the phone number the call is made to: ");
            //    string toPhoneNumber = Console.ReadLine();
            //    Console.Write("Enter the duration of the call in seconds: ");
            //    int durationInSeconds = int.Parse(Console.ReadLine());
            //    mobilePhone.AddToCallHistory(new Call(callDateAndTime, toPhoneNumber, durationInSeconds));
            //}
            //#endregion

            #region Hard-coded input
            Gsm mobilePhone = new Gsm();
            mobilePhone.Model = "GS290";
            mobilePhone.Manufacturer = "LG";
            mobilePhone.Price = 189.29;
            mobilePhone.Owner = "Pesho Peshov";
            mobilePhone.Battery = new Battery("ABC321", 70, 6.5, BatteryType.LiIon);
            mobilePhone.Display = new Display(2.2, 2000000);

            Call firstCall = new Call(new DateTime(2013, 2, 12, 22, 22, 22, DateTimeKind.Unspecified), "0888888888", 152);
            mobilePhone.AddToCallHistory(firstCall);
            Call secondCall = new Call(new DateTime(2013, 2, 22, 11, 11, 11, DateTimeKind.Unspecified), "08777777777", 151);
            mobilePhone.AddToCallHistory(secondCall);
            Call thirdCall = new Call(new DateTime(2013, 2, 5, 9, 9, 9, DateTimeKind.Unspecified), "0899999999", 152);
            mobilePhone.AddToCallHistory(thirdCall);
            #endregion
            Console.WriteLine("---Now displaying the information about the calls---");
            foreach (Call call in mobilePhone.CallHistory)
            {
                Console.WriteLine(call.ToString());
                Console.WriteLine();
            }

            Console.WriteLine("---Now displaying the total price of the calls---");
            Console.WriteLine("{0:F2}", mobilePhone.CalculateTotalPrice(0.37));
            Console.WriteLine();

            Call longestCall = mobilePhone.CallHistory[0];
            foreach (Call call in mobilePhone.CallHistory)
            {
                if (call.Duration > longestCall.Duration)
                {
                    longestCall = call;
                }
            }
            mobilePhone.DeleteFromCallHistory(longestCall);
            Console.WriteLine("---Now displaying the total price of the calls after removing \nthe longest call---");
            Console.WriteLine("{0:F2}", mobilePhone.CalculateTotalPrice(0.37));
            Console.WriteLine();

            mobilePhone.ClearCallHistory();
            Console.WriteLine("---Now displaying the call history after clearing it---");
            foreach (Call call in mobilePhone.CallHistory)
            {
                Console.WriteLine(call);
            }
        }
    }
}
