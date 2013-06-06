using System.Collections.Generic;

namespace DocumentSystem
{
    public class TextDocument : Document, IEditable
    {
        private string charset;

        public string Charset
        {
            get { return this.charset; }
            private set { this.charset = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "charset")
            {
                this.charset = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("charset", this.charset));
            base.SaveAllProperties(output);
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
