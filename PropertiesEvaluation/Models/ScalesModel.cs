using GOLite.Common;
using GOLite.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace GOLite.Models
{
    public class ScalesModel : BaseValidation
    {
        #region Свойства

        /// <summary>
        /// Шкалы
        /// </summary>
        public virtual ObservableCollection<Scale> Scales { get; set; } = new ObservableCollection<Scale>();

        #endregion Свойства

        #region Методы

        public override void OnValidate()
        {
            var scale = Scales.FirstOrDefault(x => string.IsNullOrWhiteSpace(x.Name) && !x.ForDelete);
            if (scale != null)
                AddError("Есть шкала без названия!");
            scale = Scales.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.Name) && !x.ForDelete && !x.Scores.Where(y => !y.ForDelete).Any());
            if (scale != null)
                AddError($"Шкала {scale.Name} без баллов!");
            scale = Scales.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.Name) && !x.ForDelete && x.Scores.Where(y => !y.ForDelete).Count() % 2 == 0);
            if (scale != null)
                AddError($"Шкала {scale.Name} содержит четное количество баллов! Оно должно быть нечетным!");
        }

        #endregion Методы
    }
}