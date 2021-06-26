using GOLite.Common;
using GOLite.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace GOLite.Models
{
    public class QualitiesModel : BaseValidation
    {
        #region Свойства

        /// <summary>
        /// Группы качеств
        /// </summary>
        public virtual ObservableCollection<QualityGroup> QualityGroups { get; set; } = new ObservableCollection<QualityGroup>();

        #endregion Свойства

        #region Методы

        public override void OnValidate()
        {
            var qg = QualityGroups.FirstOrDefault(x => string.IsNullOrWhiteSpace(x.Name));
            if (qg != null)
            {
                AddError("Есть группа качеств без названия!");
            }
            foreach (var group in QualityGroups.Where(x => !string.IsNullOrWhiteSpace(x.Name)))
            {
                var q = group.Qualities.FirstOrDefault(x => (string.IsNullOrWhiteSpace(x.BadQuality) || string.IsNullOrWhiteSpace(x.GoodQuality)) && !x.ForDelete);
                if (q != null)
                    AddError($"В группе качеств {group.Name} есть строки с незаполненными полями (нет положительного и/или отрицательного качеств)!");
            }
        }

        #endregion Методы
    }
}