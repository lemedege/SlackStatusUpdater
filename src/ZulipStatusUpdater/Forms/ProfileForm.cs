using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using ZulipStatusUpdater.Models;


namespace ZulipStatusUpdater.Forms
{
    public partial class ProfileForm : Form
    {
        static System.Windows.Forms.Timer ConnectionTimer = new System.Windows.Forms.Timer();

        byte[] otp;

        List<ProfileField> filled_fields;


        CheckBox run_at_startup_cbox = new CheckBox();
        CheckBox send_ip_cbox = new CheckBox();
        Label IdleTimeLabel = new Label();
        NumericUpDown IdleTimeNum = new NumericUpDown();
        NumericUpDown OfflineTimeNum = new NumericUpDown();

        TextBox realmTb = new TextBox();
        Label realmLabel = new Label();
        TextBox emailTb = new TextBox();
        Label emailLabel = new Label();
        Button ssoBtn = new Button();
        Button ssoBtn2nd = new Button();

        CheckBox disable_cbo = new CheckBox();
        Button cancelBtn = new Button();
        Button saveBtn = new Button();

        TextBox defaultEmojiTb = new TextBox();
        Label defaultEmojiLabel = new Label();
        TextBox defaultStatusTb = new TextBox();
        Label defaultStatusLabel = new Label();
        CheckBox enableDefaultStatus = new CheckBox();

        ToolStripStatusLabel ConnectionStatusTsIcon = new ToolStripStatusLabel();
        ToolStripStatusLabel ConnectionStatusTsLabel = new ToolStripStatusLabel();

        // Singleton instance field
        private static ProfileForm _instance;
        Settings _settings;

        public ProfileForm()
        {
            InitializeComponent();
            this.Text = WindowTitle;

            ConnectionTimer.Tick += new EventHandler(UpdateConnectionLabel);
            UpdateConnectionLabel(null,null); //fire the timer to update label on startup
            ConnectionTimer.Interval = 5000;
            ConnectionTimer.Start();

            // Get settings
            _settings = SettingsManager.GetSettings();

            // If client is connected to server, start by showing profile page. 
            tabControl.SelectedTab = ZulipStatusService.CheckServerStatus()? ProfileTab: LoginTab;


            // Bind datagridview to status profiles
            BindingSource bs = new BindingSource();
            bs.DataSource = _settings.StatusProfiles;
            dgWifi.DataSource = bs;


            //pictureBox1.Image = ZulipStatusService.GetProfilePicture();
            //pictureBox1.ImageLocation = ZulipStatusService.GetProfilePicture();
            //pictureBox1.Load();

            BuildBottomButtons();
            BuildProfileFields();
            BuildDefaultStatusTable();
            BuildLoginInfoTable();
            BuildSettingsTable();

            statusStrip1.Items.Add(ConnectionStatusTsLabel);

        }

        private void UpdateConnectionLabel(Object myObject,
                                           EventArgs myEventArgs)
        {
            ConnectionStatusTsLabel.Text = ZulipStatusService.CheckServerStatus() ? "Connected" : "Disconnected";
        }

        private void BuildProfileFields()
        {
            tableProfileFields.ColumnCount = 2;
            tableProfileFields.RowCount = 0;
            tableProfileFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            tableProfileFields.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            List<ProfileField> fields = ZulipStatusService.GetCustomProfileFields();
            filled_fields = ZulipStatusService.FillCustomProfileFields(fields);
            //List<string> fields = new List<string>();
            //tableProfileFields.RowCount = fields.Count;
            foreach (ProfileField field in filled_fields)
            {
                tableProfileFields.RowCount++;
                tableProfileFields.Controls.Add(new Label() { Text = field.Name.Normalize(), Dock = DockStyle.Fill }, 0, tableProfileFields.RowCount - 1);
                switch (field.Type)
                {
                    case ProfileField.FieldType.SHORT_TEXT:
                        bool nameIsIP = field.Name == "IP";
                        TextBox tbox = new TextBox() { Dock = DockStyle.Fill, Text = field.Content, Tag = field.Id, Enabled = !nameIsIP };
                        tableProfileFields.Controls.Add(tbox, 1, tableProfileFields.RowCount - 1);
                        break;
                    case ProfileField.FieldType.LONG_TEXT:
                        break;
                    case ProfileField.FieldType.LIST_OF_OPTIONS:
                        ComboBox cbox = new ComboBox() { Dock = DockStyle.Fill, Tag = field.Id };
                        cbox.Enabled = false;
                        foreach (FieldDataContent option in field.FieldData)
                        {
                            cbox.Items.Add(option.Text);
                            if (field.Content == option.Value) { cbox.SelectedIndex = cbox.Items.IndexOf(option.Text); };

                        }
                        //cbox.SelectedIndex = filled_fields.;
                        tableProfileFields.Controls.Add(cbox, 1, tableProfileFields.RowCount - 1);
                        break;


                    default:
                        continue;
                }
            }


        }
        
