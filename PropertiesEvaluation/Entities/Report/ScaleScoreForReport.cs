namespace GOLite.Entities
{
    /// <summary>
    /// Оценка шкалы для отчета
    /// </summary>
    public class ScaleScoreForReport
    {
        public ScaleScoreForReport(int scaleScoreID, int score, int metaScore)
        {
            ScaleScoreID = scaleScoreID;
            Score = score;
            MetaScore = metaScore;
        }

        /// <summary>
        /// Код балла шкалы
        /// </summary>
        public int ScaleScoreID { get; set; }

        /// <summary>
        /// Балл
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Мета-балл (для расчета итогов)
        /// </summary>
        public int MetaScore { get; set; }
    }
}