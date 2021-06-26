using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.ReportGeneration;
using DevExpress.XtraReports.UI;
using GOLite.Entities;
using GOLite.Reports;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GOLite.Common
{
    /// <summary>
    /// Создатель отчетов
    /// </summary>
    public class ReportCreator : SingletonBase<ReportCreator>
    {
        /// <summary>
        /// Создание отчета для заполнения
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <param name="test">Тест</param>
        /// <param name="qualities">Качества</param>
        /// <param name="scale">Шкала</param>
        public Task CreateEmptyBlanksForResults(string fileName, Test test, ObservableCollection<Quality> qualities, Scale scale)
        {
            var tcs = new TaskCompletionSource<bool>();
            TaskEx.Run(() =>
            {
                try
                {
                    CreateEmptyBlanksForResultsBase(fileName, test, qualities, scale);
                    tcs.SetResult(true);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Создание отчета для заполнения
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <param name="test">Тест</param>
        /// <param name="qualities">Качества</param>
        /// <param name="scale">Шкала</param>
        private void CreateEmptyBlanksForResultsBase(string fileName, Test test, ObservableCollection<Quality> qualities, Scale scale)
        {
            EmptyBlankForResults report = new EmptyBlankForResults();
            report.xrrtInfo.Text = test.Description;
            string scaleScores = scale.Scores
                .OrderBy(x => x.Sort)
                .Select(x => x.Score.ToString())
                .Aggregate((prev, next) => $"{prev}  \"{next}\"")
                .Trim();
            report.xrlScaleScores.Text = scaleScores;
            ObservableCollection<Quality> qualitiesForReport = new ObservableCollection<Quality>();
            foreach (var tq in test.TestQualities)
            {
                var q = qualities.FirstOrDefault(x => x.QualityID == tq.QualityID);
                qualitiesForReport.Add(new Quality()
                {
                    QualityID = tq.Sort,
                    GoodQuality = q.GoodQuality,
                    BadQuality = q.BadQuality
                });
            }
            QualitiesListReport qualitiesSubReport = new QualitiesListReport();
            qualitiesSubReport.DataSource = qualitiesForReport;
            report.xrQualitiesSubreport.ReportSource = qualitiesSubReport;

            ReportGenerationOptions options = new ReportGenerationOptions();
            options.AutoFitToPageWidth = DevExpress.Utils.DefaultBoolean.True;
            options.EnablePrintAppearanceEvenRow = DevExpress.Utils.DefaultBoolean.False;
            options.EnablePrintAppearanceOddRow = DevExpress.Utils.DefaultBoolean.False;
            options.UsePrintAppearances = DevExpress.Utils.DefaultBoolean.True;
            XtraReport emptyResultsReport = new XtraReport();
            GridControl gc = GridControlCreator.Instance.CreateEmptyGridControl(test.TestUsers, test.TestQualities);
            GridView gv = (GridView)gc.MainView;
            emptyResultsReport = ReportGenerator.GenerateReport(emptyResultsReport, gv);
            report.xrBlankForResults.ReportSource = emptyResultsReport;
            emptyResultsReport.Margins.Bottom = 0;
            emptyResultsReport.Margins.Left = 0;
            emptyResultsReport.Margins.Right = 0;
            emptyResultsReport.Margins.Top = 0;
            var cells = ((XRTable)emptyResultsReport.Bands[1].Controls[0]).Rows[0].Cells;
            for (int i = 1; i < cells.Count; i++)
            {
                cells[i].WidthF = 5;
                cells[i].Font = new System.Drawing.Font("Times New Roman", 8f);
            }
            //cells[0].WidthF = 126;
            //cells[0].Font = new System.Drawing.Font("Tahoma", 8);
            cells = ((XRTable)emptyResultsReport.Bands[2].Controls[0]).Rows[0].Cells;
            for (int i = 1; i < cells.Count; i++)
            {
                cells[i].WidthF = 5;
                cells[i].Font = new System.Drawing.Font("Times New Roman", 8f);
            }

            ((XRTable)emptyResultsReport.Bands[1].Controls[0]).WidthF = 820;
            ((XRTable)emptyResultsReport.Bands[2].Controls[0]).WidthF = 820;
            cells = ((XRTable)emptyResultsReport.Bands[1].Controls[0]).Rows[0].Cells;
            cells[0].Font = new System.Drawing.Font("Times New Roman", 9f);
            cells = ((XRTable)emptyResultsReport.Bands[2].Controls[0]).Rows[0].Cells;
            cells[0].Font = new System.Drawing.Font("Times New Roman", 9f);

            //ReportDesignTool designTool = new ReportDesignTool(report);
            //designTool.ShowDesignerDialog();
            report.ExportToDocx(fileName);
            Process.Start(fileName);
        }

        /// <summary>
        /// Создание отчета для заполнения
        /// </summary>
        /// <param name="test">Тест</param>
        /// <param name="qualities">Качества</param>
        /// <param name="scale">Шкала</param>
        public Task<EmptyBlankForResults> CreateEmptyBlanksForResultsReport(Test test, ObservableCollection<Quality> qualities, Scale scale)
        {
            var tcs = new TaskCompletionSource<EmptyBlankForResults>();
            TaskEx.Run(() =>
            {
                try
                {
                    var report = CreateEmptyBlanksForResultsReportBase(test, qualities, scale);
                    tcs.SetResult(report);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Создание отчета с пустыми результатами
        /// </summary>
        /// <param name="test">Тест</param>
        /// <param name="qualities">Качества</param>
        /// <param name="scale">Шкала</param>
        private EmptyBlankForResults CreateEmptyBlanksForResultsReportBase(Test test, ObservableCollection<Quality> qualities, Scale scale)
        {
            EmptyBlankForResults report = new EmptyBlankForResults();
            report.xrrtInfo.Text = test.Description;
            string scaleScores = scale.Scores
                .OrderBy(x => x.Sort)
                .Select(x => x.Score.ToString())
                .Aggregate((prev, next) => $"{prev}  \"{next}\"")
                .Trim();
            report.xrlScaleScores.Text = scaleScores;
            ObservableCollection<Quality> qualitiesForReport = new ObservableCollection<Quality>();
            foreach (var tq in test.TestQualities)
            {
                var q = qualities.FirstOrDefault(x => x.QualityID == tq.QualityID);
                qualitiesForReport.Add(new Quality()
                {
                    QualityID = tq.Sort,
                    GoodQuality = q.GoodQuality,
                    BadQuality = q.BadQuality
                });
            }
            QualitiesListReport qualitiesSubReport = new QualitiesListReport();
            qualitiesSubReport.DataSource = qualitiesForReport;
            report.xrQualitiesSubreport.ReportSource = qualitiesSubReport;

            ReportGenerationOptions options = new ReportGenerationOptions();
            options.AutoFitToPageWidth = DevExpress.Utils.DefaultBoolean.True;
            options.EnablePrintAppearanceEvenRow = DevExpress.Utils.DefaultBoolean.False;
            options.EnablePrintAppearanceOddRow = DevExpress.Utils.DefaultBoolean.False;
            options.UsePrintAppearances = DevExpress.Utils.DefaultBoolean.True;
            XtraReport emptyResultsReport = new XtraReport();
            GridControl gc = GridControlCreator.Instance.CreateEmptyGridControl(test.TestUsers, test.TestQualities);
            GridView gv = (GridView)gc.MainView;
            emptyResultsReport = ReportGenerator.GenerateReport(emptyResultsReport, gv);
            report.xrBlankForResults.ReportSource = emptyResultsReport;
            emptyResultsReport.Margins.Bottom = 0;
            emptyResultsReport.Margins.Left = 0;
            emptyResultsReport.Margins.Right = 0;
            emptyResultsReport.Margins.Top = 0;
            var cells = ((XRTable)emptyResultsReport.Bands[1].Controls[0]).Rows[0].Cells;
            for (int i = 1; i < cells.Count; i++)
            {
                cells[i].WidthF = 5;
                cells[i].Font = new System.Drawing.Font("Times New Roman", 8f);
            }
            //cells[0].WidthF = 126;
            //cells[0].Font = new System.Drawing.Font("Tahoma", 8);
            cells = ((XRTable)emptyResultsReport.Bands[2].Controls[0]).Rows[0].Cells;
            for (int i = 1; i < cells.Count; i++)
            {
                cells[i].WidthF = 5;
                cells[i].Font = new System.Drawing.Font("Times New Roman", 8f);
            }

            ((XRTable)emptyResultsReport.Bands[1].Controls[0]).WidthF = 820;
            ((XRTable)emptyResultsReport.Bands[2].Controls[0]).WidthF = 820;
            cells = ((XRTable)emptyResultsReport.Bands[1].Controls[0]).Rows[0].Cells;
            cells[0].Font = new System.Drawing.Font("Times New Roman", 9f);
            cells = ((XRTable)emptyResultsReport.Bands[2].Controls[0]).Rows[0].Cells;
            cells[0].Font = new System.Drawing.Font("Times New Roman", 9f);

            return report;
        }

        /// <summary>
        /// Создание отчета итоговых результатов
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <param name="test">Тест</param>
        /// <param name="qualities">Качества</param>
        /// <param name="scale">Шкала</param>
        public Task CreateFinalTestResults(string fileName, Test test, ObservableCollection<Quality> qualities, Scale scale)
        {
            var tcs = new TaskCompletionSource<bool>();
            TaskEx.Run(() =>
            {
                try
                {
                    CreateFinalTestResultsBase(fileName, test, qualities, scale);
                    tcs.SetResult(true);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Создание отчета итоговых результатов
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <param name="test">Тест</param>
        /// <param name="qualities">Качества</param>
        /// <param name="scale">Шкала</param>
        public void CreateFinalTestResultsBase(string fileName, Test test, ObservableCollection<Quality> qualities, Scale scale)
        {
            //  Создаем новую шкалу
            ScaleForReport scaleForReport = new ScaleForReport()
            {
                ScaleID = scale.ScaleID
            };
            int mediumSort = scale.Scores.Where(x => x.ScaleScoreID != 0).OrderBy(x => x.Sort).ToList()[scale.Scores.Where(x => x.ScaleScoreID != 0).Count() / 2].Sort;

            foreach (var score in scale.Scores.Where(x => x.ScaleScoreID != 0).OrderBy(x => x.Sort))
            {
                scaleForReport.Scores.Add(new ScaleScoreForReport(score.ScaleScoreID, score.Score.Value, mediumSort - score.Sort));
            }

            int place = 1;

            //  Создаем пользователей
            ObservableCollection<UserForReport> users = new ObservableCollection<UserForReport>();
            foreach (var u in test.UsersWithResults)
            {
                var user = new UserForReport()
                {
                    UserID = test.TestUsers.FirstOrDefault(x => x.TestUserID == u.TestUserID).UserID,
                    UserName = u.UserName,
                    Sort = u.Sort,
                    Qualities = new ObservableCollection<TestQualityForReport>(test.TestQualities.Select(x => new TestQualityForReport(x.TestQualityID, qualities.FirstOrDefault(q => q.QualityID == x.QualityID).QualityForDisplay)
                    {
                        Sort = x.Sort
                    }
                    ))
                };
                users.Add(user);

                var userTestResults = test.UsersWithResults.SelectMany(x => x.TestResults).Where(x => x.UserID == user.UserID).ToList();
                foreach (var utr in userTestResults)
                {
                    var quality = user.Qualities.FirstOrDefault(x => x.TestQualityID == utr.TestQualityID);
                    quality.Scores.Add(scaleForReport.Scores.FirstOrDefault(s => s.ScaleScoreID == utr.ScaleScoreID));
                }

                user.Qualities = new ObservableCollection<TestQualityForReport>(user.Qualities.OrderByDescending(x => x.Sum));
            }

            foreach (var q in test.TestQualities)
            {
                var qualitiesForSort = users
                    .SelectMany(x => x.Qualities)
                    .Where(x => x.TestQualityID == q.TestQualityID)
                    .OrderByDescending(x => x.Sum).ToList();
                place = 1;
                int previousSum = 0;
                for (int counter = 1; counter <= qualitiesForSort.Count; counter++)
                {
                    var currentQuality = qualitiesForSort[counter - 1];
                    if (counter == 1)
                    {
                        currentQuality.Place = place;
                        previousSum = currentQuality.Sum;
                    }
                    else
                    {
                        if (currentQuality.Sum == previousSum)
                        {
                            currentQuality.Place = place;
                        }
                        else
                        {
                            currentQuality.Place = counter;
                            place = counter;
                            previousSum = currentQuality.Sum;
                        }
                    }
                }
            }

            place = 1;
            foreach (var u in users.OrderByDescending(u => u.Sum))
            {
                u.PlaceInList = place;
                place++;
            }

            users = new ObservableCollection<UserForReport>(users.OrderBy(x => x.PlaceInList));

            UserFinalResults report = new UserFinalResults();
            report.DataSource = users;
            report.CreateDocument();

            #region Создание новых пользователей с результатами, которые содержат оценку самого пользователя, а не как оценивал он

            ObservableCollection<UserWithTestResults> usersWithResults = new ObservableCollection<UserWithTestResults>();
            foreach (var tu in test.TestUsers.OrderBy(x => x.Sort))
            {
                var newUser = new UserWithTestResults(tu.TestUserID, tu.UserName, tu.Sort);
                foreach (var uwr in test.UsersWithResults)
                {
                    var results = uwr.TestResults.Where(x => x.UserID == tu.UserID);
                    foreach (var r in results)
                    {
                        newUser.TestResults.Add(new TestResult(r.TestResultID, r.ScaleScoreID, r.TestQualityID, test.TestUsers.FirstOrDefault(x => x.TestUserID == uwr.TestUserID).UserID));
                    }
                }
                usersWithResults.Add(newUser);
            }

            #endregion Создание новых пользователей с результатами, которые содержат оценку самого пользователя, а не как оценивал он

            //foreach (var uwr in test.UsersWithResults)
            int count = 1;
            foreach (var uwr in usersWithResults)
            {
                var gc = GridControlCreator.Instance.CreateTestResultsGridControl(uwr, test, scale.Scores);
                GridView gv = (GridView)gc.MainView;
                XtraReport resultsReport = new XtraReport();
                resultsReport = ReportGenerator.GenerateReport(resultsReport, gv);
                resultsReport.Margins.Bottom = 0;
                resultsReport.Margins.Left = 0;
                resultsReport.Margins.Right = 0;
                resultsReport.Margins.Top = 0;

                UserTestResults subReport = new UserTestResults();
                subReport.xrResults.ReportSource = resultsReport;
                subReport.xrTitle.Text = $"{uwr.UserName}, оценки";

                var cells = ((XRTable)resultsReport.Bands[1].Controls[0]).Rows[0].Cells;
                for (int i = 1; i < cells.Count; i++)
                {
                    cells[i].WidthF = 5;
                    cells[i].Font = new System.Drawing.Font("Tahoma", 8f);
                }
                //cells[0].WidthF = 126;
                //cells[0].Font = new System.Drawing.Font("Tahoma", 8);
                cells = ((XRTable)resultsReport.Bands[2].Controls[0]).Rows[0].Cells;
                for (int i = 1; i < cells.Count; i++)
                {
                    cells[i].WidthF = 5;
                    cells[i].Font = new System.Drawing.Font("Tahoma", 8f);
                }

        ((XRTable)resultsReport.Bands[1].Controls[0]).WidthF = 820;
                ((XRTable)resultsReport.Bands[2].Controls[0]).WidthF = 820;
                cells = ((XRTable)resultsReport.Bands[1].Controls[0]).Rows[0].Cells;
                cells[0].Font = new System.Drawing.Font("Tahoma", 9f);
                cells = ((XRTable)resultsReport.Bands[2].Controls[0]).Rows[0].Cells;
                cells[0].Font = new System.Drawing.Font("Tahoma", 9f);

                subReport.CreateDocument();
                //report.ModifyDocument(x => x.AddPages(subReport.Pages));
                report.ModifyDocument(x => x.InsertPage((count * 2) - 1, subReport.Pages[0]));
                count++;
            }

            report.ExportToDocx(fileName);
            Process.Start(fileName);
        }
    }
}