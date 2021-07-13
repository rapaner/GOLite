using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GOLite.Entities
{
    /// <summary>
    /// Тест
    /// </summary>
    public class Test : INotifyPropertyChanged
    {
        #region Поля

        /// <summary>
        /// Начальная шкала
        /// </summary>
        private int _scaleID;

        /// <summary>
        /// Начальная группа качеств
        /// </summary>
        private int _qualityGroupID;

        /// <summary>
        /// Начальное название теста
        /// </summary>
        private string _testName;

        /// <summary>
        /// Начальная дата создания
        /// </summary>
        private DateTime _dateCreated;

        /// <summary>
        /// Начальное описание
        /// </summary>
        private string _description;

        private string testName;
        private int scaleID;
        private DateTime dateCreated;
        private string description;
        private int qualityGroupID;

        #endregion Поля

        #region Конструкторы

        public Test()
        {
            DateCreated = DateTime.Now;
            Description = "\tВаша задача - оценить выраженность перечисленных справа качеств у Ваших коллег и у себя. Оценки заносятся в нижний бланк, номера колонок которого соответствует номерам качеств в списке.\r\n" +
                "\tБланк заполняется по колонкам, т.е. сначала оценивается первое качество у всех участников, затем второе, и т.д.\r\n" +
    "\tДля исключения ошибок рекомендуется вычеркивать или обводить кружком номер качества, оценка которого произведена.\r\n" +
     "\tКачества заданы в виде полярных пар.\r\n" +
     "\tВыраженность качеств оценивается по цифровой шкале, в которой максимальной выраженности ЛЕВОГО качества соответствует оценка \"1\", а максимальной выраженности ПРАВОГО -оценка \"5\".\r\n" +
     "\tСредняя оценка \"3\" означает: \"ни одно, ни другое\"; \"оба в равной мере\"; \"проявляется то одно, то другое\"; \"не знаю\"; \"не могу оценить\"; \"не уверен\".\r\n" +
     "\tС остальными оценками можно связать следующие формулировки:\r\n" +
            "\t2, 4 - качество заметно, проявляется достаточно часто;\r\n" +
            "\t1, 5 - качество ярко выражено, проявляется всегда.\r\n" +
     "\tДля удобства над списком качеств приведена используемая шкала оценок.";

            _dateCreated = DateTime.Now;
        }

        public Test(int testID, string testName, int scaleID, int qualityGroupID, DateTime dateCreated, string description)
        {
            TestID = testID;
            TestName = testName;
            ScaleID = scaleID;
            QualityGroupID = qualityGroupID;
            DateCreated = dateCreated;
            Description = description;

            _scaleID = scaleID;
            _qualityGroupID = qualityGroupID;
            _testName = testName;
            _dateCreated = dateCreated;
            _description = description;
        }

        #endregion Конструкторы

        #region Свойства

        /// <summary>
        /// Код теста
        /// </summary>
        public int TestID { get; set; }

        /// <summary>
        /// Название теста
        /// </summary>
        public string TestName
        {
            get => testName;
            set
            {
                if (testName != value)
                {
                    testName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Код шкалы
        /// </summary>
        public int ScaleID
        {
            get => scaleID;
            set
            {
                if (scaleID != value)
                {
                    scaleID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Код группы качеств
        /// </summary>
        public int QualityGroupID
        {
            get => qualityGroupID;
            set
            {
                if (qualityGroupID != value)
                {
                    qualityGroupID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreated
        {
            get => dateCreated;
            set
            {
                if (dateCreated != value)
                {
                    dateCreated = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Удалить результаты теста в БД
        /// </summary>
        public bool DeleteTestResults { get; set; }

        /// <summary>
        /// Участники теста
        /// </summary>
        public ObservableCollection<TestUser> TestUsers { get; set; } = new ObservableCollection<TestUser>();

        /// <summary>
        /// Качества для теста
        /// </summary>
        public ObservableCollection<TestQuality> TestQualities { get; set; } = new ObservableCollection<TestQuality>();

        /// <summary>
        /// Пользователи с результатами теста
        /// </summary>
        public ObservableCollection<UserWithTestResults> UsersWithResults { get; set; } = new ObservableCollection<UserWithTestResults>();

        /// <summary>
        /// Есть изменения в теле теста
        /// </summary>
        public bool IsBodyChanged =>
            ScaleID != _scaleID
            || QualityGroupID != _qualityGroupID
            || TestName != _testName
            || DateCreated != _dateCreated
            || Description != _description;

        /// <summary>
        /// Есть изменения
        /// </summary>
        public bool IsChanged =>
            ScaleID != _scaleID
            || QualityGroupID != _qualityGroupID
            || TestName != _testName
            || DateCreated != _dateCreated
            || Description != _description
            || DeleteTestResults
            || TestUsers.FirstOrDefault(x => x.IsChanged) != null
            || TestQualities.FirstOrDefault(x => x.IsChanged) != null
            || UsersWithResults.FirstOrDefault(x => x.IsChanged) != null;

        /// <summary>
        /// Есть изменения в группе качеств
        /// </summary>
        public bool IsQualityGroupChanged =>
            QualityGroupID != _qualityGroupID;

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