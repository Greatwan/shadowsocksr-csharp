namespace Shadowsocks.View
{
    partial class NewMainForm
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
            this.components = new System.ComponentModel.Container();
            this.listViewServerBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxConnectType = new System.Windows.Forms.ComboBox();
            this.labelConnectType = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelDueDate = new System.Windows.Forms.Label();
            this.labelDueDateValue = new System.Windows.Forms.Label();
            this.labelTrafficRemain = new System.Windows.Forms.Label();
            this.labelTrafficRemainValue = new System.Windows.Forms.Label();
            this.labelSpeedDl = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelSpeedDlValue = new System.Windows.Forms.Label();
            this.labelSpeedUp = new System.Windows.Forms.Label();
            this.labelSpeedUpValue = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverImportFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverImportFromQrcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverImportManuallySetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscribeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateFromAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateFromSubscribeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountProductTrafficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productTrafficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.othersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonTest = new System.Windows.Forms.Button();
            this.labelSocksPort = new System.Windows.Forms.Label();
            this.numericUpDownSocksPort = new System.Windows.Forms.NumericUpDown();
            this.buttonSocksPortAction = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSocksPort)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewServerBox
            // 
            this.listViewServerBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewServerBox.HideSelection = false;
            this.listViewServerBox.Location = new System.Drawing.Point(0, 28);
            this.listViewServerBox.Margin = new System.Windows.Forms.Padding(4);
            this.listViewServerBox.Name = "listViewServerBox";
            this.listViewServerBox.Size = new System.Drawing.Size(528, 500);
            this.listViewServerBox.TabIndex = 0;
            this.listViewServerBox.UseCompatibleStateImageBehavior = false;
            this.listViewServerBox.View = System.Windows.Forms.View.Details;
            this.listViewServerBox.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listViewServerBox.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Server";
            this.columnHeader1.Width = 224;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ping";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 83;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "tcping";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 102;
            // 
            // comboBoxConnectType
            // 
            this.comboBoxConnectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConnectType.FormattingEnabled = true;
            this.comboBoxConnectType.Items.AddRange(new object[] {
            "不代理(仅socks)",
            "IE代理(pac)",
            "IE代理(全局)"});
            this.comboBoxConnectType.Location = new System.Drawing.Point(712, 190);
            this.comboBoxConnectType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxConnectType.Name = "comboBoxConnectType";
            this.comboBoxConnectType.Size = new System.Drawing.Size(184, 23);
            this.comboBoxConnectType.TabIndex = 1;
            this.comboBoxConnectType.SelectedIndexChanged += new System.EventHandler(this.comboBoxConnectType_selectIndexChangedEvent);
            // 
            // labelConnectType
            // 
            this.labelConnectType.AutoSize = true;
            this.labelConnectType.Location = new System.Drawing.Point(537, 190);
            this.labelConnectType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConnectType.Name = "labelConnectType";
            this.labelConnectType.Size = new System.Drawing.Size(103, 15);
            this.labelConnectType.TabIndex = 2;
            this.labelConnectType.Text = "Connect_type";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(712, 97);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(179, 41);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelDueDate
            // 
            this.labelDueDate.AutoSize = true;
            this.labelDueDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDueDate.Location = new System.Drawing.Point(862, 42);
            this.labelDueDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDueDate.Name = "labelDueDate";
            this.labelDueDate.Size = new System.Drawing.Size(89, 20);
            this.labelDueDate.TabIndex = 4;
            this.labelDueDate.Text = "Due_date";
            // 
            // labelDueDateValue
            // 
            this.labelDueDateValue.AutoSize = true;
            this.labelDueDateValue.Font = new System.Drawing.Font("宋体", 13F);
            this.labelDueDateValue.Location = new System.Drawing.Point(987, 40);
            this.labelDueDateValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDueDateValue.Name = "labelDueDateValue";
            this.labelDueDateValue.Size = new System.Drawing.Size(76, 22);
            this.labelDueDateValue.TabIndex = 9;
            this.labelDueDateValue.Text = "label3";
            // 
            // labelTrafficRemain
            // 
            this.labelTrafficRemain.AutoSize = true;
            this.labelTrafficRemain.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTrafficRemain.Location = new System.Drawing.Point(536, 42);
            this.labelTrafficRemain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTrafficRemain.Name = "labelTrafficRemain";
            this.labelTrafficRemain.Size = new System.Drawing.Size(149, 20);
            this.labelTrafficRemain.TabIndex = 10;
            this.labelTrafficRemain.Text = "Traffic_remain";
            // 
            // labelTrafficRemainValue
            // 
            this.labelTrafficRemainValue.AutoSize = true;
            this.labelTrafficRemainValue.Font = new System.Drawing.Font("宋体", 13F);
            this.labelTrafficRemainValue.Location = new System.Drawing.Point(708, 40);
            this.labelTrafficRemainValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTrafficRemainValue.Name = "labelTrafficRemainValue";
            this.labelTrafficRemainValue.Size = new System.Drawing.Size(76, 22);
            this.labelTrafficRemainValue.TabIndex = 11;
            this.labelTrafficRemainValue.Text = "label5";
            // 
            // labelSpeedDl
            // 
            this.labelSpeedDl.AutoSize = true;
            this.labelSpeedDl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSpeedDl.Location = new System.Drawing.Point(953, 97);
            this.labelSpeedDl.Name = "labelSpeedDl";
            this.labelSpeedDl.Size = new System.Drawing.Size(29, 20);
            this.labelSpeedDl.TabIndex = 14;
            this.labelSpeedDl.Text = "DL";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 250;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelSpeedDlValue
            // 
            this.labelSpeedDlValue.AutoSize = true;
            this.labelSpeedDlValue.Location = new System.Drawing.Point(1026, 97);
            this.labelSpeedDlValue.Name = "labelSpeedDlValue";
            this.labelSpeedDlValue.Size = new System.Drawing.Size(55, 15);
            this.labelSpeedDlValue.TabIndex = 15;
            this.labelSpeedDlValue.Text = "label9";
            // 
            // labelSpeedUp
            // 
            this.labelSpeedUp.AutoSize = true;
            this.labelSpeedUp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSpeedUp.Location = new System.Drawing.Point(953, 138);
            this.labelSpeedUp.Name = "labelSpeedUp";
            this.labelSpeedUp.Size = new System.Drawing.Size(29, 20);
            this.labelSpeedUp.TabIndex = 16;
            this.labelSpeedUp.Text = "UP";
            // 
            // labelSpeedUpValue
            // 
            this.labelSpeedUpValue.AutoSize = true;
            this.labelSpeedUpValue.Location = new System.Drawing.Point(1026, 138);
            this.labelSpeedUpValue.Name = "labelSpeedUpValue";
            this.labelSpeedUpValue.Size = new System.Drawing.Size(63, 15);
            this.labelSpeedUpValue.TabIndex = 17;
            this.labelSpeedUpValue.Text = "label11";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.subscribeToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.productTrafficToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.testToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1189, 28);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverEditToolStripMenuItem,
            this.serverImportToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.serverToolStripMenuItem.Text = "ServerManage";
            // 
            // serverEditToolStripMenuItem
            // 
            this.serverEditToolStripMenuItem.Name = "serverEditToolStripMenuItem";
            this.serverEditToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.serverEditToolStripMenuItem.Text = "ServerEdit";
            this.serverEditToolStripMenuItem.Click += new System.EventHandler(this.serverEditToolStripMenuItem_Click);
            // 
            // serverImportToolStripMenuItem
            // 
            this.serverImportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverImportFromClipboardToolStripMenuItem,
            this.serverImportFromQrcodeToolStripMenuItem,
            this.serverImportManuallySetupToolStripMenuItem});
            this.serverImportToolStripMenuItem.Name = "serverImportToolStripMenuItem";
            this.serverImportToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.serverImportToolStripMenuItem.Text = "ServerImport";
            // 
            // serverImportFromClipboardToolStripMenuItem
            // 
            this.serverImportFromClipboardToolStripMenuItem.Name = "serverImportFromClipboardToolStripMenuItem";
            this.serverImportFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.serverImportFromClipboardToolStripMenuItem.Text = "ServerImportFromClipboard";
            this.serverImportFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.serverImportFromClipboardToolStripMenuItem_Click);
            // 
            // serverImportFromQrcodeToolStripMenuItem
            // 
            this.serverImportFromQrcodeToolStripMenuItem.Name = "serverImportFromQrcodeToolStripMenuItem";
            this.serverImportFromQrcodeToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.serverImportFromQrcodeToolStripMenuItem.Text = "ServerImportFromQrcode";
            // 
            // serverImportManuallySetupToolStripMenuItem
            // 
            this.serverImportManuallySetupToolStripMenuItem.Name = "serverImportManuallySetupToolStripMenuItem";
            this.serverImportManuallySetupToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.serverImportManuallySetupToolStripMenuItem.Text = "ServerImportManuallySetup";
            // 
            // subscribeToolStripMenuItem
            // 
            this.subscribeToolStripMenuItem.Name = "subscribeToolStripMenuItem";
            this.subscribeToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.subscribeToolStripMenuItem.Text = "Subscribe";
            this.subscribeToolStripMenuItem.Click += new System.EventHandler(this.subscribeToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateFromAccountToolStripMenuItem,
            this.updateFromSubscribeToolStripMenuItem,
            this.updateAllToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // updateFromAccountToolStripMenuItem
            // 
            this.updateFromAccountToolStripMenuItem.Name = "updateFromAccountToolStripMenuItem";
            this.updateFromAccountToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.updateFromAccountToolStripMenuItem.Text = "UpdateFromAccount";
            // 
            // updateFromSubscribeToolStripMenuItem
            // 
            this.updateFromSubscribeToolStripMenuItem.Name = "updateFromSubscribeToolStripMenuItem";
            this.updateFromSubscribeToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.updateFromSubscribeToolStripMenuItem.Text = "UpdateFromSubscribe";
            this.updateFromSubscribeToolStripMenuItem.Click += new System.EventHandler(this.updateFromSubscribeToolStripMenuItem_Click);
            // 
            // updateAllToolStripMenuItem
            // 
            this.updateAllToolStripMenuItem.Name = "updateAllToolStripMenuItem";
            this.updateAllToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.updateAllToolStripMenuItem.Text = "UpdateAll";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountInfoToolStripMenuItem,
            this.accountProductTrafficToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // accountInfoToolStripMenuItem
            // 
            this.accountInfoToolStripMenuItem.Name = "accountInfoToolStripMenuItem";
            this.accountInfoToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.accountInfoToolStripMenuItem.Text = "AccountInfo";
            // 
            // accountProductTrafficToolStripMenuItem
            // 
            this.accountProductTrafficToolStripMenuItem.Name = "accountProductTrafficToolStripMenuItem";
            this.accountProductTrafficToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.accountProductTrafficToolStripMenuItem.Text = "AccountProductTraffic";
            // 
            // productTrafficToolStripMenuItem
            // 
            this.productTrafficToolStripMenuItem.Name = "productTrafficToolStripMenuItem";
            this.productTrafficToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.productTrafficToolStripMenuItem.Text = "ProductTraffic";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.othersToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.generalToolStripMenuItem.Text = "General";
            // 
            // othersToolStripMenuItem
            // 
            this.othersToolStripMenuItem.Name = "othersToolStripMenuItem";
            this.othersToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.othersToolStripMenuItem.Text = "Others";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testAllToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // testAllToolStripMenuItem
            // 
            this.testAllToolStripMenuItem.Name = "testAllToolStripMenuItem";
            this.testAllToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.testAllToolStripMenuItem.Text = "TestAll";
            this.testAllToolStripMenuItem.Click += new System.EventHandler(this.testAllToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logToolStripMenuItem,
            this.statisticToolStripMenuItem,
            this.contactToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.logToolStripMenuItem.Text = "Log";
            this.logToolStripMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
            // 
            // statisticToolStripMenuItem
            // 
            this.statisticToolStripMenuItem.Name = "statisticToolStripMenuItem";
            this.statisticToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.statisticToolStripMenuItem.Text = "Statistic";
            this.statisticToolStripMenuItem.Click += new System.EventHandler(this.statisticToolStripMenuItem_Click);
            // 
            // contactToolStripMenuItem
            // 
            this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            this.contactToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.contactToolStripMenuItem.Text = "Contact";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(540, 305);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 23;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.ButtonTest_Click);
            // 
            // labelSocksPort
            // 
            this.labelSocksPort.AutoSize = true;
            this.labelSocksPort.Location = new System.Drawing.Point(540, 238);
            this.labelSocksPort.Name = "labelSocksPort";
            this.labelSocksPort.Size = new System.Drawing.Size(79, 15);
            this.labelSocksPort.TabIndex = 24;
            this.labelSocksPort.Text = "socksPort";
            // 
            // numericUpDownSocksPort
            // 
            this.numericUpDownSocksPort.Location = new System.Drawing.Point(712, 238);
            this.numericUpDownSocksPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownSocksPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSocksPort.Name = "numericUpDownSocksPort";
            this.numericUpDownSocksPort.ReadOnly = true;
            this.numericUpDownSocksPort.Size = new System.Drawing.Size(115, 25);
            this.numericUpDownSocksPort.TabIndex = 25;
            this.numericUpDownSocksPort.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            // 
            // buttonSocksPortAction
            // 
            this.buttonSocksPortAction.Location = new System.Drawing.Point(866, 238);
            this.buttonSocksPortAction.Name = "buttonSocksPortAction";
            this.buttonSocksPortAction.Size = new System.Drawing.Size(70, 23);
            this.buttonSocksPortAction.TabIndex = 26;
            this.buttonSocksPortAction.Text = "Edit";
            this.buttonSocksPortAction.UseVisualStyleBackColor = true;
            this.buttonSocksPortAction.Click += new System.EventHandler(this.ButtonSocksPortAction_Click);
            // 
            // NewMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 528);
            this.Controls.Add(this.buttonSocksPortAction);
            this.Controls.Add(this.numericUpDownSocksPort);
            this.Controls.Add(this.labelSocksPort);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.labelSpeedUpValue);
            this.Controls.Add(this.labelSpeedUp);
            this.Controls.Add(this.labelSpeedDlValue);
            this.Controls.Add(this.labelSpeedDl);
            this.Controls.Add(this.labelTrafficRemainValue);
            this.Controls.Add(this.labelTrafficRemain);
            this.Controls.Add(this.labelDueDateValue);
            this.Controls.Add(this.labelDueDate);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelConnectType);
            this.Controls.Add(this.comboBoxConnectType);
            this.Controls.Add(this.listViewServerBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewMainForm";
            this.Text = "MainPanel";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSocksPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ListView listViewServerBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ComboBox comboBoxConnectType;
        private System.Windows.Forms.Label labelConnectType;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelDueDate;
        private System.Windows.Forms.Label labelDueDateValue;
        private System.Windows.Forms.Label labelTrafficRemain;
        private System.Windows.Forms.Label labelTrafficRemainValue;
        private System.Windows.Forms.Label labelSpeedDl;
        private System.Windows.Forms.Label labelSpeedDlValue;
        private System.Windows.Forms.Label labelSpeedUp;
        private System.Windows.Forms.Label labelSpeedUpValue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem othersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverImportFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverImportFromQrcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverImportManuallySetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountProductTrafficToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productTrafficToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateFromAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateFromSubscribeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscribeToolStripMenuItem;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label labelSocksPort;
        private System.Windows.Forms.NumericUpDown numericUpDownSocksPort;
        private System.Windows.Forms.Button buttonSocksPortAction;
    }
}