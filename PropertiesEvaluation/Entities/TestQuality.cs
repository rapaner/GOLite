using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GOLite.Entities
{
    /// <summary>
    /// Качество для теста
    /// </summary>
    public class TestQuality : INotifyPropertyChanged
    {
        /// <summary>
        /// Начальный код качества
        /// </summary>
        private int _qualityID;

        /// <summary>
        /// Начальная сортировка
        /// </summary>
        private int _sort;
        private int qualityID;
        private int sort;
        private bool forDelete;

        public TestQuality()
        {
        }

        public TestQuality(int testQualityID, int qualityID, int sort)
        {
            TestQualityID = testQualityID;
            QualityID = qualityID;
            Sort = sort;

            _qualityID = qualityID;
            _sort = sort;
        }

        /// <summary>
        /// Код качества для теста
        /// </summary>
        public int TestQualityID { get; set; }

        /// <summary>
        /// Код качества
        /// </summary>
        public int QualityID
        {
            get => qualityID;
            set
            {
                if(qualityID!=value)
                {
                    qualityID = value;
                    NotifyPropertyChanged();
                }
            }
        }

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
        /// На удаление
        /// </summary>
        public bool ForDelete
        {
            get => forDelete;
            set
            {
                if (forDelete != value)
                {
                    forDelete = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Есть изменения
        /// </summary>
        public bool IsChanged =>
            QualityID != _qualityID
            || Sort != _sort;

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
