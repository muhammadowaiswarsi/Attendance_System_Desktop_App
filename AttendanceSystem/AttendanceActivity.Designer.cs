namespace AttendanceSystem
{
    partial class AttendanceActivity
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
            this.btn_checkin = new System.Windows.Forms.Button();
            this.btn_checkout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_checkin
            // 
            this.btn_checkin.BackColor = System.Drawing.Color.White;
            this.btn_checkin.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_checkin.ForeColor = System.Drawing.Color.Black;
            this.btn_checkin.Location = new System.Drawing.Point(12, 12);
            this.btn_checkin.Name = "btn_checkin";
            this.btn_checkin.Size = new System.Drawing.Size(328, 106);
            this.btn_checkin.TabIndex = 3;
            this.btn_checkin.Text = "CHECK IN";
            this.btn_checkin.UseVisualStyleBackColor = false;
            this.btn_checkin.Click += new System.EventHandler(this.btn_checkin_Click);
            // 
            // btn_checkout
            // 
            this.btn_checkout.BackColor = System.Drawing.Color.White;
            this.btn_checkout.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_checkout.ForeColor = System.Drawing.Color.Black;
            this.btn_checkout.Location = new System.Drawing.Point(12, 124);
            this.btn_checkout.Name = "btn_checkout";
            this.btn_checkout.Size = new System.Drawing.Size(328, 106);
            this.btn_checkout.TabIndex = 4;
            this.btn_checkout.Text = "CHECK OUT";
            this.btn_checkout.UseVisualStyleBackColor = false;
            this.btn_checkout.Click += new System.EventHandler(this.btn_checkout_Click);
            // 
            // AttendanceActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(352, 251);
            this.Controls.Add(this.btn_checkout);
            this.Controls.Add(this.btn_checkin);
            this.MaximumSize = new System.Drawing.Size(368, 290);
            this.MinimumSize = new System.Drawing.Size(368, 290);
            this.Name = "AttendanceActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATTENDANCE";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_checkin;
        private Button btn_checkout;
    }
}