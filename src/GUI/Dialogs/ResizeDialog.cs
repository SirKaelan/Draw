using System.Windows.Forms;

namespace Draw.src.GUI.Dialogs
{
    public class ResizeDialog : Form
    {
        private Button OkButton;
        private NumericUpDown WidthInput;
        private NumericUpDown HeightInput;
        private Label WidthLabel;
        private Label HeightLabel;
        private Button CancelActionButton;

        public ResizeDialog()
        {
            InitializeComponent();
        }

        public ResizeDialog(int initialWidth, int initialHeigh)
            : this()
        {
            WidthInput.Value = initialWidth;
            HeightInput.Value = initialHeigh;
        }

        public int ShapeWidth { get { return (int)WidthInput.Value; } }

        public int ShapeHeight { get { return (int)HeightInput.Value; } }

        #region Initialization
        private void InitializeComponent()
        {
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelActionButton = new System.Windows.Forms.Button();
            this.WidthInput = new System.Windows.Forms.NumericUpDown();
            this.HeightInput = new System.Windows.Forms.NumericUpDown();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WidthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightInput)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(49, 190);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelActionButton
            // 
            this.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelActionButton.Location = new System.Drawing.Point(148, 190);
            this.CancelActionButton.Name = "CancelActionButton";
            this.CancelActionButton.Size = new System.Drawing.Size(75, 23);
            this.CancelActionButton.TabIndex = 1;
            this.CancelActionButton.Text = "Cancel";
            this.CancelActionButton.UseVisualStyleBackColor = true;
            // 
            // WidthInput
            // 
            this.WidthInput.Location = new System.Drawing.Point(103, 62);
            this.WidthInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.WidthInput.Name = "WidthInput";
            this.WidthInput.Size = new System.Drawing.Size(120, 22);
            this.WidthInput.TabIndex = 2;
            // 
            // HeightInput
            // 
            this.HeightInput.Location = new System.Drawing.Point(103, 108);
            this.HeightInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.HeightInput.Name = "HeightInput";
            this.HeightInput.Size = new System.Drawing.Size(120, 22);
            this.HeightInput.TabIndex = 3;
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(46, 64);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(48, 17);
            this.WidthLabel.TabIndex = 4;
            this.WidthLabel.Text = "Width:";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(46, 110);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(53, 17);
            this.HeightLabel.TabIndex = 5;
            this.HeightLabel.Text = "Height:";
            // 
            // ResizeDialog
            // 
            this.AcceptButton = this.OkButton;
            this.CancelButton = this.CancelActionButton;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.HeightInput);
            this.Controls.Add(this.WidthInput);
            this.Controls.Add(this.CancelActionButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResizeDialog";
            this.ShowInTaskbar = false;
            this.Text = "Resize";
            ((System.ComponentModel.ISupportInitialize)(this.WidthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
