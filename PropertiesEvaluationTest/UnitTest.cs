using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOLite.Common;
using GOLite.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace GOLiteTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void RandomizeTestResults()
        {
            DataSourceProvider.Instance.RandomizeTest(2);
        }

        [TestMethod]
        public void CreateFinalTestResults()
        {
            var testTask = DataSourceProvider.Instance.GetTestAsync(1);
            testTask.Wait();
            var test = testTask.Result;

            var qualitiesTask = DataSourceProvider.Instance.GetQualityGroupsForChooseAsync();
            qualitiesTask.Wait();
            var qualityGroups = qualitiesTask.Result;
            var qualities = new ObservableCollection<Quality>(qualityGroups.SelectMany(x => x.Qualities));

            var scalesTask = DataSourceProvider.Instance.GetScalesAsync();
            scalesTask.Wait();
            var scale = scalesTask.Result.FirstOrDefault(x => x.ScaleID == test.ScaleID);

            ReportCreator.Instance.CreateFinalTestResultsBase("Try.docx", test, qualities, scale);
        }
    }
}
