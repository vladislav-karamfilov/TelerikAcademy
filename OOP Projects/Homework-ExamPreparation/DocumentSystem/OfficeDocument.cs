using System.Collections.Generic;

namespace DocumentSystem
{
    public abstract class OfficeDocument : EncryptableDocument
    {
        private string version;

        public string Version
        {
            get { return this.version; }
            protected set { this.version = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "version")
            {
                this.version = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("version", this.version));
            base.SaveAllProperties(output);
        }
    }
}
