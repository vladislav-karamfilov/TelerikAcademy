using System;

namespace VersionAttribute
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class VersionAttribute : System.Attribute
    {
        // Instance field
        private readonly string version;

        // Property
        public string Version
        {
            get
            {
                return this.version;
            }
        }

        // Constructors
        public VersionAttribute()
            : this(1, 0)
        {
        }
        public VersionAttribute(int major, int minor)
        {
            if (major < 0 || minor < 0)
            {
                throw new ArgumentOutOfRangeException("Must set a positive numbers for version major and version minor!");
            }
            this.version = major + "." + minor;
        }
    }
}
