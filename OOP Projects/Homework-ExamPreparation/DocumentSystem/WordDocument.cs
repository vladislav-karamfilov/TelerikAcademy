using System.Collections.Generic;

namespace DocumentSystem
{
    public class WordDocument : OfficeDocument, IEditable
    {
        private ulong? chars;

        public ulong? Chars
        {
            get { return this.chars; }
            private set { this.chars = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "chars")
            {
                this.chars = ulong.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("chars", this.chars));
            base.SaveAllProperties(output);
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
