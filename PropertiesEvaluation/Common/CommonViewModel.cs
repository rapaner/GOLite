using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using GOLite.Services;
using GOLite.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GOLite.Common
{
    public class CommonViewModel
    {
        #region Сервисы

        /// <summary>
        /// Сервис отображения окна загрузки/ожидания
        /// </summary>
        public IWaitFormService WaitFormService => this.GetService<IWaitFormService>();

        /// <summary>
        /// Сервис отображения окна сообщения
        /// </summary>
        public IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();

        /// <summary>
        /// Сервис отображения привязанных окон
        /// </summary>
        public IDocumentManagerService DocumentManagerService => this.GetService<IDocumentManagerService>();

        /// <summary>
        /// Сервис сохранения файлов
        /// </summary>
        public ISaveFileDialogService SaveFileDialogService => this.GetService<ISaveFileDialogService>();

        #endregion Сервисы

        #region Методы

        /// <summary>
        /// Создание базы данных
        /// </summary>
        public void CreateDataBase()
        {
            Task.Factory.StartNew(() => DataSourceProvider.Instance.CreateDataBase());
        }

        #endregion Методы

        #region Запуск модулей

        #region QualitiesView

        /// <summary>
        /// Открыть модуль просмотра качеств
        /// </summary>
        public Task ShowQualitiesView()
        {
            return ShowQualitiesViewAsync();
        }

        /// <summary>
        /// Открыть модуль просмотра качеств
        /// </summary>
        private async Task ShowQualitiesViewAsync()
        {
            try
            {
                var document = DocumentManagerService.Documents.FirstOrDefault(x => x.Id.ToString() == "QualitiesView");

                if (document != null)
                {
                    document.Show();
                }
                else
                {
                    var qualities = await WaitFormService.ShowAsync(DataSourceProvider.Instance.GetQualityGroupsAsync());
                    var viewModel = ViewModelSource.Create(() => new QualitiesViewModel());
                    viewModel.Model.QualityGroups = qualities;
                    document = DocumentManagerService.CreateDocument("QualitiesView", viewModel);
                    document.Title = "Качества";
                    document.Id = "QualitiesView";
                    document.Show();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                MessageBoxService.ShowMessage($"Произошла ошибка открытия качеств. {msg}", "Операция прервана", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Закрыть модуль просмотра качеств
        /// </summary>
        public void CloseQualitiesView()
        {
            var document = DocumentManagerService.Documents.FirstOrDefault(x => x.Id.ToString() == "QualitiesView");

            if (document != null)
            {
                document.Close();
            }
        }

        #endregion QualitiesView

        #region ScalesView

        /// <summary>
        /// Открыть модуль просмотра качеств
        /// </summary>
        public Task ShowScalesView()
        {
            return ShowScalesViewAsync();
        }

        /// <summary>
        /// Открыть модуль просмотра качеств
        /// </summary>
        private async Task ShowScalesViewAsync()
        {
            try
            {
                var document = DocumentManagerService.Documents.FirstOrDefault(x => x.Id.ToString() == "ScalesView");

                if (document != null)
                {
                    document.Show();
                }
                else
                {
                    var scales = await WaitFormService.ShowAsync(DataSourceProvider.Instance.GetScalesAsync());
                    var viewModel = ViewModelSource.Create(() => new ScalesViewModel());
                    viewModel.Model.Scales = scales;
                    document = DocumentManagerService.CreateDocument("ScalesView", viewModel);
                    document.Title = "Шкалы";
                    document.Id = "ScalesView";
                    document.Show();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                MessageBoxService.ShowMessage($"Произошла ошибка открытия шкал. {msg}", "Операция прервана", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Закрыть модуль просмотра качеств
        /// </summary>
        public void CloseScalesView()
        {
            var document = DocumentManagerService.Documents.FirstOrDefault(x => x.Id.ToString() == "ScalesView");

            if (document != null)
            {
                document.Close();
            }
        }

        #endregion ScalesView

        #region UsersView

        /// <summary>
        /// Открыть модуль просмотра участников
        /// </summary>
        public Task ShowUsersView()
        {
            return ShowUsersViewAsync();
        }

        /// <summary>
        /// Открыть модуль просмотра участников
        /// </summary>
        private async Task ShowUsersViewAsync()
        {
            try
            {
                var document = DocumentManagerService.Documents.FirstOrDefault(x => x.Id.ToString() == "UsersView");

                if (document != null)
                {
                    document.Show();
                }
                else
                {
                    var users = await WaitFormService.ShowAsync(DataSourceProvider.Instance.GetUsersAsync());
                    var viewModel = ViewModelSource.Create(() => new UsersViewModel());
                    viewModel.Model.Users = users;
                    document = DocumentManagerService.CreateDocument("UsersView", viewModel);
                    document.Title = "Участники";
                    document.Id = "UsersView";
                    document.Show();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                MessageBoxService.ShowMessage($"Произошла ошибка открытия участников. {msg}", "Операция прервана", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Закрыть модуль просмотра участников
        /// </summary>
        public void CloseUsersView()
        {
            var document = DocumentManagerService.Documents.FirstOrDefault(x => x.Id.ToString() == "UsersView");

            if (document != null)
            {
                document.Close();
            }
        }

        #endregion UsersView

        #region TestsView

        /// <summary>
        /// Открыть модуль списка тестов
        /// </summary>
        public Task ShowTestsView()
        {
            return ShowTestsViewAsync();
        }

        /// <summary>
        /// Открыть модуль списка тестов
        /// </summary>
        private async Task ShowTestsViewAsync()
        {
            try
            {
                var document = DocumentManagerService.Documents.FirstOrDefault(x => x.Id.ToString() == "TestsView");

                if (document != null)
                {
                    document.Show();
                }
                else
                {
                    var tests = await WaitFormService.ShowAsync(DataSourceProvider.Instance.GetTestsAsync());
                    var viewModel = ViewModelSource.Create(() => new TestsViewModel());
                    viewModel.Tests = tests;
                    document = DocumentManagerService.CreateDocument("TestsView", viewModel);
                    document.Title = "Список групп";
                    document.Id = "TestsView";
                    document.Show();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                MessageBoxService.ShowMessage($"Произошла ошибка открытия списка тестов. {msg}", "Операция прервана", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Закрыть модуль списка тестов
        /// </summary>
        public void CloseTestsView()
        {
            var document = DocumentManagerService.Documents.FirstOrDefault(x => x.Id.ToString() == "TestsView");

            if (document != null)
            {
                document.Close();
            }
        }

        #endregion TestsView

        #region TestEditView

        /// <summary>
        /// Открыть модуль просмотра теста
        /// </summary>
        public Task ShowTestEditView(int testID)
        {
            return ShowTestEditViewAsync(testID);
        }

        /// <summary>
        /// Открыть модуль просмотра теста
        /// </summary>
        private async Task ShowTestEditViewAsync(int testID)
        {
            try
            {
                var document = DocumentManagerService.Documents.FirstOrDefault(x => x.Id.ToString() == $"TestEditView{testID}");

                if (document != null)
                {
                    document.Show();
                }
                else
                {
                    var scalesTask = DataSourceProvider.Instance.GetScalesForChooseAsync();
                    var qualitiesTask = DataSourceProvider.Instance.GetQualityGroupsForChooseAsync();
                    var viewModel = ViewModelSource.Create(() => new TestEditViewModel());
                    if (testID == 0)
                    {
                        await WaitFormService.ShowAsync(scalesTask, qualitiesTask);
                        viewModel.QualityGroups = await qualitiesTask;
                        viewModel.Scales = await scalesTask;

                        document = DocumentManagerService.CreateDocument("TestEditView", viewModel);
                        document.Title = "Новый тест";
                        document.Id = $"TestEditView{testID}";
                        document.Show();
                    }
                    else
                    {
                        var testTask = DataSourceProvider.Instance.GetTestAsync(testID);
                        await WaitFormService.ShowAsync(scalesTask, qualitiesTask, testTask);
                        viewModel.QualityGroups = await qualitiesTask;
                        viewModel.Scales = await scalesTask;
                        viewModel.Model.Test = await testTask;

                        document = DocumentManagerService.CreateDocument("TestEditView", viewModel);
                        document.Title = $"{viewModel.Model.Test.TestName}, {viewModel.Model.Test.DateCreated.ToShortDateString()}";
                        document.Id = $"TestEditView{testID}";
                        document.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                MessageBoxService.ShowMessage($"Произошла ошибка открытия списка тестов. {msg}", "Операция прервана", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Закрыть модуль просмотра теста
        /// </summary>
        public void CloseTestEditView(int testID)
        {
            var document = DocumentManagerService.Documents.FirstOrDefault(x => x.Id.ToString() == $"TestEditView{testID}");

            if (document == null)
            {
                document = DocumentManagerService.Documents.FirstOrDefault(x => x.Id.ToString() == $"TestEditView0");
                if (document != null)
                    document.Close();
            }
            else
            {
                document.Close();
            }
        }

        #endregion TestEditView

        #endregion Запуск модулей
    }
}