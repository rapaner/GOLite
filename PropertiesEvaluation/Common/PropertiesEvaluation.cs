// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from main on 2021-05-02 21:02:26Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
using System;
using System.ComponentModel;
using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
	using DbLinq.Data.Linq;
	using DbLinq.Vendor;
#endif  // MONO_STRICT
	using System.Data.Linq.Mapping;
using System.Diagnostics;


public partial class Main : DataContext
{
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		#endregion
	
	
	public Main(string connectionString) : 
			base(connectionString)
	{
		this.OnCreated();
	}
	
	public Main(string connection, MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		this.OnCreated();
	}
	
	public Main(IDbConnection connection, MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		this.OnCreated();
	}
	
	public Table<Qualities> Qualities
	{
		get
		{
			return this.GetTable<Qualities>();
		}
	}
	
	public Table<QualityGroups> QualityGroups
	{
		get
		{
			return this.GetTable<QualityGroups>();
		}
	}
	
	public Table<Scales> Scales
	{
		get
		{
			return this.GetTable<Scales>();
		}
	}
	
	public Table<ScaleScores> ScaleScores
	{
		get
		{
			return this.GetTable<ScaleScores>();
		}
	}
	
	public Table<TestQualities> TestQualities
	{
		get
		{
			return this.GetTable<TestQualities>();
		}
	}
	
	public Table<TestResults> TestResults
	{
		get
		{
			return this.GetTable<TestResults>();
		}
	}
	
	public Table<Tests> Tests
	{
		get
		{
			return this.GetTable<Tests>();
		}
	}
	
	public Table<TestUsers> TestUsers
	{
		get
		{
			return this.GetTable<TestUsers>();
		}
	}
	
	public Table<Users> Users
	{
		get
		{
			return this.GetTable<Users>();
		}
	}
}

#region Start MONO_STRICT
#if MONO_STRICT

public partial class Main
{
	
	public Main(IDbConnection connection) : 
			base(connection)
	{
		this.OnCreated();
	}
}
#region End MONO_STRICT
	#endregion
#else     // MONO_STRICT

public partial class Main
{
	
	public Main(IDbConnection connection) : 
			base(connection, new DbLinq.Sqlite.SqliteVendor())
	{
		this.OnCreated();
	}
	
	public Main(IDbConnection connection, IVendor sqlDialect) : 
			base(connection, sqlDialect)
	{
		this.OnCreated();
	}
	
	public Main(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) : 
			base(connection, mappingSource, sqlDialect)
	{
		this.OnCreated();
	}
}
#region End Not MONO_STRICT
	#endregion
#endif     // MONO_STRICT
#endregion

