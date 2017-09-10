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
            this.tabPage_Task = new System.Windows.Forms.TabPage();
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
            this.tabPage_MyTask = new System.Windows.Forms.TabPage();
            this.myTaskDgv = new System.Windows.Forms.DataGridView();
            this.dgvMyTask_TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMyTask_TaskContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMyTask_CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMyTask_TaskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMyTask_Finish = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvMyTask_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage_User = new System.Windows.Forms.TabPage();
            this.userDgv = new System.Windows.Forms.DataGridView();
            this.dgvUser_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUser_UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUser_RoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage_Password = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOldPsd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNewPsd = new System.Windows.Forms.TextBox();
            this.btnSavePsd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Task.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskDgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabPage_MyTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myTaskDgv)).BeginInit();
            this.tabPage_User.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.tabPage_Password.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabPage_Task);
            this.tabControl1.Controls.Add(this.tabPage_MyTask);
            this.tabControl1.Controls.Add(this.tabPage_User);
            this.tabControl1.Controls.Add(this.tabPage_Password);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(733, 364);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_Task
            // 
            this.tabPage_Task.Controls.Add(this.taskDgv);
            this.tabPage_Task.Controls.Add(this.menuStrip1);
            this.tabPage_Task.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Task.Name = "tabPage_Task";
            this.tabPage_Task.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Task.Size = new System.Drawing.Size(725, 338);
            this.tabPage_Task.TabIndex = 0;
            this.tabPage_Task.Text = "任务管理";
            this.tabPage_Task.UseVisualStyleBackColor = true;
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
            // tabPage_MyTask
            // 
            this.tabPage_MyTask.Controls.Add(this.myTaskDgv);
            this.tabPage_MyTask.Location = new System.Drawing.Point(4, 22);
            this.tabPage_MyTask.Name = "tabPage_MyTask";
            this.tabPage_MyTask.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_MyTask.Size = new System.Drawing.Size(725, 338);
            this.tabPage_MyTask.TabIndex = 3;
            this.tabPage_MyTask.Text = "我的任务";
            this.tabPage_MyTask.UseVisualStyleBackColor = true;
            // 
            // myTaskDgv
            // 
            this.myTaskDgv.AllowUserToAddRows = false;
            this.myTaskDgv.AllowUserToDeleteRows = false;
            this.myTaskDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.myTaskDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myTaskDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvMyTask_TaskName,
            this.dgvMyTask_TaskContent,
            this.dgvMyTask_CreateTime,
            this.dgvMyTask_TaskStatus,
            this.dgvMyTask_Finish,
            this.dgvMyTask_Id});
            this.myTaskDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTaskDgv.Location = new System.Drawing.Point(3, 3);
            this.myTaskDgv.Name = "myTaskDgv";
            this.myTaskDgv.ReadOnly = true;
            this.myTaskDgv.RowTemplate.Height = 23;
            this.myTaskDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.myTaskDgv.Size = new System.Drawing.Size(719, 332);
            this.myTaskDgv.TabIndex = 0;
            this.myTaskDgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myTaskDgv_CellContentClick);
            // 
            // dgvMyTask_TaskName
            // 
            this.dgvMyTask_TaskName.DataPropertyName = "TaskName";
            this.dgvMyTask_TaskName.HeaderText = "任务名称";
            this.dgvMyTask_TaskName.Name = "dgvMyTask_TaskName";
            this.dgvMyTask_TaskName.ReadOnly = true;
            // 
            // dgvMyTask_TaskContent
            // 
            this.dgvMyTask_TaskContent.DataPropertyName = "TaskContent";
            this.dgvMyTask_TaskContent.HeaderText = "任务内容";
            this.dgvMyTask_TaskContent.Name = "dgvMyTask_TaskContent";
            this.dgvMyTask_TaskContent.ReadOnly = true;
            // 
            // dgvMyTask_CreateTime
            // 
            this.dgvMyTask_CreateTime.DataPropertyName = "CreateTime";
            this.dgvMyTask_CreateTime.HeaderText = "创建时间";
            this.dgvMyTask_CreateTime.Name = "dgvMyTask_CreateTime";
            this.dgvMyTask_CreateTime.ReadOnly = true;
            // 
            // dgvMyTask_TaskStatus
            // 
            this.dgvMyTask_TaskStatus.DataPropertyName = "TaskStatus";
            this.dgvMyTask_TaskStatus.HeaderText = "任务状态";
            this.dgvMyTask_TaskStatus.Name = "dgvMyTask_TaskStatus";
            this.dgvMyTask_TaskStatus.ReadOnly = true;
            // 
            // dgvMyTask_Finish
            // 
            this.dgvMyTask_Finish.HeaderText = "操作";
            this.dgvMyTask_Finish.Name = "dgvMyTask_Finish";
            this.dgvMyTask_Finish.ReadOnly = true;
            this.dgvMyTask_Finish.Text = "完成任务";
            this.dgvMyTask_Finish.UseColumnTextForButtonValue = true;
            // 
            // dgvMyTask_Id
            // 
            this.dgvMyTask_Id.DataPropertyName = "Id";
            this.dgvMyTask_Id.HeaderText = "编号";
            this.dgvMyTask_Id.Name = "dgvMyTask_Id";
            this.dgvMyTask_Id.ReadOnly = true;
            this.dgvMyTask_Id.Visible = false;
            // 
            // tabPage_User
            // 
            this.tabPage_User.Controls.Add(this.userDgv);
            this.tabPage_User.Controls.Add(this.menuStrip2);
            this.tabPage_User.Location = new System.Drawing.Point(4, 22);
            this.tabPage_User.Name = "tabPage_User";
            this.tabPage_User.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_User.Size = new System.Drawing.Size(725, 338);
            this.tabPage_User.TabIndex = 1;
            this.tabPage_User.Text = "用户管理";
            this.tabPage_User.UseVisualStyleBackColor = true;
            // 
            // userDgv
            // 
            this.userDgv.AllowUserToAddRows = false;
            this.userDgv.AllowUserToDeleteRows = false;
            this.userDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvUser_Id,
            this.dgvUser_UserName,
            this.dgvUser_RoleName});
            this.userDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDgv.Location = new System.Drawing.Point(3, 28);
            this.userDgv.Name = "userDgv";
            this.userDgv.ReadOnly = true;
            this.userDgv.RowTemplate.Height = 23;
            this.userDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userDgv.Size = new System.Drawing.Size(719, 307);
            this.userDgv.TabIndex = 0;
            // 
            // dgvUser_Id
            // 
            this.dgvUser_Id.DataPropertyName = "Id";
            this.dgvUser_Id.HeaderText = "编号";
            this.dgvUser_Id.Name = "dgvUser_Id";
            this.dgvUser_Id.ReadOnly = true;
            // 
            // dgvUser_UserName
            // 
            this.dgvUser_UserName.DataPropertyName = "UserName";
            this.dgvUser_UserName.HeaderText = "姓名/登录名";
            this.dgvUser_UserName.Name = "dgvUser_UserName";
            this.dgvUser_UserName.ReadOnly = true;
            // 
            // dgvUser_RoleName
            // 
            this.dgvUser_RoleName.DataPropertyName = "RoleName";
            this.dgvUser_RoleName.HeaderText = "角色名";
            this.dgvUser_RoleName.Name = "dgvUser_RoleName";
            this.dgvUser_RoleName.ReadOnly = true;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(719, 25);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.添加ToolStripMenuItem.Text = "添加";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // tabPage_Password
            // 
            this.tabPage_Password.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_Password.Controls.Add(this.btnSavePsd);
            this.tabPage_Password.Controls.Add(this.tbNewPsd);
            this.tabPage_Password.Controls.Add(this.label2);
            this.tabPage_Password.Controls.Add(this.tbOldPsd);
            this.tabPage_Password.Controls.Add(this.label1);
            this.tabPage_Password.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Password.Name = "tabPage_Password";
            this.tabPage_Password.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Password.Size = new System.Drawing.Size(725, 338);
            this.tabPage_Password.TabIndex = 2;
            this.tabPage_Password.Text = "修改密码";
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "原密码";
            // 
            // tbOldPsd
            // 
            this.tbOldPsd.Location = new System.Drawing.Point(107, 28);
            this.tbOldPsd.Name = "tbOldPsd";
            this.tbOldPsd.Size = new System.Drawing.Size(100, 21);
            this.tbOldPsd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "新密码";
            // 
            // tbNewPsd
            // 
            this.tbNewPsd.Location = new System.Drawing.Point(107, 69);
            this.tbNewPsd.Name = "tbNewPsd";
            this.tbNewPsd.Size = new System.Drawing.Size(100, 21);
            this.tbNewPsd.TabIndex = 1;
            // 
            // btnSavePsd
            // 
            this.btnSavePsd.Location = new System.Drawing.Point(70, 110);
            this.btnSavePsd.Name = "btnSavePsd";
            this.btnSavePsd.Size = new System.Drawing.Size(109, 37);
            this.btnSavePsd.TabIndex = 2;
            this.btnSavePsd.Text = "保存";
            this.btnSavePsd.UseVisualStyleBackColor = true;
            this.btnSavePsd.Click += new System.EventHandler(this.btnSavePsd_Click);
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
            this.tabPage_Task.ResumeLayout(false);
            this.tabPage_Task.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskDgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage_MyTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myTaskDgv)).EndInit();
            this.tabPage_User.ResumeLayout(false);
            this.tabPage_User.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tabPage_Password.ResumeLayout(false);
            this.tabPage_Password.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Task;
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
        private System.Windows.Forms.TabPage tabPage_User;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage_Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUser_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUser_UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUser_RoleName;
        private System.Windows.Forms.DataGridView userDgv;
        private System.Windows.Forms.TabPage tabPage_MyTask;
        private System.Windows.Forms.DataGridView myTaskDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMyTask_TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMyTask_TaskContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMyTask_CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMyTask_TaskStatus;
        private System.Windows.Forms.DataGridViewButtonColumn dgvMyTask_Finish;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMyTask_Id;
        private System.Windows.Forms.Button btnSavePsd;
        private System.Windows.Forms.TextBox tbNewPsd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOldPsd;
        private System.Windows.Forms.Label label1;
    }
}