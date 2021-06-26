using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GOLite.Entities
{
    /// <summary>
    /// Шкала
    /// </summary>
    public class Scale : INotifyPropertyChanged
    {
        /// <summary>
        /// Начальное название шкалы
        /// </summary>
        private string _name;

        private int scaleID;
        private string name;
        private bool forDelete;

        public Scale()
        {
        }

        public Scale(int scaleID, string name)
        {
            ScaleID = scaleID;
            Name = name;

            _name = name;
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
        /// Название шкалы
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Баллы
        /// </summary>
        public ObservableCollection<ScaleScore> Scores { get; set; } = new ObservableCollection<ScaleScore>();

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
        /// Есть тесты
        /// </summary>
        public bool HasTests { get; set; }

        /// <summary>
        /// Есть изменения
        /// </summary>
        public bool IsChanged =>
            Name != _name
            || Scores.FirstOrDefault(x => x.IsChanged || x.ForDelete) != null;

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