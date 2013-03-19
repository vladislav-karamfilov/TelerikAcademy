using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BitArray64
{
    public class BitArray64 : IEnumerable<int>
    {
        private const int BitsCount = 64;
        private ulong bitValues;

        public BitArray64(ulong bitValues)
        {
            this.bitValues = bitValues;
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > BitsCount - 1)
                {
                    throw new IndexOutOfRangeException("Invalid index! Must be in the range [1..63]!");
                }
                int bitValue = (int)((this.bitValues >> index) & 1);
                return bitValue;
            }
            set
            {
                if (index < 0 || index > BitsCount - 1)
                {
                    throw new IndexOutOfRangeException("Invalid index! Must be in the range [1..63]!");
                }
                if (value < 0 || value > 1)
	            {
                    throw new ArgumentOutOfRangeException("Invalid value! Must be 0 or 1!");
                }
                if (value == 0)
                {
                    bitValues &= ~(1UL << index);
                }
                else
                {
                    bitValues |= 1UL << index;
                }
            }
        }
        public override bool Equals(object other)
        {
            BitArray64 bitArray = other as BitArray64;
            if ((object)bitArray == null)
            {
                return false;
            }
            return this.bitValues == bitArray.bitValues;
        }
        public override int GetHashCode()
        {
            int prime = 17;
            int hash = 37;
            unchecked
            {
                hash = hash * prime + this.bitValues.GetHashCode();
            }
            return hash;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int index = 0; index < BitsCount; index++)
            {
                result.AppendLine(string.Format("{0} bit -> {1}", index, this[index])); 
            }
            return result.ToString();
        }
        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }
        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.Equals(first, second);
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int index = 0; index < BitsCount; index++)
            {
                yield return this[index];   
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
