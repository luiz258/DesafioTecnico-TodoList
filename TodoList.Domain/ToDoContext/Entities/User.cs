using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Domain.ToDoContext.Entities
{
    public class User: Entity
    {
        public User() { }

        public User(string userName, string password, string fullname)
        {
            UserName = userName;
            Password = EncriptaSenha(password);
            FullName = fullname;
        }

        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public IList<Todo> TodosLists { get; private set; }


        public string EncriptaSenha(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }

    }
}
