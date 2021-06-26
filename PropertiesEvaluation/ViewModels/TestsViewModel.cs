using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using GOLite.Common;
using GOLite.Entities;
using GOLite.Enums;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace GOLite.ViewModels
{
    public class TestsViewModel : CommonViewModel
    {
        #region Конструкторы

        public TestsViewModel()
        {
            Messenger.Default.Register<enMessage>(this, "TestsView", x => ReceiveMessage(x));
        }

        /// <summary>
        /// Получение сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        private Task ReceiveMessage(enMessage message)
        {
            return ReceiveMessageAsync(message);
        }

        /// <summary>
        /// Получение сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        private async Task ReceiveMessageAsync(enMessage message)
        {
            switch (message)
            {
                case enMessage.RefreshTests:
                    await GetTestsAsync(false);
                    break;
            }
        }

        #endregion Конструкторы

        #region Свойства

        /// <summary>
        /// Тесты
        /// </summary>
        public virtual ObservableCollection<TestBase> Tests { get; set; }

        /// <summary>
        /// Текущий тест
        /// </summary>
        public virtual TestBase CurrentTest { get; set; }

        /// <summary>
        /// По изменению текущего теста
        /// </summary>
        public void OnCurrentTestChanged()
        {
            this.RaiseCanExecuteChanged(vm => vm.OpenTest());
        }

        #endregion Свойства

        #region Методы

        /// <summary>
        /// Получить список тестов
        /// </summary>
        /// <param name="showMessage">Показать сообщение</param>
        public Task GetTests(bool showMessage)
        {
            return GetTestsAsync(showMessage);
        }

        /// <summary>
        /// Получить список тестов
        /// </summary>
        /// <param name="showMessage">Показать сообщение</param>
        private async Task GetTestsAsync(bool showMessage)
        {
            try
            {
                Tests = await WaitFormService.ShowAsync(DataSourceProvider.Instance.GetTestsAsync());
                if (showMessage)
                    MessageBoxService.ShowMessage("Тесты загружены!", "", MessageButton.OK, MessageIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.GetExceptionMessage(), "Ошибка", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Можно открыть тест?
        /// </summary>
        public bool CanOpenTest()
        {
            return CurrentTest != null;
        }

        /// <summary>
        /// Открыть тест
        /// </summary>
        public void OpenTest()
        {
            ShowTestEditView(CurrentTest.TestID);
        }

        /// <summary>
        /// Изменить текущий тест
        /// </summary>
        /// <param name="test"></param>
        public void ChangeCurrentTest(TestBase test)
        {
            CurrentTest = test;
        }

        #endregion Методы
    }
}