[Table(Name="main.Qualities")]
public partial class Qualities : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private string _badQuality;
	
	private string _goodQuality;
	
	private int _id;
	
	private int _qualityGroupID;
	
	private int _sort;
	
	private EntitySet<TestQualities> _testQualities;
	
	private EntityRef<QualityGroups> _qualityGroups = new EntityRef<QualityGroups>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnBadQualityChanged();
		
		partial void OnBadQualityChanging(string value);
		
		partial void OnGoodQualityChanged();
		
		partial void OnGoodQualityChanging(string value);
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnQualityGroupIDChanged();
		
		partial void OnQualityGroupIDChanging(int value);
		
		partial void OnSortChanged();
		
		partial void OnSortChanging(int value);
		#endregion
	
	
	public Qualities()
	{
		_testQualities = new EntitySet<TestQualities>(new Action<TestQualities>(this.TestQualities_Attach), new Action<TestQualities>(this.TestQualities_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_badQuality", Name="BadQuality", DbType="text", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string BadQuality
	{
		get
		{
			return this._badQuality;
		}
		set
		{
			if (((_badQuality == value) 
						== false))
			{
				this.OnBadQualityChanging(value);
				this.SendPropertyChanging();
				this._badQuality = value;
				this.SendPropertyChanged("BadQuality");
				this.OnBadQualityChanged();
			}
		}
	}
	
	[Column(Storage="_goodQuality", Name="GoodQuality", DbType="text", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string GoodQuality
	{
		get
		{
			return this._goodQuality;
		}
		set
		{
			if (((_goodQuality == value) 
						== false))
			{
				this.OnGoodQualityChanging(value);
				this.SendPropertyChanging();
				this._goodQuality = value;
				this.SendPropertyChanged("GoodQuality");
				this.OnGoodQualityChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="ID", DbType="integer", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_qualityGroupID", Name="QualityGroupID", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int QualityGroupID
	{
		get
		{
			return this._qualityGroupID;
		}
		set
		{
			if ((_qualityGroupID != value))
			{
				if (_qualityGroups.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnQualityGroupIDChanging(value);
				this.SendPropertyChanging();
				this._qualityGroupID = value;
				this.SendPropertyChanged("QualityGroupID");
				this.OnQualityGroupIDChanged();
			}
		}
	}
	
	[Column(Storage="_sort", Name="Sort", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int Sort
	{
		get
		{
			return this._sort;
		}
		set
		{
			if ((_sort != value))
			{
				this.OnSortChanging(value);
				this.SendPropertyChanging();
				this._sort = value;
				this.SendPropertyChanged("Sort");
				this.OnSortChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_testQualities", OtherKey="QualityID", ThisKey="ID", Name="fk_TestQualities_0")]
	[DebuggerNonUserCode()]
	public EntitySet<TestQualities> TestQualities
	{
		get
		{
			return this._testQualities;
		}
		set
		{
			this._testQualities = value;
		}
	}
	#endregion
	
	#region Parents
	[Association(Storage="_qualityGroups", OtherKey="ID", ThisKey="QualityGroupID", Name="fk_Qualities_0", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public QualityGroups QualityGroups
	{
		get
		{
			return this._qualityGroups.Entity;
		}
		set
		{
			if (((this._qualityGroups.Entity == value) 
						== false))
			{
				if ((this._qualityGroups.Entity != null))
				{
					QualityGroups previousQualityGroups = this._qualityGroups.Entity;
					this._qualityGroups.Entity = null;
					previousQualityGroups.Qualities.Remove(this);
				}
				this._qualityGroups.Entity = value;
				if ((value != null))
				{
					value.Qualities.Add(this);
					_qualityGroupID = value.ID;
				}
				else
				{
					_qualityGroupID = default(int);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void TestQualities_Attach(TestQualities entity)
	{
		this.SendPropertyChanging();
		entity.Qualities = this;
	}
	
	private void TestQualities_Detach(TestQualities entity)
	{
		this.SendPropertyChanging();
		entity.Qualities = null;
	}
	#endregion
}

[Table(Name="main.QualityGroups")]
public partial class QualityGroups : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private int _id;
	
	private string _name;
	
	private EntitySet<Qualities> _qualities;
	
	private EntitySet<Tests> _tests;
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnNameChanged();
		
		partial void OnNameChanging(string value);
		#endregion
	
	
	public QualityGroups()
	{
		_qualities = new EntitySet<Qualities>(new Action<Qualities>(this.Qualities_Attach), new Action<Qualities>(this.Qualities_Detach));
		_tests = new EntitySet<Tests>(new Action<Tests>(this.Tests_Attach), new Action<Tests>(this.Tests_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_id", Name="ID", DbType="INTEGER", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_name", Name="Name", DbType="TEXT", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string Name
	{
		get
		{
			return this._name;
		}
		set
		{
			if (((_name == value) 
						== false))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_qualities", OtherKey="QualityGroupID", ThisKey="ID", Name="fk_Qualities_0")]
	[DebuggerNonUserCode()]
	public EntitySet<Qualities> Qualities
	{
		get
		{
			return this._qualities;
		}
		set
		{
			this._qualities = value;
		}
	}
	
	[Association(Storage="_tests", OtherKey="QualityGroupID", ThisKey="ID", Name="fk_Tests_0")]
	[DebuggerNonUserCode()]
	public EntitySet<Tests> Tests
	{
		get
		{
			return this._tests;
		}
		set
		{
			this._tests = value;
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void Qualities_Attach(Qualities entity)
	{
		this.SendPropertyChanging();
		entity.QualityGroups = this;
	}
	
	private void Qualities_Detach(Qualities entity)
	{
		this.SendPropertyChanging();
		entity.QualityGroups = null;
	}
	
	private void Tests_Attach(Tests entity)
	{
		this.SendPropertyChanging();
		entity.QualityGroups = this;
	}
	
	private void Tests_Detach(Tests entity)
	{
		this.SendPropertyChanging();
		entity.QualityGroups = null;
	}
	#endregion
}

[Table(Name="main.Scales")]
public partial class Scales : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private int _id;
	
	private string _name;
	
	private EntitySet<ScaleScores> _scaleScores;
	
	private EntitySet<Tests> _tests;
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnNameChanged();
		
		partial void OnNameChanging(string value);
		#endregion
	
	
	public Scales()
	{
		_scaleScores = new EntitySet<ScaleScores>(new Action<ScaleScores>(this.ScaleScores_Attach), new Action<ScaleScores>(this.ScaleScores_Detach));
		_tests = new EntitySet<Tests>(new Action<Tests>(this.Tests_Attach), new Action<Tests>(this.Tests_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_id", Name="ID", DbType="integer", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_name", Name="Name", DbType="text", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string Name
	{
		get
		{
			return this._name;
		}
		set
		{
			if (((_name == value) 
						== false))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_scaleScores", OtherKey="ScaleID", ThisKey="ID", Name="fk_ScaleScores_0")]
	[DebuggerNonUserCode()]
	public EntitySet<ScaleScores> ScaleScores
	{
		get
		{
			return this._scaleScores;
		}
		set
		{
			this._scaleScores = value;
		}
	}
	
	[Association(Storage="_tests", OtherKey="ScaleID", ThisKey="ID", Name="fk_Tests_1")]
	[DebuggerNonUserCode()]
	public EntitySet<Tests> Tests
	{
		get
		{
			return this._tests;
		}
		set
		{
			this._tests = value;
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void ScaleScores_Attach(ScaleScores entity)
	{
		this.SendPropertyChanging();
		entity.Scales = this;
	}
	
	private void ScaleScores_Detach(ScaleScores entity)
	{
		this.SendPropertyChanging();
		entity.Scales = null;
	}
	
	private void Tests_Attach(Tests entity)
	{
		this.SendPropertyChanging();
		entity.Scales = this;
	}
	
	private void Tests_Detach(Tests entity)
	{
		this.SendPropertyChanging();
		entity.Scales = null;
	}
	#endregion
}

[Table(Name="main.ScaleScores")]
public partial class ScaleScores : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private int _id;
	
	private int _scaleID;
	
	private int _score;
	
	private int _sort;
	
	private EntitySet<TestResults> _testResults;
	
	private EntityRef<Scales> _scales = new EntityRef<Scales>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnScaleIDChanged();
		
		partial void OnScaleIDChanging(int value);
		
		partial void OnScoreChanged();
		
		partial void OnScoreChanging(int value);
		
		partial void OnSortChanged();
		
		partial void OnSortChanging(int value);
		#endregion
	
	
	public ScaleScores()
	{
		_testResults = new EntitySet<TestResults>(new Action<TestResults>(this.TestResults_Attach), new Action<TestResults>(this.TestResults_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_id", Name="ID", DbType="integer", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_scaleID", Name="ScaleID", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ScaleID
	{
		get
		{
			return this._scaleID;
		}
		set
		{
			if ((_scaleID != value))
			{
				if (_scales.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnScaleIDChanging(value);
				this.SendPropertyChanging();
				this._scaleID = value;
				this.SendPropertyChanged("ScaleID");
				this.OnScaleIDChanged();
			}
		}
	}
	
	[Column(Storage="_score", Name="Score", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int Score
	{
		get
		{
			return this._score;
		}
		set
		{
			if ((_score != value))
			{
				this.OnScoreChanging(value);
				this.SendPropertyChanging();
				this._score = value;
				this.SendPropertyChanged("Score");
				this.OnScoreChanged();
			}
		}
	}
	
	[Column(Storage="_sort", Name="Sort", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int Sort
	{
		get
		{
			return this._sort;
		}
		set
		{
			if ((_sort != value))
			{
				this.OnSortChanging(value);
				this.SendPropertyChanging();
				this._sort = value;
				this.SendPropertyChanged("Sort");
				this.OnSortChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_testResults", OtherKey="ScaleScoreID", ThisKey="ID", Name="fk_TestResults_1")]
	[DebuggerNonUserCode()]
	public EntitySet<TestResults> TestResults
	{
		get
		{
			return this._testResults;
		}
		set
		{
			this._testResults = value;
		}
	}
	#endregion
	
	#region Parents
	[Association(Storage="_scales", OtherKey="ID", ThisKey="ScaleID", Name="fk_ScaleScores_0", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Scales Scales
	{
		get
		{
			return this._scales.Entity;
		}
		set
		{
			if (((this._scales.Entity == value) 
						== false))
			{
				if ((this._scales.Entity != null))
				{
					Scales previousScales = this._scales.Entity;
					this._scales.Entity = null;
					previousScales.ScaleScores.Remove(this);
				}
				this._scales.Entity = value;
				if ((value != null))
				{
					value.ScaleScores.Add(this);
					_scaleID = value.ID;
				}
				else
				{
					_scaleID = default(int);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void TestResults_Attach(TestResults entity)
	{
		this.SendPropertyChanging();
		entity.ScaleScores = this;
	}
	
	private void TestResults_Detach(TestResults entity)
	{
		this.SendPropertyChanging();
		entity.ScaleScores = null;
	}
	#endregion
}

[Table(Name="main.TestQualities")]
public partial class TestQualities : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private int _id;
	
	private int _qualityID;
	
	private int _sort;
	
	private int _testID;
	
	private EntitySet<TestResults> _testResults;
	
	private EntityRef<Qualities> _qualities = new EntityRef<Qualities>();
	
	private EntityRef<Tests> _tests = new EntityRef<Tests>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnQualityIDChanged();
		
		partial void OnQualityIDChanging(int value);
		
		partial void OnSortChanged();
		
		partial void OnSortChanging(int value);
		
		partial void OnTestIDChanged();
		
		partial void OnTestIDChanging(int value);
		#endregion
	
	
	public TestQualities()
	{
		_testResults = new EntitySet<TestResults>(new Action<TestResults>(this.TestResults_Attach), new Action<TestResults>(this.TestResults_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_id", Name="ID", DbType="integer", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_qualityID", Name="QualityID", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int QualityID
	{
		get
		{
			return this._qualityID;
		}
		set
		{
			if ((_qualityID != value))
			{
				if (_qualities.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnQualityIDChanging(value);
				this.SendPropertyChanging();
				this._qualityID = value;
				this.SendPropertyChanged("QualityID");
				this.OnQualityIDChanged();
			}
		}
	}
	
	[Column(Storage="_sort", Name="Sort", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int Sort
	{
		get
		{
			return this._sort;
		}
		set
		{
			if ((_sort != value))
			{
				this.OnSortChanging(value);
				this.SendPropertyChanging();
				this._sort = value;
				this.SendPropertyChanged("Sort");
				this.OnSortChanged();
			}
		}
	}
	
	[Column(Storage="_testID", Name="TestID", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int TestID
	{
		get
		{
			return this._testID;
		}
		set
		{
			if ((_testID != value))
			{
				if (_tests.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnTestIDChanging(value);
				this.SendPropertyChanging();
				this._testID = value;
				this.SendPropertyChanged("TestID");
				this.OnTestIDChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_testResults", OtherKey="TestQualityID", ThisKey="ID", Name="fk_TestResults_2")]
	[DebuggerNonUserCode()]
	public EntitySet<TestResults> TestResults
	{
		get
		{
			return this._testResults;
		}
		set
		{
			this._testResults = value;
		}
	}
	#endregion
	
	#region Parents
	[Association(Storage="_qualities", OtherKey="ID", ThisKey="QualityID", Name="fk_TestQualities_0", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Qualities Qualities
	{
		get
		{
			return this._qualities.Entity;
		}
		set
		{
			if (((this._qualities.Entity == value) 
						== false))
			{
				if ((this._qualities.Entity != null))
				{
					Qualities previousQualities = this._qualities.Entity;
					this._qualities.Entity = null;
					previousQualities.TestQualities.Remove(this);
				}
				this._qualities.Entity = value;
				if ((value != null))
				{
					value.TestQualities.Add(this);
					_qualityID = value.ID;
				}
				else
				{
					_qualityID = default(int);
				}
			}
		}
	}
	
	[Association(Storage="_tests", OtherKey="ID", ThisKey="TestID", Name="fk_TestQualities_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Tests Tests
	{
		get
		{
			return this._tests.Entity;
		}
		set
		{
			if (((this._tests.Entity == value) 
						== false))
			{
				if ((this._tests.Entity != null))
				{
					Tests previousTests = this._tests.Entity;
					this._tests.Entity = null;
					previousTests.TestQualities.Remove(this);
				}
				this._tests.Entity = value;
				if ((value != null))
				{
					value.TestQualities.Add(this);
					_testID = value.ID;
				}
				else
				{
					_testID = default(int);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void TestResults_Attach(TestResults entity)
	{
		this.SendPropertyChanging();
		entity.TestQualities = this;
	}
	
	private void TestResults_Detach(TestResults entity)
	{
		this.SendPropertyChanging();
		entity.TestQualities = null;
	}
	#endregion
}

[Table(Name="main.TestResults")]
public partial class TestResults : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private int _id;
	
	private int _scaleScoreID;
	
	private int _testID;
	
	private int _testQualityID;
	
	private int _testUserID;
	
	private int _userID;
	
	private EntityRef<Tests> _tests = new EntityRef<Tests>();
	
	private EntityRef<ScaleScores> _scaleScores = new EntityRef<ScaleScores>();
	
	private EntityRef<TestQualities> _testQualities = new EntityRef<TestQualities>();
	
	private EntityRef<Users> _users = new EntityRef<Users>();
	
	private EntityRef<TestUsers> _testUsers = new EntityRef<TestUsers>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnScaleScoreIDChanged();
		
		partial void OnScaleScoreIDChanging(int value);
		
		partial void OnTestIDChanged();
		
		partial void OnTestIDChanging(int value);
		
		partial void OnTestQualityIDChanged();
		
		partial void OnTestQualityIDChanging(int value);
		
		partial void OnTestUserIDChanged();
		
		partial void OnTestUserIDChanging(int value);
		
		partial void OnUserIDChanged();
		
		partial void OnUserIDChanging(int value);
		#endregion
	
	
	public TestResults()
	{
		this.OnCreated();
	}
	
	[Column(Storage="_id", Name="ID", DbType="integer", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_scaleScoreID", Name="ScaleScoreID", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ScaleScoreID
	{
		get
		{
			return this._scaleScoreID;
		}
		set
		{
			if ((_scaleScoreID != value))
			{
				if (_scaleScores.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnScaleScoreIDChanging(value);
				this.SendPropertyChanging();
				this._scaleScoreID = value;
				this.SendPropertyChanged("ScaleScoreID");
				this.OnScaleScoreIDChanged();
			}
		}
	}
	
	[Column(Storage="_testID", Name="TestID", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int TestID
	{
		get
		{
			return this._testID;
		}
		set
		{
			if ((_testID != value))
			{
				if (_tests.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnTestIDChanging(value);
				this.SendPropertyChanging();
				this._testID = value;
				this.SendPropertyChanged("TestID");
				this.OnTestIDChanged();
			}
		}
	}
	
	[Column(Storage="_testQualityID", Name="TestQualityID", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int TestQualityID
	{
		get
		{
			return this._testQualityID;
		}
		set
		{
			if ((_testQualityID != value))
			{
				if (_testQualities.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnTestQualityIDChanging(value);
				this.SendPropertyChanging();
				this._testQualityID = value;
				this.SendPropertyChanged("TestQualityID");
				this.OnTestQualityIDChanged();
			}
		}
	}
	
	[Column(Storage="_testUserID", Name="TestUserID", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int TestUserID
	{
		get
		{
			return this._testUserID;
		}
		set
		{
			if ((_testUserID != value))
			{
				if (_testUsers.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnTestUserIDChanging(value);
				this.SendPropertyChanging();
				this._testUserID = value;
				this.SendPropertyChanged("TestUserID");
				this.OnTestUserIDChanged();
			}
		}
	}
	
	[Column(Storage="_userID", Name="UserID", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int UserID
	{
		get
		{
			return this._userID;
		}
		set
		{
			if ((_userID != value))
			{
				if (_users.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnUserIDChanging(value);
				this.SendPropertyChanging();
				this._userID = value;
				this.SendPropertyChanged("UserID");
				this.OnUserIDChanged();
			}
		}
	}
	
	#region Parents
	[Association(Storage="_tests", OtherKey="ID", ThisKey="TestID", Name="fk_TestResults_0", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Tests Tests
	{
		get
		{
			return this._tests.Entity;
		}
		set
		{
			if (((this._tests.Entity == value) 
						== false))
			{
				if ((this._tests.Entity != null))
				{
					Tests previousTests = this._tests.Entity;
					this._tests.Entity = null;
					previousTests.TestResults.Remove(this);
				}
				this._tests.Entity = value;
				if ((value != null))
				{
					value.TestResults.Add(this);
					_testID = value.ID;
				}
				else
				{
					_testID = default(int);
				}
			}
		}
	}
	
	[Association(Storage="_scaleScores", OtherKey="ID", ThisKey="ScaleScoreID", Name="fk_TestResults_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public ScaleScores ScaleScores
	{
		get
		{
			return this._scaleScores.Entity;
		}
		set
		{
			if (((this._scaleScores.Entity == value) 
						== false))
			{
				if ((this._scaleScores.Entity != null))
				{
					ScaleScores previousScaleScores = this._scaleScores.Entity;
					this._scaleScores.Entity = null;
					previousScaleScores.TestResults.Remove(this);
				}
				this._scaleScores.Entity = value;
				if ((value != null))
				{
					value.TestResults.Add(this);
					_scaleScoreID = value.ID;
				}
				else
				{
					_scaleScoreID = default(int);
				}
			}
		}
	}
	
	[Association(Storage="_testQualities", OtherKey="ID", ThisKey="TestQualityID", Name="fk_TestResults_2", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public TestQualities TestQualities
	{
		get
		{
			return this._testQualities.Entity;
		}
		set
		{
			if (((this._testQualities.Entity == value) 
						== false))
			{
				if ((this._testQualities.Entity != null))
				{
					TestQualities previousTestQualities = this._testQualities.Entity;
					this._testQualities.Entity = null;
					previousTestQualities.TestResults.Remove(this);
				}
				this._testQualities.Entity = value;
				if ((value != null))
				{
					value.TestResults.Add(this);
					_testQualityID = value.ID;
				}
				else
				{
					_testQualityID = default(int);
				}
			}
		}
	}
	
	[Association(Storage="_users", OtherKey="ID", ThisKey="UserID", Name="fk_TestResults_3", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Users Users
	{
		get
		{
			return this._users.Entity;
		}
		set
		{
			if (((this._users.Entity == value) 
						== false))
			{
				if ((this._users.Entity != null))
				{
					Users previousUsers = this._users.Entity;
					this._users.Entity = null;
					previousUsers.TestResults.Remove(this);
				}
				this._users.Entity = value;
				if ((value != null))
				{
					value.TestResults.Add(this);
					_userID = value.ID;
				}
				else
				{
					_userID = default(int);
				}
			}
		}
	}
	
	[Association(Storage="_testUsers", OtherKey="ID", ThisKey="TestUserID", Name="fk_TestResults_4", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public TestUsers TestUsers
	{
		get
		{
			return this._testUsers.Entity;
		}
		set
		{
			if (((this._testUsers.Entity == value) 
						== false))
			{
				if ((this._testUsers.Entity != null))
				{
					TestUsers previousTestUsers = this._testUsers.Entity;
					this._testUsers.Entity = null;
					previousTestUsers.TestResults.Remove(this);
				}
				this._testUsers.Entity = value;
				if ((value != null))
				{
					value.TestResults.Add(this);
					_testUserID = value.ID;
				}
				else
				{
					_testUserID = default(int);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
}

[Table(Name="main.Tests")]
public partial class Tests : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private string _dateCreated;
	
	private string _description;
	
	private int _id;
	
	private int _qualityGroupID;
	
	private int _scaleID;
	
	private string _testName;
	
	private EntitySet<TestQualities> _testQualities;
	
	private EntitySet<TestResults> _testResults;
	
	private EntitySet<TestUsers> _testUsers;
	
	private EntityRef<QualityGroups> _qualityGroups = new EntityRef<QualityGroups>();
	
	private EntityRef<Scales> _scales = new EntityRef<Scales>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDateCreatedChanged();
		
		partial void OnDateCreatedChanging(string value);
		
		partial void OnDescriptionChanged();
		
		partial void OnDescriptionChanging(string value);
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnQualityGroupIDChanged();
		
		partial void OnQualityGroupIDChanging(int value);
		
		partial void OnScaleIDChanged();
		
		partial void OnScaleIDChanging(int value);
		
		partial void OnTestNameChanged();
		
		partial void OnTestNameChanging(string value);
		#endregion
	
	
	public Tests()
	{
		_testQualities = new EntitySet<TestQualities>(new Action<TestQualities>(this.TestQualities_Attach), new Action<TestQualities>(this.TestQualities_Detach));
		_testResults = new EntitySet<TestResults>(new Action<TestResults>(this.TestResults_Attach), new Action<TestResults>(this.TestResults_Detach));
		_testUsers = new EntitySet<TestUsers>(new Action<TestUsers>(this.TestUsers_Attach), new Action<TestUsers>(this.TestUsers_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_dateCreated", Name="DateCreated", DbType="text", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string DateCreated
	{
		get
		{
			return this._dateCreated;
		}
		set
		{
			if (((_dateCreated == value) 
						== false))
			{
				this.OnDateCreatedChanging(value);
				this.SendPropertyChanging();
				this._dateCreated = value;
				this.SendPropertyChanged("DateCreated");
				this.OnDateCreatedChanged();
			}
		}
	}
	
	[Column(Storage="_description", Name="Description", DbType="TEXT", AutoSync=AutoSync.Never)]
	[DebuggerNonUserCode()]
	public string Description
	{
		get
		{
			return this._description;
		}
		set
		{
			if (((_description == value) 
						== false))
			{
				this.OnDescriptionChanging(value);
				this.SendPropertyChanging();
				this._description = value;
				this.SendPropertyChanged("Description");
				this.OnDescriptionChanged();
			}
		}
	}
	
	[Column(Storage="_id", Name="ID", DbType="integer", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_qualityGroupID", Name="QualityGroupID", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int QualityGroupID
	{
		get
		{
			return this._qualityGroupID;
		}
		set
		{
			if ((_qualityGroupID != value))
			{
				if (_qualityGroups.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnQualityGroupIDChanging(value);
				this.SendPropertyChanging();
				this._qualityGroupID = value;
				this.SendPropertyChanged("QualityGroupID");
				this.OnQualityGroupIDChanged();
			}
		}
	}
	
	[Column(Storage="_scaleID", Name="ScaleID", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ScaleID
	{
		get
		{
			return this._scaleID;
		}
		set
		{
			if ((_scaleID != value))
			{
				if (_scales.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnScaleIDChanging(value);
				this.SendPropertyChanging();
				this._scaleID = value;
				this.SendPropertyChanged("ScaleID");
				this.OnScaleIDChanged();
			}
		}
	}
	
	[Column(Storage="_testName", Name="TestName", DbType="text", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string TestName
	{
		get
		{
			return this._testName;
		}
		set
		{
			if (((_testName == value) 
						== false))
			{
				this.OnTestNameChanging(value);
				this.SendPropertyChanging();
				this._testName = value;
				this.SendPropertyChanged("TestName");
				this.OnTestNameChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_testQualities", OtherKey="TestID", ThisKey="ID", Name="fk_TestQualities_1")]
	[DebuggerNonUserCode()]
	public EntitySet<TestQualities> TestQualities
	{
		get
		{
			return this._testQualities;
		}
		set
		{
			this._testQualities = value;
		}
	}
	
	[Association(Storage="_testResults", OtherKey="TestID", ThisKey="ID", Name="fk_TestResults_0")]
	[DebuggerNonUserCode()]
	public EntitySet<TestResults> TestResults
	{
		get
		{
			return this._testResults;
		}
		set
		{
			this._testResults = value;
		}
	}
	
	[Association(Storage="_testUsers", OtherKey="TestID", ThisKey="ID", Name="fk_TestUsers_1")]
	[DebuggerNonUserCode()]
	public EntitySet<TestUsers> TestUsers
	{
		get
		{
			return this._testUsers;
		}
		set
		{
			this._testUsers = value;
		}
	}
	#endregion
	
	#region Parents
	[Association(Storage="_qualityGroups", OtherKey="ID", ThisKey="QualityGroupID", Name="fk_Tests_0", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public QualityGroups QualityGroups
	{
		get
		{
			return this._qualityGroups.Entity;
		}
		set
		{
			if (((this._qualityGroups.Entity == value) 
						== false))
			{
				if ((this._qualityGroups.Entity != null))
				{
					QualityGroups previousQualityGroups = this._qualityGroups.Entity;
					this._qualityGroups.Entity = null;
					previousQualityGroups.Tests.Remove(this);
				}
				this._qualityGroups.Entity = value;
				if ((value != null))
				{
					value.Tests.Add(this);
					_qualityGroupID = value.ID;
				}
				else
				{
					_qualityGroupID = default(int);
				}
			}
		}
	}
	
	[Association(Storage="_scales", OtherKey="ID", ThisKey="ScaleID", Name="fk_Tests_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Scales Scales
	{
		get
		{
			return this._scales.Entity;
		}
		set
		{
			if (((this._scales.Entity == value) 
						== false))
			{
				if ((this._scales.Entity != null))
				{
					Scales previousScales = this._scales.Entity;
					this._scales.Entity = null;
					previousScales.Tests.Remove(this);
				}
				this._scales.Entity = value;
				if ((value != null))
				{
					value.Tests.Add(this);
					_scaleID = value.ID;
				}
				else
				{
					_scaleID = default(int);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void TestQualities_Attach(TestQualities entity)
	{
		this.SendPropertyChanging();
		entity.Tests = this;
	}
	
	private void TestQualities_Detach(TestQualities entity)
	{
		this.SendPropertyChanging();
		entity.Tests = null;
	}
	
	private void TestResults_Attach(TestResults entity)
	{
		this.SendPropertyChanging();
		entity.Tests = this;
	}
	
	private void TestResults_Detach(TestResults entity)
	{
		this.SendPropertyChanging();
		entity.Tests = null;
	}
	
	private void TestUsers_Attach(TestUsers entity)
	{
		this.SendPropertyChanging();
		entity.Tests = this;
	}
	
	private void TestUsers_Detach(TestUsers entity)
	{
		this.SendPropertyChanging();
		entity.Tests = null;
	}
	#endregion
}

[Table(Name="main.TestUsers")]
public partial class TestUsers : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private int _id;
	
	private int _sort;
	
	private int _testID;
	
	private int _userID;
	
	private EntitySet<TestResults> _testResults;
	
	private EntityRef<Users> _users = new EntityRef<Users>();
	
	private EntityRef<Tests> _tests = new EntityRef<Tests>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnSortChanged();
		
		partial void OnSortChanging(int value);
		
		partial void OnTestIDChanged();
		
		partial void OnTestIDChanging(int value);
		
		partial void OnUserIDChanged();
		
		partial void OnUserIDChanging(int value);
		#endregion
	
	
	public TestUsers()
	{
		_testResults = new EntitySet<TestResults>(new Action<TestResults>(this.TestResults_Attach), new Action<TestResults>(this.TestResults_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_id", Name="ID", DbType="integer", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_sort", Name="Sort", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int Sort
	{
		get
		{
			return this._sort;
		}
		set
		{
			if ((_sort != value))
			{
				this.OnSortChanging(value);
				this.SendPropertyChanging();
				this._sort = value;
				this.SendPropertyChanged("Sort");
				this.OnSortChanged();
			}
		}
	}
	
	[Column(Storage="_testID", Name="TestID", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int TestID
	{
		get
		{
			return this._testID;
		}
		set
		{
			if ((_testID != value))
			{
				if (_tests.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnTestIDChanging(value);
				this.SendPropertyChanging();
				this._testID = value;
				this.SendPropertyChanged("TestID");
				this.OnTestIDChanged();
			}
		}
	}
	
	[Column(Storage="_userID", Name="UserID", DbType="integer", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int UserID
	{
		get
		{
			return this._userID;
		}
		set
		{
			if ((_userID != value))
			{
				if (_users.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnUserIDChanging(value);
				this.SendPropertyChanging();
				this._userID = value;
				this.SendPropertyChanged("UserID");
				this.OnUserIDChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_testResults", OtherKey="TestUserID", ThisKey="ID", Name="fk_TestResults_4")]
	[DebuggerNonUserCode()]
	public EntitySet<TestResults> TestResults
	{
		get
		{
			return this._testResults;
		}
		set
		{
			this._testResults = value;
		}
	}
	#endregion
	
	#region Parents
	[Association(Storage="_users", OtherKey="ID", ThisKey="UserID", Name="fk_TestUsers_0", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Users Users
	{
		get
		{
			return this._users.Entity;
		}
		set
		{
			if (((this._users.Entity == value) 
						== false))
			{
				if ((this._users.Entity != null))
				{
					Users previousUsers = this._users.Entity;
					this._users.Entity = null;
					previousUsers.TestUsers.Remove(this);
				}
				this._users.Entity = value;
				if ((value != null))
				{
					value.TestUsers.Add(this);
					_userID = value.ID;
				}
				else
				{
					_userID = default(int);
				}
			}
		}
	}
	
	[Association(Storage="_tests", OtherKey="ID", ThisKey="TestID", Name="fk_TestUsers_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Tests Tests
	{
		get
		{
			return this._tests.Entity;
		}
		set
		{
			if (((this._tests.Entity == value) 
						== false))
			{
				if ((this._tests.Entity != null))
				{
					Tests previousTests = this._tests.Entity;
					this._tests.Entity = null;
					previousTests.TestUsers.Remove(this);
				}
				this._tests.Entity = value;
				if ((value != null))
				{
					value.TestUsers.Add(this);
					_testID = value.ID;
				}
				else
				{
					_testID = default(int);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void TestResults_Attach(TestResults entity)
	{
		this.SendPropertyChanging();
		entity.TestUsers = this;
	}
	
	private void TestResults_Detach(TestResults entity)
	{
		this.SendPropertyChanging();
		entity.TestUsers = null;
	}
	#endregion
}

[Table(Name="main.Users")]
public partial class Users : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private int _id;
	
	private string _userName;
	
	private EntitySet<TestResults> _testResults;
	
	private EntitySet<TestUsers> _testUsers;
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnUserNameChanged();
		
		partial void OnUserNameChanging(string value);
		#endregion
	
	
	public Users()
	{
		_testResults = new EntitySet<TestResults>(new Action<TestResults>(this.TestResults_Attach), new Action<TestResults>(this.TestResults_Detach));
		_testUsers = new EntitySet<TestUsers>(new Action<TestUsers>(this.TestUsers_Attach), new Action<TestUsers>(this.TestUsers_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_id", Name="ID", DbType="integer", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_userName", Name="UserName", DbType="text", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string UserName
	{
		get
		{
			return this._userName;
		}
		set
		{
			if (((_userName == value) 
						== false))
			{
				this.OnUserNameChanging(value);
				this.SendPropertyChanging();
				this._userName = value;
				this.SendPropertyChanged("UserName");
				this.OnUserNameChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_testResults", OtherKey="UserID", ThisKey="ID", Name="fk_TestResults_3")]
	[DebuggerNonUserCode()]
	public EntitySet<TestResults> TestResults
	{
		get
		{
			return this._testResults;
		}
		set
		{
			this._testResults = value;
		}
	}
	
	[Association(Storage="_testUsers", OtherKey="UserID", ThisKey="ID", Name="fk_TestUsers_0")]
	[DebuggerNonUserCode()]
	public EntitySet<TestUsers> TestUsers
	{
		get
		{
			return this._testUsers;
		}
		set
		{
			this._testUsers = value;
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void TestResults_Attach(TestResults entity)
	{
		this.SendPropertyChanging();
		entity.Users = this;
	}
	
	private void TestResults_Detach(TestResults entity)
	{
		this.SendPropertyChanging();
		entity.Users = null;
	}
	
	private void TestUsers_Attach(TestUsers entity)
	{
		this.SendPropertyChanging();
		entity.Users = this;
	}
	
	private void TestUsers_Detach(TestUsers entity)
	{
		this.SendPropertyChanging();
		entity.Users = null;
	}
	#endregion
}
