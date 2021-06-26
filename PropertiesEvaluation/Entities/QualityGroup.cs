using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GOLite.Entities
{
    public class QualityGroup : INotifyPropertyChanged
    {
        /// <summary>
        /// Начальное название групп качеств
        /// </summary>
        private string _name;

        private int qualityGroupID;
        private string name;
        private bool forDelete;

        public QualityGroup()
        {
        }

        public QualityGroup(int qualityGroupID, string name)
        {
            QualityGroupID = qualityGroupID;
            Name = name;

            _name = name;
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
        /// Название группы качеств
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
        /// Качества
        /// </summary>
        public ObservableCollection<Quality> Qualities { get; set; } = new ObservableCollection<Quality>();

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
            || Qualities.FirstOrDefault(x => x.IsChanged || x.ForDelete) != null;

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