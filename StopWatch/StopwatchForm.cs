using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class StopwatchForm : Form
    {


       List<ClassCaseVariables> ListArray = new List<StopWatch.ClassCaseVariables>();
       
       
        
       ClassCaseVariables MainCount = new ClassCaseVariables();
       ClassCaseVariables Case01 = new ClassCaseVariables();
       ClassCaseVariables Case02 = new ClassCaseVariables();
       ClassCaseVariables Case03 = new ClassCaseVariables();
       ClassCaseVariables Case04 = new ClassCaseVariables();
       ClassCaseVariables Case05 = new ClassCaseVariables();

       //Booleans 

       Boolean case01Reset;
       Boolean case02Reset;
       Boolean case03Reset;
       Boolean case04Reset;
       Boolean case05Reset;
       Boolean displayedTime;

       //Radio 
       Boolean ResetButtonEnabled;

       //Dont need to save twice
       Boolean DontSaveTwice;

       Boolean case01Display;
       Boolean case02Display;
       Boolean case03Display;
       Boolean case04Display;
       Boolean case05Display;
       Boolean mainDisplay;
       

       public void SetDataFiles()
       {


           Case01.CaseFile = "Case01DataFile.dat";
           Case02.CaseFile = "Case02DataFile.dat";
           Case03.CaseFile = "Case03DataFile.dat";
           Case04.CaseFile = "Case04DataFile.dat";
           Case05.CaseFile = "Case05DataFile.dat";

       }
        
     private void SaveClassInformationfromClass(ClassCaseVariables CaseVar1, ClassCaseVariables CaseVar2)
    {
        CaseVar1.ms01 = CaseVar2.ms01;
        CaseVar1.ms10 = CaseVar2.ms10;
        CaseVar1.sec01 = CaseVar2.sec01;
        CaseVar1.sec10 = CaseVar2.sec10;
        CaseVar1.min01 = CaseVar2.min01;
        CaseVar1.min10 = CaseVar2.min10;
        CaseVar1.hour01 = CaseVar2.hour01;
        CaseVar1.hour10 = CaseVar2.hour10;
        //CaseVar1.CurrentTimeString = CaseVar2.CurrentTimeString;

    }
     


        public int displayTime()
        {
            secBox0.Text = Convert.ToString(MainCount.sec01);
            secBox1.Text = Convert.ToString(MainCount.sec10);
            minBox0.Text = Convert.ToString(MainCount.min01);
            minBox1.Text = Convert.ToString(MainCount.min10);
            hourBox0.Text = Convert.ToString(MainCount.hour01);
            hourBox1.Text = Convert.ToString(MainCount.hour10);

            return 0;

        }

        public void displayUpdate()
        {

            if(case01Display == true)
            {

                //Case01.CurrentTimeString = case1TimeBox.Text;
                case1TimeBox.Text = Case01.CurrentTimeStringSet();
                //Case01.CaseStringText = case1Box.Text;
                case1Box.Text = Case01.CaseStringText;

            }

            if(case02Display == true)
            {
                case2TimeBox.Text = Case02.CurrentTimeStringSet();
                case2Box.Text = Case02.CaseStringText;
            }

            if(case03Display == true)
            {
                case3TimeBox.Text = Case03.CurrentTimeStringSet();
                case3Box.Text = Case03.CaseStringText;
            }

            if(case04Display == true)
            {
                case4TimeBox.Text = Case04.CurrentTimeStringSet();
                case4Box.Text = Case04.CaseStringText;
            }

            if(case05Display == true)
            {
                case5TimeBox.Text = Case05.CurrentTimeStringSet();
                case5Box.Text = Case05.CaseStringText;
            }

            if (mainDisplay == true)
            {

                secBox0.Text = "0";
                secBox1.Text = "0";
                minBox0.Text = "0";
                minBox1.Text = "0";
                hourBox0.Text = "0";
                hourBox1.Text = "0";
            }

            case01Display = false;
            case02Display = false;
            case03Display = false;
            case04Display = false;
            case05Display = false;
            mainDisplay = false;

            
        }

        public void SetRadioButton()
        {

            if(ResetButtonEnabled == true)
            {
                caseRadio1.Enabled = true;
                caseRadio2.Enabled = true;
                caseRadio3.Enabled = true;
                caseRadio4.Enabled = true;
                caseRadio5.Enabled = true;
                ResetButtonEnabled = false;
            }

            else if (ResetButtonEnabled == false)
            {
                if (caseRadio1.Checked == true)
                {
                    caseRadio1.Enabled = true;
                    caseRadio2.Enabled = false;
                    caseRadio3.Enabled = false;
                    caseRadio4.Enabled = false;
                    caseRadio5.Enabled = false;
                }

                if (caseRadio2.Checked == true)
                {
                    caseRadio1.Enabled = false;
                    caseRadio2.Enabled = true;
                    caseRadio3.Enabled = false;
                    caseRadio4.Enabled = false;
                    caseRadio5.Enabled = false;
                }

                if (caseRadio3.Checked == true)
                {
                    caseRadio1.Enabled = false;
                    caseRadio2.Enabled = false;
                    caseRadio3.Enabled = true;
                    caseRadio4.Enabled = false;
                    caseRadio5.Enabled = false;
                }

                if (caseRadio4.Checked == true)
                {
                    caseRadio1.Enabled = false;
                    caseRadio2.Enabled = false;
                    caseRadio3.Enabled = false;
                    caseRadio4.Enabled = true;
                    caseRadio5.Enabled = false;
                }

                if (caseRadio5.Checked == true)
                {
                    caseRadio1.Enabled = false;
                    caseRadio2.Enabled = false;
                    caseRadio3.Enabled = false;
                    caseRadio4.Enabled = false;
                    caseRadio5.Enabled = true;
                }

            }

        }

        public void StartStopItAll()
        {
            //Check if the timer is running 
            if(timer1.Enabled == false)
            {
                if( caseRadio1.Checked == true)
                {
                    case1Btn.Text = "Stop";
                    case2Btn.Text = "Start";
                    case3Btn.Text = "Start";
                    case4Btn.Text = "Start";
                    case5Btn.Text = "Start";
                    //case01Display = true;
                }

                if (caseRadio2.Checked == true)
                {
                    case1Btn.Text = "Start";
                    case2Btn.Text = "Stop";
                    case3Btn.Text = "Start";
                    case4Btn.Text = "Start";
                    case5Btn.Text = "Start";
                    
                }
                if (caseRadio3.Checked == true)
                {
                    case1Btn.Text = "Start";
                    case2Btn.Text = "Start";
                    case3Btn.Text = "Stop";
                    case4Btn.Text = "Start";
                    case5Btn.Text = "Start";
                }

                if (caseRadio4.Checked == true)
                {
                    case1Btn.Text = "Start";
                    case2Btn.Text = "Start";
                    case3Btn.Text = "Start";
                    case4Btn.Text = "Stop";
                    case5Btn.Text = "Start";
                }

                if (caseRadio5.Checked == true)
                {
                    case1Btn.Text = "Start";
                    case2Btn.Text = "Start";
                    case3Btn.Text = "Start";
                    case4Btn.Text = "Start";
                    case5Btn.Text = "Stop";

                }

                
                
                //Set the Defaults 
                timer1.Enabled = true;
                startBtn.Text = "Stop";
            }
            else if (timer1.Enabled == true)
            {
                if (caseRadio1.Checked == true)
                {
                    case1Btn.Text = "Start";
                    case01Display = true;
                }

                if (caseRadio2.Checked == true)
                {
                    case2Btn.Text = "Start";
                    case02Display = true;
                }
                if (caseRadio3.Checked == true)
                {
                    case3Btn.Text = "Start";
                    case03Display = true;
                }

                if (caseRadio4.Checked == true)
                {
                    case4Btn.Text = "Start";
                    case04Display = true;
                }

                if (caseRadio5.Checked == true)
                {
                    case5Btn.Text = "Start";
                    case05Display = true;
                }

                //Set the Defaults 
                timer1.Enabled = false;
                startBtn.Text = "Start";

                //If Save twice is set to true

                if (DontSaveTwice == false)
                {
                    saveTime();
                }
                DontSaveTwice = true;
                ResetButtonEnabled = true;
            }
            displayUpdate();
            SetRadioButton();
        }

        //Function to save time

        public int saveTime()

        {
            if (caseRadio1.Checked == true)
            {
                SaveClassInformationfromClass(Case01, MainCount);
                Case01.SaveMyShit(Case01.CaseFile);
                case01Display = true;   
            }

            if (caseRadio2.Checked == true)
            {
                case02Display = true;
                SaveClassInformationfromClass(Case02, MainCount);
                Case02.SaveMyShit(Case02.CaseFile);   
            }

            if (caseRadio3.Checked == true)
            {
                SaveClassInformationfromClass(Case03, MainCount);
                Case03.SaveMyShit(Case03.CaseFile);
                case03Display = true;
            }

            if (caseRadio4.Checked == true)
            {
                SaveClassInformationfromClass(Case04, MainCount);
                Case04.SaveMyShit(Case04.CaseFile);
                case04Display = true;
            }

            if (caseRadio5.Checked == true)
            {
                SaveClassInformationfromClass(Case05, MainCount);
                Case05.SaveMyShit(Case05.CaseFile);
                case05Display = true;
            }
            ResetButtonEnabled = true;
            SetRadioButton();
            displayUpdate();

            return 0;
        }
        //Update the current ClassCaseVariables while the timer is going 
        public void UpdateOnTheFly()
        {

            if(caseRadio1.Checked == true)
            {
                SaveClassInformationfromClass(Case01, MainCount);
                Case01.SaveMyShit(Case01.CaseFile);
            }

            if(caseRadio2.Checked == true)
            {
                SaveClassInformationfromClass(Case02, MainCount);
                Case02.SaveMyShit(Case02.CaseFile);
            }

            if(caseRadio3.Checked == true)
            {
                SaveClassInformationfromClass(Case03, MainCount);
                Case03.SaveMyShit(Case03.CaseFile);
            }

            if(caseRadio4.Checked == true)
            {
                SaveClassInformationfromClass(Case04, MainCount);
                Case04.SaveMyShit(Case04.CaseFile);
            }

            if(caseRadio5.Checked == true)
            {
                SaveClassInformationfromClass(Case05, MainCount);
                Case05.SaveMyShit(Case05.CaseFile);
            }
        }

        //
        /// <summary>
        /// Here is my main part of the Form ########################################
        /// 
        /// 
        /// 
        /// 
        /// 
        /// </summary>
        public StopwatchForm()
        {
            InitializeComponent();
            SetDataFiles();
            Case01.CheckForDataFiles(Case01.CaseFile);
            Case02.CheckForDataFiles(Case02.CaseFile);
            Case03.CheckForDataFiles(Case03.CaseFile);
            Case04.CheckForDataFiles(Case04.CaseFile);
            Case05.CheckForDataFiles(Case05.CaseFile);

            Case01.ReadThatShit(Case01.CaseFile);
            Case02.ReadThatShit(Case02.CaseFile);
            Case03.ReadThatShit(Case03.CaseFile);
            Case04.ReadThatShit(Case04.CaseFile);
            Case05.ReadThatShit(Case05.CaseFile);

            //Load the First Case Time for first launch view
            SaveClassInformationfromClass(MainCount, Case01);

            //Test Load Text Box
            case1Box.Text = Case01.CaseStringText;
            case2Box.Text = Case02.CaseStringText;
            case3Box.Text = Case03.CaseStringText;
            case4Box.Text = Case04.CaseStringText;
            case5Box.Text = Case05.CaseStringText;

            displayTime();

            
            case01Display = true;
            case02Display = true;
            case03Display = true;
            case04Display = true;
            case05Display = true;
            
            displayUpdate();

            case01Reset = false;
            case02Reset = false;
            case03Reset = false;
            case04Reset = false;
            case05Reset = false;


            mainDisplay = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Start Button 
            StartStopItAll();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            
            MainCount.sec01++;
            //UpdateOnTheFly();

            if (MainCount.sec01 == 10 && MainCount.sec10 != 5)
            {
                MainCount.sec10++;
                MainCount.sec01 = 0;
            }

            else if (MainCount.sec01 == 10 && MainCount.sec10 == 5)
            {
                MainCount.min01++;
                MainCount.sec01 = 0;
                MainCount.sec10 = 0;
            }

            if (MainCount.min01 == 10 && MainCount.min10 != 5)
            {
                MainCount.min10++;
                MainCount.min01 = 0;
            }

            if (MainCount.min01 == 10 && MainCount.min10 == 5)
            {
                MainCount.hour01++;
                MainCount.min01 = 0;
                MainCount.min10 = 0;
            }

            if (MainCount.hour01 == 10 && MainCount.hour10 != 5)
            {
                MainCount.hour10++;
                MainCount.hour01 = 0;
            }
            
            displayTime();
            UpdateOnTheFly();
        }

        private void resetAll_Click(object sender, EventArgs e)
        {
            //Reset all Button 
            
            case01Display = true;
            case02Display = true;
            case03Display = true;
            case04Display = true;
            case05Display = true;
            mainDisplay = true;

            
            Case01.RestTimes();
            Case02.RestTimes();
            Case03.RestTimes();
            Case04.RestTimes();
            Case05.RestTimes();
            MainCount.RestTimes();

            //Write the RestAll to File
            Case01.SaveMyShit(Case01.CaseFile);
            Case02.SaveMyShit(Case02.CaseFile);
            Case03.SaveMyShit(Case03.CaseFile);
            Case04.SaveMyShit(Case04.CaseFile);
            Case05.SaveMyShit(Case05.CaseFile);
            
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
            }
            
            caseRadio1.Checked = true;
            StartStopItAll();
            displayUpdate();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Main Reset btn

            if (caseRadio1.Checked == true)
            {
                case01Display = true;
                Case01.RestTimes();
            }

            if(caseRadio2.Checked == true)
            {
                case02Display = true;
                Case02.RestTimes();
            }

            if (caseRadio3.Checked == true)
            {
                case03Display = true;
                Case03.RestTimes();
            }

            if (caseRadio4.Checked == true)
            {
                case04Display = true;
                Case04.RestTimes();
            }

            if (caseRadio5.Checked == true)
            {
                case05Display = true;
                Case05.RestTimes();
            }
            StartStopItAll();
            mainDisplay = true;
            MainCount.RestTimes();

            displayUpdate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void case1Btn_Click(object sender, EventArgs e)
        {
            //Case 1 Start button 
            
            if(startBtn.Text == "Start")
            {
                if (caseRadio1.Checked == false)
                {
                    caseRadio1.Checked = true;
                }
            }

            else if (startBtn.Text == "Stop" && caseRadio1.Checked == true)
            {
                saveTime();
            } 
            

            else if (startBtn.Text == "Stop" && caseRadio1.Checked == false)
            {
                saveTime();
                DontSaveTwice = true;
                caseRadio1.Checked = true;
                timer1.Enabled = false;
            }
            StartStopItAll();

            }

        private void case2Btn_Click(object sender, EventArgs e)
        {
            //Case 2 Start button 

            if (startBtn.Text == "Start")
            {
                if (caseRadio2.Checked == false)
                {
                    caseRadio2.Checked = true;
                }
            }

            else if (startBtn.Text == "Stop" && caseRadio2.Checked == true)
            {
                saveTime();
            }

            else if (startBtn.Text == "Stop" && caseRadio2.Checked == false)
            {
                saveTime();
                DontSaveTwice = true;
                caseRadio2.Checked = true;
                timer1.Enabled = false;
                
            }

            StartStopItAll();
        }

        private void case3Btn_Click(object sender, EventArgs e)
        {
            //Case 3 Start button 

            if (startBtn.Text == "Start")
            {
                if (caseRadio3.Checked == false)
                {
                    caseRadio3.Checked = true;
                }
                
            }

            else if (startBtn.Text == "Stop" && caseRadio3.Checked == true)
            {
                saveTime();
            }

            else if (startBtn.Text == "Stop" && caseRadio3.Checked == false)
            {
                saveTime();
                DontSaveTwice = true;
                caseRadio3.Checked = true;
                timer1.Enabled = false;
            }
            StartStopItAll();
        }

        private void case4Btn_Click(object sender, EventArgs e)
        {
            //Case 4 Start button 

            if (startBtn.Text == "Start")
            {
                if (caseRadio4.Checked == false)
                {
                    caseRadio4.Checked = true;
                }
            }

            else if (startBtn.Text == "Stop" && caseRadio4.Checked == true)
            {
                saveTime();
            }

            else if (startBtn.Text == "Stop" && caseRadio4.Checked == false)
            {
                saveTime(); 
                DontSaveTwice = true;
                caseRadio4.Checked = true;
                timer1.Enabled = false;
            }
            StartStopItAll();
        }

        private void case5Btn_Click(object sender, EventArgs e)
        {
            //Case 5 Start button 

            if (startBtn.Text == "Start")
            {
                if (caseRadio5.Checked == false)
                {
                    caseRadio5.Checked = true;
                }
            }

            else if (startBtn.Text == "Stop" && caseRadio5.Checked == true)
            {
                saveTime();
            }

            else if (startBtn.Text == "Stop" && caseRadio5.Checked == false)
            {
                saveTime(); 
                DontSaveTwice = true;
                caseRadio5.Checked = true;
                timer1.Enabled = false;
            }
            StartStopItAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Reset btn 1 
            case01Display = true;
            if(caseRadio1.Checked == true)
            {
                displayedTime = true;
                mainDisplay = true;
                MainCount.RestTimes();
            }
            
            Case01.RestTimes();
            displayUpdate();
            Case01.SaveMyShit(Case01.CaseFile);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            case02Display = true;
            if(caseRadio2.Checked == true)
            {
                displayedTime = true;
                mainDisplay = true;
                MainCount.RestTimes();
            }

            Case02.RestTimes();
            displayUpdate();
            Case02.SaveMyShit(Case02.CaseFile);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            case03Display = true;
            if(caseRadio3.Checked == true)
            {
                displayedTime = true;
                mainDisplay = true;
                MainCount.RestTimes();
            }
            Case03.RestTimes();
            displayUpdate();
            Case03.SaveMyShit(Case03.CaseFile);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Reset btn 4

            case04Display = true;
            if(caseRadio4.Checked == true)
            {
                displayedTime = true;
                mainDisplay = true;
                MainCount.RestTimes();
            }
            Case04.RestTimes();
            displayUpdate();
            Case04.SaveMyShit(Case04.CaseFile);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Reset btn 5

            case05Display = true;
            if(caseRadio5.Checked == true)
            {
                displayedTime = true;
                mainDisplay = true;
                MainCount.RestTimes();
            }
            Case05.RestTimes();
            displayUpdate();
            Case05.SaveMyShit(Case05.CaseFile);
        }

        private void caseRadio1_CheckedChanged(object sender, EventArgs e)
        {
            //Radio Case 01 btn 
            SaveClassInformationfromClass(MainCount, Case01);
            displayTime();

        }

        private void caseRadio2_CheckedChanged(object sender, EventArgs e)
        {
            //Radio Case 02 btn 
            SaveClassInformationfromClass(MainCount, Case02);
            displayTime();
        }

        private void caseRadio3_CheckedChanged(object sender, EventArgs e)
        {
            //Radio Case 03 btn 
            SaveClassInformationfromClass(MainCount, Case03);
            displayTime();
        }

        private void caseRadio4_CheckedChanged(object sender, EventArgs e)
        {
            //Radio Case 04 btn 
            SaveClassInformationfromClass(MainCount, Case04);
            displayTime();
        }

        private void caseRadio5_CheckedChanged(object sender, EventArgs e)
        {
            //Radio Case 05 btn 
            SaveClassInformationfromClass(MainCount, Case05);
            displayTime();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void case1Box_TextChanged(object sender, EventArgs e)
        {
            Case01.CaseStringText = case1Box.Text;
            Case01.SaveMyShit(Case01.CaseFile);
        }

        private void case2Box_TextChanged(object sender, EventArgs e)
        {
            Case02.CaseStringText = case2Box.Text;
            Case02.SaveMyShit(Case02.CaseFile);
        }

        private void case3Box_TextChanged(object sender, EventArgs e)
        {
            Case03.CaseStringText = case3Box.Text;
            Case03.SaveMyShit(Case03.CaseFile);
        }

        private void case4Box_TextChanged(object sender, EventArgs e)
        {
            Case04.CaseStringText = case4Box.Text;
            Case04.SaveMyShit(Case04.CaseFile);
        }

        private void case5Box_TextChanged(object sender, EventArgs e)
        {
            Case05.CaseStringText = case5Box.Text;
            Case05.SaveMyShit(Case05.CaseFile);
        }

    }
}
