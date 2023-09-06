using ZulipStatusUpdater.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Web.UI.WebControls;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using System.Windows;

namespace ZulipStatusUpdater
{
    public partial class SettingsForm : Form
    {
        //storing last used OTP for SSO login
        byte[] otp;

        List<ProfileField> filled_fields;


        // Singleton instance field
        private static SettingsForm _instance;

        Settings _settings;

        /// <summary>
        /// Private constructor
        /// </summary>
        private SettingsForm()
        {
            InitializeComponent();
            this.Text = WindowTitle;

            // Get settings
            _settings = SettingsManager.GetSettings();


            // Bind datagridview to status profiles
            BindingSource bs = new BindingSource();
            bs.DataSource = _settings.StatusProfiles;
            dgWifi.DataSource = bs;

            // Bind other settings form controls to other settings fields.
            // Update data source as soon as data is changed on the form.
            tboZulipRealmURL.DataBindings.Add("Text", _settings, "ZulipRealm", false, DataSourceUpdateMode.OnPropertyChanged);
            tboDefaultIcon.DataBindings.Add("Text", _settings.DefaultStatus, "Emoji", false, DataSourceUpdateMode.OnPropertyChanged);
            tboDefaultMessage.DataBindings.Add("Text", _settings.DefaultStatus, "Text", false, DataSourceUpdateMode.OnPropertyChanged);
            cboDefaultSendIP.DataBindings.Add("Checked", _settings.DefaultStatus, "SendIP", false, DataSourceUpdateMode.OnPropertyChanged);
            cboAutoStart.DataBindings.Add("Checked", _settings, "AutoStart", false, DataSourceUpdateMode.OnPropertyChanged);
            tboZulipUser.DataBindings.Add("Text", _settings, "ZulipEmail", false, DataSourceUpdateMode.OnPropertyChanged);
            cboUsewifi.DataBindings.Add("Checked", _settings, "useWifi", false, DataSourceUpdateMode.OnPropertyChanged);

            // does it only update IP on startup?
            string localIP = NetworkCheck.GetCurrentIP();

            // Draw table with profile fields
            tableProfileFields.ColumnCount = 2;
            tableProfileFields.RowCount = 0;
            tableProfileFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,10));
            tableProfileFields.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            List<ProfileField> fields = ZulipStatusService.GetCustomProfileFields();
            filled_fields = ZulipStatusService.FillCustomProfileFields(fields);
            //List<string> fields = new List<string>();
            //tableProfileFields.RowCount = fields.Count;
            foreach (ProfileField field in filled_fields)
            {
                tableProfileFields.RowCount++;
                tableProfileFields.Controls.Add(new Label() { Text = field.Name.Normalize(), Dock = DockStyle.Fill }, 0, tableProfileFields.RowCount-1);
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
                        foreach (FieldDataContent option in field.FieldData)
                        {
                            cbox.Items.Add(option.Text);
                            if(field.Content == option.Value) { cbox.SelectedIndex = cbox.Items.IndexOf(option.Text); };
                            
                        }
                        //cbox.SelectedIndex = filled_fields.;
                        tableProfileFields.Controls.Add(cbox, 1, tableProfileFields.RowCount - 1);
                        break;


                    default:
                        continue;
                }
            }


        }

        /// <summary>
        /// Singleton instance getter
        /// </summary>
        public static SettingsForm GetInstance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new SettingsForm();
                }
                return _instance;
            }
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

        /// <summary>
        /// Save button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save changes made to settings
            SettingsManager.ApplySettings(_settings);

            foreach(ProfileField field in filled_fields)
            {
                var match = tableProfileFields.Controls.Find(field.Id.ToString(), true);
                foreach(Control tb in tableProfileFields.Controls.OfType<TextBox>())
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



        public string WindowTitle
        {
            get
            {
                Version version = Assembly.GetExecutingAssembly().GetName().Version;
                return Constants.NAME_OF_APP+ " v" + version;
            }
        }

        private void SSO_1st_step_Click(object sender, EventArgs e)
        {             
            string realm = Classes.Tools.TidyUpURL(tboZulipRealmURL.Text);

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
            var settings = SettingsManager.GetSettings();
            string apikey = ZulipStatusService.DecryptAPIkeySSO(settings.LastOTPEncryptedApiToken, otp);
            //Program.runicon.Say(apikey);
            tboZulipUser.Text = settings.ZulipEmail;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
