﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DolgozoProjektAsztal.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProjektAsztal.ViewModels
{
    public partial class MainViewModel: ObservableObject
    {
        private readonly ManyEmployeeRepo _manyEmployeeRepo;

        [ObservableProperty]
        private ControlPanelViewModel _controlPanelViewModel;

        [ObservableProperty]
        private DolgozoViewModel _dolgozoViewModel;

        [ObservableProperty]
        private object _currentViewModel;

        public MainViewModel()
        {
            _manyEmployeeRepo = new ManyEmployeeRepo();
            _controlPanelViewModel = new ControlPanelViewModel(_manyEmployeeRepo);
            _dolgozoViewModel = new DolgozoViewModel(_manyEmployeeRepo);

            _currentViewModel = _controlPanelViewModel;
        }

        [RelayCommand]
        public void ShowControlPanel()
        {
            ControlPanelViewModel.Update();
            CurrentViewModel = ControlPanelViewModel;
        }

        [RelayCommand]
        public void ShowDolgozoView()
        {
            DolgozoViewModel.Update();
            CurrentViewModel = DolgozoViewModel;
        }
    }
}
