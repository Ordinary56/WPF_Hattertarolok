using Balogh_Tamas_WPF_Hattertar.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Balogh_Tamas_WPF_Hattertar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() { }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();
        }
    }
}