        private void BuildSettingsTable()
        {

            
            run_at_startup_cbox.Text = "Start automatically on Windows start up";
            run_at_startup_cbox.AutoSize = true;

            send_ip_cbox.Text = "Share IP adress";
            send_ip_cbox.AutoSize = true;


            IdleTimeNum.Maximum = 200000;
            IdleTimeNum.Minimum = 2000;
            IdleTimeLabel.Text = "Idle timeout";
            FlowLayoutPanel idleTimePanel = new FlowLayoutPanel();
            idleTimePanel.FlowDirection = FlowDirection.LeftToRight;
            idleTimePanel.AutoSize = true;
            idleTimePanel.Controls.Add(IdleTimeNum);
            idleTimePanel.Controls.Add(IdleTimeLabel);
            


            SettingsTable.Controls.Add(run_at_startup_cbox, 0, 0);
            //SettingsTable.Controls.Add(send_ip_cbox, 0, -1);
            SettingsTable.Controls.Add(idleTimePanel, 0, -1);

            run_at_startup_cbox.DataBindings.Add("Checked", _settings, "AutoStart", false, DataSourceUpdateMode.OnPropertyChanged);
            IdleTimeNum.DataBindings.Add("Value", _settings, "idleThreshold", false, DataSourceUpdateMode.OnPropertyChanged);

        }


        private void BuildLoginInfoTable()
        {

            
            realmTb.Text = "https://chat.zulipchat.com";
            realmTb.Dock = DockStyle.Fill;
            realmTb.Name = "realmTb";

            
            realmLabel.Text = "Zulip Realm";
            realmLabel.AutoSize = true;
            realmLabel.TextAlign = ContentAlignment.MiddleCenter;
            realmLabel.Anchor = AnchorStyles.None;

            
            emailTb.Enabled = false;
            emailTb.Dock = DockStyle.Fill;

            
            emailLabel.Text = "email:";
            emailLabel.AutoSize = true;
            emailLabel.TextAlign = ContentAlignment.MiddleCenter;
            emailLabel.Anchor = AnchorStyles.None;
            
            ssoBtn.AutoSize = true;
            ssoBtn.Text = "Login using SSO";

            ssoBtn2nd.AutoSize = true;
            ssoBtn2nd.Text = "Press here after SSO completed";

            LoginInfoTable.Controls.Add(realmLabel, 0, 0);
            LoginInfoTable.Controls.Add(realmTb, 1, 0);

            LoginInfoTable.Controls.Add(emailLabel, 0, 1);
            LoginInfoTable.Controls.Add(emailTb, 1, 1);

            LoginInfoTable.Controls.Add(ssoBtn, 0, 2);
            LoginInfoTable.Controls.Add(ssoBtn2nd, 1, 2);

            realmTb.DataBindings.Add("Text", _settings, "ZulipRealm", false, DataSourceUpdateMode.OnPropertyChanged);
            emailTb.DataBindings.Add("Text", _settings, "ZulipEmail", false, DataSourceUpdateMode.OnPropertyChanged);

            ssoBtn.Click += new System.EventHandler(this.SSO_1st_step_Click);
            ssoBtn2nd.Click += new System.EventHandler(this.SSO_2nd_step_Click);

        }

