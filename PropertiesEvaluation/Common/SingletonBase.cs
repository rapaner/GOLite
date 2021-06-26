using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLite.Common
{
    /// <summary>
    /// Класс-создатель синглтонов
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonBase<T> where T : new()
    {
        #region Свойства

        /// <summary>
        /// Свойство-синглтон
        /// </summary>
        public static T Instance { get; } = new T();

        #endregion Свойства
    }
}
