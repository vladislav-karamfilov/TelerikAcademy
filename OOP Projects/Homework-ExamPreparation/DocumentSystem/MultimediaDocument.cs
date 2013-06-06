using System.Collections.Generic;

namespace DocumentSystem
{
    public abstract class MultimediaDocument : BinaryDocument
    {
        private ulong? length;

        public ulong? Length
        {
            get { return this.length; }
            protected set { this.length = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "length")
            {
                this.length = ulong.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("length", this.length));
            base.SaveAllProperties(output);
        }
    }
}
