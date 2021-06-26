using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

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
