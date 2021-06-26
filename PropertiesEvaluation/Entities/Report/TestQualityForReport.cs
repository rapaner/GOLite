using System.Collections.ObjectModel;
using System.Linq;

namespace GOLite.Entities
{
    /// <summary>
    /// Качество для отчета
    /// </summary>
    public class TestQualityForReport
    {
        public TestQualityForReport(int testQualityID, string name)
        {
            TestQualityID = testQualityID;
            Name = name;
        }

        /// <summary>
        /// Код качества
        /// </summary>
        public int TestQualityID { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сортировка
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// Место по баллам для пользователя
        /// </summary>
        public int Place { get; set; }

        /// <summary>
        /// Баллы
        /// </summary>
        public ObservableCollection<ScaleScoreForReport> Scores { get; set; } = new ObservableCollection<ScaleScoreForReport>();

        /// <summary>
        /// Сумма баллов
        /// </summary>
        public int Sum => Scores.Select(x => x.MetaScore).Sum();

        /// <summary>
        /// Сумма отрицательных баллов
        /// </summary>
        public int NegativeSum => Scores.Where(x => x.MetaScore < 0).Select(x => x.MetaScore).Sum();

        /// <summary>
        /// Сумма положительных баллов
        /// </summary>
        public int PositiveSum => Scores.Where(x => x.MetaScore > 0).Select(x => x.MetaScore).Sum();

        /// <summary>
        /// Количество нулевых баллов
        /// </summary>
        public int ZeroCount => Scores.Where(x => x.MetaScore == 0).Select(x => x.MetaScore).Count();
    }
}
