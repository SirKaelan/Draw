using System.Windows.Forms;

namespace Draw.src.GUI.Dialogs
{
    public class RotateDialog : Form
    {
        private Label DegreesLabel;
        private NumericUpDown RotationInput;
        private Button OkButton;
        private Button CancelActionButton;

        public RotateDialog()
        {
            InitializeComponent();
        }

        public RotateDialog(float currentRotation)
            : this()
        {
            RotationInput.Value = (decimal)currentRotation;
        }

        public float Degrees => (float)RotationInput.Value;

        #region Initialization
        private void InitializeComponent()
        {
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelActionButton = new System.Windows.Forms.Button();
            this.RotationInput = new System.Windows.Forms.NumericUpDown();
            this.DegreesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RotationInput)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(47, 110);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelActionButton
            // 
            this.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelActionButton.Location = new System.Drawing.Point(161, 110);
            this.CancelActionButton.Name = "CancelActionButton";
            this.CancelActionButton.Size = new System.Drawing.Size(75, 23);
            this.CancelActionButton.TabIndex = 1;
            this.CancelActionButton.Text = "Cancel";
            this.CancelActionButton.UseVisualStyleBackColor = true;
            // 
            // RotationInput
            // 
            this.RotationInput.Location = new System.Drawing.Point(116, 50);
            this.RotationInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RotationInput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.RotationInput.Name = "RotationInput";
            this.RotationInput.Size = new System.Drawing.Size(120, 22);
            this.RotationInput.TabIndex = 2;
            // 
            // DegreesLabel
            // 
            this.DegreesLabel.AutoSize = true;
            this.DegreesLabel.Location = new System.Drawing.Point(44, 52);
            this.DegreesLabel.Name = "DegreesLabel";
            this.DegreesLabel.Size = new System.Drawing.Size(66, 17);
            this.DegreesLabel.TabIndex = 3;
            this.DegreesLabel.Text = "Degrees:";
            // 
            // RotateDialog
            // 
            this.AcceptButton = this.OkButton;
            this.CancelButton = this.CancelActionButton;
            this.ClientSize = new System.Drawing.Size(282, 184);
            this.Controls.Add(this.DegreesLabel);
            this.Controls.Add(this.RotationInput);
            this.Controls.Add(this.CancelActionButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RotateDialog";
            this.ShowInTaskbar = false;
            this.Text = "Rotate";
            ((System.ComponentModel.ISupportInitialize)(this.RotationInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
