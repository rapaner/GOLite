using GOLite.Common;
using GOLite.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace GOLite.Models
{
    public class UsersModel : BaseValidation
    {
        #region Свойства

        /// <summary>
        /// Участники
        /// </summary>
        public virtual ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        #endregion Свойства

        #region Методы

        public override void OnValidate()
        {
            var u = Users.FirstOrDefault(x => string.IsNullOrWhiteSpace(x.UserName) && !x.ForDelete);
            if (u != null)
                AddError("Есть участники без ФИО!");
        }

        #endregion Методы
    }
}