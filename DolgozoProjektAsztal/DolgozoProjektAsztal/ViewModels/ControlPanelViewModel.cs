using CommunityToolkit.Mvvm.ComponentModel;
using DolgozoProjektAsztal.Repos;
using DolgozoProjektKonzol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProjektAsztal.ViewModels
{
    public partial class ControlPanelViewModel: ObservableObject
    {
        private readonly ManyEmployeeRepo _manyEmployeeRepo;

        [ObservableProperty]
        private string _dolgozokSzama;

        [ObservableProperty]
        private string _fizetesnelkuliek;

        [ObservableProperty]
        private string _fizetestkapok;

        [ObservableProperty]
        private string _legtobbetkapo;

        [ObservableProperty]
        private string _legkevesebbetkapo;

        [ObservableProperty]
        private string _atlagkereset;

        [ObservableProperty]
        private Dictionary<string, int> _domainSzam;

        public ControlPanelViewModel(ManyEmployeeRepo repo)
        {
            _manyEmployeeRepo = repo;

            Update();
        }

        public void Update()
        {
            DolgozokSzama = "Dolgozók száma: " + _manyEmployeeRepo.GetNumberOfEmployees();
            Fizetesnelkuliek = "Fizetésnélküliek száma: " + _manyEmployeeRepo.EmployeesWithoutPayment();
            Fizetestkapok = "Fizetést kapók száma: " + _manyEmployeeRepo.EmployeesWithPayment();
            Legkevesebbetkapo = "Leg kevesebbet kapo neve: " +_manyEmployeeRepo.NameOfLowestPaid();
            Legtobbetkapo = "Leg tobbet kapo neve: " +_manyEmployeeRepo.NameOfHighestPaid();
            Atlagkereset = "Atlagkereset: " + _manyEmployeeRepo.AvgSalary();

        }
    }
}
