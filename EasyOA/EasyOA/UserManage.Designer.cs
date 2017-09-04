namespace EasyOA
{
    partial class UserManage
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgv_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_UserType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgv_UserTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(626, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 316);
            this.panel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_Id,
            this.dgv_UserName,
            this.dgv_Account,
            this.dgv_Password,
            this.dgv_UserType,
            this.dgv_UserTypeCode});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(626, 316);
            this.dataGridView1.TabIndex = 0;
            // 
            // dgv_Id
            // 
            this.dgv_Id.DataPropertyName = "Id";
            this.dgv_Id.HeaderText = "编号";
            this.dgv_Id.Name = "dgv_Id";
            this.dgv_Id.ReadOnly = true;
            // 
            // dgv_UserName
            // 
            this.dgv_UserName.DataPropertyName = "UserName";
            this.dgv_UserName.HeaderText = "姓名";
            this.dgv_UserName.Name = "dgv_UserName";
            // 
            // dgv_Account
            // 
            this.dgv_Account.DataPropertyName = "Account";
            this.dgv_Account.HeaderText = "登录名";
            this.dgv_Account.Name = "dgv_Account";
            // 
            // dgv_Password
            // 
            this.dgv_Password.DataPropertyName = "Password";
            this.dgv_Password.HeaderText = "密码";
            this.dgv_Password.Name = "dgv_Password";
            // 
            // dgv_UserType
            // 
            this.dgv_UserType.DataPropertyName = "UserType";
            this.dgv_UserType.HeaderText = "用户类型";
            this.dgv_UserType.Name = "dgv_UserType";
            // 
            // dgv_UserTypeCode
            // 
            this.dgv_UserTypeCode.DataPropertyName = "UserType";
            this.dgv_UserTypeCode.HeaderText = "UserTypeCode";
            this.dgv_UserTypeCode.Name = "dgv_UserTypeCode";
            this.dgv_UserTypeCode.Visible = false;
            // 
            // UserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 341);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UserManage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Password;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgv_UserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_UserTypeCode;
    }
}