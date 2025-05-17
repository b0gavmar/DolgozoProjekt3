using DolgozoProjektKonzol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProjektKonzol.Repos
{
    public class EmployeeRepo
    {
        private readonly DolgozoContext _context = new DolgozoContext();

        public int GetNumberOfEmployees()
        {
            return _context.Workers.Count();
        }

        public int EmployeesWithoutPayment()
        {
            return _context.Workers.Where(w=>w.Salary == 0).Count();
        }

        public double AvgSalary()
        {
            return _context.Workers.Where(w=>w.Salary >0).Average(w=>w.Salary);
        }

        public string NameOfHighestPaid()
        {
            return _context.Workers.OrderByDescending(w => w.Salary).FirstOrDefault()!.Name;
        }

        public string NameOfLowestPaid()
        {
            return _context.Workers.OrderBy(w => w.Salary).FirstOrDefault()!.Name;
        }

        public Dictionary<string, int> GetCountByDomainName()
        {
            return _context.Workers.AsEnumerable().GroupBy(w => w.Email.Split("@")[1].ToLower()).ToDictionary(g => g.Key,g=> g.Count());
        }

        public void PayEmployee(string email, int payment)
        {
            Employee employee = _context.Workers.FirstOrDefault(w => w.Email == email);
            if (employee != null)   
            {
                employee.Pay(payment);
                _context.SaveChanges();
            }
        }

        public void RemoveEmployeeWithoutSalary(string email)
        {
            Employee employee = _context.Workers.FirstOrDefault(e=>e.Email == email);
            if (employee != null && employee.Salary <=0)
            {
                _context.Remove(employee);
                _context.SaveChanges();
            }
        }

        public void AddEmployee(string email, string name)
        {
            Employee employee = _context.Workers.FirstOrDefault(e => e.Email == email);
            if (employee == null)
            {
                Employee newEmployee = new Employee(email, name);
                _context.Workers.Add(newEmployee);
                _context.SaveChanges();
            }
        }

        public List<Employee> SearchByName(string name)
        {
            return _context.Workers.Where(w=>w.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Employee> SearchByDomain(string email)
        {
            return _context.Workers.Where(w => w.Email.Contains(email) || w.Email.Contains("@"+email)).ToList();
        }

        public List<Employee> SearchBySalary(int min, int max)
        {
            return _context.Workers.Where(w => w.Salary >= min && w.Salary<=max).ToList();
        }
    }
}
