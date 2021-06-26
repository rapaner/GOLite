using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLite.Entities
{
    /// <summary>
    /// Тест базовый
    /// </summary>
    public class TestBase
    {
        public TestBase()
        {
            DateCreated = DateTime.Now;
        }

        public TestBase(int testID, string testName, int scaleID, DateTime dateCreated)
        {
            TestID = testID;
            TestName = testName;
            ScaleID = scaleID;
            DateCreated = dateCreated;
        }

        /// <summary>
        /// Код теста
        /// </summary>
        public int TestID { get; set; }

        /// <summary>
        /// Название теста
        /// </summary>
        public string TestName { get; set; }

        /// <summary>
        /// Код шкалы
        /// </summary>
        public int ScaleID { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreated { get; set; }

    }
}
