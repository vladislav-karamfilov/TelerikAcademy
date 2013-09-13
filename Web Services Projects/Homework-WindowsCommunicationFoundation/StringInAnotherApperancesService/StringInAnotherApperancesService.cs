namespace StringInAnotherApperancesService
{
    using System;

    public class StringInAnotherApperancesService : IStringInAnotherApperancesService
    {
        public int GetStringAppearancesInAnotherString(string originString, string testString)
        {
            if (originString == null)
            {
                throw new ArgumentNullException("originString", "Origin string cannot be null!");
            }

            if (testString == null)
            {
                throw new ArgumentNullException("testString", "Test string cannot be null!");
            }
			
			originString = originString.ToLower();
			testString = testString.ToLower();
            int appearances = 0;
            int startIndex = originString.IndexOf(testString);
            while (startIndex != -1)
            {
                appearances++;
                startIndex = originString.IndexOf(testString, startIndex + testString.Length);
            }

            return appearances;
        }
    }
}
