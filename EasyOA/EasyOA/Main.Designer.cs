namespace EasyOA
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.taskDgv = new System.Windows.Forms.DataGridView();
            this.dgv_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_TaskContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_TaskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_FinishTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.状态ToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.用户ToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.新建任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskDgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 364);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(733, 364);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.taskDgv);
            this.tabPage1.Controls.Add(this.menuStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(725, 338);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "任务管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // taskDgv
            // 
            this.taskDgv.AllowUserToAddRows = false;
            this.taskDgv.AllowUserToDeleteRows = false;
            this.taskDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.taskDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_Id,
            this.dgv_TaskName,
            this.dgv_TaskContent,
            this.dgv_TaskStatus,
            this.dgv_CreateTime,
            this.dgv_UserName,
            this.dgv_FinishTime});
            this.taskDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskDgv.Location = new System.Drawing.Point(3, 32);
            this.taskDgv.Name = "taskDgv";
            this.taskDgv.ReadOnly = true;
            this.taskDgv.RowTemplate.Height = 23;
            this.taskDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.taskDgv.Size = new System.Drawing.Size(719, 303);
            this.taskDgv.TabIndex = 0;
            // 
            // dgv_Id
            // 
            this.dgv_Id.DataPropertyName = "Id";
            this.dgv_Id.HeaderText = "编号";
            this.dgv_Id.Name = "dgv_Id";
            this.dgv_Id.ReadOnly = true;
            // 
            // dgv_TaskName
            // 
            this.dgv_TaskName.DataPropertyName = "TaskName";
            this.dgv_TaskName.HeaderText = "任务名称";
            this.dgv_TaskName.Name = "dgv_TaskName";
            this.dgv_TaskName.ReadOnly = true;
            // 
            // dgv_TaskContent
            // 
            this.dgv_TaskContent.DataPropertyName = "TaskContent";
            this.dgv_TaskContent.HeaderText = "任务内容";
            this.dgv_TaskContent.Name = "dgv_TaskContent";
            this.dgv_TaskContent.ReadOnly = true;
            // 
            // dgv_TaskStatus
            // 
            this.dgv_TaskStatus.DataPropertyName = "TaskStatus";
            this.dgv_TaskStatus.HeaderText = "任务状态";
            this.dgv_TaskStatus.Name = "dgv_TaskStatus";
            this.dgv_TaskStatus.ReadOnly = true;
            // 
            // dgv_CreateTime
            // 
            this.dgv_CreateTime.DataPropertyName = "CreateTime";
            this.dgv_CreateTime.HeaderText = "创建时间";
            this.dgv_CreateTime.Name = "dgv_CreateTime";
            this.dgv_CreateTime.ReadOnly = true;
            // 
            // dgv_UserName
            // 
            this.dgv_UserName.DataPropertyName = "UserName";
            this.dgv_UserName.HeaderText = "姓名";
            this.dgv_UserName.Name = "dgv_UserName";
            this.dgv_UserName.ReadOnly = true;
            // 
            // dgv_FinishTime
            // 
            this.dgv_FinishTime.DataPropertyName = "FinishTime";
            this.dgv_FinishTime.HeaderText = "完成时间";
            this.dgv_FinishTime.Name = "dgv_FinishTime";
            this.dgv_FinishTime.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.状态ToolStripComboBox,
            this.用户ToolStripComboBox,
            this.新建任务ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(719, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 状态ToolStripComboBox
            // 
            this.状态ToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.状态ToolStripComboBox.Name = "状态ToolStripComboBox";
            this.状态ToolStripComboBox.Size = new System.Drawing.Size(75, 25);
            this.状态ToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.状态ToolStripComboBox_SelectedIndexChanged);
            // 
            // 用户ToolStripComboBox
            // 
            this.用户ToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.用户ToolStripComboBox.DropDownWidth = 80;
            this.用户ToolStripComboBox.Name = "用户ToolStripComboBox";
            this.用户ToolStripComboBox.Size = new System.Drawing.Size(80, 25);
            this.用户ToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.用户ToolStripComboBox_SelectedIndexChanged);
            // 
            // 新建任务ToolStripMenuItem
            // 
            this.新建任务ToolStripMenuItem.Name = "新建任务ToolStripMenuItem";
            this.新建任务ToolStripMenuItem.Size = new System.Drawing.Size(68, 25);
            this.新建任务ToolStripMenuItem.Text = "新建任务";
            this.新建任务ToolStripMenuItem.Click += new System.EventHandler(this.新建任务ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 342);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(733, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "总计：";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 364);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简易办公系统";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskDgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView taskDgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox 状态ToolStripComboBox;
        private System.Windows.Forms.ToolStripComboBox 用户ToolStripComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_TaskContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_TaskStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_FinishTime;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}