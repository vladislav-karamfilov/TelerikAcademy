namespace HashTable.Common
{
    using System;
    using System.Text;

    public struct KeyValuePair<Tkey, TValue>
    {
        public KeyValuePair(Tkey key, TValue value) : this()
        {
            this.Key = key;
            this.Value = value;
        }

        public Tkey Key { get; private set; }

        public TValue Value { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append('[');
            if (this.Key != null)
            {
                output.Append(this.Key);
            }

            output.Append(" -> ");
            if (this.Value != null)
            {
                output.Append(this.Value);
            }

            output.Append(']');
            return output.ToString();
        }
    }
}
