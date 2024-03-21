namespace SocketyStuffA02
{
    partial class ClientForm
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
            this._ConnectButton = new System.Windows.Forms.Button();
            this.UI_btn_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _ConnectButton
            // 
            this._ConnectButton.Location = new System.Drawing.Point(42, 36);
            this._ConnectButton.Name = "_ConnectButton";
            this._ConnectButton.Size = new System.Drawing.Size(75, 23);
            this._ConnectButton.TabIndex = 0;
            this._ConnectButton.Text = "Connect";
            this._ConnectButton.UseVisualStyleBackColor = true;
            // 
            // UI_btn_send
            // 
            this.UI_btn_send.Location = new System.Drawing.Point(286, 135);
            this.UI_btn_send.Name = "UI_btn_send";
            this.UI_btn_send.Size = new System.Drawing.Size(75, 23);
            this.UI_btn_send.TabIndex = 1;
            this.UI_btn_send.Text = "Send";
            this.UI_btn_send.UseVisualStyleBackColor = true;
            this.UI_btn_send.Click += new System.EventHandler(this.UI_btn_send_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UI_btn_send);
            this.Controls.Add(this._ConnectButton);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _ConnectButton;
        private System.Windows.Forms.Button UI_btn_send;
    }
}

