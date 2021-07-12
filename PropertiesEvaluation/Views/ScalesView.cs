using DevExpress.XtraGrid.Views.Base;
using GOLite.Entities;
using GOLite.ViewModels;
using System.Drawing;

namespace GOLite.Views
{
    public partial class ScalesView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ScalesView()
        {
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            InitializeComponent();

            mvvmContext.ViewModelType = typeof(ScalesViewModel);

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
            var fluentAPI = mvvmContext.OfType<ScalesViewModel>();

            //  Привязка гридов к источнику данных
            fluentAPI.SetObjectDataSourceBinding(scalesBindingSource, vm => vm.Model.Scales);
            fluentAPI.SetObjectDataSourceBinding(scoresBindingSource, vm => vm.CurrentScale.Scores);

            //  Привязка кнопок
            fluentAPI.BindCommand(bbiSave, vm => vm.SaveScales());
            fluentAPI.BindCommand(bbiAddScale, vm => vm.AddScale());
            fluentAPI.BindCommand(bbiDeleteScale, vm => vm.DeleteScale());
            fluentAPI.BindCommand(bbiAddScore, vm => vm.AddScore());
            fluentAPI.BindCommand(bbiUpScore, vm => vm.UpScore());
            fluentAPI.BindCommand(bbiDownScore, vm => vm.DownScore());
            fluentAPI.BindCommand(bbiDeleteScore, vm => vm.DeleteScore());
            fluentAPI.BindCommand(bbiClose, vm => vm.CloseWindow());

            //  Триггеры
            fluentAPI.WithCommand(vm => vm.SaveScales())
                .Before(() =>
                {
                    gvScales.CloseEditor();
                    gvScores.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.AddScale())
                .Before(() =>
                {
                    gvScales.CloseEditor();
                    gvScores.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.DeleteScale())
                .Before(() =>
                {
                    gvScales.CloseEditor();
                    gvScores.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.AddScore())
                .Before(() =>
                {
                    gvScales.CloseEditor();
                    gvScores.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.UpScore())
                .Before(() =>
                {
                    gvScales.CloseEditor();
                    gvScores.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.DownScore())
                .Before(() =>
                {
                    gvScales.CloseEditor();
                    gvScores.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.DeleteScore())
                .Before(() =>
                {
                    gvScales.CloseEditor();
                    gvScores.CloseEditor();
                });
            fluentAPI.WithCommand(vm => vm.CloseWindow())
                .Before(() =>
                {
                    gvScales.CloseEditor();
                    gvScores.CloseEditor();
                });

            fluentAPI.WithCommand(vm => vm.AddScale())
                .After(() =>
                {
                    gvScales.RefreshData();
                    gvScales.FocusedRowHandle = gvScales.RowCount - 1;
                });
            fluentAPI.WithCommand(vm => vm.DeleteScale())
                .After(() =>
                {
                    gvScales.RefreshData();
                });
            fluentAPI.WithCommand(vm => vm.AddScore())
                .After(() =>
                {
                    gvScores.RefreshData();
                    gvScores.FocusedRowHandle = gvScores.RowCount - 1;
                });
            fluentAPI.WithCommand(vm => vm.UpScore())
                .After(() =>
                {
                    gvScores.RefreshData();
                    //gvScores.FocusedRowHandle--;
                });
            fluentAPI.WithCommand(vm => vm.DownScore())
                .After(() =>
                {
                    gvScores.RefreshData();
                    //gvScores.FocusedRowHandle++;
                });
            fluentAPI.WithCommand(vm => vm.DeleteScore())
                .After(() =>
                {
                    gvScores.RefreshData();
                });
            fluentAPI.WithCommand(vm => vm.ChangeCurrentScale(vm.CurrentScale))
                .After(() =>
                {
                    gvScores.RefreshData();
                });

            //  Триггер
            fluentAPI.SetTrigger(vm => vm.RefreshScalesTrigger, (x) =>
            {
                fluentAPI.SetObjectDataSourceBinding(scalesBindingSource, vm => vm.Model.Scales);
                fluentAPI.SetObjectDataSourceBinding(scoresBindingSource, vm => vm.CurrentScale.Scores);
            });


            //  Изменения выбранных строк
            fluentAPI.EventToCommand<FocusedRowObjectChangedEventArgs>(gvScales, "FocusedRowObjectChanged", vm => vm.ChangeCurrentScale(null), args =>
            {
                if (args.Row is Scale scale)
                {
                    return scale;
                }

                return null;
            });
            fluentAPI.EventToCommand<FocusedRowObjectChangedEventArgs>(gvScores, "FocusedRowObjectChanged", vm => vm.ChangeCurrentScore(null), args =>
            {
                if (args.Row is ScaleScore score)
                {
                    return score;
                }

                return null;
            });
        }

        private void InitializeEvents()
        {
            gvScales.RowStyle += (o, e) =>
            {
                if (e.RowHandle < 0)
                    return;
                if (gvScales.GetRow(e.RowHandle) is Scale at && at.ForDelete)
                    e.Appearance.FontStyleDelta = FontStyle.Strikeout;
            };
            gvScores.RowStyle += (o, e) =>
            {
                if (e.RowHandle < 0)
                    return;
                if (gvScores.GetRow(e.RowHandle) is ScaleScore at && at.ForDelete)
                    e.Appearance.FontStyleDelta = FontStyle.Strikeout;
            };
        }
    }
}