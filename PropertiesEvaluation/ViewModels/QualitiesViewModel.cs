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
    public class QualitiesViewModel : CommonViewModel
    {
        #region Свойства

        /// <summary>
        /// Модель с группами качеств
        /// </summary>
        public virtual QualitiesModel Model { get; set; } = new QualitiesModel();

        /// <summary>
        /// Текущая группа качеств
        /// </summary>
        public virtual QualityGroup CurrentQualityGroup { get; set; }

        public void OnCurrentQualityGroupChanged()
        {
            this.RaiseCanExecuteChanged(vm => vm.DeleteQualityGroup());
            this.RaiseCanExecuteChanged(vm => vm.AddQuality());
            this.RaiseCanExecuteChanged(vm => vm.CopyQualityGroup());
        }

        /// <summary>
        /// Текущее качество
        /// </summary>
        public virtual Quality CurrentQuality { get; set; }

        public void OnCurrentQualityChanged()
        {
            this.RaiseCanExecuteChanged(vm => vm.DeleteQuality());
            this.RaiseCanExecuteChanged(vm => vm.UpQuality());
            this.RaiseCanExecuteChanged(vm => vm.DownQuality());
        }

        /// <summary>
        /// Обновить качества
        /// </summary>
        public virtual bool RefreshQualitiesTrigger { get; set; }

        #endregion Свойства

        #region Методы

        /// <summary>
        /// Получить список групп качеств
        /// </summary>
        /// <param name="showMessage">Показать сообщение</param>
        public Task GetQualityGroups(bool showMessage)
        {
            return GetQualityGroupsAsync(showMessage);
        }

        /// <summary>
        /// Получить список групп качеств
        /// </summary>
        /// <param name="showMessage">Показать сообщение</param>
        private async Task GetQualityGroupsAsync(bool showMessage)
        {
            try
            {
                Model.QualityGroups = await WaitFormService.ShowAsync(DataSourceProvider.Instance.GetQualityGroupsAsync());
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.GetExceptionMessage(), "Ошибка", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Сохранить список групп качеств
        /// </summary>
        public Task SaveQualityGroups()
        {
            return SaveQualityGroupsAsync();
        }

        /// <summary>
        /// Сохранить список групп качеств
        /// </summary>
        private async Task SaveQualityGroupsAsync()
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
                var changedQualityGroups = new ObservableCollection<QualityGroup>(Model.QualityGroups.Where(x => x.IsChanged || x.ForDelete));
                var result = await WaitFormService.ShowAsync(DataSourceProvider.Instance.SaveQualityGroupsAsync(changedQualityGroups));
                if (result)
                {
                    Model.QualityGroups = await WaitFormService.ShowAsync(DataSourceProvider.Instance.GetQualityGroupsAsync());
                    RefreshQualitiesTrigger = !RefreshQualitiesTrigger;
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
        /// Добавить группу качеств
        /// </summary>
        public void AddQualityGroup()
        {
            QualityGroup qualityGroup = new QualityGroup();

            Model.QualityGroups.Add(qualityGroup);
        }

        /// <summary>
        /// Можно удалить группу качеств?
        /// </summary>
        public bool CanDeleteQualityGroup()
        {
            return CurrentQualityGroup != null
                && !CurrentQualityGroup.HasTests
                && CurrentQualityGroup.Qualities.FirstOrDefault(x => x.HasTests) == null;
        }

        /// <summary>
        /// Удалить группу качеств
        /// </summary>
        public void DeleteQualityGroup()
        {
            CurrentQualityGroup.ForDelete = !CurrentQualityGroup.ForDelete;
        }

        /// <summary>
        /// Можно сделать копию группы качеств
        /// </summary>
        public bool CanCopyQualityGroup()
        {
            return CurrentQualityGroup != null;
        }

        /// <summary>
        /// Сделать копию группы качеств
        /// </summary>
        public void CopyQualityGroup()
        {
            var newCopy = CurrentQualityGroup.DeepCopyByExpressionTree();
            newCopy.Name = $"{newCopy.Name}-копия";
            newCopy.QualityGroupID = 0;
            foreach (var q in newCopy.Qualities)
            {
                q.QualityID = 0;
            }
            Model.QualityGroups.Add(newCopy);
            this.RaisePropertiesChanged();
        }

        /// <summary>
        /// Изменить текущую группу качеств
        /// </summary>
        /// <param name="qualityGroup">Группа качеств</param>
        public void ChangeCurrentQualityGroup(QualityGroup qualityGroup)
        {
            CurrentQualityGroup = qualityGroup;
        }

        /// <summary>
        /// Можно добавить качество?
        /// </summary>
        public bool CanAddQuality()
        {
            return CurrentQualityGroup != null;
        }

        /// <summary>
        /// Добавить качество
        /// </summary>
        public void AddQuality()
        {
            Quality quality = new Quality();
            int sort = CurrentQualityGroup.Qualities.Count() + 1;
            quality.Sort = sort;

            CurrentQualityGroup.Qualities.Add(quality);
        }

        /// <summary>
        /// Можно удалить качество?
        /// </summary>
        public bool CanDeleteQuality()
        {
            return CurrentQuality != null
                && !CurrentQuality.HasTests;
        }

        /// <summary>
        /// Удалить качество
        /// </summary>
        public void DeleteQuality()
        {
            CurrentQuality.ForDelete = !CurrentQuality.ForDelete;
        }

        /// <summary>
        /// Можно поднять качество?
        /// </summary>
        public bool CanUpQuality()
        {
            return CurrentQuality != null
                && CurrentQuality.Sort > 1;
        }

        /// <summary>
        /// Поднять качество
        /// </summary>
        public void UpQuality()
        {
            var qualityForChange = CurrentQualityGroup.Qualities.FirstOrDefault(x => x.Sort == CurrentQuality.Sort - 1);
            if (qualityForChange is null)
                return;
            qualityForChange.Sort += 1;
            CurrentQuality.Sort -= 1;

            this.RaiseCanExecuteChanged(vm => vm.UpQuality());
            this.RaiseCanExecuteChanged(vm => vm.DownQuality());
            this.RaisePropertiesChanged();
        }

        /// <summary>
        /// Можно опустить качество?
        /// </summary>
        public bool CanDownQuality()
        {
            return CurrentQuality != null
                && CurrentQuality.Sort < CurrentQualityGroup.Qualities.Count;
        }

        /// <summary>
        /// Опустить качество
        /// </summary>
        public void DownQuality()
        {
            var qualityForChange = CurrentQualityGroup.Qualities.FirstOrDefault(x => x.Sort == CurrentQuality.Sort + 1);
            if (qualityForChange is null)
                return;
            qualityForChange.Sort -= 1;
            CurrentQuality.Sort += 1;

            this.RaiseCanExecuteChanged(vm => vm.UpQuality());
            this.RaiseCanExecuteChanged(vm => vm.DownQuality());
            this.RaisePropertiesChanged();
        }

        /// <summary>
        /// Изменить текущее качество
        /// </summary>
        /// <param name="quality">Качество</param>
        public void ChangeCurrentQuality(Quality quality)
        {
            CurrentQuality = quality;
        }

        /// <summary>
        /// Закрыть окно
        /// </summary>
        public void CloseWindow()
        {
            if (Model.QualityGroups.FirstOrDefault(x => x.IsChanged || x.ForDelete) != null && MessageBoxService.ShowMessage("Есть несохраненные изменения. Закрыть окно?", "", MessageButton.YesNoCancel, MessageIcon.Question) != MessageResult.Yes)
            {
                return;
            }
            CloseQualitiesView();
        }

        #endregion Методы
    }
}