using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WizardWorld.Client.Models.Elixirs;

namespace WizardWorldDesktop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public List<Elixir> Elixirs { get; set; }
        public Repository Repository { get; set; }
        public MainWindow() {
            InitializeComponent();
            DataContext = this;
            Repository = new Repository();
            LoadData();
        }

        private async void LoadData() {
            Elixirs = await Repository.LoadElixirs();
            OnLoaded();
        }

        private void OnLoaded() {
            ElixirsListView.ItemsSource = Elixirs;
        }

    }
}