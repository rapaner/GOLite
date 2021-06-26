using System.Collections.ObjectModel;

namespace GOLite.Entities
{
    /// <summary>
    /// Шкала для отчета
    /// </summary>
    public class ScaleForReport
    {
        /// <summary>
        /// Код шкалы
        /// </summary>
        public int ScaleID { get; set; }

        /// <summary>
        /// Баллы шкалы
        /// </summary>
        public ObservableCollection<ScaleScoreForReport> Scores { get; set; } = new ObservableCollection<ScaleScoreForReport>();
    }
}