using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Threading.Tasks;

namespace GOLite.Services
{
    /// <summary>
    /// Сервис формы-ожидания с автоматическим закрытием
    /// </summary>
    public class WaitFormService : IWaitFormService
    {
        #region Конструктор

        public WaitFormService(XtraForm parentForm = null)
        {
            ParentForm = parentForm;
        }

        #endregion Конструктор

        #region Свойства

        /// <summary>
        /// Владелец формы ожидания
        /// </summary>
        public XtraForm ParentForm { get; }

        #endregion Свойства

        #region Методы

        /// <summary>
        /// Открывает форму-ожидание, выполняет действие и закрывается по завершении
        /// </summary>
        public void Show(Action action)
        {
            try
            {
                if (SplashScreenManager.Default == null || !SplashScreenManager.Default.IsSplashFormVisible)
                {
                    SplashScreenManager.ShowForm(ParentForm, typeof(WaitFormView), false, false, false, ParentFormState.Unlocked);
                }

                action.Invoke();
            }
            finally
            {
                CloseWaitForm();
            }
        }

        /// <summary>
        /// Открывает форму-ожидание, выполняет действие и закрывается по завершении
        /// </summary>
        public void Show(Action action, string caption, string description)
        {
            try
            {
                SplashScreenManager.ShowForm(ParentForm, typeof(WaitFormView), false, false, false, ParentFormState.Unlocked);
                SplashScreenManager.Default.SetWaitFormDescription(description);
                SplashScreenManager.Default.SetWaitFormCaption(caption);

                action.Invoke();
            }
            finally
            {
                CloseWaitForm();
            }
        }

        /// <summary>
        /// Открывает форму-ожидание, выполняет асинхронную задачу и закрывается по завершении
        /// </summary>
        public async Task<T> ShowAsync<T>(Task<T> task)
        {
            try
            {
                if (SplashScreenManager.Default == null || !SplashScreenManager.Default.IsSplashFormVisible)
                {
                    SplashScreenManager.ShowForm(ParentForm, typeof(WaitFormView), false, false, false, ParentFormState.Unlocked);
                }

                if (task.Status == TaskStatus.Created)
                {
                    task.Start();
                }

                return await task;
            }
            finally
            {
                CloseWaitForm();
            }
        }

        /// <summary>
        /// Открывает форму-ожидание, выполняет асинхронную задачу и закрывается по завершении
        /// </summary>
        public async Task<T> ShowAsync<T>(Task<T> task, string caption, string description)
        {
            try
            {
                SplashScreenManager.ShowForm(ParentForm, typeof(WaitFormView), false, false, false, ParentFormState.Unlocked);
                SplashScreenManager.Default.SetWaitFormDescription(description);
                SplashScreenManager.Default.SetWaitFormCaption(caption);

                if (task.Status == TaskStatus.Created)
                {
                    task.Start();
                }

                return await task;
            }
            finally
            {
                CloseWaitForm();
            }
        }

        /// <summary>
        /// Открывает форму-ожидание, выполняет асинхронные задачи и закрывается по завершении
        /// </summary>
        public async Task ShowAsync(params Task[] taskArray)
        {
            try
            {
                if (SplashScreenManager.Default == null || !SplashScreenManager.Default.IsSplashFormVisible)
                {
                    SplashScreenManager.ShowForm(ParentForm, typeof(WaitFormView), false, false, false, ParentFormState.Unlocked);
                }

                foreach (var task in taskArray)
                {
                    if (task.Status == TaskStatus.Created)
                    {
                        task.Start();
                    }
                }

                await TaskEx.WhenAll(taskArray);
            }
            finally
            {
                CloseWaitForm();
            }
        }

        /// <summary>
        /// Открывает форму-ожидание, выполняет асинхронные задачи и закрывается по завершении
        /// </summary>
        public async Task ShowAsync(string caption, string description, params Task[] taskArray)
        {
            try
            {
                SplashScreenManager.ShowForm(ParentForm, typeof(WaitFormView), false, false, false, ParentFormState.Unlocked);
                SplashScreenManager.Default.SetWaitFormDescription(description);
                SplashScreenManager.Default.SetWaitFormCaption(caption);

                foreach (var task in taskArray)
                {
                    if (task.Status == TaskStatus.Created)
                    {
                        task.Start();
                    }
                }

                await TaskEx.WhenAll(taskArray);
            }
            finally
            {
                CloseWaitForm();
            }
        }

        /// <summary>
        /// Закрывает форму-ожидание
        /// </summary>
        private void CloseWaitForm()
        {
            if (SplashScreenManager.Default?.IsSplashFormVisible == true)
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        /// <summary>
        /// Создание экземпляра сервиса формы-ожидания
        /// </summary>
        public static IWaitFormService Create(XtraForm parentForm = null)
        {
            return new WaitFormService(parentForm);
        }

        #endregion Методы
    }
}
