using System.Collections.Generic;

namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocument
    {
        private ulong? sampleRate;

        public ulong? SampleRate
        {
            get { return this.sampleRate; }
            private set { this.sampleRate = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate")
            {
                this.sampleRate = ulong.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("samplerate", this.sampleRate));
            base.SaveAllProperties(output);
        }
    }
}
