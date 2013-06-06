using System.Collections.Generic;

namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocument
    {
        private ulong? rows;
        private ulong? cols;

        public ulong? Rows
        {
            get { return this.rows; }
            private set { this.rows = value; }
        }
        public ulong? Cols
        {
            get { return this.cols; }
            private set { this.cols = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.rows = ulong.Parse(value);
            }
            else if (key == "cols")
            {
                this.cols = ulong.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("rows", this.rows));
            output.Add(new KeyValuePair<string, object>("cols", this.cols));
            base.SaveAllProperties(output);
        }
    }
}
