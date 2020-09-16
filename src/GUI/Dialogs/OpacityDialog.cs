using System.Windows.Forms;

namespace Draw.src.GUI.Dialogs
{
    public class OpacityDialog : Form
    {
        private Label OpacityLabel;
        private Button OkButton;
        private Button CancelActionButton;
        private NumericUpDown OpacityInput;

        public OpacityDialog()
        {
            InitializeComponent();
        }

        public OpacityDialog(int initialOpacity)
            : this()
        {
            OpacityInput.Value = initialOpacity;
        }

        public int ShapeOpacity => (int)OpacityInput.Value;

        #region Initialize
        private void InitializeComponent()
        {
            this.OpacityInput = new System.Windows.Forms.NumericUpDown();
            this.OpacityLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelActionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityInput)).BeginInit();
            this.SuspendLayout();
            // 
            // OpacityInput
            // 
            this.OpacityInput.Location = new System.Drawing.Point(165, 50);
            this.OpacityInput.Name = "OpacityInput";
            this.OpacityInput.Size = new System.Drawing.Size(69, 22);
            this.OpacityInput.TabIndex = 0;
            // 
            // OpacityLabel
            // 
            this.OpacityLabel.AutoSize = true;
            this.OpacityLabel.Location = new System.Drawing.Point(42, 52);
            this.OpacityLabel.Name = "OpacityLabel";
            this.OpacityLabel.Size = new System.Drawing.Size(111, 17);
            this.OpacityLabel.TabIndex = 1;
            this.OpacityLabel.Text = "Opacity (0-100):";
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(45, 123);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 39);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelActionButton
            // 
            this.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelActionButton.Location = new System.Drawing.Point(159, 123);
            this.CancelActionButton.Name = "CancelActionButton";
            this.CancelActionButton.Size = new System.Drawing.Size(75, 39);
            this.CancelActionButton.TabIndex = 3;
            this.CancelActionButton.Text = "Cancel";
            this.CancelActionButton.UseVisualStyleBackColor = true;
            // 
            // OpacityDialog
            // 
            this.AcceptButton = this.OkButton;
            this.CancelButton = this.CancelActionButton;
            this.ClientSize = new System.Drawing.Size(282, 198);
            this.Controls.Add(this.CancelActionButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.OpacityLabel);
            this.Controls.Add(this.OpacityInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpacityDialog";
            this.ShowInTaskbar = false;
            this.Text = "Opacity";
            ((System.ComponentModel.ISupportInitialize)(this.OpacityInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
