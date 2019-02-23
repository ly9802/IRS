namespace _647project
{
    partial class Formofabstract
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
            this.AbtractBox = new System.Windows.Forms.TextBox();
            this.labelofabstract = new System.Windows.Forms.Label();
            this.Button_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AbtractBox
            // 
            this.AbtractBox.Location = new System.Drawing.Point(21, 54);
            this.AbtractBox.Multiline = true;
            this.AbtractBox.Name = "AbtractBox";
            this.AbtractBox.Size = new System.Drawing.Size(753, 346);
            this.AbtractBox.TabIndex = 0;
            // 
            // labelofabstract
            // 
            this.labelofabstract.AutoSize = true;
            this.labelofabstract.Location = new System.Drawing.Point(19, 24);
            this.labelofabstract.Name = "labelofabstract";
            this.labelofabstract.Size = new System.Drawing.Size(101, 12);
            this.labelofabstract.TabIndex = 1;
            this.labelofabstract.Text = "Abstract Details";
            // 
            // Button_Close
            // 
            this.Button_Close.Location = new System.Drawing.Point(699, 415);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(75, 23);
            this.Button_Close.TabIndex = 2;
            this.Button_Close.Text = "Close";
            this.Button_Close.UseVisualStyleBackColor = true;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // Formofabstract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.labelofabstract);
            this.Controls.Add(this.AbtractBox);
            this.Name = "Formofabstract";
            this.Text = "Formofabstract";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox AbtractBox;
        private System.Windows.Forms.Button Button_Close;
        public System.Windows.Forms.Label labelofabstract;
    }
}