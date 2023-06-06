namespace ZulipStatusUpdater
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
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.tableProfileFields = new System.Windows.Forms.TableLayoutPanel();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.SSObtnAfter = new System.Windows.Forms.Button();
            this.SSObtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tboZulipRealmURL = new System.Windows.Forms.TextBox();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.cboUsewifi = new System.Windows.Forms.CheckBox();
            this.cboDefaultSendIP = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tboDefaultMessage = new System.Windows.Forms.TextBox();
            this.tboDefaultIcon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgWifi = new System.Windows.Forms.DataGridView();
            this.cboAutoStart = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.tabStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWifi)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabProfile);
            this.tabControl.Controls.Add(this.tabLogin);
            this.tabControl.Controls.Add(this.tabStatus);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(799, 410);
            this.tabControl.TabIndex = 0;
            // 
            // tabProfile
            // 
            this.tabProfile.BackColor = System.Drawing.SystemColors.Window;
            this.tabProfile.Controls.Add(this.tableProfileFields);
            this.tabProfile.Location = new System.Drawing.Point(4, 22);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(791, 384);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Profile";
            // 
            // tableProfileFields
            // 
            this.tableProfileFields.AutoScroll = true;
            this.tableProfileFields.ColumnCount = 2;
            this.tableProfileFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableProfileFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableProfileFields.Location = new System.Drawing.Point(250, 13);
            this.tableProfileFields.Name = "tableProfileFields";
            this.tableProfileFields.RowCount = 2;
            this.tableProfileFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableProfileFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableProfileFields.Size = new System.Drawing.Size(291, 358);
            this.tableProfileFields.TabIndex = 28;
            // 
            // tabLogin
            // 
            this.tabLogin.BackColor = System.Drawing.Color.Transparent;
            this.tabLogin.Controls.Add(this.SSObtnAfter);
            this.tabLogin.Controls.Add(this.SSObtn);
            this.tabLogin.Controls.Add(this.label7);
            this.tabLogin.Controls.Add(this.tboZulipRealmURL);
            this.tabLogin.Location = new System.Drawing.Point(4, 22);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogin.Size = new System.Drawing.Size(791, 384);
            this.tabLogin.TabIndex = 1;
            this.tabLogin.Text = "Login";
            // 
            // SSObtnAfter
            // 
            this.SSObtnAfter.Location = new System.Drawing.Point(101, 45);
            this.SSObtnAfter.Name = "SSObtnAfter";
            this.SSObtnAfter.Size = new System.Drawing.Size(121, 23);
            this.SSObtnAfter.TabIndex = 28;
            this.SSObtnAfter.Text = "Press here after SSO login";
            this.SSObtnAfter.UseVisualStyleBackColor = true;
            // 
            // SSObtn
            // 
            this.SSObtn.Location = new System.Drawing.Point(20, 45);
            this.SSObtn.Name = "SSObtn";
            this.SSObtn.Size = new System.Drawing.Size(75, 23);
            this.SSObtn.TabIndex = 27;
            this.SSObtn.Text = "Google SSO";
            this.SSObtn.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Zulip Realm URL:";
            // 
            // tboZulipRealmURL
            // 
            this.tboZulipRealmURL.Location = new System.Drawing.Point(123, 15);
            this.tboZulipRealmURL.Name = "tboZulipRealmURL";
            this.tboZulipRealmURL.Size = new System.Drawing.Size(202, 20);
            this.tboZulipRealmURL.TabIndex = 16;
            // 
            // tabStatus
            // 
            this.tabStatus.BackColor = System.Drawing.Color.Transparent;
            this.tabStatus.Controls.Add(this.cboUsewifi);
            this.tabStatus.Controls.Add(this.cboDefaultSendIP);
            this.tabStatus.Controls.Add(this.label5);
            this.tabStatus.Controls.Add(this.label4);
            this.tabStatus.Controls.Add(this.label3);
            this.tabStatus.Controls.Add(this.tboDefaultMessage);
            this.tabStatus.Controls.Add(this.tboDefaultIcon);
            this.tabStatus.Controls.Add(this.label6);
            this.tabStatus.Controls.Add(this.label2);
            this.tabStatus.Controls.Add(this.dgWifi);
            this.tabStatus.Location = new System.Drawing.Point(4, 22);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatus.Size = new System.Drawing.Size(791, 384);
            this.tabStatus.TabIndex = 2;
            this.tabStatus.Text = "Automatic status";
            // 
            // cboUsewifi
            // 
            this.cboUsewifi.AutoSize = true;
            this.cboUsewifi.Location = new System.Drawing.Point(512, 217);
            this.cboUsewifi.Name = "cboUsewifi";
            this.cboUsewifi.Size = new System.Drawing.Size(229, 17);
            this.cboUsewifi.TabIndex = 30;
            this.cboUsewifi.Text = "Determine status on available wifi networks";
            this.cboUsewifi.UseVisualStyleBackColor = true;
            // 
            // cboDefaultSendIP
            // 
            this.cboDefaultSendIP.AutoSize = true;
            this.cboDefaultSendIP.Location = new System.Drawing.Point(202, 263);
            this.cboDefaultSendIP.Name = "cboDefaultSendIP";
            this.cboDefaultSendIP.Size = new System.Drawing.Size(64, 17);
            this.cboDefaultSendIP.TabIndex = 29;
            this.cboDefaultSendIP.Text = "Send IP";
            this.cboDefaultSendIP.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Text";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Emoji";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Default Status:";
            // 
            // tboDefaultMessage
            // 
            this.tboDefaultMessage.Location = new System.Drawing.Point(280, 237);
            this.tboDefaultMessage.Name = "tboDefaultMessage";
            this.tboDefaultMessage.Size = new System.Drawing.Size(161, 20);
            this.tboDefaultMessage.TabIndex = 25;
            // 
            // tboDefaultIcon
            // 
            this.tboDefaultIcon.Location = new System.Drawing.Point(113, 237);
            this.tboDefaultIcon.Name = "tboDefaultIcon";
            this.tboDefaultIcon.Size = new System.Drawing.Size(161, 20);
            this.tboDefaultIcon.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Press DEL on your keyboard to delete a profile";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Profiles:";
            // 
            // dgWifi
            // 
            this.dgWifi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgWifi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWifi.Location = new System.Drawing.Point(24, 38);
            this.dgWifi.Name = "dgWifi";
            this.dgWifi.Size = new System.Drawing.Size(710, 153);
            this.dgWifi.TabIndex = 14;
            // 
            // cboAutoStart
            // 
            this.cboAutoStart.AutoSize = true;
            this.cboAutoStart.Location = new System.Drawing.Point(12, 421);
            this.cboAutoStart.Name = "cboAutoStart";
            this.cboAutoStart.Size = new System.Drawing.Size(212, 17);
            this.cboAutoStart.TabIndex = 15;
            this.cboAutoStart.Text = "Start automatically on Windows start up";
            this.cboAutoStart.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(639, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(720, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cboAutoStart);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProfileForm";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.tabLogin.PerformLayout();
            this.tabStatus.ResumeLayout(false);
            this.tabStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWifi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.TabPage tabStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tboZulipRealmURL;
        private System.Windows.Forms.Button SSObtnAfter;
        private System.Windows.Forms.Button SSObtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgWifi;
        private System.Windows.Forms.CheckBox cboUsewifi;
        private System.Windows.Forms.CheckBox cboDefaultSendIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tboDefaultMessage;
        private System.Windows.Forms.TextBox tboDefaultIcon;
        private System.Windows.Forms.CheckBox cboAutoStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableProfileFields;
    }
}