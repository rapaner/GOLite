using GOLite.Common;
using GOLite.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace GOLite.Models
{
    /// <summary>
    /// Модель для теста
    /// </summary>
    public class TestModel : BaseValidation
    {
        #region Свойства

        /// <summary>
        /// Тест
        /// </summary>
        public Test Test { get; set; } = new Test();

        /// <summary>
        /// Шкалы
        /// </summary>
        public ObservableCollection<Scale> Scales { get; set; } = new ObservableCollection<Scale>();

        #endregion Свойства

        #region Методы

        /// <summary>
        /// Валидация
        /// </summary>
        public override void OnValidate()
        {
            if (string.IsNullOrWhiteSpace(Test.TestName))
                AddError("Введите название теста!");
            if (Test.ScaleID == 0)
                AddError("Не выбрана шкала! Выберите шкалу.");
            if (Test.QualityGroupID == 0)
                AddError("Не выбрана группа качества! Выберите группу качеств.");
            if (string.IsNullOrWhiteSpace(Test.Description))
                AddError("Введите описание для теста!");
            if (Test.TestUsers.FirstOrDefault(x => string.IsNullOrWhiteSpace(x.UserName) && !x.ForDelete) != null)
                AddError("Есть участник без ФИО! Введите ФИО всем участникам.");
            if (Test.TestQualities.FirstOrDefault(x => x.QualityID == 0 && !x.ForDelete) != null)
                AddError("Есть пустая строка с качеством! Выберите качество или удалите строку!");
            if (Test.TestQualities.Any())
            {
                var qualitiesGroups = Test.TestQualities
                    .Where(x => !x.ForDelete)
                    .GroupBy((x) => x.QualityID)
                    .Select(x => new { Quality = x.Key, Count = x.Count() })
                    .Where(x => x.Count > 1).ToList();
                if (qualitiesGroups.Any())
                {
                    AddError($"Есть качества, указанные дважды! Необходимо устранить дубли.");
                }
            }
        }

        #endregion Методы
    }
}