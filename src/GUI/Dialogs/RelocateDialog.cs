using System.Windows.Forms;

namespace Draw.src.GUI.Dialogs
{
    public class RelocateDialog : Form
    {
        private Button OkButton;
        private Button CancelActionButton;
        private NumericUpDown XInput;
        private NumericUpDown YInput;
        private Label XLabel;
        private Label YLabel;

        public RelocateDialog()
        {
            InitializeComponent();
        }

        public RelocateDialog(int initialX, int initialY)
            : this()
        {
            XInput.Value = initialX;
            YInput.Value = initialY;
        }

        public int XCoord => (int)XInput.Value;

        public int YCoord => (int)YInput.Value;

        #region Initialize
        private void InitializeComponent()
        {
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelActionButton = new System.Windows.Forms.Button();
            this.XInput = new System.Windows.Forms.NumericUpDown();
            this.YInput = new System.Windows.Forms.NumericUpDown();
            this.XLabel = new System.Windows.Forms.Label();
            this.YLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.XInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YInput)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(42, 173);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 36);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelActionButton
            // 
            this.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelActionButton.Location = new System.Drawing.Point(157, 173);
            this.CancelActionButton.Name = "CancelActionButton";
            this.CancelActionButton.Size = new System.Drawing.Size(75, 36);
            this.CancelActionButton.TabIndex = 1;
            this.CancelActionButton.Text = "Cancel";
            this.CancelActionButton.UseVisualStyleBackColor = true;
            // 
            // XInput
            // 
            this.XInput.Location = new System.Drawing.Point(112, 54);
            this.XInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.XInput.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.XInput.Name = "XInput";
            this.XInput.Size = new System.Drawing.Size(120, 22);
            this.XInput.TabIndex = 2;
            // 
            // YInput
            // 
            this.YInput.Location = new System.Drawing.Point(112, 104);
            this.YInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.YInput.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.YInput.Name = "YInput";
            this.YInput.Size = new System.Drawing.Size(120, 22);
            this.YInput.TabIndex = 3;
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(39, 56);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(21, 17);
            this.XLabel.TabIndex = 4;
            this.XLabel.Text = "X:";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Location = new System.Drawing.Point(39, 106);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(21, 17);
            this.YLabel.TabIndex = 5;
            this.YLabel.Text = "Y:";
            // 
            // RelocateDialog
            // 
            this.AcceptButton = this.OkButton;
            this.CancelButton = this.CancelActionButton;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.YLabel);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.YInput);
            this.Controls.Add(this.XInput);
            this.Controls.Add(this.CancelActionButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelocateDialog";
            this.ShowInTaskbar = false;
            this.Text = "Relocate";
            ((System.ComponentModel.ISupportInitialize)(this.XInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
