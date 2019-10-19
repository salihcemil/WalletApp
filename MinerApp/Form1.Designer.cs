namespace MinerApp
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
            this.lbl_transactionsList = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_validate = new System.Windows.Forms.Button();
            this.btn_mine = new System.Windows.Forms.Button();
            this.listBox_minedBlocks = new System.Windows.Forms.ListBox();
            this.btn_publishBlock = new System.Windows.Forms.Button();
            this.datagrid_incomingTrx = new System.Windows.Forms.DataGridView();
            this.datagrid_validTrx = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_incomingTrx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_validTrx)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_transactionsList
            // 
            this.lbl_transactionsList.AutoSize = true;
            this.lbl_transactionsList.Location = new System.Drawing.Point(7, 16);
            this.lbl_transactionsList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_transactionsList.Name = "lbl_transactionsList";
            this.lbl_transactionsList.Size = new System.Drawing.Size(114, 13);
            this.lbl_transactionsList.TabIndex = 2;
            this.lbl_transactionsList.Text = "Incoming Transactions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Valid Transactions";
            // 
            // btn_validate
            // 
            this.btn_validate.Location = new System.Drawing.Point(500, 102);
            this.btn_validate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_validate.Name = "btn_validate";
            this.btn_validate.Size = new System.Drawing.Size(62, 19);
            this.btn_validate.TabIndex = 4;
            this.btn_validate.Text = "Validate>>";
            this.btn_validate.UseVisualStyleBackColor = true;
            this.btn_validate.Click += new System.EventHandler(this.btn_validate_Click);
            // 
            // btn_mine
            // 
            this.btn_mine.Location = new System.Drawing.Point(960, 196);
            this.btn_mine.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_mine.Name = "btn_mine";
            this.btn_mine.Size = new System.Drawing.Size(91, 19);
            this.btn_mine.TabIndex = 5;
            this.btn_mine.Text = "Mine";
            this.btn_mine.UseVisualStyleBackColor = true;
            this.btn_mine.Click += new System.EventHandler(this.btn_mine_Click);
            // 
            // listBox_minedBlocks
            // 
            this.listBox_minedBlocks.FormattingEnabled = true;
            this.listBox_minedBlocks.Location = new System.Drawing.Point(9, 231);
            this.listBox_minedBlocks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox_minedBlocks.Name = "listBox_minedBlocks";
            this.listBox_minedBlocks.Size = new System.Drawing.Size(1046, 173);
            this.listBox_minedBlocks.TabIndex = 6;
            // 
            // btn_publishBlock
            // 
            this.btn_publishBlock.Location = new System.Drawing.Point(963, 408);
            this.btn_publishBlock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_publishBlock.Name = "btn_publishBlock";
            this.btn_publishBlock.Size = new System.Drawing.Size(91, 19);
            this.btn_publishBlock.TabIndex = 7;
            this.btn_publishBlock.Text = "Publish";
            this.btn_publishBlock.UseVisualStyleBackColor = true;
            this.btn_publishBlock.Click += new System.EventHandler(this.btn_publishBlock_Click);
            // 
            // datagrid_incomingTrx
            // 
            this.datagrid_incomingTrx.AllowUserToAddRows = false;
            this.datagrid_incomingTrx.AllowUserToDeleteRows = false;
            this.datagrid_incomingTrx.AllowUserToResizeRows = false;
            this.datagrid_incomingTrx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrid_incomingTrx.BackgroundColor = System.Drawing.SystemColors.Control;
            this.datagrid_incomingTrx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_incomingTrx.Location = new System.Drawing.Point(9, 32);
            this.datagrid_incomingTrx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.datagrid_incomingTrx.Name = "datagrid_incomingTrx";
            this.datagrid_incomingTrx.ReadOnly = true;
            this.datagrid_incomingTrx.RowTemplate.Height = 24;
            this.datagrid_incomingTrx.Size = new System.Drawing.Size(487, 159);
            this.datagrid_incomingTrx.TabIndex = 8;
            // 
            // datagrid_validTrx
            // 
            this.datagrid_validTrx.BackgroundColor = System.Drawing.SystemColors.Control;
            this.datagrid_validTrx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_validTrx.Location = new System.Drawing.Point(567, 32);
            this.datagrid_validTrx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.datagrid_validTrx.Name = "datagrid_validTrx";
            this.datagrid_validTrx.RowTemplate.Height = 24;
            this.datagrid_validTrx.Size = new System.Drawing.Size(487, 159);
            this.datagrid_validTrx.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 436);
            this.Controls.Add(this.datagrid_validTrx);
            this.Controls.Add(this.datagrid_incomingTrx);
            this.Controls.Add(this.btn_publishBlock);
            this.Controls.Add(this.listBox_minedBlocks);
            this.Controls.Add(this.btn_mine);
            this.Controls.Add(this.btn_validate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_transactionsList);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_incomingTrx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_validTrx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_transactionsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_validate;
        private System.Windows.Forms.Button btn_mine;
        private System.Windows.Forms.ListBox listBox_minedBlocks;
        private System.Windows.Forms.Button btn_publishBlock;
        private System.Windows.Forms.DataGridView datagrid_incomingTrx;
        private System.Windows.Forms.DataGridView datagrid_validTrx;
    }
}

