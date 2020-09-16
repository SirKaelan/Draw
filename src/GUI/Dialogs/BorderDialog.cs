using System.Drawing;
using System.Windows.Forms;

namespace Draw.src.GUI.Dialogs
{
    public class BorderDialog : Form
    {
        private Button ColorPickerButton;
        private NumericUpDown BorderWidthInput;
        private ColorDialog ColorPickerDialog;
        private Label BorderWidthLabel;
        private Label BorderColorLabel;
        private Button OkButton;
        private Button CancelActionButton;

        public BorderDialog()
        {
            InitializeComponent();
        }

        public BorderDialog(float initialBorderWidth, Color initialColor)
            : this()
        {
            BorderWidthInput.Value = (decimal)initialBorderWidth;
            ColorPickerDialog.Color = initialColor;
            ColorPickerButton.BackColor = initialColor;
        }

        public float BorderWidth => (float)BorderWidthInput.Value;

        public Color BorderColor => ColorPickerDialog.Color;

        #region Initialize
        private void InitializeComponent()
        {
            this.BorderWidthInput = new System.Windows.Forms.NumericUpDown();
            this.BorderWidthLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelActionButton = new System.Windows.Forms.Button();
            this.ColorPickerDialog = new System.Windows.Forms.ColorDialog();
            this.BorderColorLabel = new System.Windows.Forms.Label();
            this.ColorPickerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BorderWidthInput)).BeginInit();
            this.SuspendLayout();
            // 
            // BorderWidthInput
            // 
            this.BorderWidthInput.Location = new System.Drawing.Point(143, 58);
            this.BorderWidthInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.BorderWidthInput.Name = "BorderWidthInput";
            this.BorderWidthInput.Size = new System.Drawing.Size(95, 22);
            this.BorderWidthInput.TabIndex = 0;
            // 
            // BorderWidthLabel
            // 
            this.BorderWidthLabel.AutoSize = true;
            this.BorderWidthLabel.Location = new System.Drawing.Point(42, 60);
            this.BorderWidthLabel.Name = "BorderWidthLabel";
            this.BorderWidthLabel.Size = new System.Drawing.Size(95, 17);
            this.BorderWidthLabel.TabIndex = 1;
            this.BorderWidthLabel.Text = "Border Width:";
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(45, 188);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 37);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelActionButton
            // 
            this.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelActionButton.Location = new System.Drawing.Point(163, 188);
            this.CancelActionButton.Name = "CancelActionButton";
            this.CancelActionButton.Size = new System.Drawing.Size(75, 37);
            this.CancelActionButton.TabIndex = 3;
            this.CancelActionButton.Text = "Cancel";
            this.CancelActionButton.UseVisualStyleBackColor = true;
            // 
            // BorderColorLabel
            // 
            this.BorderColorLabel.AutoSize = true;
            this.BorderColorLabel.Location = new System.Drawing.Point(42, 110);
            this.BorderColorLabel.Name = "BorderColorLabel";
            this.BorderColorLabel.Size = new System.Drawing.Size(92, 17);
            this.BorderColorLabel.TabIndex = 4;
            this.BorderColorLabel.Text = "Border Color:";
            // 
            // ColorPickerButton
            // 
            this.ColorPickerButton.Location = new System.Drawing.Point(143, 107);
            this.ColorPickerButton.Name = "ColorPickerButton";
            this.ColorPickerButton.Size = new System.Drawing.Size(95, 23);
            this.ColorPickerButton.TabIndex = 5;
            this.ColorPickerButton.UseVisualStyleBackColor = true;
            this.ColorPickerButton.Click += new System.EventHandler(this.ColorPickerButton_Click);
            // 
            // BorderDialog
            // 
            this.AcceptButton = this.OkButton;
            this.CancelButton = this.CancelActionButton;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.ColorPickerButton);
            this.Controls.Add(this.BorderColorLabel);
            this.Controls.Add(this.CancelActionButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.BorderWidthLabel);
            this.Controls.Add(this.BorderWidthInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorderDialog";
            this.ShowInTaskbar = false;
            this.Text = "Border";
            ((System.ComponentModel.ISupportInitialize)(this.BorderWidthInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void ColorPickerButton_Click(object sender, System.EventArgs e)
        {
            if (ColorPickerDialog.ShowDialog() == DialogResult.OK)
            {
                ColorPickerButton.BackColor = ColorPickerDialog.Color;
            }
        }
    }
}
