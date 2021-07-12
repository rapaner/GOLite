using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using GOLite.Common;
using GOLite.Entities;
using GOLite.Entities.Messages;
using GOLite.Enums;
using GOLite.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GOLite.ViewModels
{
    /// <summary>
    /// ViewModel для просмотра теста
    /// </summary>
    public class TestEditViewModel : CommonViewModel
    {
        #region Свойства

        /// <summary>
        /// Модель
        /// </summary>
        public virtual TestModel Model { get; set; } = new TestModel();

        /// <summary>
        /// Шкалы
        /// </summary>
        public virtual ObservableCollection<Scale> Scales { get; set; } = new ObservableCollection<Scale>();

        /// <summary>
        /// Качества
        /// </summary>
        public virtual ObservableCollection<QualityGroup> QualityGroups { get; set; } = new ObservableCollection<QualityGroup>();

        /// <summary>
        /// Текущее качество теста
        /// </summary>
        public virtual TestQuality CurrentTestQuality { get; set; }

        /// <summary>
        /// По изменению текущего качества теста
        /// </summary>
        public void OnCurrentTestQualityChanged()
        {
            this.RaiseCanExecuteChanged(vm => vm.UpQuality());
            this.RaiseCanExecuteChanged(vm => vm.DownQuality());
            this.RaiseCanExecuteChanged(vm => vm.DeleteQuality());
        }

        /// <summary>
        /// Тестируемые
        /// </summary>
        public virtual ObservableCollection<TestUser> TestUsers { get; set; } = new ObservableCollection<TestUser>();

        /// <summary>
        /// Текущий участник теста
        /// </summary>
        public virtual TestUser CurrentTestUser { get; set; }

        /// <summary>
        /// По изменению текущего участника теста
        /// </summary>
        public void OnCurrentTestUserChanged()
        {
            this.RaiseCanExecuteChanged(vm => vm.UpUser());
            this.RaiseCanExecuteChanged(vm => vm.DownUser());
            this.RaiseCanExecuteChanged(vm => vm.DeleteUser());
        }

        /// <summary>
        /// Текущий пользователь с результатами
        /// </summary>
        public virtual UserWithTestResults CurrentUserWithResults { get; set; }

        /// <summary>
        /// Обновить тест
        /// </summary>
        public virtual bool RefreshTestToken { get; set; }

        /// <summary>
        /// Создать грид для результатов
        /// </summary>
        public virtual bool CreateGridControlForResults { get; set; }

        /// <summary>
        /// Строка с результатами
        /// </summary>
        public virtual string ResultsLine { get; set; }

        #endregion Свойства

        #region Методы

        /// <summary>
        /// Действия после загрузки данных для модели
        /// </summary>
        public void AfterLoad()
        {
            if (Model.Test.ScaleID == 0)
                Model.Test.ScaleID = Scales.FirstOrDefault()?.ScaleID ?? 0;
        }

        /// <summary>
        /// Получить тест
        /// </summary>
        public Task GetTest()
        {
            return GetTestAsync();
        }

        /// <summary>
        /// Получить тест
        /// </summary>
        private async Task GetTestAsync()
        {
            try
            {
                if (Model.Test.TestID == 0)
                    return;
                Model.Test = await WaitFormService.ShowAsync(DataSourceProvider.Instance.GetTestAsync(Model.Test.TestID));

                this.RaisePropertiesChanged();
                this.RaiseCanExecuteChanged(vm => vm.CreateFinalTestResults());
                this.RaiseCanExecuteChanged(vm => vm.DeleteTest());
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.GetExceptionMessage(), "Ошибка", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Сохранить тест
        /// </summary>
        public Task SaveTest(bool showMessage)
        {
            if (Model.Test.TestID == 0)
                return SaveNewTestAsync(showMessage);
            else
                return SaveCurrentTestAsync(showMessage);
        }

        /// <summary>
        /// Сохранить новый тест
        /// </summary>
        private async Task SaveNewTestAsync(bool showMessage)
        {
            if (!Model.IsValid)
            {
                MessageBoxService.ShowMessage(Model.GetErrorListInterpolation(), "", MessageButton.OK, MessageIcon.Warning);
                return;
            }
            try
            {
                int testID = await WaitFormService.ShowAsync(DataSourceProvider.Instance.SaveNewTestAsync(Model.Test));
                Model.Test.TestID = testID;
                Messenger.Default.Send(enMessage.RefreshTests, "TestsView");
                await WaitFormService.ShowAsync(GetTestAsync());
                RefreshTestToken = !RefreshTestToken;
                CreateGridControlForResults = !CreateGridControlForResults;
                if (showMessage)
                    MessageBoxService.ShowMessage("Тест сохранен!", "", MessageButton.OK, MessageIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.GetExceptionMessage(), "Ошибка", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Сохранить существующий тест
        /// </summary>
        private async Task SaveCurrentTestAsync(bool showMessage)
        {
            if (!Model.IsValid)
            {
                MessageBoxService.ShowMessage(Model.GetErrorListInterpolation(), "", MessageButton.OK, MessageIcon.Warning);
                return;
            }
            if ((Model.Test.IsQualityGroupChanged || Model.Test.TestUsers.FirstOrDefault(x => x.ForDelete || x.IsChangedForResultsDelete) != null)
                && Model.Test.UsersWithResults.SelectMany(x => x.TestResults).Any()
                && MessageBoxService.ShowMessage("Есть изменения в участниках и/или качествах для тестирования. Сохранение приведет к удалению результатов. Продолжить?", "", MessageButton.YesNoCancel, MessageIcon.Question) != MessageResult.Yes)
            {
                return;
            }
            try
            {
                await WaitFormService.ShowAsync(DataSourceProvider.Instance.SaveTestAsync(Model.Test));
                Messenger.Default.Send(enMessage.RefreshTests, "TestsView");
                await WaitFormService.ShowAsync(GetTestAsync());
                RefreshTestToken = !RefreshTestToken;
                CreateGridControlForResults = !CreateGridControlForResults;
                if (showMessage)
                    MessageBoxService.ShowMessage("Тест сохранен!", "", MessageButton.OK, MessageIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.GetExceptionMessage(), "Ошибка", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Создать список для сохранения результатов
        /// </summary>
        public void CreateTestResults()
        {
            if (Model.Test.IsChanged)
            {
                MessageBoxService.ShowMessage("Есть несохраненные изменения! Сохраните тест перед созданием результатов!");
                return;
            }

            if (Model.Test.UsersWithResults.SelectMany(x => x.TestResults).Any()
                    && MessageBoxService.ShowMessage("Удалить существующие результаты?", "", MessageButton.YesNoCancel, MessageIcon.Question) != MessageResult.Yes)
            {
                return;
            }

            Model.Test.UsersWithResults = new ObservableCollection<UserWithTestResults>(Model.Test.TestUsers.OrderBy(x => x.Sort).Select(x => new UserWithTestResults(x.TestUserID, x.UserName, x.Sort)
            {
                TestResults = new ObservableCollection<TestResult>(from tu in Model.Test.TestUsers
                                                                   from tq in Model.Test.TestQualities
                                                                   select new TestResult()
                                                                   {
                                                                       TestQualityID = tq.TestQualityID,
                                                                       UserID = tu.UserID
                                                                   })
            }));
            RefreshTestToken = !RefreshTestToken;
            CreateGridControlForResults = !CreateGridControlForResults;
            MessageBoxService.ShowMessage("Результаты созданы!", "", MessageButton.OK, MessageIcon.Information);
        }

        /// <summary>
        /// Показать документы для раздачи
        /// </summary>
        public Task ShowDocument()
        {
            return ShowDocumentAsync();
        }

        /// <summary>
        /// Показать документы для раздачи
        /// </summary>
        private async Task ShowDocumentAsync()
        {
            try
            {
                if (Model.Test.IsChanged)
                {
                    MessageBoxService.ShowMessage("Есть несохраненные изменения! Сохраните тест перед созданием результатов!");
                    return;
                }

                string fileName = null;
                SaveFileDialogService.DefaultFileName = $"{Model.Test.TestName} {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}.docx";
                SaveFileDialogService.Filter = "Word| *.docx";
                if (SaveFileDialogService.ShowDialog())
                {
                    fileName = SaveFileDialogService.GetFullFileName();
                }

                if (fileName == null)
                {
                    return;
                }
                await WaitFormService.ShowAsync(ReportCreator.Instance.CreateEmptyBlanksForResults(fileName, Model.Test, QualityGroups.FirstOrDefault(x => x.QualityGroupID == Model.Test.QualityGroupID).Qualities, Scales.FirstOrDefault(x => x.ScaleID == Model.Test.ScaleID)));
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                MessageBoxService.ShowMessage($"Произошла ошибка создания документов. {msg}", "Операция прервана", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Можно создать отчет итоговых результатов?
        /// </summary>
        public bool CanCreateFinalTestResults()
        {
            return Model.Test.UsersWithResults.Any()
                && Model.Test.UsersWithResults.SelectMany(x => x.TestResults).Any()
                && Model.Test.ScaleID != 0;
        }

        /// <summary>
        /// Создание отчета итоговых результатов
        /// </summary>
        public Task CreateFinalTestResults()
        {
            return CreateFinalTestResultsAsync();
        }

        /// <summary>
        /// Создание отчета итоговых результатов
        /// </summary>
        private async Task CreateFinalTestResultsAsync()
        {
            if (Model.Test.IsChanged)
            {
                MessageBoxService.ShowMessage("Есть несохраненные изменения! Сохраните тест перед формированием отчета!", "", MessageButton.OK, MessageIcon.Warning);
                return;
            }

            if (Model.Test.UsersWithResults.FirstOrDefault(x => x.TestResults.FirstOrDefault(y => y.ScaleScoreID == 0) != null) != null)
            {
                MessageBoxService.ShowMessage("Не для всех участников введены баллы!", "", MessageButton.OK, MessageIcon.Warning);
                return;
            }

            string fileName = null;
            SaveFileDialogService.DefaultFileName = $"{Model.Test.TestName} {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}.docx";
            SaveFileDialogService.Filter = "Word| *.docx";
            if (SaveFileDialogService.ShowDialog())
            {
                fileName = SaveFileDialogService.GetFullFileName();
            }

            if (fileName == null)
            {
                return;
            }
            await WaitFormService.ShowAsync(ReportCreator.Instance.CreateFinalTestResults(fileName, Model.Test, QualityGroups.FirstOrDefault(x => x.QualityGroupID == Model.Test.QualityGroupID).Qualities, Scales.FirstOrDefault(x => x.ScaleID == Model.Test.ScaleID)));
        }

        /// <summary>
        /// Можно удалить тест?
        /// </summary>
        public bool CanDeleteTest()
        {
            return Model.Test.TestID != 0;
        }

        /// <summary>
        /// Удалить тест
        /// </summary>
        public Task DeleteTest()
        {
            return DeleteTestAsync();
        }

        /// <summary>
        /// Удалить тест
        /// </summary>
        public async Task DeleteTestAsync()
        {
            if (MessageBoxService.ShowMessage("Удалить тест?", "", MessageButton.YesNoCancel, MessageIcon.Question) != MessageResult.Yes)
            {
                return;
            }

            try
            {
                await WaitFormService.ShowAsync("Пожалуйста, подождите", "Происходит удаление теста...", DataSourceProvider.Instance.DeleteTestAsync(Model.Test.TestID));
                Messenger.Default.Send(enMessage.RefreshTests, "TestsView");
                MessageBoxService.ShowMessage("Тест удален!", "", MessageButton.OK, MessageIcon.Information);
                CloseWindow(false);
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.GetExceptionMessage(), "Ошибка", MessageButton.OK, MessageIcon.Error);
            }
        }

        #region Управление участниками

        /// <summary>
        /// Добавить участника
        /// </summary>
        public void AddUser()
        {
            Model.Test.TestUsers.Add(new TestUser()
            {
                Sort = Model.Test.TestUsers.Count + 1
            });
        }

        /// <summary>
        /// Можно поднять пользователя?
        /// </summary>
        public bool CanUpUser() =>
            CurrentTestUser != null
            && CurrentTestUser.Sort > 1;

        /// <summary>
        /// Поднять пользователя
        /// </summary>
        public void UpUser()
        {
            Model.Test.TestUsers.FirstOrDefault(x => x.Sort == CurrentTestUser.Sort - 1).Sort++;
            CurrentTestUser.Sort--;
        }

        /// <summary>
        /// Можно опустить пользователя?
        /// </summary>
        public bool CanDownUser() =>
            CurrentTestUser != null
            && CurrentTestUser.Sort < Model.Test.TestUsers.Count;

        /// <summary>
        /// Опустить пользователя
        /// </summary>
        public void DownUser()
        {
            Model.Test.TestUsers.FirstOrDefault(x => x.Sort == CurrentTestUser.Sort + 1).Sort--;
            CurrentTestUser.Sort++;
        }

        /// <summary>
        /// Можно удалить пользователя
        /// </summary>
        public bool CanDeleteUser() =>
            CurrentTestUser != null;

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        public void DeleteUser()
        {
            CurrentTestUser.ForDelete = !CurrentTestUser.ForDelete;
        }

        #endregion Управление участниками

        #region Управление качествами

        /// <summary>
        /// Добавить качество
        /// </summary>
        public void AddQuality()
        {
            Model.Test.TestQualities.Add(new TestQuality()
            {
                Sort = Model.Test.TestQualities.Count + 1
            });
        }

        /// <summary>
        /// Можно поднять качество?
        /// </summary>
        public bool CanUpQuality() =>
            CurrentTestQuality != null
            && CurrentTestQuality.Sort > 1;

        /// <summary>
        /// Поднять качество
        /// </summary>
        public void UpQuality()
        {
            Model.Test.TestQualities.FirstOrDefault(x => x.Sort == CurrentTestQuality.Sort - 1).Sort++;
            CurrentTestQuality.Sort--;
        }

        /// <summary>
        /// Можно опустить качество?
        /// </summary>
        public bool CanDownQuality() =>
            CurrentTestQuality != null
            && CurrentTestQuality.Sort < Model.Test.TestQualities.Count - 1;

        /// <summary>
        /// Опустить качество
        /// </summary>
        public void DownQuality()
        {
            Model.Test.TestQualities.FirstOrDefault(x => x.Sort == CurrentTestQuality.Sort + 1).Sort--;
            CurrentTestQuality.Sort++;
        }

        /// <summary>
        /// Можно удалить качество
        /// </summary>
        public bool CanDeleteQuality() =>
            CurrentTestQuality != null;

        /// <summary>
        /// Удалить качество
        /// </summary>
        public void DeleteQuality()
        {
            CurrentTestQuality.ForDelete = !CurrentTestQuality.ForDelete;
        }

        #endregion Управление качествами

        /// <summary>
        /// Пачечная вставка результатов
        /// </summary>
        /// <param name="resultsLine">Строка результатов</param>
        public void BulkInsertResults()
        {
            GridResultsMessage message = new GridResultsMessage()
            {
                ResultsLine = ResultsLine
            };
            Messenger.Default.Send(message, "ResultsGrid");
            ResultsLine = null;
            //Thread.Sleep(1000);
            //CreateGridControlForResults = !CreateGridControlForResults;
        }

        /// <summary>
        /// Изменить текущего пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        public void ChangeCurrentUserWithResults(UserWithTestResults user)
        {
            CurrentUserWithResults = user;
            CreateGridControlForResults = !CreateGridControlForResults;
        }

        /// <summary>
        /// Изменить результат теста
        /// </summary>
        /// <param name="userIndex">Порядковый индекс пользователя</param>
        /// <param name="qualityIndex">Порядковый индекс качества</param>
        /// <param name="scaleScoreID">Код балла шкалы</param>
        public void ChangeTestResult(int userIndex, int qualityIndex, int scaleScoreID)
        {
            var user = Model.Test.UsersWithResults[userIndex].TestResults[qualityIndex].ScaleScoreID = scaleScoreID;
        }

        /// <summary>
        /// Изменить текущего участника
        /// </summary>
        /// <param name="testUser">Участник</param>
        public void ChangeCurrentTestUser(TestUser testUser)
        {
            CurrentTestUser = testUser;
        }

        /// <summary>
        /// Изменить текущее качество
        /// </summary>
        /// <param name="testQuality">Качество</param>
        public void ChangeCurrentTestQuality(TestQuality testQuality)
        {
            CurrentTestQuality = testQuality;
        }

        /// <summary>
        /// Закрыть окно
        /// </summary>
        public void CloseWindow(bool withQuestion)
        {
            if (withQuestion
                && Model.Test.IsChanged
                && MessageBoxService.ShowMessage("Есть несохраненные изменения. Закрыть окно?", "", MessageButton.YesNoCancel, MessageIcon.Question) != MessageResult.Yes)
                return;

            CloseTestEditView(Model.Test.TestID);
        }

        #endregion Методы
    }
}