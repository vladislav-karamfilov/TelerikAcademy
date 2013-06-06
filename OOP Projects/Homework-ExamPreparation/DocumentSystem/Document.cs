using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {
        private string name;
        private string content;

        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }

        public string Content
        {
            get { return this.content; }
            protected set { this.content = value; }
        }

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }
            else if (key == "content")
            {
                this.Content = value;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.name));
            output.Add(new KeyValuePair<string, object>("content", this.content));
        }

        public override string ToString()
        {
            List<KeyValuePair<string, object>> attributes = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(attributes);
            attributes.Sort((firstAttribute, secondAttribute) => firstAttribute.Key.CompareTo(secondAttribute.Key));

            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append('[');
            foreach (KeyValuePair<string, object> attribute in attributes)
            {
                var currentAttributeValue = attribute.Value;
                if (currentAttributeValue != null)
                {
                    result.Append(attribute.Key);
                    result.Append('=');
                    result.Append(currentAttributeValue);
                    result.Append(';');
                }
            }
            result.Length--;
            result.Append(']');

            return result.ToString();
        }
    }
}
