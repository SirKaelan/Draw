﻿namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filledRectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filledEllipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filledTriangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pentagonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filledPentagonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexagonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filledHexagonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filledPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relocateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ungroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.PointerButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ColorBucketButton = new System.Windows.Forms.ToolStripButton();
            this.ColorPickerButton = new System.Windows.Forms.ToolStripButton();
            this.RotateButton = new System.Windows.Forms.ToolStripButton();
            this.ResizeButton = new System.Windows.Forms.ToolStripButton();
            this.RelocateButton = new System.Windows.Forms.ToolStripButton();
            this.OpacityButton = new System.Windows.Forms.ToolStripButton();
            this.BorderButton = new System.Windows.Forms.ToolStripButton();
            this.GroupShapesButton = new System.Windows.Forms.ToolStripButton();
            this.UngroupShapesButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DrawRectangleButton = new System.Windows.Forms.ToolStripButton();
            this.DrawFilledRectangleButton = new System.Windows.Forms.ToolStripButton();
            this.DrawEllipseButton = new System.Windows.Forms.ToolStripButton();
            this.DrawFilledEllipseButton = new System.Windows.Forms.ToolStripButton();
            this.DrawTriangleButton = new System.Windows.Forms.ToolStripButton();
            this.DrawFilledTriangleButton = new System.Windows.Forms.ToolStripButton();
            this.DrawPentagonButton = new System.Windows.Forms.ToolStripButton();
            this.DrawFilledPentagonButton = new System.Windows.Forms.ToolStripButton();
            this.DrawHexagonButton = new System.Windows.Forms.ToolStripButton();
            this.DrawFilledHexagonButton = new System.Windows.Forms.ToolStripButton();
            this.DrawNPolygonButton = new System.Windows.Forms.ToolStripButton();
            this.DrawFilledNPolygonButton = new System.Windows.Forms.ToolStripButton();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(924, 28);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shapeToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.resizeToolStripMenuItem,
            this.relocateToolStripMenuItem,
            this.opacityToolStripMenuItem,
            this.borderToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.ungroupToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // shapeToolStripMenuItem
            // 
            this.shapeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem,
            this.filledRectangleToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.filledEllipseToolStripMenuItem,
            this.triangleToolStripMenuItem,
            this.filledTriangleToolStripMenuItem,
            this.pentagonToolStripMenuItem,
            this.filledPentagonToolStripMenuItem,
            this.hexagonToolStripMenuItem,
            this.filledHexagonToolStripMenuItem,
            this.polygonToolStripMenuItem,
            this.filledPolygonToolStripMenuItem});
            this.shapeToolStripMenuItem.Name = "shapeToolStripMenuItem";
            this.shapeToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.shapeToolStripMenuItem.Text = "New &Shape";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.R)));
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.RectangleToolStripMenuItem_Click);
            // 
            // filledRectangleToolStripMenuItem
            // 
            this.filledRectangleToolStripMenuItem.Name = "filledRectangleToolStripMenuItem";
            this.filledRectangleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.filledRectangleToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.filledRectangleToolStripMenuItem.Text = "Filled Rectangle";
            this.filledRectangleToolStripMenuItem.Click += new System.EventHandler(this.FilledRectangleToolStripMenuItem_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.E)));
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.EllipseToolStripMenuItem_Click);
            // 
            // filledEllipseToolStripMenuItem
            // 
            this.filledEllipseToolStripMenuItem.Name = "filledEllipseToolStripMenuItem";
            this.filledEllipseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.L)));
            this.filledEllipseToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.filledEllipseToolStripMenuItem.Text = "Filled Ellipse";
            this.filledEllipseToolStripMenuItem.Click += new System.EventHandler(this.FilledEllipseToolStripMenuItem_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.T)));
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.TriangleToolStripMenuItem_Click);
            // 
            // filledTriangleToolStripMenuItem
            // 
            this.filledTriangleToolStripMenuItem.Name = "filledTriangleToolStripMenuItem";
            this.filledTriangleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.G)));
            this.filledTriangleToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.filledTriangleToolStripMenuItem.Text = "Filled Triangle";
            this.filledTriangleToolStripMenuItem.Click += new System.EventHandler(this.FilledTriangleToolStripMenuItem_Click);
            // 
            // pentagonToolStripMenuItem
            // 
            this.pentagonToolStripMenuItem.Name = "pentagonToolStripMenuItem";
            this.pentagonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.P)));
            this.pentagonToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.pentagonToolStripMenuItem.Text = "Pentagon";
            this.pentagonToolStripMenuItem.Click += new System.EventHandler(this.PentagonToolStripMenuItem_Click);
            // 
            // filledPentagonToolStripMenuItem
            // 
            this.filledPentagonToolStripMenuItem.Name = "filledPentagonToolStripMenuItem";
            this.filledPentagonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.G)));
            this.filledPentagonToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.filledPentagonToolStripMenuItem.Text = "Filled Pentagon";
            this.filledPentagonToolStripMenuItem.Click += new System.EventHandler(this.FilledPentagonToolStripMenuItem_Click);
            // 
            // hexagonToolStripMenuItem
            // 
            this.hexagonToolStripMenuItem.Name = "hexagonToolStripMenuItem";
            this.hexagonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.H)));
            this.hexagonToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.hexagonToolStripMenuItem.Text = "Hexagon";
            this.hexagonToolStripMenuItem.Click += new System.EventHandler(this.HexagonToolStripMenuItem_Click);
            // 
            // filledHexagonToolStripMenuItem
            // 
            this.filledHexagonToolStripMenuItem.Name = "filledHexagonToolStripMenuItem";
            this.filledHexagonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.X)));
            this.filledHexagonToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.filledHexagonToolStripMenuItem.Text = "Filled Hexagon";
            this.filledHexagonToolStripMenuItem.Click += new System.EventHandler(this.FilledHexagonToolStripMenuItem_Click);
            // 
            // polygonToolStripMenuItem
            // 
            this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            this.polygonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.N)));
            this.polygonToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.polygonToolStripMenuItem.Text = "Polygon";
            this.polygonToolStripMenuItem.Click += new System.EventHandler(this.PolygonToolStripMenuItem_Click);
            // 
            // filledPolygonToolStripMenuItem
            // 
            this.filledPolygonToolStripMenuItem.Name = "filledPolygonToolStripMenuItem";
            this.filledPolygonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Y)));
            this.filledPolygonToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.filledPolygonToolStripMenuItem.Text = "Filled Polygon";
            this.filledPolygonToolStripMenuItem.Click += new System.EventHandler(this.FilledPolygonToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.colorToolStripMenuItem.Text = "&Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.ColorToolStripMenuItem_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.rotateToolStripMenuItem.Text = "&Rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.RotateToolStripMenuItem_Click);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.resizeToolStripMenuItem.Text = "R&esize";
            this.resizeToolStripMenuItem.Click += new System.EventHandler(this.ResizeToolStripMenuItem_Click);
            // 
            // relocateToolStripMenuItem
            // 
            this.relocateToolStripMenuItem.Name = "relocateToolStripMenuItem";
            this.relocateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.relocateToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.relocateToolStripMenuItem.Text = "Re&locate";
            this.relocateToolStripMenuItem.Click += new System.EventHandler(this.RelocateToolStripMenuItem_Click);
            // 
            // opacityToolStripMenuItem
            // 
            this.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
            this.opacityToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.opacityToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.opacityToolStripMenuItem.Text = "&Opacity";
            this.opacityToolStripMenuItem.Click += new System.EventHandler(this.OpacityToolStripMenuItem_Click);
            // 
            // borderToolStripMenuItem
            // 
            this.borderToolStripMenuItem.Name = "borderToolStripMenuItem";
            this.borderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.borderToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.borderToolStripMenuItem.Text = "&Border";
            this.borderToolStripMenuItem.Click += new System.EventHandler(this.BorderToolStripMenuItem_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.groupToolStripMenuItem.Text = "&Group";
            this.groupToolStripMenuItem.Click += new System.EventHandler(this.GroupToolStripMenuItem_Click);
            // 
            // ungroupToolStripMenuItem
            // 
            this.ungroupToolStripMenuItem.Name = "ungroupToolStripMenuItem";
            this.ungroupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.U)));
            this.ungroupToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.ungroupToolStripMenuItem.Text = "&Ungroup";
            this.ungroupToolStripMenuItem.Click += new System.EventHandler(this.UngroupToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 499);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(924, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // speedMenu
            // 
            this.speedMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PointerButton,
            this.toolStripSeparator2,
            this.ColorBucketButton,
            this.ColorPickerButton,
            this.RotateButton,
            this.ResizeButton,
            this.RelocateButton,
            this.OpacityButton,
            this.BorderButton,
            this.GroupShapesButton,
            this.UngroupShapesButton,
            this.toolStripSeparator1,
            this.DrawRectangleButton,
            this.DrawFilledRectangleButton,
            this.DrawEllipseButton,
            this.DrawFilledEllipseButton,
            this.DrawTriangleButton,
            this.DrawFilledTriangleButton,
            this.DrawPentagonButton,
            this.DrawFilledPentagonButton,
            this.DrawHexagonButton,
            this.DrawFilledHexagonButton,
            this.DrawNPolygonButton,
            this.DrawFilledNPolygonButton});
            this.speedMenu.Location = new System.Drawing.Point(0, 28);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(924, 27);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // PointerButton
            // 
            this.PointerButton.CheckOnClick = true;
            this.PointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PointerButton.Image = ((System.Drawing.Image)(resources.GetObject("PointerButton.Image")));
            this.PointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PointerButton.Name = "PointerButton";
            this.PointerButton.Size = new System.Drawing.Size(29, 24);
            this.PointerButton.Text = "toolStripButton1";
            this.PointerButton.ToolTipText = "Selector";
            this.PointerButton.Click += new System.EventHandler(this.PointerButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // ColorBucketButton
            // 
            this.ColorBucketButton.CheckOnClick = true;
            this.ColorBucketButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ColorBucketButton.Image = ((System.Drawing.Image)(resources.GetObject("ColorBucketButton.Image")));
            this.ColorBucketButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ColorBucketButton.Name = "ColorBucketButton";
            this.ColorBucketButton.Size = new System.Drawing.Size(29, 24);
            this.ColorBucketButton.Text = "toolStripButton1";
            this.ColorBucketButton.ToolTipText = "Color Fill";
            // 
            // ColorPickerButton
            // 
            this.ColorPickerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.ColorPickerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ColorPickerButton.Name = "ColorPickerButton";
            this.ColorPickerButton.Size = new System.Drawing.Size(29, 24);
            this.ColorPickerButton.Text = "toolStripButton1";
            this.ColorPickerButton.ToolTipText = "Color Picker";
            this.ColorPickerButton.Click += new System.EventHandler(this.SelectedColor_Click);
            // 
            // RotateButton
            // 
            this.RotateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RotateButton.Image = ((System.Drawing.Image)(resources.GetObject("RotateButton.Image")));
            this.RotateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(29, 24);
            this.RotateButton.Text = "toolStripButton1";
            this.RotateButton.ToolTipText = "Rotate";
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // ResizeButton
            // 
            this.ResizeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ResizeButton.Image = ((System.Drawing.Image)(resources.GetObject("ResizeButton.Image")));
            this.ResizeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResizeButton.Name = "ResizeButton";
            this.ResizeButton.Size = new System.Drawing.Size(29, 24);
            this.ResizeButton.Text = "toolStripButton2";
            this.ResizeButton.ToolTipText = "Resize";
            this.ResizeButton.Click += new System.EventHandler(this.ResizeButton_Click);
            // 
            // RelocateButton
            // 
            this.RelocateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RelocateButton.Image = ((System.Drawing.Image)(resources.GetObject("RelocateButton.Image")));
            this.RelocateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RelocateButton.Name = "RelocateButton";
            this.RelocateButton.Size = new System.Drawing.Size(29, 24);
            this.RelocateButton.Text = "toolStripButton3";
            this.RelocateButton.ToolTipText = "Relocate";
            this.RelocateButton.Click += new System.EventHandler(this.RelocateButton_Click);
            // 
            // OpacityButton
            // 
            this.OpacityButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpacityButton.Image = ((System.Drawing.Image)(resources.GetObject("OpacityButton.Image")));
            this.OpacityButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpacityButton.Name = "OpacityButton";
            this.OpacityButton.Size = new System.Drawing.Size(29, 24);
            this.OpacityButton.Text = "toolStripButton4";
            this.OpacityButton.ToolTipText = "Opacity";
            this.OpacityButton.Click += new System.EventHandler(this.OpacityButton_Click);
            // 
            // BorderButton
            // 
            this.BorderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BorderButton.Image = ((System.Drawing.Image)(resources.GetObject("BorderButton.Image")));
            this.BorderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BorderButton.Name = "BorderButton";
            this.BorderButton.Size = new System.Drawing.Size(29, 24);
            this.BorderButton.Text = "toolStripButton5";
            this.BorderButton.ToolTipText = "Border";
            this.BorderButton.Click += new System.EventHandler(this.BorderButton_Click);
            // 
            // GroupShapesButton
            // 
            this.GroupShapesButton.CheckOnClick = true;
            this.GroupShapesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GroupShapesButton.Image = ((System.Drawing.Image)(resources.GetObject("GroupShapesButton.Image")));
            this.GroupShapesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GroupShapesButton.Name = "GroupShapesButton";
            this.GroupShapesButton.Size = new System.Drawing.Size(29, 24);
            this.GroupShapesButton.Text = "toolStripButton1";
            this.GroupShapesButton.ToolTipText = "Group Shapes";
            this.GroupShapesButton.Click += new System.EventHandler(this.GroupShapesButton_Click);
            // 
            // UngroupShapesButton
            // 
            this.UngroupShapesButton.CheckOnClick = true;
            this.UngroupShapesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UngroupShapesButton.Image = ((System.Drawing.Image)(resources.GetObject("UngroupShapesButton.Image")));
            this.UngroupShapesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UngroupShapesButton.Name = "UngroupShapesButton";
            this.UngroupShapesButton.Size = new System.Drawing.Size(29, 24);
            this.UngroupShapesButton.Text = "toolStripButton2";
            this.UngroupShapesButton.ToolTipText = "Ungroup Shapes";
            this.UngroupShapesButton.Click += new System.EventHandler(this.UngroupShapesButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // DrawRectangleButton
            // 
            this.DrawRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawRectangleButton.Image")));
            this.DrawRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawRectangleButton.Name = "DrawRectangleButton";
            this.DrawRectangleButton.Size = new System.Drawing.Size(29, 24);
            this.DrawRectangleButton.Text = "Draw Rectangle";
            this.DrawRectangleButton.Click += new System.EventHandler(this.DrawRectangleButtonClick);
            // 
            // DrawFilledRectangleButton
            // 
            this.DrawFilledRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawFilledRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawFilledRectangleButton.Image")));
            this.DrawFilledRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawFilledRectangleButton.Name = "DrawFilledRectangleButton";
            this.DrawFilledRectangleButton.Size = new System.Drawing.Size(29, 24);
            this.DrawFilledRectangleButton.Text = "Draw Filled Rectangle";
            this.DrawFilledRectangleButton.Click += new System.EventHandler(this.DrawFilledRectangle_Click);
            // 
            // DrawEllipseButton
            // 
            this.DrawEllipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawEllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawEllipseButton.Image")));
            this.DrawEllipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawEllipseButton.Name = "DrawEllipseButton";
            this.DrawEllipseButton.Size = new System.Drawing.Size(29, 24);
            this.DrawEllipseButton.Text = "Draw Ellipse";
            this.DrawEllipseButton.Click += new System.EventHandler(this.DrawEllipse_Click);
            // 
            // DrawFilledEllipseButton
            // 
            this.DrawFilledEllipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawFilledEllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawFilledEllipseButton.Image")));
            this.DrawFilledEllipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawFilledEllipseButton.Name = "DrawFilledEllipseButton";
            this.DrawFilledEllipseButton.Size = new System.Drawing.Size(29, 24);
            this.DrawFilledEllipseButton.Text = "Draw Filled Ellipse";
            this.DrawFilledEllipseButton.Click += new System.EventHandler(this.DrawFilledEllipse_Click);
            // 
            // DrawTriangleButton
            // 
            this.DrawTriangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawTriangleButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawTriangleButton.Image")));
            this.DrawTriangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawTriangleButton.Name = "DrawTriangleButton";
            this.DrawTriangleButton.Size = new System.Drawing.Size(29, 24);
            this.DrawTriangleButton.Text = "toolStripButton1";
            this.DrawTriangleButton.ToolTipText = "Draw Triangle";
            this.DrawTriangleButton.Click += new System.EventHandler(this.DrawTriangleButton_Click);
            // 
            // DrawFilledTriangleButton
            // 
            this.DrawFilledTriangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawFilledTriangleButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawFilledTriangleButton.Image")));
            this.DrawFilledTriangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawFilledTriangleButton.Name = "DrawFilledTriangleButton";
            this.DrawFilledTriangleButton.Size = new System.Drawing.Size(29, 24);
            this.DrawFilledTriangleButton.Text = "toolStripButton2";
            this.DrawFilledTriangleButton.ToolTipText = "Draw Filled Triangle";
            this.DrawFilledTriangleButton.Click += new System.EventHandler(this.DrawFilledTriangleButton_Click);
            // 
            // DrawPentagonButton
            // 
            this.DrawPentagonButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawPentagonButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawPentagonButton.Image")));
            this.DrawPentagonButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawPentagonButton.Name = "DrawPentagonButton";
            this.DrawPentagonButton.Size = new System.Drawing.Size(29, 24);
            this.DrawPentagonButton.Text = "toolStripButton3";
            this.DrawPentagonButton.ToolTipText = "Draw Pentagon";
            this.DrawPentagonButton.Click += new System.EventHandler(this.DrawPentagonButton_Click);
            // 
            // DrawFilledPentagonButton
            // 
            this.DrawFilledPentagonButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawFilledPentagonButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawFilledPentagonButton.Image")));
            this.DrawFilledPentagonButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawFilledPentagonButton.Name = "DrawFilledPentagonButton";
            this.DrawFilledPentagonButton.Size = new System.Drawing.Size(29, 24);
            this.DrawFilledPentagonButton.Text = "toolStripButton4";
            this.DrawFilledPentagonButton.ToolTipText = "Draw Filled Pentagon";
            this.DrawFilledPentagonButton.Click += new System.EventHandler(this.DrawFilledPentagonButton_Click);
            // 
            // DrawHexagonButton
            // 
            this.DrawHexagonButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawHexagonButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawHexagonButton.Image")));
            this.DrawHexagonButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawHexagonButton.Name = "DrawHexagonButton";
            this.DrawHexagonButton.Size = new System.Drawing.Size(29, 24);
            this.DrawHexagonButton.Text = "toolStripButton5";
            this.DrawHexagonButton.ToolTipText = "Draw Hexagon";
            this.DrawHexagonButton.Click += new System.EventHandler(this.DrawHexagonButton_Click);
            // 
            // DrawFilledHexagonButton
            // 
            this.DrawFilledHexagonButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawFilledHexagonButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawFilledHexagonButton.Image")));
            this.DrawFilledHexagonButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawFilledHexagonButton.Name = "DrawFilledHexagonButton";
            this.DrawFilledHexagonButton.Size = new System.Drawing.Size(29, 24);
            this.DrawFilledHexagonButton.Text = "toolStripButton6";
            this.DrawFilledHexagonButton.ToolTipText = "Draw Filled Hexagon";
            this.DrawFilledHexagonButton.Click += new System.EventHandler(this.DrawFilledHexagonButton_Click);
            // 
            // DrawNPolygonButton
            // 
            this.DrawNPolygonButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawNPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawNPolygonButton.Image")));
            this.DrawNPolygonButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawNPolygonButton.Name = "DrawNPolygonButton";
            this.DrawNPolygonButton.Size = new System.Drawing.Size(29, 24);
            this.DrawNPolygonButton.Text = "toolStripButton7";
            this.DrawNPolygonButton.ToolTipText = "Draw N-sided Polygon";
            this.DrawNPolygonButton.Click += new System.EventHandler(this.DrawNPolygonButton_Click);
            // 
            // DrawFilledNPolygonButton
            // 
            this.DrawFilledNPolygonButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawFilledNPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawFilledNPolygonButton.Image")));
            this.DrawFilledNPolygonButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawFilledNPolygonButton.Name = "DrawFilledNPolygonButton";
            this.DrawFilledNPolygonButton.Size = new System.Drawing.Size(29, 24);
            this.DrawFilledNPolygonButton.Text = "toolStripButton8";
            this.DrawFilledNPolygonButton.ToolTipText = "Draw Filled N-sides Polygon";
            this.DrawFilledNPolygonButton.Click += new System.EventHandler(this.DrawFilledNPolygonButton_Click);
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(0, 55);
            this.viewPort.Margin = new System.Windows.Forms.Padding(5);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(924, 444);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 521);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Draw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton PointerButton;
		private System.Windows.Forms.ToolStripButton DrawRectangleButton;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton ColorBucketButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton DrawFilledRectangleButton;
        private System.Windows.Forms.ToolStripButton DrawEllipseButton;
        private System.Windows.Forms.ToolStripButton DrawFilledEllipseButton;
        private System.Windows.Forms.ToolStripButton ColorPickerButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relocateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filledRectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filledEllipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opacityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filledTriangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton RotateButton;
        private System.Windows.Forms.ToolStripButton ResizeButton;
        private System.Windows.Forms.ToolStripButton RelocateButton;
        private System.Windows.Forms.ToolStripButton OpacityButton;
        private System.Windows.Forms.ToolStripButton BorderButton;
        private System.Windows.Forms.ToolStripMenuItem pentagonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filledPentagonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexagonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filledHexagonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filledPolygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton DrawTriangleButton;
        private System.Windows.Forms.ToolStripButton DrawFilledTriangleButton;
        private System.Windows.Forms.ToolStripButton DrawPentagonButton;
        private System.Windows.Forms.ToolStripButton DrawFilledPentagonButton;
        private System.Windows.Forms.ToolStripButton DrawHexagonButton;
        private System.Windows.Forms.ToolStripButton DrawFilledHexagonButton;
        private System.Windows.Forms.ToolStripButton DrawNPolygonButton;
        private System.Windows.Forms.ToolStripButton DrawFilledNPolygonButton;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ungroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton GroupShapesButton;
        private System.Windows.Forms.ToolStripButton UngroupShapesButton;
    }
}
