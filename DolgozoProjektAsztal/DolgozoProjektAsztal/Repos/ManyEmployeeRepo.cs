﻿using DolgozoProjektKonzol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProjektAsztal.Repos
{
    public class ManyEmployeeRepo
    {
        private readonly DolgozoContext2 _context = new DolgozoContext2();

        public List<Employee> GetAll()
        {
            return _context.Manyworkers.ToList();
        }

        public int GetNumberOfEmployees()
        {
            return _context.Manyworkers.Count();
        }

        public int EmployeesWithoutPayment()
        {
            return _context.Manyworkers.Where(w=>w.Salary == 0).Count();
        }

        public int EmployeesWithPayment()
        {
            return _context.Manyworkers.Where(w => w.Salary > 0).Count();
        }

        public double AvgSalary()
        {
            return _context.Manyworkers.Where(w=>w.Salary >0).Average(w=>w.Salary);
        }

        public string NameOfHighestPaid()
        {
            return _context.Manyworkers.OrderByDescending(w => w.Salary).FirstOrDefault()!.Name;
        }

        public string NameOfLowestPaid()
        {
            return _context.Manyworkers.OrderBy(w => w.Salary).FirstOrDefault()!.Name;
        }

        public Dictionary<string, int> GetCountByDomainName()
        {
            return _context.Manyworkers.AsEnumerable().GroupBy(w => w.Email.Split("@")[1].ToLower()).ToDictionary(g => g.Key,g=> g.Count());
        }

        public void PayEmployee(string email, int payment)
        {
            Employee employee = _context.Manyworkers.FirstOrDefault(w => w.Email == email);
            if (employee != null)   
            {
                employee.Pay(payment);
                _context.SaveChanges();
            }
        }

        public void RemoveEmployeeWithoutSalary(string email)
        {
            Employee employee = _context.Manyworkers.FirstOrDefault(e=>e.Email == email);
            if (employee != null && employee.Salary <=0)
            {
                _context.Remove(employee);
                _context.SaveChanges();
            }
        }

        public void AddEmployee(string email, string name)
        {
            Employee employee = _context.Manyworkers.FirstOrDefault(e => e.Email == email);
            if (employee == null)
            {
                Employee newEmployee = new Employee(email, name);
                _context.Manyworkers.Add(newEmployee);
                _context.SaveChanges();
            }
        }

        public List<Employee> SearchByName(string name)
        {
            return _context.Manyworkers.Where(w=>w.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Employee> SearchByDomain(string email)
        {
            string domain;
            if (email.Contains("@"))
            {
                domain = email.Split("@")[1];
            }
            else
            {
                domain =email;
            }
            return _context.Manyworkers.Where(w => w.Email.Contains(domain)).ToList();
        }

        public List<Employee> SearchBySalary(int min, int max)
        {
            return _context.Manyworkers.Where(w => w.Salary >= min && w.Salary<=max).ToList();
        }
    }
}