        private void BuildBottomButtons()
        {
            
            disable_cbo.AutoSize = true;
            disable_cbo.Text = "Disable updates";
            disable_cbo.Anchor = AnchorStyles.Left;

            
            cancelBtn.AutoSize = true;
            cancelBtn.Text = "Cancel";
            cancelBtn.Anchor = AnchorStyles.Right;

            
            saveBtn.AutoSize = true;
            saveBtn.Text = "Save";
            saveBtn.Anchor = AnchorStyles.Right;

            flowLayoutPanel1.Controls.Add(saveBtn);
            flowLayoutPanel1.Controls.Add(cancelBtn);
            flowLayoutPanel1.Controls.Add(disable_cbo);

            disable_cbo.DataBindings.Add("Checked", _settings, "disablePresenceUpdate", false, DataSourceUpdateMode.OnPropertyChanged);

            saveBtn.Click += new System.EventHandler(this.btnSave_Click);
            cancelBtn.Click += new System.EventHandler(this.btnCancel_Click);
        }

        private void BuildDefaultStatusTable()
        {

            defaultEmojiTb.Dock = DockStyle.Fill;
            
            defaultEmojiLabel.Text = "Default emoji";
            defaultEmojiLabel.AutoSize = true;
            defaultEmojiLabel.TextAlign = ContentAlignment.MiddleCenter;
            defaultEmojiLabel.Anchor = AnchorStyles.Left;

            defaultStatusTb.Dock = DockStyle.Fill;
            
            defaultStatusLabel.Text = "Default status";
            defaultStatusLabel.AutoSize = true;
            defaultStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            defaultStatusLabel.Anchor = AnchorStyles.Left;

            enableDefaultStatus.Text = "Set default status when no match in table";
            enableDefaultStatus.AutoSize = true;

            defaultStatusTable.Controls.Add(defaultEmojiLabel, 1, 0);
            defaultStatusTable.Controls.Add(defaultEmojiTb, 1, 1);
            defaultStatusTable.Controls.Add(defaultStatusLabel, 0, 0);
            defaultStatusTable.Controls.Add(defaultStatusTb, 0, 1);
            defaultStatusTable.Controls.Add(enableDefaultStatus, 0, 2);

            defaultEmojiTb.DataBindings.Add("Text", _settings.DefaultStatus, "Emoji", false, DataSourceUpdateMode.OnPropertyChanged);
            defaultStatusTb.DataBindings.Add("Text", _settings.DefaultStatus, "Text", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        /// <summary>
        /// Singleton instance getter
        /// </summary>
        public static ProfileForm GetInstance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new ProfileForm();
                }
                return _instance;
            }
        }
        public string WindowTitle
        {
            get
            {
                Version version = Assembly.GetExecutingAssembly().GetName().Version;
                return Constants.NAME_OF_APP + " v" + version;
            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Save button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save changes made to settings
            SettingsManager.ApplySettings(_settings);

            foreach (ProfileField field in filled_fields)
            {
                var match = tableProfileFields.Controls.Find(field.Id.ToString(), true);
                foreach (Control tb in tableProfileFields.Controls.OfType<TextBox>())
                {
                    if (tb.Tag.ToString() == field.Id.ToString())
                    {
                        if (field.Content != tb.Text)
                        {
                            field.Content = tb.Text;
                            ZulipStatusService.UpdateProfileOnServer(field);
                        }
                        break;
                    }

                }
                //.Where(box => box.Tag.ToString() == "2491");
                //.Select(box => box.Text).First().ToString();
            }

            this.Dispose();

        }


        /// <summary>
        /// Cancel button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void SSO_1st_step_Click(object sender, EventArgs e)
        {
            string realm = Classes.Tools.TidyUpURL(realmTb.Text);

            System.Windows.MessageBox.Show(
            "A browser window will open asking you to open zulip:// urls with ZulipStatusUpdater. Accept and login via Google. When finished, press the second button in the settings pane", "Signing in with Gooogle-SSO",
            MessageBoxButton.OK,
            MessageBoxImage.Information,
            MessageBoxResult.OK,
            System.Windows.MessageBoxOptions.ServiceNotification);

            otp = ZulipStatusService.InitializeSSOLogin(realm);
        }

        private void SSO_2nd_step_Click(object sender, EventArgs e)
        {
            _settings = SettingsManager.GetSettings();
            string apikey = ZulipStatusService.DecryptAPIkeySSO(_settings.LastOTPEncryptedApiToken, otp);
            _settings.ZulipApikey = apikey;
            _settings.ZulipRealm = Classes.Tools.TidyUpURL(realmTb.Text);
            emailTb.Text = _settings.ZulipEmail;
            //Program.runicon.Say(apikey);
            SettingsManager.ApplySettings(_settings);
            UpdateConnectionLabel(null, null);
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {

        }
    }
}
