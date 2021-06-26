using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GOLite.Entities
{
    /// <summary>
    /// Пользователь (не используется, так как участники не нужны вне теста)
    /// </summary>
    public class User : INotifyPropertyChanged
    {
        /// <summary>
        /// Начальное ФИО
        /// </summary>
        private string _userName;
        private int userID;
        private string userName;

        public User()
        {
        }

        public User(int userID, string userName)
        {
            UserID = userID;
            UserName = userName;

            _userName = userName;
        }

        /// <summary>
        /// Код пользователя
        /// </summary>
        public int UserID
        {
            get => userID;
            set
            {
                if (userID != value)
                {
                    userID = value;
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
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// На удаление
        /// </summary>
        public bool ForDelete { get; set; }

        /// <summary>
        /// Есть тесты?
        /// </summary>
        public bool HasTests { get; set; }

        /// <summary>
        /// Есть изменения
        /// </summary>
        public bool IsChanged =>
            UserName != _userName;

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
