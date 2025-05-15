namespace QTE_Project
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPerfect;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnStart;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblPerfect = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPerfect
            // 
            this.lblPerfect.AutoSize = true;
            this.lblPerfect.Font = new System.Drawing.Font("Microsoft YaHei", 18F);
            this.lblPerfect.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblPerfect.Location = new System.Drawing.Point(100, 50);
            this.lblPerfect.Name = "lblPerfect";
            this.lblPerfect.Size = new System.Drawing.Size(120, 31);
            this.lblPerfect.TabIndex = 0;
            this.lblPerfect.Text = "Perfect!";
            this.lblPerfect.Visible = false;
            // 
            // lblTimer
            // 
        
            // 
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblPerfect);
            this.Name = "Form1";
            this.Text = "QTE Mini Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

            //
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPerfect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(100, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // lblPerfect
            // 
            this.lblPerfect.AutoSize = true;
            this.lblPerfect.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.lblPerfect.Location = new System.Drawing.Point(220, 20);
            this.lblPerfect.Name = "lblPerfect";
            this.lblPerfect.Size = new System.Drawing.Size(60, 21);
            this.lblPerfect.Text = "Perfect!";
            this.lblPerfect.Visible = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblPerfect);
            this.Name = "Form1";
            this.Text = "QTE Training model";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
