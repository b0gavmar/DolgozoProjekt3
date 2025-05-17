using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DolgozoProjektAsztal.Repos;
using DolgozoProjektKonzol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProjektAsztal.ViewModels
{
    public partial class DolgozoViewModel: ObservableObject
    {
        private readonly ManyEmployeeRepo _manyEmployeeRepo;

        public DolgozoViewModel(ManyEmployeeRepo repo)
        {
            _manyEmployeeRepo = repo;

            Update();
        }

        [ObservableProperty]
        private List<Employee> _dolgozok;

        [ObservableProperty]
        private int _payment;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private int _min;
        [ObservableProperty]
        private int _max;

        [RelayCommand]
        public void PayEmployee()
        {
            if(!string.IsNullOrEmpty(Email) && Payment > 0)
            {
                _manyEmployeeRepo.PayEmployee(Email,Payment);
                Update();
            }
        }

        [RelayCommand]
        public void RemoveIfNoPayment()
        {
            if (!string.IsNullOrEmpty(Email))
            {
                _manyEmployeeRepo.RemoveEmployeeWithoutSalary(Email);
                Update();
            }
        }

        [RelayCommand]
        public void SearchByName()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                 _manyEmployeeRepo.SearchByName(Name);
                Update();
            }
        }

        [RelayCommand]
        public void AddNew()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email))
            {
                _manyEmployeeRepo.AddEmployee(Email,Name);
                Update();
            }
        }

        [RelayCommand]
        public void SearchBySalary()
        {
            if (Min >0 && Max>0 && Max>Min)
            {
                _manyEmployeeRepo.SearchBySalary(Min,Max);
                Update();
            }
        }

        public void Update()
        {
            Dolgozok = _manyEmployeeRepo.GetAll();
        }
    }
}
