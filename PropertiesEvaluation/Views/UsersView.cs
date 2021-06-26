using DevExpress.XtraGrid.Views.Base;
using GOLite.Entities;
using GOLite.ViewModels;
using System.Drawing;

namespace GOLite.Views
{
    public partial class UsersView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public UsersView()
        {
            InitializeComponent();

            mvvmContext.ViewModelType = typeof(UsersViewModel);

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
            var fluentAPI = mvvmContext.OfType<UsersViewModel>();

            //  Привязка гридов к источнику данных
            fluentAPI.SetObjectDataSourceBinding(usersBindingSource, vm => vm.Model.Users);

            //  Привязка кнопок
            fluentAPI.BindCommand(bbiSave, vm => vm.SaveUsers());
            fluentAPI.BindCommand(bbiAddUser, vm => vm.AddUser());
            fluentAPI.BindCommand(bbiDeleteUser, vm => vm.DeleteUser());
            fluentAPI.BindCommand(bbiClose, vm => vm.CloseUsersView());

            //  Триггеры
            fluentAPI.WithCommand(vm => vm.SaveUsers())
                .Before(() => gvUsers.CloseEditor());
            fluentAPI.WithCommand(vm => vm.AddUser())
                .Before(() => gvUsers.CloseEditor());
            fluentAPI.WithCommand(vm => vm.DeleteUser())
                .Before(() => gvUsers.CloseEditor());
            fluentAPI.WithCommand(vm => vm.CloseUsersView())
                .Before(() => gvUsers.CloseEditor());
            fluentAPI.WithCommand(vm => vm.SaveUsers())
                .After(() => gvUsers.RefreshData());
            fluentAPI.WithCommand(vm => vm.AddUser())
                .After(() =>
                {
                    gvUsers.RefreshData();
                    gvUsers.FocusedRowHandle = gvUsers.RowCount - 1;
                });
            fluentAPI.WithCommand(vm => vm.DeleteUser())
                .After(() => gvUsers.RefreshData());

            //  Триггер
            fluentAPI.SetTrigger(vm => vm.RefreshUsersTrigger, (x) =>
            {
                fluentAPI.SetObjectDataSourceBinding(usersBindingSource, vm => vm.Model.Users);
            });


            //  Изменения выбранных строк
            fluentAPI.EventToCommand<FocusedRowObjectChangedEventArgs>(gvUsers, "FocusedRowObjectChanged", vm => vm.ChangeCurrentUser(null), args =>
            {
                if (args.Row is User user)
                {
                    return user;
                }

                return null;
            });
        }

        private void InitializeEvents()
        {
            gvUsers.RowStyle += (o, e) =>
            {
                if (e.RowHandle < 0)
                    return;
                if (gvUsers.GetRow(e.RowHandle) is Quality at && at.ForDelete)
                    e.Appearance.FontStyleDelta = FontStyle.Strikeout;
            };
        }
    }
}