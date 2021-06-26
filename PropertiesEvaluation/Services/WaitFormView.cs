using DevExpress.XtraWaitForm;

namespace GOLite.Services
{
    /// <summary>
    /// Форма-ожидание для долгоработающих процессов
    /// </summary>
    public partial class WaitFormView : WaitForm
    {
        #region Конструктор

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public WaitFormView()
        {
            InitializeComponent();
        }

        #endregion Конструктор

        #region Методы

        /// <summary>
        /// Установка действия формы
        /// </summary>
        public override void SetDescription(string description)
        {
            base.SetDescription(description);

            progressPanel1.Description = description;
        }

        /// <summary>
        /// Установка заголовка формы
        /// </summary>
        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);

            progressPanel1.Caption = caption;
        }

        #endregion Методы
    }
}