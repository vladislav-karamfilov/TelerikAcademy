using System;
using System.Collections.Generic;

namespace JustGsm.CommonPackage
{
    public class Gsm
    {
        #region Instance fields
        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        private Battery battery;
        private Display display;
        #endregion
        
        #region Static field
        private static readonly Gsm iPhone4S;
        #endregion

        #region Constructors
        // Parameterless
        public Gsm()
            : this("[undefined]", "[undefined]") 
        {
        }
        // One parameter
        public Gsm(string model)
            : this(model, "[undefined]")
        {
        }
        // Two parameters
        public Gsm(string model, string manufacturer)
            : this(model, manufacturer, null)
        {
        }
        // Three parameters
        public Gsm(string model, string manufacturer, double? price)
            : this(model, manufacturer, price, null)
        {
        }
        // Four parameters
        public Gsm(string model, string manufacturer, double? price, string owner)
            : this(model, manufacturer, price, owner, new Battery())
        {
        }
        // Five parameters
        public Gsm(string model, string manufacturer, double? price, string owner, Battery battery)
            : this(model, manufacturer, price, owner, battery, new Display())
        {
        }
        // All information provided
        public Gsm(string model, string manufacturer, double? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }
        // Static constructor for setting the iPhone4S field
        static Gsm()
        {
            iPhone4S = new Gsm();
            iPhone4S.Model = "iPhone4S";
            iPhone4S.Manufacturer = "Apple";
            iPhone4S.Battery = new Battery("ABC123", 200, 14, BatteryType.LiIon);
            iPhone4S.Display = new Display(3.5, 16777216);
        }
        #endregion

        #region Properties
        public string Model
        {
            get { return this.model; }
            set 
            {
                if (value == "")
                {
                    throw new ArgumentOutOfRangeException("Mobile phone model cannot be empty!");
                }
                if (value != null && value.Length > 50)
                {
                    throw new ArgumentException("Mobile phone model too long! It should be maximum 50 letters!");
                }
                this.model = value; 
            }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set 
            {
                if (value == "")
                {
                    throw new ArgumentOutOfRangeException("Mobile phone manufacturer cannot be empty!");
                }
                if (value != null && value.Length > 50)
                {
                    throw new ArgumentException("Mobile phone manufacturer too long! It should be maximum 50 letters!");
                }
                this.manufacturer = value; 
            }
        }
        public double? Price
        {
            get { return this.price; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Mobile phone price cannot be a negative number!");
                }
                this.price = value; 
            }
        }
        public string Owner
        {
            get { return this.owner; }
            set 
            {
                if (value == null)
                {
                    this.owner = value;
                    return;
                }
                if (value == "")
                {
                    throw new ArgumentOutOfRangeException("Mobile phone owner cannot be empty!");
                }
                string[] names = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (names.Length < 2)
                {
                    throw new ArgumentException("Only one name provided! Two names must be provided for mobile phone owner!");
                }
                foreach (string name in names)
                {
                    if (name.Length < 2)
                    {
                        throw new ArgumentException("First and/or last name too short! They should be at least 2 letters!");
                    }
                    if (name.Length > 50)
                    {
                        throw new ArgumentException("First and/or last name too long! They should be maximum 50 letters!");
                    }
                    foreach (char symbol in name)
                    {
                        if (!char.IsLetter(symbol) && symbol != '-')
                        {
                            throw new ArgumentOutOfRangeException("Invalid name! Allowed symbols are only letters and hyphen!");
                        }
                    }
                }
                this.owner = value; 
            }
        }
        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }
        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }
        public static Gsm IPhone4S
        {
            get { return iPhone4S; }
        }
        public List<Call> CallHistory { get; private set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            string mainInformation = string.Format("Manufacturer: {0}\nModel: {1}\nPrice: {2}\nOwner: {3}\n",
                this.Manufacturer, this.Model, this.Price, this.Owner);
            string batteryInformation = string.Format("Battery model: {0}\nBattery idle hours: {1}\nBattery talk hours: {2}\nBattery type: {3}\n",
                this.Battery.Model, this.Battery.HoursIdle, this.Battery.HoursTalk, this.Battery.Type);
            string displayInformation = string.Format("Display size in inches: {0}\nDisplay number of colors: {1}",
                this.Display.SizeInInches, this.display.NumberOfColors);
            return mainInformation + batteryInformation + displayInformation;
        }
        public void AddToCallHistory(Call newCall)
        {
            if (CallHistory == null)
            {
                this.CallHistory = new List<Call>();
            }
            this.CallHistory.Add(newCall);
        }
        public bool DeleteFromCallHistory(Call call)
        {
            return this.CallHistory.Remove(call);
        }
        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }
        public double CalculateTotalPrice(double pricePerMinute)
        {
            double totalPrice = 0;
            foreach (Call call in this.CallHistory)
            {
                totalPrice += call.Duration * (pricePerMinute / 60);
            }
            return totalPrice;
        }
        #endregion
    }
}
