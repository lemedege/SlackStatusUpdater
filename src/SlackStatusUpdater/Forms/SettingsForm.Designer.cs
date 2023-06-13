namespace ZulipStatusUpdater
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.dgWifi = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tboDefaultIcon = new System.Windows.Forms.TextBox();
            this.tboDefaultMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboAutoStart = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tboZulipRealmURL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tboZulipUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDefaultSendIP = new System.Windows.Forms.CheckBox();
            this.cboUsewifi = new System.Windows.Forms.CheckBox();
            this.SSObtn = new System.Windows.Forms.Button();
            this.SSObtnAfter = new System.Windows.Forms.Button();
            this.tableProfileFields = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgWifi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgWifi
            // 
            this.dgWifi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgWifi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWifi.Location = new System.Drawing.Point(11, 131);
            this.dgWifi.Name = "dgWifi";
            this.dgWifi.Size = new System.Drawing.Size(710, 153);
            this.dgWifi.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(646, 341);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Profiles:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(565, 341);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tboDefaultIcon
            // 
            this.tboDefaultIcon.Location = new System.Drawing.Point(93, 315);
            this.tboDefaultIcon.Name = "tboDefaultIcon";
            this.tboDefaultIcon.Size = new System.Drawing.Size(161, 20);
            this.tboDefaultIcon.TabIndex = 6;
            // 
            // tboDefaultMessage
            // 
            this.tboDefaultMessage.Location = new System.Drawing.Point(260, 315);
            this.tboDefaultMessage.Name = "tboDefaultMessage";
            this.tboDefaultMessage.Size = new System.Drawing.Size(161, 20);
            this.tboDefaultMessage.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Default Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Emoji";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Text";
            // 
            // cboAutoStart
            // 
            this.cboAutoStart.AutoSize = true;
            this.cboAutoStart.Location = new System.Drawing.Point(492, 318);
            this.cboAutoStart.Name = "cboAutoStart";
            this.cboAutoStart.Size = new System.Drawing.Size(212, 17);
            this.cboAutoStart.TabIndex = 12;
            this.cboAutoStart.Text = "Start automatically on Windows start up";
            this.cboAutoStart.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(494, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Press DEL on your keyboard to delete a profile";
            // 
            // tboZulipRealmURL
            // 
            this.tboZulipRealmURL.Location = new System.Drawing.Point(465, 6);
            this.tboZulipRealmURL.Name = "tboZulipRealmURL";
            this.tboZulipRealmURL.Size = new System.Drawing.Size(202, 20);
            this.tboZulipRealmURL.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(359, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Zulip Realm URL:";
            // 
            // tboZulipUser
            // 
            this.tboZulipUser.Location = new System.Drawing.Point(95, 6);
            this.tboZulipUser.Name = "tboZulipUser";
            this.tboZulipUser.ReadOnly = true;
            this.tboZulipUser.Size = new System.Drawing.Size(192, 20);
            this.tboZulipUser.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Zulip user:";
            // 
            // cboDefaultSendIP
            // 
            this.cboDefaultSendIP.AutoSize = true;
            this.cboDefaultSendIP.Location = new System.Drawing.Point(182, 341);
            this.cboDefaultSendIP.Name = "cboDefaultSendIP";
            this.cboDefaultSendIP.Size = new System.Drawing.Size(64, 17);
            this.cboDefaultSendIP.TabIndex = 22;
            this.cboDefaultSendIP.Text = "Send IP";
            this.cboDefaultSendIP.UseVisualStyleBackColor = true;
            // 
            // cboUsewifi
            // 
            this.cboUsewifi.AutoSize = true;
            this.cboUsewifi.Location = new System.Drawing.Point(492, 295);
            this.cboUsewifi.Name = "cboUsewifi";
            this.cboUsewifi.Size = new System.Drawing.Size(229, 17);
            this.cboUsewifi.TabIndex = 23;
            this.cboUsewifi.Text = "Determine status on available wifi networks";
            this.cboUsewifi.UseVisualStyleBackColor = true;
            // 
            // SSObtn
            // 
            this.SSObtn.Location = new System.Drawing.Point(465, 60);
            this.SSObtn.Name = "SSObtn";
            this.SSObtn.Size = new System.Drawing.Size(75, 23);
            this.SSObtn.TabIndex = 24;
            this.SSObtn.Text = "Google SSO";
            this.SSObtn.UseVisualStyleBackColor = true;
            this.SSObtn.Click += new System.EventHandler(this.SSO_1st_step_Click);
            // 
            // SSObtnAfter
            // 
            this.SSObtnAfter.Location = new System.Drawing.Point(546, 60);
            this.SSObtnAfter.Name = "SSObtnAfter";
            this.SSObtnAfter.Size = new System.Drawing.Size(121, 23);
            this.SSObtnAfter.TabIndex = 26;
            this.SSObtnAfter.Text = "Press here after SSO login";
            this.SSObtnAfter.UseVisualStyleBackColor = true;
            this.SSObtnAfter.Click += new System.EventHandler(this.SSO_2nd_step_Click);
            // 
            // tableProfileFields
            // 
            this.tableProfileFields.AutoScroll = true;
            this.tableProfileFields.ColumnCount = 2;
            this.tableProfileFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableProfileFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableProfileFields.Location = new System.Drawing.Point(741, 6);
            this.tableProfileFields.Name = "tableProfileFields";
            this.tableProfileFields.RowCount = 2;
            this.tableProfileFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableProfileFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableProfileFields.Size = new System.Drawing.Size(291, 358);
            this.tableProfileFields.TabIndex = 27;
            this.tableProfileFields.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(732, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(2, 358);
            this.label10.TabIndex = 28;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 374);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tableProfileFields);
            this.Controls.Add(this.SSObtnAfter);
            this.Controls.Add(this.SSObtn);
            this.Controls.Add(this.cboUsewifi);
            this.Controls.Add(this.cboDefaultSendIP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tboZulipUser);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tboZulipRealmURL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboAutoStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tboDefaultMessage);
            this.Controls.Add(this.tboDefaultIcon);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgWifi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.dgWifi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgWifi;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tboDefaultIcon;
        private System.Windows.Forms.TextBox tboDefaultMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cboAutoStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tboZulipRealmURL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tboZulipUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cboDefaultSendIP;
        private System.Windows.Forms.CheckBox cboUsewifi;
        private System.Windows.Forms.Button SSObtn;
        private System.Windows.Forms.Button SSObtnAfter;
        private System.Windows.Forms.TableLayoutPanel tableProfileFields;
        private System.Windows.Forms.Label label10;
    }
}