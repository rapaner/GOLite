using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GOLite.Entities
{
    /// <summary>
    /// Балл шкалы
    /// </summary>
    public class ScaleScore : INotifyPropertyChanged
    {
        /// <summary>
        /// Начальный балл
        /// </summary>
        private int? _score;

        /// <summary>
        /// Начальная сортировка
        /// </summary>
        private int _sort;
        private int scaleScoreID;
        private int? score;
        private int sort;
        private bool forDelete;

        public ScaleScore()
        {
        }

        public ScaleScore(int scaleScoreID, int score, int sort)
        {
            ScaleScoreID = scaleScoreID;
            Score = score;
            Sort = sort;

            _score = score;
            _sort = sort;
        }

        /// <summary>
        /// Код
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
        /// Балл
        /// </summary>
        public int? Score
        {
            get => score;
            set
            {
                if (score != value)
                {
                    score = value;
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
        /// Есть результаты тестов?
        /// </summary>
        public bool HasTestResults { get; set; }

        /// <summary>
        /// Есть изменения
        /// </summary>
        public bool IsChanged =>
            Score != _score
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
