using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLite.Entities.Messages
{
    /// <summary>
    /// Сообщение с результатами участника
    /// </summary>
    public class GridResultsMessage
    {
        /// <summary>
        /// Строка с результатами
        /// </summary>
        public string ResultsLine { get; set; }
    }
}
