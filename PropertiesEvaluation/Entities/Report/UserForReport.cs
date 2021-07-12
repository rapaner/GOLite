using System.Collections.ObjectModel;
using System.Linq;

namespace GOLite.Entities
{
    /// <summary>
    /// Пользователь для отчета
    /// </summary>
    public class UserForReport
    {
        /// <summary>
        /// Код пользователя
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Код тестового пользователя
        /// </summary>
        public int TestUserID { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Сортировка в тесте
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// Качества
        /// </summary>
        public ObservableCollection<TestQualityForReport> Qualities { get; set; } = new ObservableCollection<TestQualityForReport>();

        /// <summary>
        /// Место в списке
        /// </summary>
        public int PlaceInList { get; set; }

        /// <summary>
        /// Сумма баллов
        /// </summary>
        public int Sum => Qualities.Select(x => x.Sum).Sum();
    }
}