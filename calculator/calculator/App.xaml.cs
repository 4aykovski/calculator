using calculator.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() { }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = mainWindowViewModel
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
