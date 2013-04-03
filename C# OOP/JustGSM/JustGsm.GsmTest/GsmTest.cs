using System;
using JustGsm.CommonPackage;

namespace JustGsm.GsmTest
{
    class GsmTest
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Entering and displaying the information about mobile phone devices***");
            Console.Write(decorationLine);

            Gsm[] mobilePhones;
            //#region User-defined input
            //Console.Write("Enter the number of mobile phone devices: ");
            //int numberOfMobilePhones = int.Parse(Console.ReadLine());
            //mobilePhones = new Gsm[numberOfMobilePhones];
            //for (int index = 0; index < numberOfMobilePhones; index++)
            //{
            //    Console.WriteLine("---Getting information about a mobile phone---");
            //    Console.Write("Enter model: ");
            //    string model = Console.ReadLine();
            //    Console.Write("Enter manufacturer: ");
            //    string manufacturer = Console.ReadLine();
            //    Console.Write("Enter price: ");
            //    double price = double.Parse(Console.ReadLine());
            //    Console.Write("Enter owner's first name: ");
            //    string ownerFirstName = Console.ReadLine();
            //    Console.Write("Enter owner's last name: ");
            //    string ownerLastName = Console.ReadLine();
            //    string owner = ownerFirstName + " " + ownerLastName;
            //    Console.WriteLine("---Getting information about the mobile phone's battery---");
            //    Console.Write("Enter model: ");
            //    string batteryModel = Console.ReadLine();
            //    Console.Write("Enter idle hours: ");
            //    double batteryIdleHours = double.Parse(Console.ReadLine());
            //    Console.Write("Enter talk hours: ");
            //    double battertTalkHours = double.Parse(Console.ReadLine());
            //    Console.Write("Enter battery type (LiIon/NiMH/NiCd/NiZn): ");
            //    BatteryType batteryType;
            //    switch (Console.ReadLine().ToLower())
            //    {
            //        case "liion":
            //        case "li-ion":
            //            batteryType = BatteryType.LiIon;
            //            break;
            //        case "nimh":
            //            batteryType = BatteryType.NiMH;
            //            break;
            //        case "nicd":
            //            batteryType = BatteryType.NiCd;
            //            break;
            //        case "nizn":
            //            batteryType = BatteryType.NiZn;
            //            break;
            //        default:
            //            batteryType = (BatteryType)int.MinValue;
            //            break;
            //    }
            //    Battery battery = new Battery(batteryModel, batteryIdleHours, battertTalkHours, batteryType);
            //    Console.WriteLine("---Getting information about the mobile phone's display---");
            //    Display display = new Display();
            //    Console.Write("Enter size in inches: ");
            //    display.SizeInInches = double.Parse(Console.ReadLine());
            //    Console.Write("Enter number of colors: ");
            //    display.NumberOfColors = int.Parse(Console.ReadLine());
            //    mobilePhones[index] = new Gsm(model, manufacturer, price, owner, battery, display);
            //    Console.WriteLine();
            //}
            //#endregion

            #region Hard-coded input
            mobilePhones = new Gsm[3];

            Gsm firstGsm = new Gsm();
            firstGsm.Model = "GS290";
            firstGsm.Manufacturer = "LG";
            firstGsm.Price = 189.29;
            firstGsm.Owner = "Pesho Peshov";
            firstGsm.Battery = new Battery("ABC321", 70, 6.5, BatteryType.LiIon);
            firstGsm.Display = new Display(2.2, 2000000);

            Battery secondPhoneBattery = new Battery();
            secondPhoneBattery.Model = "XY456";
            secondPhoneBattery.HoursIdle = 90;
            secondPhoneBattery.HoursTalk = 7;
            secondPhoneBattery.Type = BatteryType.LiIon;
            Display secondPhoneDisplay = new Display();
            secondPhoneDisplay.NumberOfColors = 2000000;
            secondPhoneDisplay.SizeInInches = 2.6;
            Gsm secondGsm = new Gsm("C-5", "Nokia", 199.99, "Gosho Goshov", secondPhoneBattery, secondPhoneDisplay);

            Gsm thirdGsm = new Gsm("One", "HTC");
            thirdGsm.Price = 700.99;
            thirdGsm.Owner = "Petko Petkov";
            thirdGsm.Battery = new Battery();
            thirdGsm.Battery.Model = "XYZ987";
            thirdGsm.Battery.HoursIdle = 70;
            thirdGsm.Battery.Type = BatteryType.NiMH;
            thirdGsm.Display = new Display(4.7, 16000000);

            mobilePhones[0] = firstGsm;
            mobilePhones[1] = secondGsm;
            mobilePhones[2] = thirdGsm;
            #endregion

            Console.WriteLine("---Displaying the information about all the mobile phones you've entered---");
            foreach (Gsm mobilePhone in mobilePhones)
            {
                Console.WriteLine(mobilePhone.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("---Now displaying the information about the iPhone4S---");
            Console.WriteLine(Gsm.IPhone4S.ToString());
        }
    }
}
