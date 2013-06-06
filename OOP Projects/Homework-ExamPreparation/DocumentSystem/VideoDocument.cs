using System.Collections.Generic;

namespace DocumentSystem
{
    public class VideoDocument : MultimediaDocument
    {
        private ulong? frameRate;

        public ulong? FrameRate
        {
            get { return this.frameRate; }
            private set { this.frameRate = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "framerate")
            {
                this.frameRate = ulong.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("framerate", this.frameRate));
            base.SaveAllProperties(output);
        }
    }
}
