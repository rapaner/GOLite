
namespace GOLite.Views
{
    partial class QualitiesView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QualitiesView));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.qualitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.gcQualities = new DevExpress.XtraGrid.GridControl();
            this.gvQualities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodQuality = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBadQuality = new DevExpress.XtraGrid.Columns.GridColumn();
            this.standaloneBarDockControl4 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbiAddGroup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteGroup = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl2 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.bbiAddQuality = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUpQuality = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDownQuality = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteQuality = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gcQualityGroups = new DevExpress.XtraGrid.GridControl();
            this.qualityGroupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvQualityGroups = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualitiesBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcQualities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQualities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcQualityGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityGroupsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQualityGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.AutoHideEmptyItems = true;
            this.ribbon.AutoSizeItems = true;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiSave,
            this.bbiClose});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(705, 143);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Сохранить";
            this.bbiSave.Id = 1;
            this.bbiSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSave.ImageOptions.Image")));
            this.bbiSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSave.ImageOptions.LargeImage")));
            this.bbiSave.Name = "bbiSave";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Закрыть";
            this.bbiClose.Id = 2;
            this.bbiClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.Image")));
            this.bbiClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.LargeImage")));
            this.bbiClose.Name = "bbiClose";
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Качества";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Управление";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Закрытие";
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            // 
            // qualitiesBindingSource
            // 
            this.qualitiesBindingSource.DataSource = typeof(GOLite.Entities.Quality);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 143);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(705, 417);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.layoutControl2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(355, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(347, 411);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "Пары качеств";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.gcQualities);
            this.layoutControl2.Controls.Add(this.standaloneBarDockControl4);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(343, 389);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // gcQualities
            // 
            this.gcQualities.DataSource = this.qualitiesBindingSource;
            this.gcQualities.Location = new System.Drawing.Point(5, 40);
            this.gcQualities.MainView = this.gvQualities;
            this.gcQualities.MenuManager = this.ribbon;
            this.gcQualities.Name = "gcQualities";
            this.gcQualities.Size = new System.Drawing.Size(333, 344);
            this.gcQualities.TabIndex = 0;
            this.gcQualities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvQualities});
            // 
            // gvQualities
            // 
            this.gvQualities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSort,
            this.colNumeration,
            this.colGoodQuality,
            this.colBadQuality});
            this.gvQualities.GridControl = this.gcQualities;
            this.gvQualities.Name = "gvQualities";
            this.gvQualities.OptionsCustomization.AllowGroup = false;
            this.gvQualities.OptionsCustomization.AllowSort = false;
            this.gvQualities.OptionsView.ShowGroupPanel = false;
            this.gvQualities.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSort, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colSort
            // 
            this.colSort.Caption = "Сортировка";
            this.colSort.FieldName = "Sort";
            this.colSort.Name = "colSort";
            this.colSort.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            // 
            // colNumeration
            // 
            this.colNumeration.Caption = "№";
            this.colNumeration.FieldName = "colNumeration";
            this.colNumeration.Name = "colNumeration";
            this.colNumeration.OptionsColumn.AllowEdit = false;
            this.colNumeration.OptionsColumn.ReadOnly = true;
            this.colNumeration.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colNumeration.Visible = true;
            this.colNumeration.VisibleIndex = 0;
            // 
            // colGoodQuality
            // 
            this.colGoodQuality.Caption = "Положительное";
            this.colGoodQuality.FieldName = "GoodQuality";
            this.colGoodQuality.Name = "colGoodQuality";
            this.colGoodQuality.Visible = true;
            this.colGoodQuality.VisibleIndex = 1;
            // 
            // colBadQuality
            // 
            this.colBadQuality.Caption = "Отрицательное";
            this.colBadQuality.FieldName = "BadQuality";
            this.colBadQuality.Name = "colBadQuality";
            this.colBadQuality.Visible = true;
            this.colBadQuality.VisibleIndex = 2;
            // 
            // standaloneBarDockControl4
            // 
            this.standaloneBarDockControl4.CausesValidation = false;
            this.standaloneBarDockControl4.Location = new System.Drawing.Point(5, 5);
            this.standaloneBarDockControl4.Manager = this.barManager1;
            this.standaloneBarDockControl4.Name = "standaloneBarDockControl4";
            this.standaloneBarDockControl4.Size = new System.Drawing.Size(333, 31);
            this.standaloneBarDockControl4.Text = "standaloneBarDockControl4";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar4});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl2);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl4);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiAddGroup,
            this.bbiDeleteGroup,
            this.bbiAddQuality,
            this.bbiUpQuality,
            this.bbiDownQuality,
            this.bbiDeleteQuality});
            this.barManager1.MaxItemId = 10;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Standalone;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(79, 256);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiAddGroup),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDeleteGroup)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl2;
            this.bar1.Text = "Custom 2";
            // 
            // bbiAddGroup
            // 
            this.bbiAddGroup.Caption = "Добавить";
            this.bbiAddGroup.Id = 0;
            this.bbiAddGroup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAddGroup.ImageOptions.Image")));
            this.bbiAddGroup.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAddGroup.ImageOptions.LargeImage")));
            this.bbiAddGroup.Name = "bbiAddGroup";
            // 
            // bbiDeleteGroup
            // 
            this.bbiDeleteGroup.Caption = "Удалить шкалу";
            this.bbiDeleteGroup.Id = 1;
            this.bbiDeleteGroup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDeleteGroup.ImageOptions.Image")));
            this.bbiDeleteGroup.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDeleteGroup.ImageOptions.LargeImage")));
            this.bbiDeleteGroup.Name = "bbiDeleteGroup";
            // 
            // standaloneBarDockControl2
            // 
            this.standaloneBarDockControl2.CausesValidation = false;
            this.standaloneBarDockControl2.Location = new System.Drawing.Point(5, 5);
            this.standaloneBarDockControl2.Manager = this.barManager1;
            this.standaloneBarDockControl2.Name = "standaloneBarDockControl2";
            this.standaloneBarDockControl2.Size = new System.Drawing.Size(332, 31);
            this.standaloneBarDockControl2.Text = "standaloneBarDockControl2";
            // 
            // bar4
            // 
            this.bar4.BarName = "Custom 4";
            this.bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Standalone;
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar4.FloatLocation = new System.Drawing.Point(384, 291);
            this.bar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiAddQuality),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiUpQuality),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDownQuality),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDeleteQuality)});
            this.bar4.OptionsBar.AllowQuickCustomization = false;
            this.bar4.OptionsBar.DrawDragBorder = false;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.StandaloneBarDockControl = this.standaloneBarDockControl4;
            this.bar4.Text = "Custom 4";
            // 
            // bbiAddQuality
            // 
            this.bbiAddQuality.Caption = "Доб";
            this.bbiAddQuality.Id = 6;
            this.bbiAddQuality.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAddQuality.ImageOptions.Image")));
            this.bbiAddQuality.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAddQuality.ImageOptions.LargeImage")));
            this.bbiAddQuality.Name = "bbiAddQuality";
            // 
            // bbiUpQuality
            // 
            this.bbiUpQuality.Caption = "Вверх";
            this.bbiUpQuality.Id = 7;
            this.bbiUpQuality.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiUpQuality.ImageOptions.Image")));
            this.bbiUpQuality.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiUpQuality.ImageOptions.LargeImage")));
            this.bbiUpQuality.Name = "bbiUpQuality";
            // 
            // bbiDownQuality
            // 
            this.bbiDownQuality.Caption = "Вниз";
            this.bbiDownQuality.Id = 8;
            this.bbiDownQuality.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDownQuality.ImageOptions.Image")));
            this.bbiDownQuality.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDownQuality.ImageOptions.LargeImage")));
            this.bbiDownQuality.Name = "bbiDownQuality";
            // 
            // bbiDeleteQuality
            // 
            this.bbiDeleteQuality.Caption = "Удалить";
            this.bbiDeleteQuality.Id = 9;
            this.bbiDeleteQuality.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDeleteQuality.ImageOptions.Image")));
            this.bbiDeleteQuality.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDeleteQuality.ImageOptions.LargeImage")));
            this.bbiDeleteQuality.Name = "bbiDeleteQuality";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(705, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 560);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(705, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 560);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(705, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 560);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup2.Size = new System.Drawing.Size(343, 389);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcQualities;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(337, 348);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.standaloneBarDockControl4;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(337, 35);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(346, 411);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Название списка";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcQualityGroups);
            this.layoutControl1.Controls.Add(this.standaloneBarDockControl2);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 20);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(342, 389);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcQualityGroups
            // 
            this.gcQualityGroups.DataSource = this.qualityGroupsBindingSource;
            this.gcQualityGroups.Location = new System.Drawing.Point(5, 40);
            this.gcQualityGroups.MainView = this.gvQualityGroups;
            this.gcQualityGroups.MenuManager = this.ribbon;
            this.gcQualityGroups.Name = "gcQualityGroups";
            this.gcQualityGroups.Size = new System.Drawing.Size(332, 344);
            this.gcQualityGroups.TabIndex = 0;
            this.gcQualityGroups.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvQualityGroups});
            // 
            // qualityGroupsBindingSource
            // 
            this.qualityGroupsBindingSource.DataSource = typeof(GOLite.Entities.QualityGroup);
            // 
            // gvQualityGroups
            // 
            this.gvQualityGroups.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName});
            this.gvQualityGroups.GridControl = this.gcQualityGroups;
            this.gvQualityGroups.Name = "gvQualityGroups";
            this.gvQualityGroups.OptionsCustomization.AllowGroup = false;
            this.gvQualityGroups.OptionsCustomization.AllowSort = false;
            this.gvQualityGroups.OptionsDetail.EnableMasterViewMode = false;
            this.gvQualityGroups.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.Caption = "Название";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(342, 389);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcQualityGroups;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(336, 348);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.standaloneBarDockControl2;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(336, 35);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // bar3
            // 
            this.bar3.BarName = "Custom 3";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar3.FloatLocation = new System.Drawing.Point(459, 291);
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.StandaloneBarDockControl = this.standaloneBarDockControl2;
            this.bar3.Text = "Custom 3";
            // 
            // QualitiesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 560);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "QualitiesView";
            this.Ribbon = this.ribbon;
            this.Text = "QualitiesView";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualitiesBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcQualities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQualities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcQualityGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityGroupsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQualityGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private System.Windows.Forms.BindingSource qualitiesBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource qualityGroupsBindingSource;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gcQualityGroups;
        private DevExpress.XtraGrid.Views.Grid.GridView gvQualityGroups;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiAddGroup;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteGroup;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarButtonItem bbiAddQuality;
        private DevExpress.XtraBars.BarButtonItem bbiUpQuality;
        private DevExpress.XtraBars.BarButtonItem bbiDownQuality;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteQuality;
        private DevExpress.XtraGrid.GridControl gcQualities;
        private DevExpress.XtraGrid.Views.Grid.GridView gvQualities;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodQuality;
        private DevExpress.XtraGrid.Columns.GridColumn colBadQuality;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeration;
        private DevExpress.XtraGrid.Columns.GridColumn colSort;
    }
}