using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVPL
{
    class LoginValid
    {

        private static string _Username;
        private static string _Pass;

        public LoginValid(string un, string ps)
        {
            _Username = un;
            _Pass = ps;
        }

        public static User getUser(string username, string pass)
        {
            return LoginValid._getUser(username, pass);
        }
        private static User _getUser(string username, string pass)
        {
            DataClasses1DataContext dc1 = new DataClasses1DataContext();
            var queryResult = (from user in dc1.GetTable<User>()
                               where (user.Username == username) &&
                                   (user.Pass == pass)
                               select user).ToArray<User>();
            if (queryResult.Count<User>() > 0)
                return queryResult[0];
            else return null;
        }

        public bool ValidateUser(out User user)
        {
            User queryResult = LoginValid._getUser(_Username, _Pass);
            user = queryResult;
            if (queryResult == null)
            {
                return false;
            }
            return true;
        }






    }
}
