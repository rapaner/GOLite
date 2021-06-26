
namespace GOLite.Views
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiTests = new DevExpress.XtraBars.BarButtonItem();
            this.bbiQualities = new DevExpress.XtraBars.BarButtonItem();
            this.bbiScales = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUsers = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.AutoHideEmptyItems = true;
            this.ribbon.AutoSizeItems = true;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiTests,
            this.bbiQualities,
            this.bbiScales,
            this.bbiUsers});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(736, 143);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // bbiTests
            // 
            this.bbiTests.Caption = "Список тестов";
            this.bbiTests.Id = 1;
            this.bbiTests.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiTests.ImageOptions.Image")));
            this.bbiTests.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiTests.ImageOptions.LargeImage")));
            this.bbiTests.Name = "bbiTests";
            // 
            // bbiQualities
            // 
            this.bbiQualities.Caption = "Качества";
            this.bbiQualities.Id = 2;
            this.bbiQualities.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiQualities.ImageOptions.Image")));
            this.bbiQualities.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiQualities.ImageOptions.LargeImage")));
            this.bbiQualities.Name = "bbiQualities";
            // 
            // bbiScales
            // 
            this.bbiScales.Caption = "Шкалы";
            this.bbiScales.Id = 3;
            this.bbiScales.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiScales.ImageOptions.Image")));
            this.bbiScales.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiScales.ImageOptions.LargeImage")));
            this.bbiScales.Name = "bbiScales";
            // 
            // bbiUsers
            // 
            this.bbiUsers.Caption = "Участники";
            this.bbiUsers.Id = 4;
            this.bbiUsers.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiUsers.ImageOptions.Image")));
            this.bbiUsers.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiUsers.ImageOptions.LargeImage")));
            this.bbiUsers.Name = "bbiUsers";
            this.bbiUsers.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Тестирование на качества";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiTests);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Тесты";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiQualities);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiScales);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiUsers);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Настройки";
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbon;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 566);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainView";
            this.Ribbon = this.ribbon;
            this.Text = "Тестирование на качества";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiTests;
        private DevExpress.XtraBars.BarButtonItem bbiQualities;
        private DevExpress.XtraBars.BarButtonItem bbiScales;
        private DevExpress.XtraBars.BarButtonItem bbiUsers;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
    }
}