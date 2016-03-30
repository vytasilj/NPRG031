using System;

namespace Testing
{
    public class SimpleClass
    {
        private readonly string _id;
        private readonly string _password;


        public SimpleClass(string id, string password)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            _id = id;
            _password = password;
        }


        public string Id
        {
            get { return _id; }
        }

        public string Password
        {
            get { return _password; }
        }
    }
}