using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GOLite.Common
{
    /// <summary>
    /// Базовая модель для всех классов, реализующая поддержку интерфейса <see cref="INotifyPropertyChanged"/>
    /// </summary>
    public class BaseNotification : INotifyPropertyChanged
    {
        #region События

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion События

        #region Методы

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Методы
    }
}