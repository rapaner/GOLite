using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace GOLite.Entities
{
    /// <summary>
    /// Пользователь с результатами теста
    /// </summary>
    public class UserWithTestResults : INotifyPropertyChanged
    {
        public UserWithTestResults(int testUserID, string userName, int sort)
        {
            TestUserID = testUserID;
            UserName = userName;
            Sort = sort;
        }

        /// <summary>
        /// Код пользователя с результатами
        /// </summary>
        public int TestUserID { get; set; }

        /// <summary>
        /// ФИО пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Сортировка
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// Кодовое имя
        /// </summary>
        public string CodeName => $"Участник {Sort}";

        /// <summary>
        /// Результаты теста
        /// </summary>
        public ObservableCollection<TestResult> TestResults { get; set; } = new ObservableCollection<TestResult>();

        /// <summary>
        /// Есть изменения
        /// </summary>
        public bool IsChanged =>
            TestResults.FirstOrDefault(x => x.IsChanged) != null;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}