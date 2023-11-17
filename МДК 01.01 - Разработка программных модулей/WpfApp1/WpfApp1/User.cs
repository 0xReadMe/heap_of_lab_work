using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class User
    {

        public int ID { get; set; }
        public string login, Email, Password;

        public string Login { 
            get { return login; }
            set { login = value; } 
        }
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

        public User() { }

        public User(string login,string Email,string Password) 
        {
            this.login = login;
            this.Email = Email;
            this.Password = Password;

        }

        //public override string ToString()
        //{
        //    return $"Пользователь: {Login}. Email: {email}";
        //}
    }
}
