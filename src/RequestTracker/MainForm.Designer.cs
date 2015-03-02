namespace RequestTracker
{
  partial class MainForm
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
      DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.colIsImportant = new DevExpress.XtraGrid.Columns.GridColumn();
      this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
      this.gridRequests = new DevExpress.XtraGrid.GridControl();
      this.gridViewRequests = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colState = new DevExpress.XtraGrid.Columns.GridColumn();
      this.cboImages = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
      this.images = new DevExpress.Utils.ImageCollection(this.components);
      this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colSummary = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colProgramID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.cboPrograms = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colEnteredByID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.cboUsers = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colEntered = new DevExpress.XtraGrid.Columns.GridColumn();
      this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
      this.bar1 = new DevExpress.XtraBars.Bar();
      this.tbbSave = new DevExpress.XtraBars.BarButtonItem();
      this.tbbUsers = new DevExpress.XtraBars.BarButtonItem();
      this.tbbPrograms = new DevExpress.XtraBars.BarButtonItem();
      this.tbbNewRequest = new DevExpress.XtraBars.BarButtonItem();
      this.tbbSignInOut = new DevExpress.XtraBars.BarButtonItem();
      this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      this.mnuApprove = new DevExpress.XtraBars.BarButtonItem();
      this.mnuSchedule = new DevExpress.XtraBars.BarButtonItem();
      this.mnuResolve = new DevExpress.XtraBars.BarButtonItem();
      this.mnuReject = new DevExpress.XtraBars.BarButtonItem();
      this.mnuFixed = new DevExpress.XtraBars.BarButtonItem();
      this.mnuReOpen = new DevExpress.XtraBars.BarButtonItem();
      this.cboProgramFilters = new DevExpress.XtraEditors.LookUpEdit();
      this.cboRequestFilters = new DevExpress.XtraEditors.ComboBoxEdit();
      this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
      this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
      this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
      this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
      this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
      this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
      this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
      this.layoutControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridRequests)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewRequests)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboImages)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.images)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboPrograms)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboUsers)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboProgramFilters.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboRequestFilters.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
      this.SuspendLayout();
      // 
      // colIsImportant
      // 
      this.colIsImportant.Caption = "IsImportant";
      this.colIsImportant.FieldName = "IsImportant";
      this.colIsImportant.Name = "colIsImportant";
      // 
      // layoutControl1
      // 
      this.layoutControl1.Controls.Add(this.gridRequests);
      this.layoutControl1.Controls.Add(this.cboProgramFilters);
      this.layoutControl1.Controls.Add(this.cboRequestFilters);
      this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.layoutControl1.Location = new System.Drawing.Point(0, 31);
      this.layoutControl1.Name = "layoutControl1";
      this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(858, 241, 250, 350);
      this.layoutControl1.Root = this.layoutControlGroup1;
      this.layoutControl1.Size = new System.Drawing.Size(708, 384);
      this.layoutControl1.TabIndex = 0;
      this.layoutControl1.Text = "layoutControl1";
      // 
      // gridRequests
      // 
      this.gridRequests.Cursor = System.Windows.Forms.Cursors.Default;
      this.gridRequests.Location = new System.Drawing.Point(24, 110);
      this.gridRequests.MainView = this.gridViewRequests;
      this.gridRequests.MenuManager = this.barManager1;
      this.gridRequests.Name = "gridRequests";
      this.gridRequests.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboPrograms,
            this.cboUsers,
            this.cboImages});
      this.gridRequests.Size = new System.Drawing.Size(660, 250);
      this.gridRequests.TabIndex = 6;
      this.gridRequests.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRequests});
      // 
      // gridViewRequests
      // 
      this.gridViewRequests.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colState,
            this.colNumber,
            this.colSummary,
            this.colProgramID,
            this.colEnteredByID,
            this.colEntered,
            this.colIsImportant});
      this.gridViewRequests.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
      styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.SlateBlue;
      styleFormatCondition1.Appearance.Options.UseFont = true;
      styleFormatCondition1.Appearance.Options.UseForeColor = true;
      styleFormatCondition1.ApplyToRow = true;
      styleFormatCondition1.Column = this.colIsImportant;
      styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
      styleFormatCondition1.Value1 = true;
      this.gridViewRequests.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
      this.gridViewRequests.GridControl = this.gridRequests;
      this.gridViewRequests.Name = "gridViewRequests";
      this.gridViewRequests.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
      this.gridViewRequests.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
      this.gridViewRequests.OptionsBehavior.Editable = false;
      this.gridViewRequests.OptionsBehavior.ReadOnly = true;
      this.gridViewRequests.OptionsCustomization.AllowColumnMoving = false;
      this.gridViewRequests.OptionsCustomization.AllowFilter = false;
      this.gridViewRequests.OptionsCustomization.AllowQuickHideColumns = false;
      this.gridViewRequests.OptionsDetail.EnableMasterViewMode = false;
      this.gridViewRequests.OptionsMenu.EnableColumnMenu = false;
      this.gridViewRequests.OptionsMenu.EnableFooterMenu = false;
      this.gridViewRequests.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridViewRequests.OptionsSelection.MultiSelect = true;
      this.gridViewRequests.OptionsView.ShowGroupPanel = false;
      this.gridViewRequests.OptionsView.ShowIndicator = false;
      this.gridViewRequests.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewRequests_RowClick);
      this.gridViewRequests.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewRequests_PopupMenuShowing);
      this.gridViewRequests.CustomRowFilter += new DevExpress.XtraGrid.Views.Base.RowFilterEventHandler(this.gridViewRequests_CustomRowFilter);
      this.gridViewRequests.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewRequests_KeyDown);
      // 
      // colState
      // 
      this.colState.ColumnEdit = this.cboImages;
      this.colState.FieldName = "State";
      this.colState.MaxWidth = 22;
      this.colState.MinWidth = 22;
      this.colState.Name = "colState";
      this.colState.OptionsColumn.AllowSize = false;
      this.colState.OptionsColumn.ShowCaption = false;
      this.colState.Visible = true;
      this.colState.VisibleIndex = 0;
      this.colState.Width = 22;
      // 
      // cboImages
      // 
      this.cboImages.AutoHeight = false;
      this.cboImages.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cboImages.Name = "cboImages";
      this.cboImages.SmallImages = this.images;
      // 
      // images
      // 
      this.images.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("images.ImageStream")));
      this.images.IsDpiAware = DevExpress.Utils.DefaultBoolean.False;
      this.images.InsertGalleryImage("question_16x16.png", "images/support/question_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/question_16x16.png"), 0);
      this.images.Images.SetKeyName(0, "question_16x16.png");
      this.images.InsertGalleryImage("newtask_16x16.png", "images/tasks/newtask_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/tasks/newtask_16x16.png"), 1);
      this.images.Images.SetKeyName(1, "newtask_16x16.png");
      this.images.InsertGalleryImage("show_16x16.png", "images/actions/show_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/show_16x16.png"), 2);
      this.images.Images.SetKeyName(2, "show_16x16.png");
      this.images.InsertGalleryImage("calendar_16x16.png", "images/scheduling/calendar_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/scheduling/calendar_16x16.png"), 3);
      this.images.Images.SetKeyName(3, "calendar_16x16.png");
      this.images.InsertGalleryImage("knowledgebasearticle_16x16.png", "images/support/knowledgebasearticle_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/knowledgebasearticle_16x16.png"), 4);
      this.images.Images.SetKeyName(4, "knowledgebasearticle_16x16.png");
      this.images.InsertGalleryImage("checkbox_16x16.png", "images/content/checkbox_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/content/checkbox_16x16.png"), 5);
      this.images.Images.SetKeyName(5, "checkbox_16x16.png");
      // 
      // colNumber
      // 
      this.colNumber.Caption = "Number";
      this.colNumber.FieldName = "Number";
      this.colNumber.MaxWidth = 60;
      this.colNumber.MinWidth = 60;
      this.colNumber.Name = "colNumber";
      this.colNumber.Visible = true;
      this.colNumber.VisibleIndex = 1;
      this.colNumber.Width = 60;
      // 
      // colSummary
      // 
      this.colSummary.Caption = "Summary";
      this.colSummary.FieldName = "Summary";
      this.colSummary.Name = "colSummary";
      this.colSummary.Visible = true;
      this.colSummary.VisibleIndex = 3;
      this.colSummary.Width = 253;
      // 
      // colProgramID
      // 
      this.colProgramID.Caption = "Program";
      this.colProgramID.ColumnEdit = this.cboPrograms;
      this.colProgramID.FieldName = "ProgramID";
      this.colProgramID.Name = "colProgramID";
      this.colProgramID.Visible = true;
      this.colProgramID.VisibleIndex = 2;
      this.colProgramID.Width = 157;
      // 
      // cboPrograms
      // 
      this.cboPrograms.AutoHeight = false;
      this.cboPrograms.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cboPrograms.Name = "cboPrograms";
      // 
      // colEnteredByID
      // 
      this.colEnteredByID.Caption = "Entered By";
      this.colEnteredByID.ColumnEdit = this.cboUsers;
      this.colEnteredByID.FieldName = "EnteredByID";
      this.colEnteredByID.MaxWidth = 80;
      this.colEnteredByID.MinWidth = 80;
      this.colEnteredByID.Name = "colEnteredByID";
      this.colEnteredByID.Visible = true;
      this.colEnteredByID.VisibleIndex = 4;
      this.colEnteredByID.Width = 80;
      // 
      // cboUsers
      // 
      this.cboUsers.AutoHeight = false;
      this.cboUsers.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cboUsers.Name = "cboUsers";
      // 
      // colEntered
      // 
      this.colEntered.Caption = "Entered";
      this.colEntered.FieldName = "Entered";
      this.colEntered.MaxWidth = 70;
      this.colEntered.MinWidth = 70;
      this.colEntered.Name = "colEntered";
      this.colEntered.Visible = true;
      this.colEntered.VisibleIndex = 5;
      this.colEntered.Width = 70;
      // 
      // barManager1
      // 
      this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
      this.barManager1.DockControls.Add(this.barDockControlTop);
      this.barManager1.DockControls.Add(this.barDockControlBottom);
      this.barManager1.DockControls.Add(this.barDockControlLeft);
      this.barManager1.DockControls.Add(this.barDockControlRight);
      this.barManager1.Form = this;
      this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.tbbSave,
            this.tbbPrograms,
            this.tbbUsers,
            this.tbbSignInOut,
            this.tbbNewRequest,
            this.mnuApprove,
            this.mnuSchedule,
            this.mnuResolve,
            this.mnuReject,
            this.mnuFixed,
            this.mnuReOpen});
      this.barManager1.MaxItemId = 20;
      // 
      // bar1
      // 
      this.bar1.BarName = "Tools";
      this.bar1.DockCol = 0;
      this.bar1.DockRow = 0;
      this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.tbbSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.tbbUsers, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.tbbPrograms),
            new DevExpress.XtraBars.LinkPersistInfo(this.tbbNewRequest, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.tbbSignInOut)});
      this.bar1.OptionsBar.AllowQuickCustomization = false;
      this.bar1.OptionsBar.DisableClose = true;
      this.bar1.OptionsBar.DisableCustomization = true;
      this.bar1.OptionsBar.DrawDragBorder = false;
      this.bar1.OptionsBar.UseWholeRow = true;
      this.bar1.Text = "Tools";
      // 
      // tbbSave
      // 
      this.tbbSave.Caption = "Save";
      this.tbbSave.Glyph = ((System.Drawing.Image)(resources.GetObject("tbbSave.Glyph")));
      this.tbbSave.Id = 1;
      this.tbbSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("tbbSave.LargeGlyph")));
      this.tbbSave.Name = "tbbSave";
      this.tbbSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      this.tbbSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbbSave_ItemClick);
      // 
      // tbbUsers
      // 
      this.tbbUsers.Caption = "Users";
      this.tbbUsers.Glyph = ((System.Drawing.Image)(resources.GetObject("tbbUsers.Glyph")));
      this.tbbUsers.Id = 3;
      this.tbbUsers.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("tbbUsers.LargeGlyph")));
      this.tbbUsers.Name = "tbbUsers";
      this.tbbUsers.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      this.tbbUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbbUsers_ItemClick);
      // 
      // tbbPrograms
      // 
      this.tbbPrograms.Caption = "Programs";
      this.tbbPrograms.Glyph = ((System.Drawing.Image)(resources.GetObject("tbbPrograms.Glyph")));
      this.tbbPrograms.Id = 2;
      this.tbbPrograms.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("tbbPrograms.LargeGlyph")));
      this.tbbPrograms.Name = "tbbPrograms";
      this.tbbPrograms.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      this.tbbPrograms.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbbPrograms_ItemClick);
      // 
      // tbbNewRequest
      // 
      this.tbbNewRequest.Caption = "New Request";
      this.tbbNewRequest.Glyph = ((System.Drawing.Image)(resources.GetObject("tbbNewRequest.Glyph")));
      this.tbbNewRequest.Id = 12;
      this.tbbNewRequest.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("tbbNewRequest.LargeGlyph")));
      this.tbbNewRequest.Name = "tbbNewRequest";
      this.tbbNewRequest.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      this.tbbNewRequest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbbNewRequest_ItemClick);
      // 
      // tbbSignInOut
      // 
      this.tbbSignInOut.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.tbbSignInOut.Caption = "Sign In";
      this.tbbSignInOut.Glyph = ((System.Drawing.Image)(resources.GetObject("tbbSignInOut.Glyph")));
      this.tbbSignInOut.Id = 7;
      this.tbbSignInOut.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("tbbSignInOut.LargeGlyph")));
      this.tbbSignInOut.Name = "tbbSignInOut";
      this.tbbSignInOut.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      this.tbbSignInOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbbSignInOut_ItemClick);
      // 
      // barDockControlTop
      // 
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
      this.barDockControlTop.Size = new System.Drawing.Size(708, 31);
      // 
      // barDockControlBottom
      // 
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.barDockControlBottom.Location = new System.Drawing.Point(0, 415);
      this.barDockControlBottom.Size = new System.Drawing.Size(708, 0);
      // 
      // barDockControlLeft
      // 
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
      this.barDockControlLeft.Size = new System.Drawing.Size(0, 384);
      // 
      // barDockControlRight
      // 
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.barDockControlRight.Location = new System.Drawing.Point(708, 31);
      this.barDockControlRight.Size = new System.Drawing.Size(0, 384);
      // 
      // mnuApprove
      // 
      this.mnuApprove.Caption = "Approve";
      this.mnuApprove.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuApprove.Glyph")));
      this.mnuApprove.Id = 13;
      this.mnuApprove.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuApprove.LargeGlyph")));
      this.mnuApprove.Name = "mnuApprove";
      this.mnuApprove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuApprove_ItemClick);
      // 
      // mnuSchedule
      // 
      this.mnuSchedule.Caption = "Schedule";
      this.mnuSchedule.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuSchedule.Glyph")));
      this.mnuSchedule.Id = 14;
      this.mnuSchedule.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuSchedule.LargeGlyph")));
      this.mnuSchedule.Name = "mnuSchedule";
      this.mnuSchedule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuSchedule_ItemClick);
      // 
      // mnuResolve
      // 
      this.mnuResolve.Caption = "Resolve";
      this.mnuResolve.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuResolve.Glyph")));
      this.mnuResolve.Id = 15;
      this.mnuResolve.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuResolve.LargeGlyph")));
      this.mnuResolve.Name = "mnuResolve";
      this.mnuResolve.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuResolve_ItemClick);
      // 
      // mnuReject
      // 
      this.mnuReject.Caption = "Reject";
      this.mnuReject.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuReject.Glyph")));
      this.mnuReject.Id = 16;
      this.mnuReject.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuReject.LargeGlyph")));
      this.mnuReject.Name = "mnuReject";
      this.mnuReject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuReject_ItemClick);
      // 
      // mnuFixed
      // 
      this.mnuFixed.Caption = "Fixed";
      this.mnuFixed.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuFixed.Glyph")));
      this.mnuFixed.Id = 17;
      this.mnuFixed.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuFixed.LargeGlyph")));
      this.mnuFixed.Name = "mnuFixed";
      this.mnuFixed.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuFixed_ItemClick);
      // 
      // mnuReOpen
      // 
      this.mnuReOpen.Caption = "Re-Open";
      this.mnuReOpen.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuReOpen.Glyph")));
      this.mnuReOpen.Id = 18;
      this.mnuReOpen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuReOpen.LargeGlyph")));
      this.mnuReOpen.Name = "mnuReOpen";
      this.mnuReOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuReOpen_ItemClick);
      // 
      // cboProgramFilters
      // 
      this.cboProgramFilters.Location = new System.Drawing.Point(406, 43);
      this.cboProgramFilters.MenuManager = this.barManager1;
      this.cboProgramFilters.Name = "cboProgramFilters";
      this.cboProgramFilters.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cboProgramFilters.Size = new System.Drawing.Size(278, 20);
      this.cboProgramFilters.StyleController = this.layoutControl1;
      this.cboProgramFilters.TabIndex = 5;
      // 
      // cboRequestFilters
      // 
      this.cboRequestFilters.Location = new System.Drawing.Point(74, 43);
      this.cboRequestFilters.MenuManager = this.barManager1;
      this.cboRequestFilters.Name = "cboRequestFilters";
      this.cboRequestFilters.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cboRequestFilters.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
      this.cboRequestFilters.Size = new System.Drawing.Size(278, 20);
      this.cboRequestFilters.StyleController = this.layoutControl1;
      this.cboRequestFilters.TabIndex = 4;
      // 
      // layoutControlGroup1
      // 
      this.layoutControlGroup1.CustomizationFormText = "Root";
      this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
      this.layoutControlGroup1.GroupBordersVisible = false;
      this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
      this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
      this.layoutControlGroup1.Name = "Root";
      this.layoutControlGroup1.Size = new System.Drawing.Size(708, 384);
      this.layoutControlGroup1.Text = "Root";
      this.layoutControlGroup1.TextVisible = false;
      // 
      // layoutControlGroup2
      // 
      this.layoutControlGroup2.CustomizationFormText = "Request Filter";
      this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
      this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
      this.layoutControlGroup2.Name = "layoutControlGroup2";
      this.layoutControlGroup2.Size = new System.Drawing.Size(688, 67);
      this.layoutControlGroup2.Text = "Request Filter";
      // 
      // layoutControlItem1
      // 
      this.layoutControlItem1.Control = this.cboRequestFilters;
      this.layoutControlItem1.CustomizationFormText = "Show me:";
      this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
      this.layoutControlItem1.Name = "layoutControlItem1";
      this.layoutControlItem1.Size = new System.Drawing.Size(332, 24);
      this.layoutControlItem1.Text = "Show me:";
      this.layoutControlItem1.TextSize = new System.Drawing.Size(47, 13);
      // 
      // layoutControlItem2
      // 
      this.layoutControlItem2.Control = this.cboProgramFilters;
      this.layoutControlItem2.CustomizationFormText = "For:";
      this.layoutControlItem2.Location = new System.Drawing.Point(332, 0);
      this.layoutControlItem2.Name = "layoutControlItem2";
      this.layoutControlItem2.Size = new System.Drawing.Size(332, 24);
      this.layoutControlItem2.Text = "For:";
      this.layoutControlItem2.TextSize = new System.Drawing.Size(47, 13);
      // 
      // layoutControlGroup3
      // 
      this.layoutControlGroup3.CustomizationFormText = "Requests";
      this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
      this.layoutControlGroup3.Location = new System.Drawing.Point(0, 67);
      this.layoutControlGroup3.Name = "layoutControlGroup3";
      this.layoutControlGroup3.Size = new System.Drawing.Size(688, 297);
      this.layoutControlGroup3.Text = "Requests";
      // 
      // layoutControlItem3
      // 
      this.layoutControlItem3.Control = this.gridRequests;
      this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
      this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
      this.layoutControlItem3.Name = "layoutControlItem3";
      this.layoutControlItem3.Size = new System.Drawing.Size(664, 254);
      this.layoutControlItem3.Text = "layoutControlItem3";
      this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
      this.layoutControlItem3.TextToControlDistance = 0;
      this.layoutControlItem3.TextVisible = false;
      // 
      // popupMenu1
      // 
      this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuApprove),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuSchedule),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuResolve),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuReject),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuFixed),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuReOpen)});
      this.popupMenu1.Manager = this.barManager1;
      this.popupMenu1.Name = "popupMenu1";
      this.popupMenu1.BeforePopup += new System.ComponentModel.CancelEventHandler(this.popupMenu1_BeforePopup);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(708, 415);
      this.Controls.Add(this.layoutControl1);
      this.Controls.Add(this.barDockControlLeft);
      this.Controls.Add(this.barDockControlRight);
      this.Controls.Add(this.barDockControlBottom);
      this.Controls.Add(this.barDockControlTop);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Request Tracker";
      ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
      this.layoutControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridRequests)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewRequests)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboImages)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.images)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboPrograms)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboUsers)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboProgramFilters.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboRequestFilters.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraLayout.LayoutControl layoutControl1;
    private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    private DevExpress.XtraBars.BarManager barManager1;
    private DevExpress.XtraBars.Bar bar1;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraBars.BarButtonItem tbbSave;
    private DevExpress.XtraBars.BarButtonItem tbbUsers;
    private DevExpress.XtraBars.BarButtonItem tbbPrograms;
    private DevExpress.XtraBars.BarButtonItem tbbSignInOut;
    private DevExpress.XtraBars.BarButtonItem tbbNewRequest;
    private DevExpress.XtraEditors.ComboBoxEdit cboRequestFilters;
    private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    private DevExpress.XtraEditors.LookUpEdit cboProgramFilters;
    private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    private DevExpress.XtraGrid.GridControl gridRequests;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewRequests;
    private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
    private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
    private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    private DevExpress.XtraGrid.Columns.GridColumn colNumber;
    private DevExpress.XtraGrid.Columns.GridColumn colProgramID;
    private DevExpress.XtraGrid.Columns.GridColumn colEnteredByID;
    private DevExpress.XtraGrid.Columns.GridColumn colEntered;
    private DevExpress.XtraGrid.Columns.GridColumn colSummary;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboPrograms;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboUsers;
    private DevExpress.XtraBars.BarButtonItem mnuApprove;
    private DevExpress.XtraBars.PopupMenu popupMenu1;
    private DevExpress.XtraBars.BarButtonItem mnuSchedule;
    private DevExpress.XtraBars.BarButtonItem mnuResolve;
    private DevExpress.XtraBars.BarButtonItem mnuReject;
    private DevExpress.XtraBars.BarButtonItem mnuFixed;
    private DevExpress.XtraBars.BarButtonItem mnuReOpen;
    private DevExpress.XtraGrid.Columns.GridColumn colState;
    private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cboImages;
    private DevExpress.Utils.ImageCollection images;
    private DevExpress.XtraGrid.Columns.GridColumn colIsImportant;

  }
}

