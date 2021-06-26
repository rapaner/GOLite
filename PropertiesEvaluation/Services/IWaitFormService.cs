using System;
using System.Threading.Tasks;

namespace GOLite.Services
{

    /// <summary>
    /// Интерфейс формы-ожидания с автоматическим закрытием
    /// </summary>
    public interface IWaitFormService
    {
        #region Методы
        /// <summary>
        /// Открывает форму-ожидание, выполняет действие и закрывает форму по завершении
        /// </summary>
        void Show(Action action);

        /// <summary>
        /// Открывает форму-ожидание, выполняет действие и закрывает форму по завершении
        /// </summary>
        void Show(Action action, string caption, string description);

        /// <summary>
        /// Открывает форму-ожидание, выполняет асинхронную задачу и закрывается по завершении
        /// </summary>
        Task<T> ShowAsync<T>(Task<T> func);

        /// <summary>
        /// Открывает форму-ожидание, выполняет асинхронную задачу и закрывается по завершении
        /// </summary>
        Task<T> ShowAsync<T>(Task<T> func, string caption, string description);

        /// <summary>
        /// Открывает форму-ожидание, выполняет асинхронные задачи и закрывается по завершении
        /// </summary>
        Task ShowAsync(params Task[] taskArray);

        /// <summary>
        /// Открывает форму-ожидание, выполняет асинхронные задачи и закрывается по завершении
        /// </summary>
        Task ShowAsync(string caption, string description, params Task[] taskArray);
        #endregion Методы
    }
}
