using DevExpress.Mvvm;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using GOLite.Entities;
using GOLite.Entities.Messages;
using GOLite.ViewModels;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GOLite.Common
{
    public class GridControlCreator : SingletonBase<GridControlCreator>
    {
        /// <summary>
        /// Создание GridControl для заведения результатов теста
        /// </summary>
        /// <param name="viewModel">ViewModel</param>
        public GridControl CreateTestResultsGridControl(TestEditViewModel viewModel)
        {
            UserWithTestResults user = viewModel.CurrentUserWithResults;
            ObservableCollection<TestUser> testUsers = viewModel.Model.Test.TestUsers;
            ObservableCollection<ScaleScore> scaleScores = viewModel.Scales.FirstOrDefault(x => x.ScaleID == viewModel.Model.Test.ScaleID)?.Scores;
            ObservableCollection<TestQuality> qualities = viewModel.Model.Test.TestQualities;

            if (user is null
                || testUsers is null
                || scaleScores is null
                || qualities is null)
                return null;

            BindingSource bsUsers = new BindingSource()
            {
                DataSource = testUsers
            };
            RepositoryItemLookUpEdit rilueUsers = new RepositoryItemLookUpEdit()
            {
                DataSource = bsUsers,
                DisplayMember = "UserName",
                ValueMember = "UserID"
            };

            BindingSource bsScaleScores = new BindingSource()
            {
                DataSource = scaleScores
            };
            RepositoryItemLookUpEdit rilueScaleScores = new RepositoryItemLookUpEdit()
            {
                DataSource = bsScaleScores,
                DisplayMember = "Score",
                ValueMember = "ScaleScoreID",
                ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
            };
            rilueScaleScores.Columns.Clear();
            rilueScaleScores.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Score", "Балл"));

            DataTable dt = new DataTable("TestResults");
            dt.Columns.Add(new DataColumn("UserID", typeof(int)));

            foreach (var q in qualities)
            {
                dt.Columns.Add(new DataColumn($"TestQuality{q.Sort}", typeof(int)));
            }

            foreach (var tu in testUsers.OrderBy(x => x.Sort))
            {
                var dr = dt.NewRow();
                dr["UserID"] = tu.UserID;

                foreach (var q in qualities)
                {
                    var testResult = user.TestResults.FirstOrDefault(x => x.TestQualityID == q.TestQualityID && x.UserID == tu.UserID);
                    if (testResult is null)
                    {
                        dr[$"TestQuality{q.Sort}"] = 0;
                    }
                    else
                    {
                        dr[$"TestQuality{q.Sort}"] = testResult.ScaleScoreID;
                    }
                }
                dt.Rows.Add(dr);
            }

            GridView gv = new GridView();
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsView.ColumnAutoWidth = false;
            gv.OptionsCustomization.AllowGroup = false;
            gv.OptionsCustomization.AllowSort = false;
            gv.Columns.Clear();
            GridColumn colTestUserID = new GridColumn()
            {
                Caption = "ФИО участника",
                FieldName = "UserID",
                ColumnEdit = rilueUsers,
                Visible = true,
                Width = 100
            };
            colTestUserID.OptionsColumn.ReadOnly = true;
            colTestUserID.OptionsColumn.AllowEdit = false;
            gv.Columns.Add(colTestUserID);

            foreach (var q in qualities)
            {
                GridColumn col = new GridColumn()
                {
                    Caption = q.Sort.ToString(),
                    FieldName = $"TestQuality{q.Sort}",
                    ColumnEdit = rilueScaleScores,
                    Visible = true,
                    Tag = q.TestQualityID,
                    Width = 38
                };
                gv.Columns.Add(col);
            }

            GridControl gc = new GridControl();
            gc.Dock = DockStyle.Fill;
            gv.GridControl = gc;
            gc.ViewCollection.Add(gv);
            gc.MainView = gv;

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            gc.DataSource = bs;

            gv.CellValueChanged += (o, e) =>
            {
                if (e.Column == colTestUserID)
                    return;
                int testQualityID = (int)e.Column.Tag;
                int userID = (int)dt.Rows[e.RowHandle]["UserID"];
                var testResult = user.TestResults.FirstOrDefault(x => x.UserID == userID && x.TestQualityID == testQualityID);
                if (testResult is null)
                    return;
                testResult.ScaleScoreID = (int)e.Value;

                try
                {
                    int tag = (int)e.Column.Tag;
                    if (tag < qualities.Count)
                    {
                        var columns = gv.Columns.Where(x => x.Tag != null);
                        gv.FocusedColumn = columns.FirstOrDefault(x => (int)x.Tag == tag + 1);
                    }
                }
                catch { }
            };

            gc.HandleDestroyed += (o, e) =>
              {
                  try
                  {
                      Messenger.Default.Unregister(gv);
                  }
                  catch { }
              };

            gv.CustomDrawCell += (o, e) =>
              {
                  if (e.Column.Tag != null && e.Column.Tag is int)
                  {
                      int colNum = (int)e.Column.Tag;
                      if (colNum % 5 == 0)
                      {
                          GridCellDrawing.DoDefaultDrawCell(gv, e);
                          GridCellDrawing.DrawCellBorder(e);
                          e.Handled = true;
                      }
                  }
              };

            Messenger.Default.Register<GridResultsMessage>(gv, "ResultsGrid", (grm) =>
            {
                try
                {
                    if (dt.Rows.Count == 0)
                        return;
                    if (!user.TestResults.Any())
                        return;
                    if (string.IsNullOrWhiteSpace(grm.ResultsLine))
                        return;
                    var rowHandle = gv.FocusedRowHandle;
                    int userID = (int)dt.Rows[rowHandle]["UserID"];
                    var testResults = user.TestResults
                        .Where(x => x.UserID == userID)
                        .ToList();
                    for (int counter = 0; counter < grm.ResultsLine.Length; counter++)
                    {
                        if (counter >= testResults.Count)
                        {
                            gv.RefreshRow(rowHandle);
                            if (gv.RowCount > rowHandle + 1)
                                gv.FocusedRowHandle = rowHandle + 1;
                            return;
                        }
                        var charElement = $"{grm.ResultsLine[counter]}";
                        if (int.TryParse(charElement, out int value))
                        {
                            var scaleScore = scaleScores.FirstOrDefault(x => x.Score == value);
                            if (scaleScore != null)
                            {
                                testResults[counter].ScaleScoreID = scaleScore.ScaleScoreID;
                                dt.Rows[rowHandle][counter + 1] = scaleScore.ScaleScoreID;
                            }
                        }
                    }
                    gv.RefreshRow(rowHandle);
                    if (gv.RowCount > rowHandle + 1)
                        gv.FocusedRowHandle = rowHandle + 1;
                }
                catch { }
            });

            return gc;
        }

        public GridControl CreateTestResultsGridControl(UserWithTestResults user, Test test, ObservableCollection<ScaleScore> scaleScores)
        {
            ObservableCollection<TestUser> testUsers = test.TestUsers;
            ObservableCollection<TestQuality> qualities = test.TestQualities;

            if (user is null
                || testUsers is null
                || scaleScores is null
                || qualities is null)
                return null;

            BindingSource bsScaleScores = new BindingSource()
            {
                DataSource = scaleScores
            };
            RepositoryItemLookUpEdit rilueScaleScores = new RepositoryItemLookUpEdit()
            {
                DataSource = bsScaleScores,
                DisplayMember = "Score",
                ValueMember = "ScaleScoreID"
            };
            rilueScaleScores.Columns.Clear();
            rilueScaleScores.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Score", "Балл"));

            DataTable dt = new DataTable("TestResults");
            dt.Columns.Add(new DataColumn("CodeName", typeof(string)));

            foreach (var q in qualities)
            {
                dt.Columns.Add(new DataColumn($"TestQuality{q.Sort}", typeof(int)));
            }

            foreach (var tu in testUsers)
            {
                var dr = dt.NewRow();
                dr["CodeName"] = tu.CodeName;

                foreach (var q in qualities)
                {
                    var testResult = user.TestResults.FirstOrDefault(x => x.TestQualityID == q.TestQualityID && x.UserID == tu.UserID);
                    if (testResult is null)
                    {
                        dr[$"TestQuality{q.Sort}"] = 0;
                    }
                    else
                    {
                        //dr[$"TestQuality{q.Sort}"] = testResult.ScaleScoreID;
                        dr[$"TestQuality{q.Sort}"] = scaleScores.FirstOrDefault(x => x.ScaleScoreID == testResult.ScaleScoreID).Score;
                    }
                }
                dt.Rows.Add(dr);
            }

            GridView gv = new GridView();
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsView.ColumnAutoWidth = false;
            gv.Columns.Clear();
            GridColumn colTestUserID = new GridColumn()
            {
                Caption = "Участник",
                FieldName = "CodeName",
                Visible = true
            };
            colTestUserID.OptionsColumn.ReadOnly = true;
            colTestUserID.OptionsColumn.AllowEdit = false;
            gv.Columns.Add(colTestUserID);

            foreach (var q in qualities)
            {
                GridColumn col = new GridColumn()
                {
                    Caption = q.Sort.ToString(),
                    FieldName = $"TestQuality{q.Sort}",
                    ColumnEdit = rilueScaleScores,
                    Visible = true,
                    Tag = q.TestQualityID,
                    Width = 38
                };
                gv.Columns.Add(col);
            }

            GridControl gc = new GridControl();
            gc.Dock = DockStyle.Fill;
            gv.GridControl = gc;
            gc.ViewCollection.Add(gv);
            gc.MainView = gv;

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            gc.DataSource = bs;

            gv.CellValueChanged += (o, e) =>
            {
                if (e.Column == colTestUserID)
                    return;
                int testQualityID = (int)e.Column.Tag;
                int userID = (int)dt.Rows[e.RowHandle]["UserID"];
                var testResult = user.TestResults.FirstOrDefault(x => x.UserID == userID && x.TestQualityID == testQualityID);
                if (testResult is null)
                    return;
                testResult.ScaleScoreID = (int)e.Value;
            };

            return gc;
        }

        /// <summary>
        /// Создание GridControl для заведения результатов теста
        /// </summary>
        /// <param name="viewModel">ViewModel</param>
        public GridControl CreateEmptyGridControl(ObservableCollection<TestUser> testUsers, ObservableCollection<TestQuality> qualities)
        {
            if (testUsers is null
                || qualities is null)
                return null;

            DataTable dt = new DataTable("TestResults");
            dt.Columns.Add(new DataColumn("UserName", typeof(string)));

            foreach (var q in qualities)
            {
                dt.Columns.Add(new DataColumn($"TestQuality{q.Sort}", typeof(string)));
            }

            foreach (var tu in testUsers)
            {
                var dr = dt.NewRow();
                dr["UserName"] = tu.UserName;

                foreach (var q in qualities)
                {
                    dr[$"TestQuality{q.Sort}"] = "   ";
                }
                dt.Rows.Add(dr);
            }

            GridView gv = new GridView();
            gv.OptionsView.ShowGroupPanel = false;
            gv.Columns.Clear();
            GridColumn colTestUserID = new GridColumn()
            {
                Caption = "Участник",
                FieldName = "UserName",
                Visible = true,
                Width = 100
            };
            colTestUserID.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            colTestUserID.OptionsColumn.ReadOnly = true;
            colTestUserID.OptionsColumn.AllowEdit = false;
            gv.Columns.Add(colTestUserID);

            foreach (var q in qualities)
            {
                GridColumn col = new GridColumn()
                {
                    Caption = q.Sort.ToString(),
                    FieldName = $"TestQuality{q.Sort}",
                    Visible = true,
                    Tag = q.TestQualityID,
                    Width = 38
                };
                gv.Columns.Add(col);
            }

            GridControl gc = new GridControl();
            gc.Dock = DockStyle.Fill;
            gv.GridControl = gc;
            gc.ViewCollection.Add(gv);
            gc.MainView = gv;

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            gc.DataSource = bs;

            return gc;
        }
    }
}