using System.Collections.Generic;

namespace DocumentSystem
{
    public class PDFDocument : EncryptableDocument 
    {
        private ulong? pages;

        public ulong? Pages
        {
            get { return this.pages; }
            private set { this.pages = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "pages")
            {
                this.pages = ulong.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("pages", this.pages));
            base.SaveAllProperties(output);
        }
    }
}
