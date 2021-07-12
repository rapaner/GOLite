using DbLinq.Sqlite;
using GOLite.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GOLite.Common
{
    public class DataSourceProvider : SingletonBase<DataSourceProvider>
    {
        #region Свойства

        /// <summary>
        /// Строка подключения
        /// </summary>
        private string DataBaseFile { get; } = @"C:\LocalDBs\GOLite_v2.db3";

        #endregion Свойства

        #region Методы

        #region База данных

        /// <summary>
        /// Создать базу данных
        /// </summary>
        public void CreateDataBase()
        {
            if (File.Exists(DataBaseFile))
            {
                return;
            }
            else
            {
                if (!Directory.Exists(@"C:\LocalDBs\"))
                    Directory.CreateDirectory(@"C:\LocalDBs\");
                SQLiteConnection.CreateFile(DataBaseFile);
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"CREATE TABLE [Users] (
                            [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                            [UserName] text NOT NULL
                        );";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        command.CommandText = @"CREATE TABLE [Scales] (
                            [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                            [Name] text NOT NULL
                        );";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        command.CommandText = @"CREATE TABLE [ScaleScores] (
                            [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                            [ScaleID] integer NOT NULL,
                            [Score] integer NOT NULL,
                            [Sort] integer NOT NULL,
                            FOREIGN KEY(ScaleID) REFERENCES Scales(ID)
                        );";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        command.CommandText = @"CREATE TABLE [QualityGroups] (
                            [ID]    INTEGER NOT NULL,
	                        [Name]  TEXT NOT NULL,
	                        PRIMARY KEY([ID] AUTOINCREMENT)
                        )";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        command.CommandText = @"CREATE TABLE [Qualities] (
                            [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                            [GoodQuality] text NOT NULL,
                            [BadQuality] text NOT NULL,
	                        [QualityGroupID]    INTEGER NOT NULL DEFAULT 1,
                            [Sort] integer NOT NULL
                        );";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        command.CommandText = @"CREATE TABLE [Tests] (
                            [ID]    integer NOT NULL,
	                        [ScaleID]   integer NOT NULL,
	                        [TestName]  text NOT NULL,
	                        [DateCreated]   text NOT NULL,
	                        [Description]   TEXT,
	                        [QualityGroupID]    INTEGER NOT NULL DEFAULT 1,
	                        FOREIGN KEY([ScaleID]) REFERENCES Scales(ID),
	                        FOREIGN KEY([QualityGroupID]) REFERENCES QualityGroups(ID),
	                        PRIMARY KEY([ID] AUTOINCREMENT)
                        ); ";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        command.CommandText = @"CREATE TABLE [TestUsers] (
                            [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                            [TestID] integer NOT NULL,
                            [UserID] integer NOT NULL,
                            [Sort] integer NOT NULL,
                            FOREIGN KEY(TestID) REFERENCES Tests(ID),
                            FOREIGN KEY(UserID) REFERENCES Users(ID)
                        );";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        command.CommandText = @"CREATE TABLE [TestQualities] (
                            [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                            [QualityID] integer NOT NULL,
                            [TestID] integer NOT NULL,
                            [Sort] integer NOT NULL,
                            FOREIGN KEY(TestID) REFERENCES Tests(ID),
                            FOREIGN KEY(QualityID) REFERENCES Qualities(ID)
                        );";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        command.CommandText = @"CREATE TABLE [TestResults] (
                            [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                            [TestID] integer NOT NULL REFERENCES Tests(ID),
                            [TestUserID] integer NOT NULL REFERENCES TestUsers(ID),
                            [UserID] integer NOT NULL REFERENCES Users(ID),
                            [TestQualityID] integer NOT NULL REFERENCES TestQualities(ID),
                            [ScaleScoreID] integer NOT NULL REFERENCES ScaleScores(ID)
                        );";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        #endregion База данных

        #region Качества

        /// <summary>
        /// Получить список групп качеств
        /// </summary>
        public Task<ObservableCollection<QualityGroup>> GetQualityGroupsAsync()
        {
            var tcs = new TaskCompletionSource<ObservableCollection<QualityGroup>>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = GetQualityGroups();
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Получить список групп качеств
        /// </summary>
        private ObservableCollection<QualityGroup> GetQualityGroups()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var qualityGroupsDB = context.QualityGroups.ToList();
                        return new ObservableCollection<QualityGroup>(qualityGroupsDB.Select(x => new QualityGroup(x.ID, x.Name)
                        {
                            HasTests = x.Tests.Any(),
                            Qualities = new ObservableCollection<Quality>(x.Qualities.Select(y => new Quality(y.ID, y.GoodQuality, y.BadQuality, y.Sort)
                            {
                                HasTests = y.TestQualities.Any()
                            }))
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Группы качеств не получены!", ex);
            }
        }

        /// <summary>
        /// Сохранить список групп качеств
        /// </summary>
        /// <param name="qualityGroups">Группа качеств</param>
        public Task<bool> SaveQualityGroupsAsync(ObservableCollection<QualityGroup> qualityGroups)
        {
            var tcs = new TaskCompletionSource<bool>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = SaveQualityGroups(qualityGroups);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Сохранить список групп качеств
        /// </summary>
        /// <param name="qualityGroups">Группа качеств</param>
        private bool SaveQualityGroups(ObservableCollection<QualityGroup> qualityGroups)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var qualityGroupsDB = context.QualityGroups.ToList();
                        var qualityGroupsForDelete = (from qgDB in qualityGroupsDB
                                                      join qg in qualityGroups
                                                      on qgDB.ID equals qg.QualityGroupID
                                                      where qg.ForDelete
                                                      select qgDB).ToList();
                        var qualitiesForDelete = qualityGroupsForDelete.SelectMany(x => x.Qualities);
                        context.Qualities.DeleteAllOnSubmit(qualitiesForDelete);
                        context.SubmitChanges();
                        context.QualityGroups.DeleteAllOnSubmit(qualityGroupsForDelete);
                        context.SubmitChanges();

                        var qualityGroupsForUpdate = (from qgDB in qualityGroupsDB
                                                      join qg in qualityGroups
                                                      on qgDB.ID equals qg.QualityGroupID
                                                      where qg.IsChanged
                                                      select qgDB).ToList();
                        foreach (var qgDB in qualityGroupsForUpdate)
                        {
                            var s = qualityGroups.FirstOrDefault(x => x.QualityGroupID == qgDB.ID);
                            qgDB.Name = s.Name?.Trim();

                            qualitiesForDelete = (from qDB in context.Qualities.ToList()
                                                  join q in s.Qualities
                                                  on qDB.ID equals q.QualityID
                                                  where q.ForDelete
                                                  select qDB).ToList();
                            context.Qualities.DeleteAllOnSubmit(qualitiesForDelete);
                            context.SubmitChanges();

                            if (qualitiesForDelete.Any())
                            {
                                //  Изменение сортировки неудаленных элементов
                                int sort = 1;
                                var qualitiesForResort = s.Qualities.Where(x => !x.ForDelete);
                                foreach (var q in qualitiesForResort)
                                {
                                    q.Sort = sort;
                                    sort++;
                                }
                            }

                            var qualitiesForUpdate = (from qDB in qgDB.Qualities
                                                      join q in s.Qualities
                                                      on qDB.ID equals q.QualityID
                                                      where q.IsChanged
                                                      select qDB).ToList();
                            foreach (var qDB in qualitiesForUpdate)
                            {
                                var q = s.Qualities.FirstOrDefault(x => x.QualityID == qDB.ID);
                                qDB.BadQuality = q.BadQuality;
                                qDB.GoodQuality = q.GoodQuality;
                                qDB.Sort = q.Sort;
                            }
                            context.SubmitChanges();

                            var qualitiesForInsert = s.Qualities.Where(x => x.QualityID == 0 && !x.ForDelete).ToList();
                            context.Qualities.InsertAllOnSubmit(qualitiesForInsert.Select(x => new Qualities() { QualityGroupID = qgDB.ID, GoodQuality = x.GoodQuality, BadQuality = x.BadQuality, Sort = x.Sort }));
                            context.SubmitChanges();
                        }

                        var qualityGroupsForInsert = qualityGroups.Where(x => x.QualityGroupID == 0 && !x.ForDelete).ToList();
                        foreach (var qg in qualityGroupsForInsert)
                        {
                            QualityGroups qgDB = new QualityGroups()
                            {
                                Name = qg.Name?.Trim()
                            };
                            context.QualityGroups.InsertOnSubmit(qgDB);
                            context.SubmitChanges();

                            context.Qualities.InsertAllOnSubmit(qg.Qualities.Where(x => !x.ForDelete).Select(x => new Qualities()
                            {
                                QualityGroupID = qgDB.ID,
                                GoodQuality = x.GoodQuality,
                                BadQuality = x.BadQuality,
                                Sort = x.Sort
                            }));
                            var changes = context.GetChangeSet();
                            context.SubmitChanges();
                        }

                        context.SubmitChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Группы качеств не сохранены!", ex);
            }
        }

        /// <summary>
        /// Получить список групп качеств для выбора
        /// </summary>
        public Task<ObservableCollection<QualityGroup>> GetQualityGroupsForChooseAsync()
        {
            var tcs = new TaskCompletionSource<ObservableCollection<QualityGroup>>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = GetQualityGroupsForChoose();
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Получить список групп качеств для выбора
        /// </summary>
        private ObservableCollection<QualityGroup> GetQualityGroupsForChoose()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var qualityGroupsDB = context.QualityGroups.ToList();
                        var qualityGroups = new List<QualityGroup>()
                    {
                        new QualityGroup(0, "(не выбрана)")
                    };
                        qualityGroups.AddRange(qualityGroupsDB.Select(x => new QualityGroup(x.ID, x.Name)
                        {
                            HasTests = x.Tests.Any(),
                            Qualities = new ObservableCollection<Quality>(x.Qualities.Select(y => new Quality(y.ID, y.GoodQuality, y.BadQuality, y.Sort)
                            {
                                HasTests = y.TestQualities.Any()
                            }))
                        }));
                        return new ObservableCollection<QualityGroup>(qualityGroups);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Группы качеств не получены!", ex);
            }
        }

        #endregion Качества

        #region Шкалы

        /// <summary>
        /// Получить список шкал
        /// </summary>
        public Task<ObservableCollection<Scale>> GetScalesAsync()
        {
            var tcs = new TaskCompletionSource<ObservableCollection<Scale>>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = GetScales();
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Получить список шкал
        /// </summary>
        private ObservableCollection<Scale> GetScales()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var scalesDB = context.Scales.ToList();
                        return new ObservableCollection<Scale>(scalesDB.Select(x => new Scale(x.ID, x.Name)
                        {
                            HasTests = x.Tests.Any(),
                            Scores = new ObservableCollection<ScaleScore>(x.ScaleScores.Select(y => new ScaleScore(y.ID, y.Score, y.Sort)
                            {
                                HasTestResults = y.TestResults.ToList().Any()
                            }).ToList())
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Шкалы не получены!", ex);
            }
        }

        /// <summary>
        /// Сохранить шкалы
        /// </summary>
        /// <param name="scales">Шкалы</param>
        public Task<bool> SaveScalesAsync(ObservableCollection<Scale> scales)
        {
            var tcs = new TaskCompletionSource<bool>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = SaveScales(scales);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Сохранить шкалы
        /// </summary>
        /// <param name="scales">Шкалы</param>
        private bool SaveScales(ObservableCollection<Scale> scales)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var scalesDB = context.Scales.ToList();
                        var scalesForDelete = (from sDB in scalesDB
                                               join s in scales
                                               on sDB.ID equals s.ScaleID
                                               where s.ForDelete
                                               select sDB).ToList();
                        var scaleScoresForDelete = scalesForDelete.SelectMany(x => x.ScaleScores);
                        context.ScaleScores.DeleteAllOnSubmit(scaleScoresForDelete);
                        context.SubmitChanges();
                        context.Scales.DeleteAllOnSubmit(scalesForDelete);

                        var scalesForUpdate = (from sDB in scalesDB
                                               join s in scales
                                               on sDB.ID equals s.ScaleID
                                               where s.IsChanged
                                               select sDB).ToList();
                        foreach (var sDB in scalesForUpdate)
                        {
                            var s = scales.FirstOrDefault(x => x.ScaleID == sDB.ID);
                            sDB.Name = s.Name?.Trim();

                            var scoresForDelete = (from scDB in sDB.ScaleScores
                                                   join sc in s.Scores
                                                   on scDB.ID equals sc.ScaleScoreID
                                                   where sc.ForDelete
                                                   select scDB).ToList();
                            foreach (var ss in scoresForDelete)
                            {
                                context.ExecuteCommandRaw($"DELETE FROM ScaleScores WHERE ID = {ss.ID}");
                            }
                            context.SubmitChanges();

                            if (scoresForDelete.Any())
                            {
                                //  Изменение сортировки неудаленных элементов
                                int sort = 1;
                                var scoresForResort = s.Scores.Where(x => !x.ForDelete);
                                foreach (var sc in scoresForResort)
                                {
                                    sc.Sort = sort;
                                    sort++;
                                }
                            }

                            var scoresForUpdate = (from scDB in sDB.ScaleScores
                                                   join sc in s.Scores
                                                   on scDB.ID equals sc.ScaleScoreID
                                                   where sc.IsChanged
                                                   select scDB).ToList();
                            foreach (var scDB in scoresForUpdate)
                            {
                                var sc = s.Scores.FirstOrDefault(x => x.ScaleScoreID == scDB.ID);
                                scDB.Score = sc.Score.Value;
                                scDB.Sort = sc.Sort;
                            }
                            context.SubmitChanges();

                            var scoresForInsert = s.Scores.Where(x => x.ScaleScoreID == 0 && !x.ForDelete).ToList();
                            context.ScaleScores.InsertAllOnSubmit(scoresForInsert.Select(x => new ScaleScores() { ScaleID = sDB.ID, Score = x.Score.Value, Sort = x.Sort }));
                            context.SubmitChanges();
                        }

                        var scalesForInsert = scales.Where(x => x.ScaleID == 0 && !x.ForDelete).ToList();
                        foreach (var s in scalesForInsert)
                        {
                            Scales sDB = new Scales()
                            {
                                Name = s.Name?.Trim()
                            };
                            context.Scales.InsertOnSubmit(sDB);
                            context.SubmitChanges();

                            context.ScaleScores.InsertAllOnSubmit(s.Scores.Where(x => !x.ForDelete).Select(x => new ScaleScores()
                            {
                                ScaleID = sDB.ID,
                                Score = x.Score.Value,
                                Sort = x.Sort
                            }));
                            var changes = context.GetChangeSet();
                            context.SubmitChanges();
                        }

                        context.SubmitChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Шкалы не сохранены!", ex);
            }
        }

        /// <summary>
        /// Получить список шкал
        /// </summary>
        public Task<ObservableCollection<Scale>> GetScalesForChooseAsync()
        {
            var tcs = new TaskCompletionSource<ObservableCollection<Scale>>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = GetScalesForChoose();
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Получить список шкал
        /// </summary>
        private ObservableCollection<Scale> GetScalesForChoose()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var scalesDB = context.Scales.ToList();
                        var scales = new List<Scale>()
                    {
                        new Scale(0, "(не выбрана)")
                    };
                        foreach (var sDB in scalesDB)
                        {
                            var s = new Scale(sDB.ID, sDB.Name)
                            {
                                HasTests = sDB.Tests.Any(),
                            };
                            List<ScaleScore> scores = new List<ScaleScore>()
                        {
                            new ScaleScore()
                        };
                            scores.AddRange(sDB.ScaleScores.Select(y => new ScaleScore(y.ID, y.Score, y.Sort)
                            {
                                HasTestResults = y.TestResults.ToList().Any()
                            }));

                            s.Scores = new ObservableCollection<ScaleScore>(scores);
                            scales.Add(s);
                        }
                        return new ObservableCollection<Scale>(scales);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Шкалы не получены!", ex);
            }
        }

        #endregion Шкалы

        #region Участники

        /// <summary>
        /// Получить список всех участников
        /// </summary>
        public Task<ObservableCollection<User>> GetUsersAsync()
        {
            var tcs = new TaskCompletionSource<ObservableCollection<User>>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = GetUsers();
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Получить список всех участников
        /// </summary>
        private ObservableCollection<User> GetUsers()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var usersDB = context.Users.ToList();
                        return new ObservableCollection<User>(usersDB.Select(x => new User(x.ID, x.UserName)
                        {
                            HasTests = x.TestResults.Any() || x.TestUsers.Any()
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Участники не получены!", ex);
            }
        }

        /// <summary>
        /// Сохранить участников
        /// </summary>
        /// <param name="users">Участники</param>
        public Task<bool> SaveUsersAsync(ObservableCollection<User> users)
        {
            var tcs = new TaskCompletionSource<bool>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = SaveUsers(users);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Сохранить участников
        /// </summary>
        /// <param name="users">Участники</param>
        private bool SaveUsers(ObservableCollection<User> users)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var usersDB = context.Users.ToList();

                        var usersForDelete = (from uDB in usersDB
                                              join u in users
                                              on uDB.ID equals u.UserID
                                              where u.ForDelete
                                              select uDB).ToList();

                        context.Users.DeleteAllOnSubmit(usersForDelete);
                        context.SubmitChanges();

                        var usersForUpdate = (from uDB in usersDB
                                              join u in users
                                              on uDB.ID equals u.UserID
                                              where u.IsChanged
                                              select uDB).ToList();
                        foreach (var uDB in usersForUpdate)
                        {
                            var u = users.FirstOrDefault(x => x.UserID == uDB.ID);
                            uDB.UserName = u.UserName?.Trim();
                        }
                        context.SubmitChanges();

                        var usersForInsert = users.Where(x => x.UserID == 0).ToList();
                        context.Users.InsertAllOnSubmit(usersForInsert.Select(x => new Users() { UserName = x.UserName }));
                        context.SubmitChanges();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Участники не сохранены!", ex);
            }
        }

        #endregion Участники

        #region Тестирование

        /// <summary>
        /// Получить список тестов
        /// </summary>
        public Task<ObservableCollection<TestBase>> GetTestsAsync()
        {
            var tcs = new TaskCompletionSource<ObservableCollection<TestBase>>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = GetTests();
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Получить список тестов
        /// </summary>
        private ObservableCollection<TestBase> GetTests()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var testsDB = context.Tests.ToList();
                        return new ObservableCollection<TestBase>(testsDB.Select(x => new TestBase(x.ID, x.TestName, x.ScaleID, x.DateCreated.GetDateFromString())));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Тесты не получены!", ex);
            }
        }

        /// <summary>
        /// Сохранение нового теста
        /// </summary>
        /// <param name="test">Тест</param>
        public Task<int> SaveNewTestAsync(Test test)
        {
            var tcs = new TaskCompletionSource<int>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = SaveNewTest(test);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Сохранение нового теста
        /// </summary>
        /// <param name="test">Тест</param>
        private int SaveNewTest(Test test)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        //  Сохранение теста
                        var testDB = new Tests()
                        {
                            TestName = test.TestName,
                            DateCreated = test.DateCreated.GetStringFromDateForDB(),
                            ScaleID = test.ScaleID,
                            QualityGroupID = test.QualityGroupID,
                            Description = test.Description
                        };
                        context.Tests.InsertOnSubmit(testDB);
                        context.SubmitChanges();

                        //  Сохранение качеств теста
                        var qualitiesDB = context.Qualities
                            .Where(x => x.QualityGroupID == test.QualityGroupID)
                            .OrderBy(x => x.Sort)
                            .ToList();
                        context.TestQualities.InsertAllOnSubmit(qualitiesDB
                            .Select(x => new TestQualities()
                            {
                                QualityID = x.ID,
                                Sort = x.Sort,
                                TestID = testDB.ID
                            }));

                        //  Сохранение участников
                        foreach (var u in test.TestUsers.Where(x => !x.ForDelete))
                        {
                            var userDB = new Users()
                            {
                                UserName = u.UserName
                            };
                            context.Users.InsertOnSubmit(userDB);
                            context.SubmitChanges();

                            context.TestUsers.InsertOnSubmit(new TestUsers()
                            {
                                Sort = u.Sort,
                                UserID = userDB.ID,
                                TestID = testDB.ID
                            });
                            context.SubmitChanges();
                        }

                        //  Сохранение результатов теста
                        foreach (var uwc in test.UsersWithResults)
                        {
                            var resultsForInsert = uwc.TestResults.ToList();
                            context.TestResults.InsertAllOnSubmit(uwc.TestResults.Select(x => new TestResults()
                            {
                                ScaleScoreID = x.ScaleScoreID,
                                TestID = test.TestID,
                                TestQualityID = x.TestQualityID,
                                TestUserID = uwc.TestUserID,
                                UserID = x.UserID
                            }));
                            context.SubmitChanges();
                        }

                        return testDB.ID;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Тесты не получены!", ex);
            }
        }

        /// <summary>
        /// Сохранить тест
        /// </summary>
        /// <param name="test">Тест</param>
        public Task<bool> SaveTestAsync(Test test)
        {
            var tcs = new TaskCompletionSource<bool>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = SaveTest(test);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Сохранить тест
        /// </summary>
        /// <param name="test">Тест</param>
        private bool SaveTest(Test test)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var testDB = context.Tests.FirstOrDefault(x => x.ID == test.TestID);
                        //  Изменение тела теста
                        if (test.IsBodyChanged)
                        {
                            testDB.DateCreated = test.DateCreated.GetStringFromDateForDB();
                            testDB.ScaleID = test.ScaleID;
                            testDB.QualityGroupID = test.QualityGroupID;
                            testDB.TestName = test.TestName;
                            testDB.Description = test.Description;
                            context.SubmitChanges();
                        }

                        //  Изменение участников
                        if (test.TestUsers.FirstOrDefault(x => x.IsChanged || x.ForDelete) != null)
                        {
                            //  Удаление участников
                            var usersForDelete = (from u in test.TestUsers
                                                  join uDB in context.Users
                                                  on u.UserID equals uDB.ID
                                                  where u.ForDelete
                                                  select uDB).ToList();
                            var testUsersForDelete = (from u in test.TestUsers
                                                      join tuDB in context.TestUsers
                                                      on u.TestUserID equals tuDB.ID
                                                      where u.ForDelete
                                                      select tuDB).ToList();
                            context.TestUsers.DeleteAllOnSubmit(testUsersForDelete);
                            context.SubmitChanges();

                            context.Users.DeleteAllOnSubmit(usersForDelete);
                            context.SubmitChanges();

                            if (testUsersForDelete.Any())
                            {
                                //  Изменение сортировки неудаленных элементов
                                int sort = 1;
                                var testUsersForSort = test.TestUsers.Where(x => !x.ForDelete);
                                foreach (var tu in testUsersForSort)
                                {
                                    tu.Sort = sort;
                                    sort++;
                                }
                            }

                            //  Обновление данных участников
                            var usersForUpdate = (from u in test.TestUsers
                                                  join uDB in context.Users
                                                  on u.UserID equals uDB.ID
                                                  where u.IsUserNameChanged
                                                  select uDB).ToList();
                            usersForUpdate.ForEach(uDB =>
                            {
                                var u = test.TestUsers.FirstOrDefault(tu => tu.UserID == uDB.ID);
                                uDB.UserName = u.UserName;
                            });

                            var testUsersForUpdate = (from u in test.TestUsers
                                                      join uDB in context.TestUsers
                                                      on u.TestUserID equals uDB.ID
                                                      where u.IsSortChanged
                                                      select uDB).ToList();
                            testUsersForUpdate.ForEach(tuDB =>
                            {
                                var u = test.TestUsers.FirstOrDefault(tu => tu.TestUserID == tuDB.ID);
                                tuDB.Sort = u.Sort;
                            });

                            context.SubmitChanges();

                            //  Добавление новых участников
                            var usersForInsert = test.TestUsers.Where(x => x.UserID == 0 && !x.ForDelete).ToList();
                            foreach (var u in usersForInsert)
                            {
                                var userDB = new Users()
                                {
                                    UserName = u.UserName
                                };
                                context.Users.InsertOnSubmit(userDB);
                                context.SubmitChanges();

                                context.TestUsers.InsertOnSubmit(new TestUsers()
                                {
                                    UserID = userDB.ID,
                                    Sort = u.Sort,
                                    TestID = test.TestID
                                });
                                context.SubmitChanges();
                            }
                        }

                        //  Если были изменения участников или качеств - удаляем все результаты
                        if (test.TestUsers.FirstOrDefault(x => x.IsChangedForResultsDelete || x.ForDelete) != null
                            || test.IsQualityGroupChanged
                            || test.DeleteTestResults)
                        {
                            using (Main context2 = new Main(connection, new SqliteVendor()))
                            {
                                context2.TestResults.DeleteAllOnSubmit(testDB.TestResults);
                                context2.SubmitChanges();
                            }
                        }

                        //  Изменение качеств
                        if (test.IsQualityGroupChanged)
                        {
                            using (Main context2 = new Main(connection, new SqliteVendor()))
                            {
                                context2.TestQualities.DeleteAllOnSubmit(context2.TestQualities.Where(x => x.TestID == test.TestID).ToList());
                                context2.SubmitChanges();
                            }

                            var qualitiesDB = context.Qualities
                                .Where(x => x.QualityGroupID == test.QualityGroupID)
                                .OrderBy(x => x.Sort)
                                .ToList();
                            context.TestQualities.InsertAllOnSubmit(qualitiesDB
                                .Select(x => new TestQualities()
                                {
                                    QualityID = x.ID,
                                    Sort = x.Sort,
                                    TestID = testDB.ID
                                }));
                            context.SubmitChanges();
                        }

                        //  Сохранение результатов теста
                        else if (test.UsersWithResults.FirstOrDefault(x => x.IsChanged) != null)
                        {
                            var usersWithChanges = test.UsersWithResults.Where(x => x.IsChanged).ToList();
                            foreach (var uwc in usersWithChanges)
                            {
                                var resultsForUpdate = (from tr in uwc.TestResults
                                                        join trDB in testDB.TestResults
                                                        on tr.TestResultID equals trDB.ID
                                                        where tr.IsChanged
                                                        select trDB).ToList();
                                resultsForUpdate.ForEach(x =>
                                {
                                    var tr = uwc.TestResults.FirstOrDefault(y => y.TestResultID == x.ID);
                                    x.ScaleScoreID = tr.ScaleScoreID;
                                });
                                context.SubmitChanges();

                                var resultsForInsert = uwc.TestResults.Where(x => x.TestResultID == 0).ToList();
                                context.TestResults.InsertAllOnSubmit(uwc.TestResults.Where(x => x.TestResultID == 0).Select(x => new TestResults()
                                {
                                    ScaleScoreID = x.ScaleScoreID,
                                    TestID = test.TestID,
                                    TestQualityID = x.TestQualityID,
                                    UserID = x.UserID,
                                    TestUserID = uwc.TestUserID
                                }));
                                context.SubmitChanges();
                            }
                            context.SubmitChanges();
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Тест не сохранен!", ex);
            }
        }

        /// <summary>
        /// Получить тест
        /// </summary>
        /// <param name="testID">Код теста</param>
        public Task<Test> GetTestAsync(int testID)
        {
            var tcs = new TaskCompletionSource<Test>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = GetTest(testID);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Получить тест
        /// </summary>
        /// <param name="testID">Код теста</param>
        private Test GetTest(int testID)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var testDB = context.Tests.FirstOrDefault(x => x.ID == testID);
                        Test test = new Test(testDB.ID, testDB.TestName, testDB.ScaleID, testDB.QualityGroupID, testDB.DateCreated.GetDateFromString(), testDB.Description)
                        {
                            TestQualities = new ObservableCollection<TestQuality>(testDB.TestQualities.Select(x => new TestQuality(x.ID, x.QualityID, x.Sort))),
                            TestUsers = new ObservableCollection<TestUser>(testDB.TestUsers.Select(x => new TestUser(x.ID, x.UserID, x.Users.UserName, x.Sort))),
                            UsersWithResults = new ObservableCollection<UserWithTestResults>(testDB.TestUsers.Select(x => new UserWithTestResults(x.ID, x.Users.UserName, x.Sort)
                            {
                                TestResults = new ObservableCollection<TestResult>(x.TestResults.Select(tr => new TestResult(tr.ID, tr.ScaleScoreID, tr.TestQualityID, tr.UserID)))
                            }))
                        };
                        return test;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Тесты не получены!", ex);
            }
        }

        public void RandomizeTest(int testID)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var testDB = context.Tests.FirstOrDefault(x => x.ID == testID);
                        var testResults = testDB.TestResults.ToList();
                        var scaleScores = testDB.Scales.ScaleScores.Select(x => new ScaleScore(x.ID, x.Score, x.Sort)).ToList();
                        int seed = 0;
                        foreach (var tr in testResults)
                        {
                            Random random = new Random();
                            int scaleScoreID = scaleScores[random.Next(0, scaleScores.Count)].ScaleScoreID;
                            tr.ScaleScoreID = scaleScoreID;
                            seed++;
                            Thread.Sleep(10);
                        }

                        context.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Тесты не получены!", ex);
            }
        }

        /// <summary>
        /// Удалить тест
        /// </summary>
        /// <param name="testID">Код теста</param>
        public Task<bool> DeleteTestAsync(int testID)
        {
            var tcs = new TaskCompletionSource<bool>();
            TaskEx.Run(() =>
            {
                try
                {
                    var result = DeleteTest(testID);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).ConfigureAwait(false);
            return tcs.Task;
        }

        /// <summary>
        /// Удалить тест
        /// </summary>
        /// <param name="testID">Код теста</param>
        private bool DeleteTest(int testID)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {DataBaseFile}"))
                {
                    connection.Open();
                    using (Main context = new Main(connection, new SqliteVendor()))
                    {
                        var testDB = context.Tests.FirstOrDefault(x => x.ID == testID);
                        context.TestResults.DeleteAllOnSubmit(context.TestResults.Where(x => x.TestID == testID).ToList());
                        context.SubmitChanges();
                        context.TestQualities.DeleteAllOnSubmit(context.TestQualities.Where(x => x.TestID == testID).ToList());
                        context.TestUsers.DeleteAllOnSubmit(context.TestUsers.Where(x => x.TestID == testID).ToList());
                        context.SubmitChanges();
                        context.Tests.DeleteOnSubmit(testDB);
                        context.SubmitChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Тест не удален!", ex);
            }
        }

        #endregion Тестирование

        #endregion Методы
    }
}