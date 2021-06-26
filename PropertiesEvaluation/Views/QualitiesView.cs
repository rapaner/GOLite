using DevExpress.XtraGrid.Views.Base;
using GOLite.Entities;
using GOLite.ViewModels;
using System.Drawing;

namespace GOLite.Views
{
    public partial class QualitiesView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public QualitiesView()
        {
            InitializeComponent();

            mvvmContext.ViewModelType = typeof(QualitiesViewModel);

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
            var fluentAPI = mvvmContext.OfType<QualitiesViewModel>();

            //  Привязка гридов к источнику данных
            fluentAPI.SetObjectDataSourceBinding(qualityGroupsBindingSource, vm => vm.Model.QualityGroups);
            fluentAPI.SetObjectDataSourceBinding(qualitiesBindingSource, vm => vm.CurrentQualityGroup.Qualities);

            //  Привязка кнопок
            fluentAPI.BindCommand(bbiSave, vm => vm.SaveQualityGroups());
            fluentAPI.BindCommand(bbiAddGroup, vm => vm.AddQualityGroup());
            fluentAPI.BindCommand(bbiDeleteGroup, vm => vm.DeleteQualityGroup());
            fluentAPI.BindCommand(bbiAddQuality, vm => vm.AddQuality());
            fluentAPI.BindCommand(bbiUpQuality, vm => vm.UpQuality());
            fluentAPI.BindCommand(bbiDownQuality, vm => vm.DownQuality());
            fluentAPI.BindCommand(bbiDeleteQuality, vm => vm.DeleteQuality());
            fluentAPI.BindCommand(bbiClose, vm => vm.CloseWindow());

            //  Триггеры
            fluentAPI.WithCommand(vm => vm.SaveQualityGroups())
                .Before(() =>
                {
                    gvQualityGroups.CloseEditor();
                    gvQualities.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.AddQualityGroup())
                .Before(() =>
                {
                    gvQualityGroups.CloseEditor();
                    gvQualities.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.DeleteQualityGroup())
                .Before(() =>
                {
                    gvQualityGroups.CloseEditor();
                    gvQualities.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.AddQuality())
                .Before(() =>
                {
                    gvQualityGroups.CloseEditor();
                    gvQualities.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.UpQuality())
                .Before(() =>
                {
                    gvQualityGroups.CloseEditor();
                    gvQualities.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.DownQuality())
                .Before(() =>
                {
                    gvQualityGroups.CloseEditor();
                    gvQualities.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.DeleteQuality())
                .Before(() =>
                {
                    gvQualityGroups.CloseEditor();
                    gvQualities.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.CloseWindow())
                .Before(() =>
                {
                    gvQualityGroups.CloseEditor();
                    gvQualities.CloseEditor();
                });

            fluentAPI.WithCommand(vm => vm.AddQualityGroup())
                .After(() =>
                {
                    gvQualityGroups.RefreshData();
                    gvQualityGroups.FocusedRowHandle = gvQualityGroups.RowCount - 1;
                });
            fluentAPI.WithCommand(vm => vm.DeleteQualityGroup())
                .After(() =>
                {
                    gvQualityGroups.RefreshData();
                });
            fluentAPI.WithCommand(vm => vm.AddQuality())
                .After(() =>
                {
                    gvQualities.RefreshData();
                    gvQualities.FocusedRowHandle = gvQualities.RowCount - 1;
                });
            fluentAPI.WithCommand(vm => vm.UpQuality())
                .After(() =>
                {
                    gvQualities.RefreshData();
                    gvQualities.FocusedRowHandle--;
                });
            fluentAPI.WithCommand(vm => vm.DownQuality())
                .After(() =>
                {
                    gvQualities.RefreshData();
                    gvQualities.FocusedRowHandle++;
                });
            fluentAPI.WithCommand(vm => vm.DeleteQuality())
                .After(() =>
                {
                    gvQualities.RefreshData();
                });
            fluentAPI.WithCommand(vm => vm.ChangeCurrentQualityGroup(vm.CurrentQualityGroup))
                .After(() =>
                {
                    gvQualities.RefreshData();
                });

            //  Триггер
            fluentAPI.SetTrigger(vm => vm.RefreshQualitiesTrigger, (x) =>
            {
                fluentAPI.SetObjectDataSourceBinding(qualityGroupsBindingSource, vm => vm.Model.QualityGroups);
                fluentAPI.SetObjectDataSourceBinding(qualitiesBindingSource, vm => vm.CurrentQualityGroup.Qualities);
            });

            //  Изменения выбранных строк
            fluentAPI.EventToCommand<FocusedRowObjectChangedEventArgs>(gvQualityGroups, "FocusedRowObjectChanged", vm => vm.ChangeCurrentQualityGroup(null), args =>
            {
                if (args.Row is QualityGroup qualityGroup)
                {
                    return qualityGroup;
                }

                return null;
            });
            fluentAPI.EventToCommand<FocusedRowObjectChangedEventArgs>(gvQualities, "FocusedRowObjectChanged", vm => vm.ChangeCurrentQuality(null), args =>
            {
                if (args.Row is Quality quality)
                {
                    return quality;
                }

                return null;
            });
        }

        private void InitializeEvents()
        {
            gvQualityGroups.RowStyle += (o, e) =>
            {
                if (e.RowHandle < 0)
                    return;
                if (gvQualityGroups.GetRow(e.RowHandle) is QualityGroup at && at.ForDelete)
                    e.Appearance.FontStyleDelta = FontStyle.Strikeout;
            };

            gvQualities.RowStyle += (o, e) =>
            {
                if (e.RowHandle < 0)
                    return;
                if (gvQualities.GetRow(e.RowHandle) is Quality at && at.ForDelete)
                    e.Appearance.FontStyleDelta = FontStyle.Strikeout;
            };

            gvQualities.CustomDrawCell += (o, e) =>
              {
                  if (e.Column == colNumeration)
                  {
                      e.DisplayText = $"{e.RowHandle + 1}";
                  }
              };
        }
    }
}