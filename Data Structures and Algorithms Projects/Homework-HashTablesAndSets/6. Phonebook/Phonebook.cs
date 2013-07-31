namespace Phonebook
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class Phonebook
    {
        private const bool AllowDuplicates = true;

        private readonly MultiDictionary<string, PhonebookEntry> byFirstName;

        private readonly MultiDictionary<string, PhonebookEntry> byMiddleName;

        private readonly MultiDictionary<string, PhonebookEntry> byLastName;

        private readonly MultiDictionary<string, PhonebookEntry> byNickname;

        public Phonebook()
        {
            this.byFirstName = new MultiDictionary<string, PhonebookEntry>(AllowDuplicates);
            this.byMiddleName = new MultiDictionary<string, PhonebookEntry>(AllowDuplicates);
            this.byLastName = new MultiDictionary<string, PhonebookEntry>(AllowDuplicates);
            this.byNickname = new MultiDictionary<string, PhonebookEntry>(AllowDuplicates);
        }

        public void Add(PhonebookEntry newEntry)
        {
            this.byFirstName.Add(newEntry.FirstName, newEntry);

            if (newEntry.MiddleName != null)
            {
                this.byMiddleName.Add(newEntry.MiddleName, newEntry);
            }

            if (newEntry.LastName != null)
            {
                this.byLastName.Add(newEntry.LastName, newEntry);
            }

            if (newEntry.Nickname != null)
            {
                this.byNickname.Add(newEntry.Nickname, newEntry);
            }
        }

        public IEnumerable<PhonebookEntry> Find(string name)
        {
            HashSet<PhonebookEntry> matched = new HashSet<PhonebookEntry>();
            matched.UnionWith(this.byFirstName[name]);
            matched.UnionWith(this.byMiddleName[name]);
            matched.UnionWith(this.byLastName[name]);
            matched.UnionWith(this.byNickname[name]);
            return matched;
        }

        public IEnumerable<PhonebookEntry> Find(string name, string town)
        {
            HashSet<PhonebookEntry> matchedByName = new HashSet<PhonebookEntry>();
            matchedByName.UnionWith(this.byFirstName[name]);
            matchedByName.UnionWith(this.byMiddleName[name]);
            matchedByName.UnionWith(this.byLastName[name]);
            matchedByName.UnionWith(this.byNickname[name]);

            IEnumerable<PhonebookEntry> matchedByNameAndTown =
                matchedByName.Where(entry => entry.Town == town);
            return matchedByNameAndTown;
        }
    }
}
