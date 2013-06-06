using System.Collections.Generic;

namespace DocumentSystem
{
    public abstract class BinaryDocument : Document
    {
        private ulong? size;

        public ulong? Size
        {
            get { return this.size; }
            protected set { this.size = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "size")
            {
                this.size = ulong.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("size", this.size));
            base.SaveAllProperties(output);
        }
    }
}
