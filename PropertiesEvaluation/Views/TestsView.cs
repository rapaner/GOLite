using DevExpress.Mvvm;
using DevExpress.XtraGrid.Views.Base;
using GOLite.Entities;
using GOLite.ViewModels;
using System;
using System.Drawing;

namespace GOLite.Views
{
    public partial class TestsView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public TestsView()
        {
            InitializeComponent();

            mvvmContext.ViewModelType = typeof(TestsViewModel);

            Load += (o, e) =>
            {
                if (!mvvmContext.IsDesignMode)
                {
                    InitializeEvents();
                    InitializeBindings();
                }
            };
        }

        public T GetDataContext<T>() => mvvmContext.GetViewModel<T>();

        private void InitializeBindings()
        {
            var fluentAPI = mvvmContext.OfType<TestsViewModel>();

            //  Привязка кнопок
            fluentAPI.BindCommand(bbiGetTests, vm => vm.GetTests(true));
            fluentAPI.BindCommand(bbiNewTest, vm => vm.ShowTestEditView(0), vm => 0);
            fluentAPI.BindCommand(bbiOpenTest, vm => vm.OpenTest());
            fluentAPI.BindCommand(bbiClose, vm => vm.CloseTestsView());

            //  Триггеры
            fluentAPI.WithCommand(vm => vm.GetTests(true))
                .After(() => gvTests.RefreshData());

            //  Изменения выбранных строк
            fluentAPI.EventToCommand<FocusedRowObjectChangedEventArgs>(gvTests, "FocusedRowObjectChanged", vm => vm.ChangeCurrentTest(null), args =>
            {
                if (args.Row is TestBase test)
                {
                    return test;
                }

                return null;
            });
            fluentAPI.EventToCommand<EventArgs>(gcTests, "DoubleClick", vm => vm.OpenTest());

            //  Привязка гридов к источнику данных
            fluentAPI.SetObjectDataSourceBinding(testsBindingSource, vm => vm.Tests);
        }

        private void InitializeEvents()
        {
            FormClosing += (o, e) =>
            {
                var vm = mvvmContext.GetViewModel<TestsViewModel>();
                Messenger.Default.Unregister(vm);
            };
        }
    }
}