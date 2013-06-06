using System;
using System.Reflection;

namespace VersionAttribute
{
    [Version()]
    class VersionAttributeTest
    {
        [Version(1, 7)]
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Getting the versions of the current class and the methods in it***");
            Console.Write(decorationLine);

            Type classType = typeof(VersionAttributeTest);
            object[] classAttributes = classType.GetCustomAttributes(false);
            foreach (var classAttribute in classAttributes)
            {
                if (classAttribute is VersionAttribute)
                {
                    string version = ((VersionAttribute)classAttribute).Version;
                    Console.WriteLine("This class has version: " + version);
                }
            }

            MethodInfo[] methodTypes = classType.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            foreach (var methodType in methodTypes)
            {
                object[] methodAttributes = methodType.GetCustomAttributes(false);
                foreach (var methodAttribute in methodAttributes)
                {
                    if (methodAttribute is VersionAttribute)
                    {
                        Console.WriteLine("Method '{0}' has version: {1}", methodType.Name, ((VersionAttribute)methodAttribute).Version);
                    }                    
                }
            }
        }

        [Version(3, 9)]
        static bool ReturnTrue()
        {
            return true;
        }
    }
}
