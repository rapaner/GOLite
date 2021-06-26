using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GOLite.Entities
{
    /// <summary>
    /// Участник тестирования
    /// </summary>
    public class TestUser : INotifyPropertyChanged
    {
        #region Поля

        /// <summary>
        /// Начальное ФИО
        /// </summary>
        private string _userName;

        /// <summary>
        /// Начальная сортировка
        /// </summary>
        private int _sort;

        private int sort;
        private string userName;

        #endregion Поля

        #region Конструкторы

        public TestUser()
        {
        }

        public TestUser(int testUserID, int userID, string userName, int sort)
        {
            TestUserID = testUserID;
            UserID = userID;
            UserName = userName;
            Sort = sort;

            _userName = userName;
            _sort = sort;
        }

        #endregion Конструкторы

        #region Свойства

        /// <summary>
        /// Код участника теста
        /// </summary>
        public int TestUserID { get; set; }

        /// <summary>
        /// Код участника
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Сортировка
        /// </summary>
        public int Sort
        {
            get => sort;
            set
            {
                if (sort != value)
                {
                    sort = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// ФИО
        /// </summary>
        public string UserName
        {
            get => userName;
            set
            {
                if (userName != value)
                {
                    userName = value;
                    if (userName != null && userName.Length > 0)
                    {
                        if (userName.Length == 1)
                        {
                            userName = char.ToUpper(userName[0]).ToString();
                        }
                        else
                        {
                            userName = char.ToUpper(userName[0]) + userName.Substring(1);
                        }
                    }
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Кодовое имя
        /// </summary>
        public string CodeName => $"Участник {Sort}";

        /// <summary>
        /// На удаление
        /// </summary>
        public bool ForDelete { get; set; }

        /// <summary>
        /// Есть изменения
        /// </summary>
        public bool IsChanged =>
            UserName != _userName
            || Sort != _sort;

        /// <summary>
        /// Изменены ФИО
        /// </summary>
        public bool IsUserNameChanged =>
            UserName != _userName;

        /// <summary>
        /// Изменен порядок
        /// </summary>
        public bool IsSortChanged =>
            Sort != _sort;

        #endregion Свойства

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}