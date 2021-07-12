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
    public class ScalesViewModel : CommonViewModel
    {
        #region Свойства

        /// <summary>
        /// Модель с качествами
        /// </summary>
        public virtual ScalesModel Model { get; set; } = new ScalesModel();

        /// <summary>
        /// Текущее качество
        /// </summary>
        public virtual Scale CurrentScale { get; set; }

        public void OnCurrentScaleChanged()
        {
            this.RaiseCanExecuteChanged(vm => vm.DeleteScale());
            this.RaiseCanExecuteChanged(vm => vm.AddScore());
        }

        /// <summary>
        /// Текущий балл
        /// </summary>
        public virtual ScaleScore CurrentScore { get; set; }

        public void OnCurrentScoreChanged()
        {
            this.RaiseCanExecuteChanged(vm => vm.DeleteScore());
            this.RaiseCanExecuteChanged(vm => vm.UpScore());
            this.RaiseCanExecuteChanged(vm => vm.DownScore());
        }

        /// <summary>
        /// Обновить качества
        /// </summary>
        public virtual bool RefreshScalesTrigger { get; set; }

        #endregion Свойства

        #region Методы

        /// <summary>
        /// Получить список шкал
        /// </summary>
        /// <param name="showMessage">Показать сообщение</param>
        public Task GetScales(bool showMessage)
        {
            return GetScalesAsync(showMessage);
        }

        /// <summary>
        /// Получить список шкал
        /// </summary>
        /// <param name="showMessage">Показать сообщение</param>
        private async Task GetScalesAsync(bool showMessage)
        {
            try
            {
                Model.Scales = await WaitFormService.ShowAsync(DataSourceProvider.Instance.GetScalesAsync());
                this.RaisePropertiesChanged();
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.GetExceptionMessage(), "Ошибка", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Сохранить список шкал
        /// </summary>
        public Task SaveScales()
        {
            return SaveScalesAsync();
        }

        /// <summary>
        /// Сохранить список качеств
        /// </summary>
        private async Task SaveScalesAsync()
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
                var changedScales = new ObservableCollection<Scale>(Model.Scales.Where(x => x.IsChanged || x.ForDelete));
                var result = await WaitFormService.ShowAsync(DataSourceProvider.Instance.SaveScalesAsync(changedScales));
                if (result)
                {
                    Model.Scales = await WaitFormService.ShowAsync(DataSourceProvider.Instance.GetScalesAsync());
                    RefreshScalesTrigger = !RefreshScalesTrigger;
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
        /// Добавить шкалу
        /// </summary>
        public void AddScale()
        {
            Scale scale = new Scale();

            Model.Scales.Add(scale);
        }

        /// <summary>
        /// Можно удалить шкалу?
        /// </summary>
        public bool CanDeleteScale()
        {
            return CurrentScale != null
                && !CurrentScale.HasTests
                && CurrentScale.Scores.FirstOrDefault(x => x.HasTestResults) == null;
        }

        /// <summary>
        /// Удалить шкалу
        /// </summary>
        public void DeleteScale()
        {
            CurrentScale.ForDelete = !CurrentScale.ForDelete;
        }

        /// <summary>
        /// Изменить текущее качество
        /// </summary>
        /// <param name="scale">Качество</param>
        public void ChangeCurrentScale(Scale scale)
        {
            CurrentScale = scale;
        }

        /// <summary>
        /// Можно добавить балл?
        /// </summary>
        public bool CanAddScore()
        {
            return CurrentScale != null;
        }

        /// <summary>
        /// Добавить балл
        /// </summary>
        public void AddScore()
        {
            ScaleScore score = new ScaleScore();
            int sort = CurrentScale.Scores.Count() + 1;
            score.Sort = sort;

            CurrentScale.Scores.Add(score);
        }

        /// <summary>
        /// Можно удалить балл?
        /// </summary>
        public bool CanDeleteScore()
        {
            return CurrentScore != null
                && !CurrentScore.HasTestResults;
        }

        /// <summary>
        /// Удалить балл
        /// </summary>
        public void DeleteScore()
        {
            CurrentScore.ForDelete = !CurrentScore.ForDelete;
        }

        /// <summary>
        /// Можно поднять балл?
        /// </summary>
        public bool CanUpScore()
        {
            return CurrentScore != null
                && CurrentScore.Sort > 1;
        }

        /// <summary>
        /// Поднять балл
        /// </summary>
        public void UpScore()
        {
            var scoreForChange = CurrentScale.Scores.FirstOrDefault(x => x.Sort == CurrentScore.Sort - 1);
            if (scoreForChange is null)
                return;
            scoreForChange.Sort += 1;
            CurrentScore.Sort -= 1;
            this.RaiseCanExecuteChanged(vm => vm.UpScore());
            this.RaiseCanExecuteChanged(vm => vm.DownScore());
        }

        /// <summary>
        /// Можно опустить балл?
        /// </summary>
        public bool CanDownScore()
        {
            return CurrentScore != null
                && CurrentScore.Sort < CurrentScale.Scores.Count - 1;
        }

        /// <summary>
        /// Опустить балл
        /// </summary>
        public void DownScore()
        {
            var scoreForChange = CurrentScale.Scores.FirstOrDefault(x => x.Sort == CurrentScore.Sort + 1);
            if (scoreForChange is null)
                return;
            scoreForChange.Sort -= 1;
            CurrentScore.Sort += 1;
            this.RaiseCanExecuteChanged(vm => vm.UpScore());
            this.RaiseCanExecuteChanged(vm => vm.DownScore());
        }

        /// <summary>
        /// Изменить текущий балл
        /// </summary>
        /// <param name="score">Балл</param>
        public void ChangeCurrentScore(ScaleScore score)
        {
            CurrentScore = score;
        }

        /// <summary>
        /// Закрыть окно
        /// </summary>
        public void CloseWindow()
        {
            if (Model.Scales.FirstOrDefault(x => x.IsChanged || x.ForDelete) != null && MessageBoxService.ShowMessage("Есть несохраненные изменения. Закрыть окно?", "", MessageButton.YesNoCancel, MessageIcon.Question) != MessageResult.Yes)
            {
                return;
            }
            CloseScalesView();
        }

        #endregion Методы
    }
}