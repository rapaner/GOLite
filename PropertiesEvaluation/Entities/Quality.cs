using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GOLite.Entities
{
    /// <summary>
    /// Качество
    /// </summary>
    public class Quality : INotifyPropertyChanged
    {
        /// <summary>
        /// Начальное название хорошего качества
        /// </summary>
        private string _goodQuality;

        /// <summary>
        /// Начальное название плохого качества
        /// </summary>
        private string _badQuality;

        /// <summary>
        /// Начальная сортировка
        /// </summary>
        private int _sort;

        private string badQuality;
        private string goodQuality;
        private bool forDelete;
        private int qualityID;
        private int sort;

        public Quality()
        {
        }

        public Quality(int qualityID, string goodQuality, string badQuality, int sort)
        {
            QualityID = qualityID;
            GoodQuality = goodQuality;
            BadQuality = badQuality;
            Sort = sort;

            _goodQuality = goodQuality;
            _badQuality = badQuality;
            _sort = sort;
        }

        /// <summary>
        /// Код качества
        /// </summary>
        public int QualityID
        {
            get => qualityID;
            set
            {
                if (qualityID != value)
                {
                    qualityID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Хорошее качество
        /// </summary>
        public string GoodQuality
        {
            get => goodQuality;
            set
            {
                if (goodQuality != value)
                {
                    goodQuality = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Плохое качество
        /// </summary>
        public string BadQuality
        {
            get => badQuality;
            set
            {
                if (badQuality != value)
                {
                    badQuality = value;
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
        /// Есть тесты?
        /// </summary>
        public bool HasTests { get; set; }

        /// <summary>
        /// Качество для отображения
        /// </summary>
        public string QualityForDisplay
        {
            get
            {
                if (string.IsNullOrWhiteSpace(GoodQuality) && string.IsNullOrWhiteSpace(BadQuality))
                    return "";
                return $"{GoodQuality} - {BadQuality}";
            }
        }

        /// <summary>
        /// Есть изменения
        /// </summary>
        public bool IsChanged =>
            GoodQuality != _goodQuality
            || BadQuality != _badQuality
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
