using System;

namespace JustGsm.CommonPackage
{
    public class Display
    {
        #region Instance fields
        private double? sizeInInches;
        private int? numberOfColors;
        #endregion

        #region Constructors
        // Parameterless
        public Display()
            : this(null)
        {
        }
        // One parameter
        public Display(double? sizeInInches)
            : this(sizeInInches, null)
        {
        }
        // All information provided
        public Display(double? sizeInInches, int? numberOfColors)
        {
            this.SizeInInches = sizeInInches;
            this.NumberOfColors = numberOfColors;
        }
        #endregion

        #region Properties
        public double? SizeInInches
        {
            get { return this.sizeInInches; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The size of the display must be a positive number!");
                }
                this.sizeInInches = value;
            }
        }
        public int? NumberOfColors
        {
            get { return this.numberOfColors; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The number of colors of the display must be a positive number!");
                }
                this.numberOfColors = value;
            }
        }
        #endregion
    }
}
