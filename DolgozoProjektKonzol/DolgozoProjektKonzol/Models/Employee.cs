using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProjektKonzol.Models
{
    public class Employee
    {
        private string _email;
        private int _salary;

        public Employee(string email, string name)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("A név és email nem lehet üres");
            }
            if (!email.Contains("@"))
            {
                throw new ArgumentException("Az email formátuma nem helyes");
            }
            Name = name;
            _email = email;
            _salary = 0;
        }

        public string Name { get; set; }
        public string Email { get => _email; set => value = _email; }
        public int Salary { get => _salary; set => value = _salary; }


        public void Pay(int payment)
        {
            if(payment <= 0)
            {
                throw new ArgumentException("A kifizetés nem lehet nulla vagy negatív");
            }
            _salary += payment;
        }

        public override string ToString()
        {
            return $"Név: {Name}, Email: {Email}, Fizetés: {Salary}";
        }
    }
}
