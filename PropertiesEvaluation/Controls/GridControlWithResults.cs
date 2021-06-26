using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using GOLite.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GOLite.Controls
{
    public class GridControlWithResults:GridControl
    {
        #region Свойства
        /// <summary>
        /// Баллы
        /// </summary>
        public ObservableCollection<ScaleScore> ScaleScores { get; set; } = new ObservableCollection<ScaleScore>();
        #endregion

        #region Методы
        public void ParseScores(string scoresString)
        {
            var gv = (GridView)MainView;
            var scoresStringLength = scoresString.Length;
            var qualitiesColumns = gv.Columns.Where(x => x.Tag != null);
            //var qualitiesColumnsCount = 
        }
        #endregion
    }
}
