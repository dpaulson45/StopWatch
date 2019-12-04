using StopWatch.Data;
using System;
using System.Windows.Forms;

namespace StopWatch.TimeTracker
{
    public partial class InsertForm : Form
    {
        private const string FileName = "InsertFormUserSettings.xml";
        private const string DefaultTimeType = "Case,Project,Event,General";
        private string fileLocation;

        private XmlUserSettings XmlUserSettings;
        private InsertFormUserSettings insertFormUserSettings;

        private string FileLocation { get { return fileLocation; } set { fileLocation = value + "\\" + FileName; } }

        public InsertForm(string SaveDirectory)
        {
            FileLocation = SaveDirectory;
            LoadForm();
        }

        public InsertForm(string SaveDirectory, int Time, string Notes = null)
        {
            FileLocation = SaveDirectory;
            LoadForm();
            tbNotes.Text = Notes;
            tbTimeAmount.Text = Time.ToString();
        }

        private void LoadForm()
        {
            InitializeComponent();
            XmlUserSettings = new XmlUserSettings(FileLocation,
                (insertFormUserSettings = new InsertFormUserSettings()));
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
                insertFormUserSettings = XmlUserSettings.ReadFromFile() as InsertFormUserSettings;
            }

            UpdateComboBoxTimeType();
        }

        private void SaveuserPreferences()
        {
            XmlUserSettings.SaveToFile(insertFormUserSettings);
        }

        private void UpdateComboBoxTimeType()
        {
            cbTimeType.Items.Clear();
            cbTimeType.Items.AddRange(insertFormUserSettings.TimeType.Split(','));
        }

        private void BtnEditTimeType_Click(object sender, EventArgs e)
        {
            EditTimeTypeForm editTimeForm = new EditTimeTypeForm(insertFormUserSettings.TimeType.Split(','));
            editTimeForm.ShowDialog();

            object[] timeTypes = editTimeForm.GetTimeTypeList;
            string timeTypesAdd = "";
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
            TimeTrackerModel timeTracker = new TimeTrackerModel
            {
                DateTimeEntered = DateTime.Now.ToString(),
                TimeType = cbTimeType.Text,
                Notes = tbNotes.Text,
                SubGroupTimeType = tbSubGroupTimeType.Text,
                TimeWorkedAmount = Convert.ToInt32(tbTimeAmount.Text),
                WorkedDate = dtDateWorked.Text
            };

            try
            {
                SqliteDataAccess.SaveLaborEntry(timeTracker);
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
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

    public class InsertFormUserSettings
    {
        public string TimeType { get; set; }
    }
}
