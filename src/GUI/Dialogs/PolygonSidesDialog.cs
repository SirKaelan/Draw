using System.Windows.Forms;

namespace Draw.src.GUI.Dialogs
{
    public class PolygonSidesDialog : Form
    {
        private Label SidesLabel;
        private NumericUpDown SidesInput;
        private Button OkButton;
        private Button CancelActionButton;

        public PolygonSidesDialog()
        {
            InitializeComponent();
        }

        public int Sides => (int)SidesInput.Value;

        #region Initialize
        private void InitializeComponent()
        {
            this.SidesLabel = new System.Windows.Forms.Label();
            this.SidesInput = new System.Windows.Forms.NumericUpDown();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelActionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SidesInput)).BeginInit();
            this.SuspendLayout();
            // 
            // SidesLabel
            // 
            this.SidesLabel.AutoSize = true;
            this.SidesLabel.Location = new System.Drawing.Point(39, 69);
            this.SidesLabel.Name = "SidesLabel";
            this.SidesLabel.Size = new System.Drawing.Size(47, 17);
            this.SidesLabel.TabIndex = 0;
            this.SidesLabel.Text = "Sides:";
            // 
            // SidesInput
            // 
            this.SidesInput.Location = new System.Drawing.Point(116, 67);
            this.SidesInput.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.SidesInput.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.SidesInput.Name = "SidesInput";
            this.SidesInput.Size = new System.Drawing.Size(120, 22);
            this.SidesInput.TabIndex = 1;
            this.SidesInput.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(42, 158);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 46);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelActionButton
            // 
            this.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelActionButton.Location = new System.Drawing.Point(161, 158);
            this.CancelActionButton.Name = "CancelActionButton";
            this.CancelActionButton.Size = new System.Drawing.Size(75, 46);
            this.CancelActionButton.TabIndex = 3;
            this.CancelActionButton.Text = "Cancel";
            this.CancelActionButton.UseVisualStyleBackColor = true;
            // 
            // PolygonSidesDialog
            // 
            this.AcceptButton = this.OkButton;
            this.CancelButton = this.CancelActionButton;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.CancelActionButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.SidesInput);
            this.Controls.Add(this.SidesLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PolygonSidesDialog";
            this.ShowInTaskbar = false;
            this.Text = "Polygon Sides";
            ((System.ComponentModel.ISupportInitialize)(this.SidesInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
