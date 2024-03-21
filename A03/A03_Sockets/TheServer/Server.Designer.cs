namespace TheServer
{
    partial class ServerForm
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
            this.UI_CB_Enable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // UI_CB_Enable
            // 
            this.UI_CB_Enable.AutoSize = true;
            this.UI_CB_Enable.Location = new System.Drawing.Point(230, 109);
            this.UI_CB_Enable.Name = "UI_CB_Enable";
            this.UI_CB_Enable.Size = new System.Drawing.Size(99, 17);
            this.UI_CB_Enable.TabIndex = 1;
            this.UI_CB_Enable.Text = "Server Enabled";
            this.UI_CB_Enable.UseVisualStyleBackColor = true;
            this.UI_CB_Enable.CheckedChanged += new System.EventHandler(this.UI_CB_Enable_CheckedChanged);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UI_CB_Enable);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox UI_CB_Enable;
    }
}

