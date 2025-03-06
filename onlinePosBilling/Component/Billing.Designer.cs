
namespace onlinePosBilling.Component
{
    partial class Billing
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
            this.store = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // store
            // 
            this.store.AutoSize = true;
            this.store.Location = new System.Drawing.Point(193, 74);
            this.store.Name = "store";
            this.store.Size = new System.Drawing.Size(32, 13);
            this.store.TabIndex = 0;
            this.store.Text = "Store";
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Location = new System.Drawing.Point(49, 74);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(57, 13);
            this.user.TabIndex = 1;
            this.user.Text = "UserName";
            // 
            // Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 631);
            this.Controls.Add(this.user);
            this.Controls.Add(this.store);
            this.Name = "Billing";
            this.Text = "Billing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label store;
        private System.Windows.Forms.Label user;
    }
}