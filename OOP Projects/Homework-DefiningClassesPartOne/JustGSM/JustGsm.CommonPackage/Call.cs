using System;
using System.Linq;

namespace JustGsm.CommonPackage
{
    public class Call
    {
        #region Instance fields
        private DateTime dateAndTime;
        private string phoneNumber;
        private int duration;
        #endregion

        #region Constructors
        public Call(DateTime dateAndTime, string phoneNumber, int duration)
        {
            this.DateAndTime = dateAndTime;
            this.PhoneNumber = phoneNumber;
            this.Duration = duration;
        }
        #endregion

        #region Properties
        public DateTime DateAndTime
        {
            get { return this.dateAndTime; }
            set { this.dateAndTime = value; }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set
            {
                if (value != null)
                {
                    foreach (char symbol in value)
                    {
                        if (!char.IsDigit(symbol) && symbol != ' ')
                        {
                            throw new ArgumentException("Invalid phone number!");
                        }
                    }
                }
                this.phoneNumber = value;
            }
        }
        public int Duration
        {
            get { return this.duration; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid call duration provided! Must be a postive number!");
                }
                this.duration = value;
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Format("Call made on: {0}\nTo phone number: {1}\nCall duration: {2}",
                this.DateAndTime, this.PhoneNumber, this.Duration);
        }
        #endregion
    }
}
