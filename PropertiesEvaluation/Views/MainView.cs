using DevExpress.Mvvm;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraBars;
using GOLite.Services;
using GOLite.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GOLite.Views
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Конструкторы
        public MainView()
        {
            InitializeComponent();

            mvvmContext.ViewModelType = typeof(MainViewModel);

            Load += (o, e) =>
            {
                if (!mvvmContext.IsDesignMode)
                {
                    InitializeBindings();
                    InitializeEvents();
                }
            };
        }
        #endregion

        #region Свойства
        public T GetDataContext<T>() => mvvmContext.GetViewModel<T>();
        #endregion

        #region Методы
        /// <summary>
        /// Настройка привязок
        /// </summary>
        private void InitializeBindings()
        {
            var fluentAPI = mvvmContext.OfType<MainViewModel>();

            //  Регистрация глобальных сервисов
            mvvmContext.RegisterDefaultService(WaitFormService.Create(this));
            mvvmContext.RegisterDefaultService(DocumentManagerService.Create(tabbedView1));
            mvvmContext.RegisterDefaultService(SaveFileDialogService.Create());

            //  Регистрация локальных сервисов

            //  Кнопки
            fluentAPI.BindCommand(bbiTests, vm => vm.ShowTestsView());
            fluentAPI.BindCommand(bbiQualities, vm => vm.ShowQualitiesView());
            fluentAPI.BindCommand(bbiScales, vm => vm.ShowScalesView());
            fluentAPI.BindCommand(bbiUsers, vm => vm.ShowUsersView());

            //  Триггеры

        }

        /// <summary>
        /// Инициализация событий
        /// </summary>
        private void InitializeEvents()
        {
            //  Соединение меню
            ribbon.Merge += (o, e) =>
            {
                if (ribbon.MergedCategories.Count > 0 && ribbon.MergedCategories[0].Pages.Count > 0)
                    ribbon.SelectedPage = ribbon?.MergedCategories?[0]?.Pages?[0] ?? ribbon.SelectedPage;
            };

            FormClosing += (o, e) =>
              {
                  var vm = GetDataContext<MainViewModel>();
                  if (vm.MessageBoxService.ShowMessage("Закрыть программу?", "Завершение работы", MessageButton.YesNoCancel, MessageIcon.Question) != MessageResult.Yes)
                  {
                      e.Cancel = true;
                  }
              };
        }
        #endregion
    }
}