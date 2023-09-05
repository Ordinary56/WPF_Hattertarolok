using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Balogh_Tamas_WPF_Hattertar.Core;

#pragma warning disable

namespace Balogh_Tamas_WPF_Hattertar.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        //Fields
        string? _capacity ;
        double? _speed = 10;
        string? _capacityType = "GB";
        string? _speedType = "Gbps";
        string? _result;

        //Properties
 
        public ICommand ResultCommand { get; }
        public string Capacity
        {
            get => _capacity;
            set
            {
                _capacity = value;
                OnPropertyChanged(Capacity);
            }
        }

        public double? Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }

        public string CapacityType
        {
            get => _capacityType;
            set
            {
                _capacityType = value;
                OnPropertyChanged(CapacityType);
            }
        }

        public string SpeedType
        {
            get => _speedType;
            set
            {
                _speedType = value;
                OnPropertyChanged(SpeedType);
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }
        public MainViewModel()
        {
            ResultCommand = new RelayCommand(GetResult,CanExecute);
        }

        void GetResult(object? parameter)
        {
            string currCapacity = Capacity;
            double? currSpeed = Speed;
            if (!CapacityType.Equals("MB"))
            {
                if(CapacityType.Equals("GB"))
                {
                    currCapacity = $"{Convert.ToInt32(Capacity) * 1000}";

                }
                if(CapacityType.Equals("TB"))
                {
                    currCapacity = $"{Convert.ToInt32(Capacity) * Math.Pow(1000,2)}";
                }
            }
            if (!SpeedType.Equals("Mbps"))
            {
                if(SpeedType.Equals("Gbps"))
                {
                    currSpeed *= 1000;
                }
                if(SpeedType.Equals("Kbps"))
                {
                    currSpeed /= 1000;
                }
                if(SpeedType.Equals("mbps")) { currSpeed /= 8; }
                
            }
            double? Result_db = Convert.ToDouble(currCapacity) / currSpeed;
            Result = $"{Result_db:F3} sec(s), {Result_db/60:F1} minute(s)";
        }

        bool CanExecute(object? param)
        {
            return !string.IsNullOrEmpty(Capacity);
        }
    }
}
