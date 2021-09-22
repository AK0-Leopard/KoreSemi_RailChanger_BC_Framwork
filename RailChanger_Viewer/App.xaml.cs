using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RailChanger_Viewer
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        public App() {
            InitializeComponent();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            new MainWindow();
        }
    }
}
