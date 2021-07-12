using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using GOLite.Common;
using GOLite.Entities;
using GOLite.ViewModels;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GOLite.Views
{
    public partial class TestEditView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Свойства

        public T GetDataContext<T>() => mvvmContext.GetViewModel<T>();

        /// <summary>
        /// GridControl результатов
        /// </summary>
        protected GridControl TestResultsGridControl { get; set; }

        #endregion Свойства

        public TestEditView()
        {
            InitializeComponent();

            mvvmContext.ViewModelType = typeof(TestEditViewModel);

            Load += (o, e) =>
            {
                if (!mvvmContext.IsDesignMode)
                {
                    InitializeEvents();
                    InitializeBindings();
                }
            };
        }

        private void InitializeBindings()
        {
            var fluentAPI = mvvmContext.OfType<TestEditViewModel>();

            //  Привязка кнопок
            fluentAPI.BindCommand(bbiSave, vm => vm.SaveTest(true), vm => true);
            fluentAPI.BindCommand(bbiCreateTestResults, vm => vm.CreateTestResults());
            fluentAPI.BindCommand(bbiShowDocument, vm => vm.ShowDocument());
            fluentAPI.BindCommand(bbiCreateFinalTestResults, vm => vm.CreateFinalTestResults());
            fluentAPI.BindCommand(bbiDelete, vm => vm.DeleteTest());
            fluentAPI.BindCommand(bbiClose, vm => vm.CloseWindow(true), vm => true);
            fluentAPI.BindCommand(bbiAddUser, vm => vm.AddUser());
            fluentAPI.BindCommand(bbiUpUser, vm => vm.UpUser());
            fluentAPI.BindCommand(bbiDownUser, vm => vm.DownUser());
            fluentAPI.BindCommand(bbiDeleteUser, vm => vm.DeleteUser());
            fluentAPI.BindCommand(bbiAddQuality, vm => vm.AddQuality());
            fluentAPI.BindCommand(bbiUpQuality, vm => vm.UpQuality());
            fluentAPI.BindCommand(bbiDownQuality, vm => vm.DownQuality());
            fluentAPI.BindCommand(bbiDeleteQuality, vm => vm.DeleteQuality());
            fluentAPI.BindCommand(btnInsertResults, vm => vm.BulkInsertResults());

            //  Триггеры

            #region Триггеры до

            fluentAPI.WithCommand(vm => vm.SaveTest(true))
                .Before(() =>
                {
                    CloseGridViewEditors(Controls);
                    TestResultsGridControl?.MainView?.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.CreateTestResults())
                .Before(() =>
                {
                    CloseGridViewEditors(Controls);
                    TestResultsGridControl?.MainView?.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.CloseWindow(true))
                .Before(() =>
                {
                    CloseGridViewEditors(Controls);
                    TestResultsGridControl?.MainView?.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.AddUser())
                .Before(() =>
                {
                    gvTestUsers.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.UpUser())
                .Before(() =>
                {
                    gvTestUsers.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.DownUser())
                .Before(() =>
                {
                    gvTestUsers.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.DeleteUser())
                .Before(() =>
                {
                    gvTestUsers.CloseEditor();
                });

            #endregion Триггеры до

            #region Триггеры после

            fluentAPI.WithCommand(vm => vm.AddUser())
                .After(() =>
                {
                    gvTestUsers.RefreshData();
                    gvTestUsers.FocusedRowHandle = gvTestUsers.RowCount - 1;
                });
            fluentAPI.WithCommand(vm => vm.UpUser())
                .After(() =>
                {
                    gvTestUsers.RefreshData();
                });
            fluentAPI.WithCommand(vm => vm.DownUser())
                .After(() =>
                {
                    gvTestUsers.RefreshData();
                });
            fluentAPI.WithCommand(vm => vm.DeleteUser())
                .After(() =>
                {
                    gvTestUsers.RefreshData();
                });

            #endregion Триггеры после

            //  Триггер
            fluentAPI.SetTrigger(vm => vm.RefreshTestToken, (x) =>
            {
                fluentAPI.SetObjectDataSourceBinding(testBindingSource, vm => vm.Model.Test);
                gvTestUsers.RefreshData();
                gvUsersWithResults.RefreshData();
            });
            fluentAPI.SetTrigger(vm => vm.CreateGridControlForResults, (x) =>
              {
                  TestResultsGridControl = CreateResultsGridControl();
              });

            //  Изменения выбранных строк
            fluentAPI.EventToCommand<FocusedRowObjectChangedEventArgs>(gvTestUsers, "FocusedRowObjectChanged", vm => vm.ChangeCurrentTestUser(null), args =>
            {
                if (args.Row is TestUser obj)
                {
                    return obj;
                }

                return null;
            });
            fluentAPI.EventToCommand<FocusedRowObjectChangedEventArgs>(gvUsersWithResults, "FocusedRowObjectChanged", vm => vm.ChangeCurrentUserWithResults(null), args =>
            {
                if (args.Row is UserWithTestResults obj)
                {
                    return obj;
                }

                return null;
            });
            fluentAPI.EventToCommand<KeyEventArgs>(teResultsForInsert, "KeyDown", vm => vm.BulkInsertResults(), (e) => e.KeyCode == Keys.Enter);

            //  Привязка гридов к источнику данных
            fluentAPI.SetObjectDataSourceBinding(testBindingSource, vm => vm.Model.Test);
            fluentAPI.SetObjectDataSourceBinding(scalesBindingSource, vm => vm.Scales);
            fluentAPI.SetObjectDataSourceBinding(qualityGroupsBindingSource, vm => vm.QualityGroups);

            fluentAPI.SetBinding(teResultsForInsert, te => te.EditValue, vm => vm.ResultsLine);
        }

        private void InitializeEvents()
        {
            gvTestUsers.RowStyle += (o, e) =>
            {
                if (e.RowHandle < 0)
                    return;
                if (gvTestUsers.GetRow(e.RowHandle) is TestUser at && at.ForDelete)
                    e.Appearance.FontStyleDelta = FontStyle.Strikeout;
            };

            gvTestUsers.CustomDrawCell += (o, e) =>
            {
                if (e.Column == colNumeration)
                {
                    e.DisplayText = $"{e.RowHandle + 1}";
                }
            };
        }

        private GridControl CreateResultsGridControl()
        {
            var vm = GetDataContext<TestEditViewModel>();
            if (tlpResults.Controls.Count > 1)
            {
                var control = (GridControl)tlpResults.Controls[1];
                control.Dispose();
            }
            if (!vm.Model.Test.UsersWithResults.SelectMany(x => x.TestResults).Any())
                return null;
            var gc = GridControlCreator.Instance.CreateTestResultsGridControl(vm);
            if(gc != null)
            {
                tlpResults.Controls.Add(gc, 0, 1);
            }

            return gc;
        }

        /// <summary>
        /// Закрыть все редакторы
        /// </summary>
        /// <param name="controls">Список элементов</param>
        private void CloseGridViewEditors(Control.ControlCollection controls)
        {
            foreach (var control in controls)
            {
                if (control is GridControl)
                {
                    var gc = control as GridControl;
                    gc.MainView.CloseEditor();
                }
                else if (((Control)control).Controls.Count > 0)
                {
                    CloseGridViewEditors(((Control)control).Controls);
                }
            }
        }
    }
}