using System;
using System.Windows.Forms;
using StopWatch.Data.Services;
using StopWatch.UI.Models;

namespace StopWatch.UI.Views
{
    /// <summary>
    /// Insert Form.
    /// </summary>
    public partial class InsertForm : Form
    {
        private const string FileName = "InsertFormUserSettings.xml";
        private const string DefaultTimeType = "Case,Project,Event,General";
        private string fileLocation;

        private XmlUserSettings xmlUserSettings;
        private InsertFormUserSettings insertFormUserSettings;

        public InsertForm(string saveDirectory)
        {
            FileLocation = saveDirectory;
            LoadForm();
        }

        public InsertForm(string saveDirectory, int time, string notes = null)
        {
            FileLocation = saveDirectory;
            LoadForm();
            tbNotes.Text = notes;
            tbTimeAmount.Text = time.ToString();
        }

        private string FileLocation
        {
            get
            {
                return fileLocation;
            }

            set
            {
                fileLocation = value + "\\" + FileName;
            }
        }

        private void LoadForm()
        {
            InitializeComponent();
            xmlUserSettings = new XmlUserSettings(
                FileLocation,
                insertFormUserSettings = new InsertFormUserSettings());
            LoaduserPreferences();
        }

        private void LoaduserPreferences()
        {
            if (!System.IO.File.Exists(FileLocation))
            {
                insertFormUserSettings.TimeType = DefaultTimeType;
                SaveuserPreferences();
            }
            else
            {
                insertFormUserSettings = xmlUserSettings.ReadFromFile() as InsertFormUserSettings;
            }

            UpdateComboBoxTimeType();
        }

        private void SaveuserPreferences()
        {
            xmlUserSettings.SaveToFile(insertFormUserSettings);
        }

        private void UpdateComboBoxTimeType()
        {
            cbTimeType.Items.Clear();
            cbTimeType.Items.AddRange(insertFormUserSettings.TimeType.Split(','));
        }

        private void BtnEditTimeType_Click(object sender, EventArgs e)
        {
            var editTimeForm = new EditTimeTypeForm(insertFormUserSettings.TimeType.Split(','));
            editTimeForm.ShowDialog();

            object[] timeTypes = editTimeForm.GetTimeTypeList;
            string timeTypesAdd = string.Empty;
            foreach (object timeType in timeTypes)
            {
                timeTypesAdd += timeType.ToString();
                if (timeType != timeTypes[timeTypes.Length - 1])
                {
                    timeTypesAdd += ",";
                }
            }

            insertFormUserSettings.TimeType = timeTypesAdd;
            UpdateComboBoxTimeType();
            SaveuserPreferences();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            var timeTracker = new StopWatch.Data.Models.TimeTracker
            {
                DateTimeEntered = DateTime.Now.ToString(),
                TimeType = cbTimeType.Text,
                Notes = tbNotes.Text,
                SubGroupTimeType = tbSubGroupTimeType.Text,
                TimeWorkedAmount = Convert.ToInt32(tbTimeAmount.Text),
                WorkedDate = dtDateWorked.Text,
            };

            try
            {
                SqliteDataAccess.SaveLaborEntry(timeTracker);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Abort;
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                this.Close();
            }
        }
    }
}
