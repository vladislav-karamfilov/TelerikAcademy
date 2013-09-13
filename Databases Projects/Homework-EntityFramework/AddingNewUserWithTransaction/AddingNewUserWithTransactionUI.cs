namespace AddingNewUserWithTransaction
{
    using System;
    using System.Linq;
    using System.Transactions;

    class AddingNewUserWithTransactionUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Creating a user and putting it into group 'Admin' with transaction***");
            Console.Write(decorationLine);

            string userName = "Pesho Goshov";
            string groupName = "Admins";

            if (AddUserToGroup(userName, groupName))
            {
                
                Console.WriteLine("User '{0}' added successfully to group '{1}'!", userName, groupName);
            }
            else
            {
                Console.WriteLine("User '{0}' is already in group '{1}'!", userName, groupName);
            }
        }

        static bool AddUserToGroup(string userName, string groupName)
        {
            using (UsersGroupsEntities context = new UsersGroupsEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    if (!context.Groups.Where(g => g.Name == groupName).Any())
                    {
                        context.Groups.Add(new Group() { Name = groupName });
                        context.SaveChanges();
                    }

                    Group groupToAddIn = context.Groups.Where(g => g.Name == groupName).First();
                    if (groupToAddIn.Users.Where(u => u.Name == userName).Any())
                    {
                        scope.Dispose();
                        return false;
                    }
                    else
                    {
                        User newUser = new User() { Name = userName };
                        groupToAddIn.Users.Add(newUser);
                        context.SaveChanges();
                        scope.Complete();
                        return true;
                    }
                }
            }
        }
    }
}
