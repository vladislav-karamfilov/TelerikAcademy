using System;

namespace JustGsm.CommonPackage
{
    public class Battery
    {
        #region Instance fields
        private string model;
        private double? hoursIdle;
        private double? hoursTalk;
        private BatteryType type;
        #endregion

        #region Constructors
        // Parameterless
        public Battery()
            : this(null) 
        {
        }
        // One parameter
        public Battery(string model)
            : this(model, null)
        {
        }
        // Two parameters
        public Battery(string model, double? hoursIdle)
            : this(model, hoursIdle, null)
        {
        }
        // Three parameters
        public Battery(string model, double? hoursIdle, double? hoursTalk)
            : this(model, hoursIdle, hoursTalk, default(BatteryType))
        {
        }
        // All information provided
        public Battery(string model, double? hoursIdle, double? hoursTalk, BatteryType type)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
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
                    throw new ArgumentOutOfRangeException("Battery model cannot be empty!");
                }
                if (value != null && value.Length > 50)
                {
                    throw new ArgumentException("Battery model is too long! It should be maximum 50 letters!");
                }
                this.model = value;
            }
        }
        public double? HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Battery idle hours must be a positive number!");
                }
                this.hoursIdle = value;
            }
        }
        public double? HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Battery talk hours must be a positive number!");
                }
                this.hoursTalk = value;
            }
        }
        public BatteryType Type
        {
            get { return this.type; }
            set
            {
                if ((int)value < 0 || (int)value > 3)
                {
                    throw new ArgumentOutOfRangeException("Invalid battery type!");
                }
                this.type = value;
            }
        }
        #endregion
    }
}
