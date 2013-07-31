namespace Phonebook
{
    using System;
    using System.Text;

    public class PhonebookEntry
    {
        public PhonebookEntry(
            string firstName, 
            string middleName, 
            string lastName, 
            string nickname, 
            string town, 
            string phoneNumber)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Nickname = nickname;
            this.Town = town;
            this.PhoneNumber = phoneNumber;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Town { get; set; }

        public string PhoneNumber { get; set; }

        public static PhonebookEntry Parse(string entry)
        {
            string[] splitted = 
                entry.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            string[] names = 
                splitted[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int providedNames = names.Length;

            string firstName = names[0].Trim();
            
            string middleName = null;
            if (providedNames > 1)
            {
                middleName = names[1].Trim();
            }

            string lastName = null;
            if (providedNames > 2)
            {
                lastName = names[2].Trim();
            }

            string nickname = null;
            if (providedNames > 3)
            {
                nickname = names[3].Trim();
            }

            PhonebookEntry phonebookEntry =
                new PhonebookEntry(firstName, middleName, lastName, nickname, splitted[1].Trim(), splitted[2].Trim());
            return phonebookEntry;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("[First name: {0}; ", this.FirstName);

            if (this.MiddleName != null)
            {
                output.AppendFormat("Middle name: {0}; ", this.MiddleName);
            }

            if (this.LastName != null)
            {
                output.AppendFormat("Last name: {0}; ", this.LastName);
            }

            if (this.Nickname != null)
            {
                output.AppendFormat("Nickname: {0}; ", this.Nickname);
            }

            output.AppendFormat("Town: {0}; ", this.Town);

            output.AppendFormat("Phone number: {0}]", this.PhoneNumber);

            return output.ToString();
        }
    }
}
