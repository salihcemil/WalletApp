namespace WalletApp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_address = new System.Windows.Forms.Label();
            this.lbl_balanceHeader = new System.Windows.Forms.Label();
            this.lbl_balance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_receiverAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_amount = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_refreshBalance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.Location = new System.Drawing.Point(140, 9);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(79, 16);
            this.lbl_address.TabIndex = 1;
            this.lbl_address.Text = "lbl_address";
            // 
            // lbl_balanceHeader
            // 
            this.lbl_balanceHeader.AutoSize = true;
            this.lbl_balanceHeader.Location = new System.Drawing.Point(70, 39);
            this.lbl_balanceHeader.Name = "lbl_balanceHeader";
            this.lbl_balanceHeader.Size = new System.Drawing.Size(64, 16);
            this.lbl_balanceHeader.TabIndex = 2;
            this.lbl_balanceHeader.Text = "Balance :";
            this.lbl_balanceHeader.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_balance
            // 
            this.lbl_balance.AutoSize = true;
            this.lbl_balance.Location = new System.Drawing.Point(140, 39);
            this.lbl_balance.Name = "lbl_balance";
            this.lbl_balance.Size = new System.Drawing.Size(0, 16);
            this.lbl_balance.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Receiver Address :";
            // 
            // tb_receiverAddress
            // 
            this.tb_receiverAddress.Location = new System.Drawing.Point(143, 80);
            this.tb_receiverAddress.Name = "tb_receiverAddress";
            this.tb_receiverAddress.Size = new System.Drawing.Size(513, 22);
            this.tb_receiverAddress.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Amount :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tb_amount
            // 
            this.tb_amount.Location = new System.Drawing.Point(143, 118);
            this.tb_amount.Name = "tb_amount";
            this.tb_amount.Size = new System.Drawing.Size(118, 22);
            this.tb_amount.TabIndex = 7;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(538, 168);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(118, 23);
            this.btn_send.TabIndex = 8;
            this.btn_send.Text = "SEND";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_refreshBalance
            // 
            this.btn_refreshBalance.Location = new System.Drawing.Point(308, 32);
            this.btn_refreshBalance.Name = "btn_refreshBalance";
            this.btn_refreshBalance.Size = new System.Drawing.Size(118, 23);
            this.btn_refreshBalance.TabIndex = 9;
            this.btn_refreshBalance.Text = "Refresh Balance";
            this.btn_refreshBalance.UseVisualStyleBackColor = true;
            this.btn_refreshBalance.Click += new System.EventHandler(this.btn_refreshBalance_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 207);
            this.Controls.Add(this.btn_refreshBalance);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.tb_amount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_receiverAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_balance);
            this.Controls.Add(this.lbl_balanceHeader);
            this.Controls.Add(this.lbl_address);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.Label lbl_balanceHeader;
        private System.Windows.Forms.Label lbl_balance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_receiverAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_amount;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_refreshBalance;
    }
}

