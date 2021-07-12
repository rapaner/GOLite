
namespace GOLite.Views
{
    partial class TestsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestsView));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiGetTests = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNewTest = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOpenTest = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gcTests = new DevExpress.XtraGrid.GridControl();
            this.testsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvTests = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTestName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.AutoHideEmptyItems = true;
            this.ribbon.AutoSizeItems = true;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiGetTests,
            this.bbiNewTest,
            this.bbiOpenTest,
            this.bbiClose});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(533, 143);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // bbiGetTests
            // 
            this.bbiGetTests.Caption = "Обновить список";
            this.bbiGetTests.Id = 1;
            this.bbiGetTests.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiGetTests.ImageOptions.Image")));
            this.bbiGetTests.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiGetTests.ImageOptions.LargeImage")));
            this.bbiGetTests.Name = "bbiGetTests";
            // 
            // bbiNewTest
            // 
            this.bbiNewTest.Caption = "Создать тест";
            this.bbiNewTest.Id = 2;
            this.bbiNewTest.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiNewTest.ImageOptions.Image")));
            this.bbiNewTest.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiNewTest.ImageOptions.LargeImage")));
            this.bbiNewTest.Name = "bbiNewTest";
            // 
            // bbiOpenTest
            // 
            this.bbiOpenTest.Caption = "Открыть тест";
            this.bbiOpenTest.Id = 3;
            this.bbiOpenTest.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiOpenTest.ImageOptions.Image")));
            this.bbiOpenTest.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiOpenTest.ImageOptions.LargeImage")));
            this.bbiOpenTest.Name = "bbiOpenTest";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Закрыть";
            this.bbiClose.Id = 4;
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
            this.ribbonPage1.Text = "Тесты";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiGetTests);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNewTest);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiOpenTest);
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
            // gcTests
            // 
            this.gcTests.DataSource = this.testsBindingSource;
            this.gcTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTests.Location = new System.Drawing.Point(0, 143);
            this.gcTests.MainView = this.gvTests;
            this.gcTests.MenuManager = this.ribbon;
            this.gcTests.Name = "gcTests";
            this.gcTests.Size = new System.Drawing.Size(533, 352);
            this.gcTests.TabIndex = 2;
            this.gcTests.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTests});
            // 
            // testsBindingSource
            // 
            this.testsBindingSource.DataSource = typeof(GOLite.Entities.TestBase);
            // 
            // gvTests
            // 
            this.gvTests.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTestName,
            this.colDateCreated});
            this.gvTests.GridControl = this.gcTests;
            this.gvTests.Name = "gvTests";
            this.gvTests.OptionsBehavior.Editable = false;
            this.gvTests.OptionsCustomization.AllowGroup = false;
            this.gvTests.OptionsView.ShowGroupPanel = false;
            // 
            // colTestName
            // 
            this.colTestName.Caption = "Название группы";
            this.colTestName.FieldName = "TestName";
            this.colTestName.Name = "colTestName";
            this.colTestName.Visible = true;
            this.colTestName.VisibleIndex = 0;
            // 
            // colDateCreated
            // 
            this.colDateCreated.Caption = "Дата создания";
            this.colDateCreated.DisplayFormat.FormatString = "d";
            this.colDateCreated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateCreated.FieldName = "DateCreated";
            this.colDateCreated.Name = "colDateCreated";
            this.colDateCreated.Visible = true;
            this.colDateCreated.VisibleIndex = 1;
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            // 
            // TestsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 495);
            this.ControlBox = false;
            this.Controls.Add(this.gcTests);
            this.Controls.Add(this.ribbon);
            this.Name = "TestsView";
            this.Ribbon = this.ribbon;
            this.Text = "TestsView";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem bbiGetTests;
        private DevExpress.XtraBars.BarButtonItem bbiNewTest;
        private DevExpress.XtraBars.BarButtonItem bbiOpenTest;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraGrid.GridControl gcTests;
        private System.Windows.Forms.BindingSource testsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTests;
        private DevExpress.XtraGrid.Columns.GridColumn colTestName;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreated;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
    }
}