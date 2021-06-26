using GOLite.ViewModels;
using GOLite.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GOLite
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainView mainView = new MainView();
            MainViewModel mainViewModel = mainView.GetDataContext<MainViewModel>();
            Application.Run(mainView);
        }
    }
}
