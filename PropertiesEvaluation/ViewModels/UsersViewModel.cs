using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using GOLite.Common;
using GOLite.Entities;
using GOLite.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GOLite.ViewModels
{
    public class UsersViewModel : CommonViewModel
    {
        #region Свойства
        /// <summary>
        /// Модель с участниками
        /// </summary>
        public virtual UsersModel Model { get; set; } = new UsersModel();

        /// <summary>
        /// Текущий участник
        /// </summary>
        public virtual User CurrentUser { get; set; }

        public void OnCurrentUserChanged()
        {
            this.RaiseCanExecuteChanged(vm => vm.DeleteUser());
        }

        /// <summary>
        /// Обновить участников
        /// </summary>
        public virtual bool RefreshUsersTrigger { get; set; }
        #endregion

        #region Методы
        /// <summary>
        /// Получить список участников
        /// </summary>
        /// <param name="showMessage">Показать сообщение</param>
        public Task GetUsers(bool showMessage)
        {
            return GetUsersAsync(showMessage);
        }

        /// <summary>
        /// Получить список участников
        /// </summary>
        /// <param name="showMessage">Показать сообщение</param>
        private async Task GetUsersAsync(bool showMessage)
        {
            try
            {
                Model.Users = await WaitFormService.ShowAsync(DataSourceProvider.Instance.GetUsersAsync());
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.GetExceptionMessage(), "Ошибка", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Сохранить список участников
        /// </summary>
        public Task SaveUsers()
        {
            return SaveUsersAsync();
        }

        /// <summary>
        /// Сохранить список участников
        /// </summary>
        private async Task SaveUsersAsync()
        {
            try
            {
                if (!Model.IsValid)
                {
                    MessageBoxService.ShowMessage(Model.GetErrorListInterpolation(), "", MessageButton.OK, MessageIcon.Warning);
                    return;
                }
                if (MessageBoxService.ShowMessage("Сохранить изменения?", "", MessageButton.YesNoCancel, MessageIcon.Question) != MessageResult.Yes)
                    return;
                var changedUsers = new ObservableCollection<User>(Model.Users.Where(x => x.IsChanged || x.ForDelete));
                var result = await WaitFormService.ShowAsync(DataSourceProvider.Instance.SaveUsersAsync(changedUsers));
                if (result)
                {
                    Model.Users = await WaitFormService.ShowAsync(DataSourceProvider.Instance.GetUsersAsync());
                    RefreshUsersTrigger = !RefreshUsersTrigger;
                    MessageBoxService.ShowMessage("Список сохранен!", "", MessageButton.OK, MessageIcon.Information);
                }
                else
                {
                    MessageBoxService.ShowMessage("Список не сохранен!", "", MessageButton.OK, MessageIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.GetExceptionMessage(), "Ошибка", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Добавить участника
        /// </summary>
        public void AddUser()
        {
            User user = new User();

            Model.Users.Add(user);
        }

        /// <summary>
        /// Можно удалить участника?
        /// </summary>
        public bool CanDeleteUser()
        {
            return CurrentUser != null
                && !CurrentUser.HasTests;
        }

        /// <summary>
        /// Удалить участника
        /// </summary>
        public void DeleteUser()
        {
            CurrentUser.ForDelete = !CurrentUser.ForDelete;
        }

        /// <summary>
        /// Изменить текущего участника
        /// </summary>
        /// <param name="user">Участник</param>
        public void ChangeCurrentUser(User user)
        {
            CurrentUser = user;
        }
        #endregion
    }
}
