namespace ZulipStatusUpdater.Forms
{
    partial class ProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ProfileTab = new System.Windows.Forms.TabPage();
            this.LoginTab = new System.Windows.Forms.TabPage();
            this.LoginInfoTable = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ConnectionStatusTsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SettingsTable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableProfileFields = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgWifi = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.defaultStatusTable = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl.SuspendLayout();
            this.ProfileTab.SuspendLayout();
            this.LoginTab.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWifi)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.ProfileTab);
            this.tabControl.Controls.Add(this.LoginTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 410);
            this.tabControl.TabIndex = 0;
            // 
            // ProfileTab
            // 
            this.ProfileTab.Controls.Add(this.tableLayoutPanel2);
            this.ProfileTab.Location = new System.Drawing.Point(4, 22);
            this.ProfileTab.Name = "ProfileTab";
            this.ProfileTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProfileTab.Size = new System.Drawing.Size(792, 384);
            this.ProfileTab.TabIndex = 0;
            this.ProfileTab.Text = "Profile";
            this.ProfileTab.UseVisualStyleBackColor = true;
            // 
            // LoginTab
            // 
            this.LoginTab.Controls.Add(this.tableLayoutPanel1);
            this.LoginTab.Location = new System.Drawing.Point(4, 22);
            this.LoginTab.Name = "LoginTab";
            this.LoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.LoginTab.Size = new System.Drawing.Size(792, 384);
            this.LoginTab.TabIndex = 1;
            this.LoginTab.Text = "Login";
            this.LoginTab.UseVisualStyleBackColor = true;
            // 
            // LoginInfoTable
            // 
            this.LoginInfoTable.AutoSize = true;
            this.LoginInfoTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginInfoTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.LoginInfoTable.ColumnCount = 2;
            this.LoginInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LoginInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LoginInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LoginInfoTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginInfoTable.Location = new System.Drawing.Point(3, 3);
            this.LoginInfoTable.Name = "LoginInfoTable";
            this.LoginInfoTable.Padding = new System.Windows.Forms.Padding(10);
            this.LoginInfoTable.RowCount = 2;
            this.LoginInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LoginInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LoginInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LoginInfoTable.Size = new System.Drawing.Size(387, 372);
            this.LoginInfoTable.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectionStatusTsLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ConnectionStatusTsLabel
            // 
            this.ConnectionStatusTsLabel.Name = "ConnectionStatusTsLabel";
            this.ConnectionStatusTsLabel.Size = new System.Drawing.Size(16, 17);
            this.ConnectionStatusTsLabel.Text = "...";
            // 
            // SettingsTable
            // 
            this.SettingsTable.AutoSize = true;
            this.SettingsTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SettingsTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.SettingsTable.ColumnCount = 1;
            this.SettingsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SettingsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SettingsTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsTable.Location = new System.Drawing.Point(396, 3);
            this.SettingsTable.Name = "SettingsTable";
            this.SettingsTable.Padding = new System.Windows.Forms.Padding(10);
            this.SettingsTable.RowCount = 2;
            this.SettingsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SettingsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SettingsTable.Size = new System.Drawing.Size(387, 23);
            this.SettingsTable.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.SettingsTable, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LoginInfoTable, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 378);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableProfileFields, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(786, 378);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableProfileFields
            // 
            this.tableProfileFields.AutoScroll = true;
            this.tableProfileFields.ColumnCount = 2;
            this.tableProfileFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableProfileFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableProfileFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableProfileFields.Location = new System.Drawing.Point(3, 3);
            this.tableProfileFields.Name = "tableProfileFields";
            this.tableProfileFields.RowCount = 2;
            this.tableProfileFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableProfileFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableProfileFields.Size = new System.Drawing.Size(387, 372);
            this.tableProfileFields.TabIndex = 28;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 428);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 0);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // dgWifi
            // 
            this.dgWifi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgWifi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWifi.Location = new System.Drawing.Point(3, 3);
            this.dgWifi.Name = "dgWifi";
            this.dgWifi.Size = new System.Drawing.Size(381, 153);
            this.dgWifi.TabIndex = 29;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dgWifi, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.defaultStatusTable, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(396, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(387, 372);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // defaultStatusTable
            // 
            this.defaultStatusTable.AutoSize = true;
            this.defaultStatusTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.defaultStatusTable.ColumnCount = 2;
            this.defaultStatusTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.defaultStatusTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.defaultStatusTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.defaultStatusTable.Location = new System.Drawing.Point(3, 366);
            this.defaultStatusTable.Name = "defaultStatusTable";
            this.defaultStatusTable.RowCount = 2;
            this.defaultStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.defaultStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.defaultStatusTable.Size = new System.Drawing.Size(381, 3);
            this.defaultStatusTable.TabIndex = 30;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProfileForm";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.ProfileTab.ResumeLayout(false);
            this.LoginTab.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWifi)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage ProfileTab;
        private System.Windows.Forms.TabPage LoginTab;
        private System.Windows.Forms.TableLayoutPanel LoginInfoTable;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ConnectionStatusTsLabel;
        private System.Windows.Forms.TableLayoutPanel SettingsTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableProfileFields;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgWifi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel defaultStatusTable;
    }
}