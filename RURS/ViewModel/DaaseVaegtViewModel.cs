﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLibary.Models;
using RURS.Common;
using RURS.Handler;
using RURS.Model;
using WinRTXamlToolkit.Input;

namespace RURS.ViewModel
{
    class DaaseVaegtViewModel : VaegtKontrolViewModel
    {
        private double _selectedVaegt;
        private int _selectedNr;
        private int _selectedIndex;
        private VaegtKontrol _newSelectedVaegtKontrol;
        private Record _selectedRecord;
        private string _image;
        private double _minVaegt;
        private double _snit;
        private double _maxVaegt;

        public double SelectedVaegt
        {
            get { return _selectedVaegt;}
            set
            {
                _selectedVaegt = value;
                OnPropertyChanged();
            }
        }

        public int SelectedNr
        {
            get { return _selectedNr;}
            set
            {
                _selectedNr = value;
                OnPropertyChanged();
            }
        }

        public VaegtKontrol NewSelectedVaegtKontrol
        {
            get { return _newSelectedVaegtKontrol; }
            set
            {
                _newSelectedVaegtKontrol = value;
                OnPropertyChanged();
                Handler.GetDasser();
            }
        }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                OnPropertyChanged();
            }
        }

        public Record SelectedRecord
        {
            get { return _selectedRecord; }
            set
            {
                _selectedRecord = value;
                OnPropertyChanged();
            }
        }

        public string Image
        {
            get { return _image;}
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        public double MinVaegt
        {
            get { return _minVaegt;}
            set
            {
                _minVaegt = value;
                OnPropertyChanged();
            }
        }

        public double MaxVaegt
        {
            get { return _maxVaegt; }
            set
            {
                _maxVaegt = value;
                OnPropertyChanged();
            }
        }

        public double SnitVaegt
        {
            get { return _snit;}
            set
            {
                _snit = value;
                OnPropertyChanged();
            }
        }

        public DaaseVaegtHandler Handler { get; set; }
        public ObservableCollection<Record> Maximum { get; set; }
        public ObservableCollection<Record> Snit { get; set; }
        public ObservableCollection<Record> Minimum { get; set; }
        public ObservableCollection<Record> Expted { get; set; }
        public ObservableCollection<Record> Vaegts { get; set; }
        //public ObservableCollection<DaaseVaegt> DaaseVaegts { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand TjekCommand { get; set; }

        public DaaseVaegtViewModel()
        {
            Handler = new DaaseVaegtHandler(this);
            Handler.GetMaxAndMin();
            Expted = new ObservableCollection<Record>();
            Vaegts = new ObservableCollection<Record>();
            Handler.GetVægtKontrol();
            
            AddCommand = new RelayCommand(Handler.GetMax);
            TjekCommand = new RelayCommand(Handler.Tjek);

            Handler.GetDiagram();
        }

       
    }
}
