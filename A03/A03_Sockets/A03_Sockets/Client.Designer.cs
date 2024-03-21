namespace A03_Sockets
{
    partial class MainForm
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
            this._btn = new System.Windows.Forms.Button();
            this.UI_SendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btn
            // 
            this._btn.Location = new System.Drawing.Point(22, 12);
            this._btn.Name = "_btn";
            this._btn.Size = new System.Drawing.Size(75, 23);
            this._btn.TabIndex = 0;
            this._btn.Text = "Connect";
            this._btn.UseVisualStyleBackColor = true;
            this._btn.Click += new System.EventHandler(this._btn_Click);
            // 
            // UI_SendBtn
            // 
            this.UI_SendBtn.Location = new System.Drawing.Point(413, 51);
            this.UI_SendBtn.Name = "UI_SendBtn";
            this.UI_SendBtn.Size = new System.Drawing.Size(75, 23);
            this.UI_SendBtn.TabIndex = 1;
            this.UI_SendBtn.Text = "Send Data :)";
            this.UI_SendBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UI_SendBtn);
            this.Controls.Add(this._btn);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btn;
        private System.Windows.Forms.Button UI_SendBtn;
    }
}

