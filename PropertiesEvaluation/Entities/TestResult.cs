using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GOLite.Entities
{
    /// <summary>
    /// Результат теста
    /// </summary>
    public class TestResult : INotifyPropertyChanged
    {
        private int _scaleScoreID;
        private int scaleScoreID;

        public TestResult()
        {
        }

        public TestResult(int testResultID, int scaleScoreID, int testQualityID, int userID)
        {
            TestResultID = testResultID;
            ScaleScoreID = scaleScoreID;
            TestQualityID = testQualityID;
            UserID = userID;

            _scaleScoreID = scaleScoreID;
        }

        /// <summary>
        /// Код результата теста
        /// </summary>
        public int TestResultID { get; set; }

        /// <summary>
        /// Код значения шкалы
        /// </summary>
        public int ScaleScoreID
        {
            get => scaleScoreID;
            set
            {
                if (scaleScoreID != value)
                {
                    scaleScoreID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Код качества в тесте
        /// </summary>
        public int TestQualityID { get; set; }

        /// <summary>
        /// Код оцениваемого пользователя
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Есть изменения
        /// </summary>
        public bool IsChanged =>
            ScaleScoreID != _scaleScoreID
            || TestResultID == 0;

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
