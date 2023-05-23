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
            tboApiToken.DataBindings.Add("Text", _settings, "ZulipApikey", false, DataSourceUpdateMode.OnPropertyChanged);
            tboZulipRealmURL.DataBindings.Add("Text", _settings, "ZulipRealm", false, DataSourceUpdateMode.OnPropertyChanged);
            tboDefaultIcon.DataBindings.Add("Text", _settings.DefaultStatus, "Emoji", false, DataSourceUpdateMode.OnPropertyChanged);
            tboDefaultMessage.DataBindings.Add("Text", _settings.DefaultStatus, "Text", false, DataSourceUpdateMode.OnPropertyChanged);
            cboDefaultSendIP.DataBindings.Add("Checked", _settings.DefaultStatus, "SendIP", false, DataSourceUpdateMode.OnPropertyChanged);
            cboAutoStart.DataBindings.Add("Checked", _settings, "AutoStart", false, DataSourceUpdateMode.OnPropertyChanged);
            tboZulipUser.DataBindings.Add("Text", _settings, "ZulipEmail", false, DataSourceUpdateMode.OnPropertyChanged);
            cboUsewifi.DataBindings.Add("Checked", _settings, "useWifi", false, DataSourceUpdateMode.OnPropertyChanged);


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
                        tableProfileFields.Controls.Add(new TextBox() { Dock = DockStyle.Fill, Text = field.Content, Tag = field.Id }, 1, tableProfileFields.RowCount - 1);
                        break;
                    case ProfileField.FieldType.LONG_TEXT:
                        break;
                    case ProfileField.FieldType.LIST_OF_OPTIONS:
                        ComboBox cbox = new ComboBox() { Dock = DockStyle.Fill, Tag = field.Id };
                        foreach (FieldDataContent option in field.FieldData)
                        {
                            cbox.Items.Add(option.Text);
                        }
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


        private void btnGetAPIkey_Click(object sender, EventArgs e)
        {
            SettingsManager.ApplySettings(_settings);

            if (ZulipStatusService.GetZulipApiKey(tboZulipPassword.Text))
            {
                
                tboApiToken.Text = SettingsManager.GetSettings().ZulipApikey;
                tboZulipPassword.Clear();
                // Save changes made to settings
                //SettingsManager.ApplySettings(_settings);
                //this.Dispose();
            }
            else tboZulipPassword.Clear();
        }

        public string WindowTitle
        {
            get
            {
                Version version = Assembly.GetExecutingAssembly().GetName().Version;
                return Constants.NAME_OF_APP+ " v" + version;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            otp = ZulipStatusService.GoogleSSOLogin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var settings = SettingsManager.GetSettings();
            string apikey = ZulipStatusService.DecryptAPIkeySSO(settings.LastOTPEncryptedApiToken, otp);
            Program.runicon.Say(apikey);
            tboApiToken.Text = apikey;
            tboZulipUser.Text = settings.ZulipEmail;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
