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
    public partial class Form1 : Form
    {

        int  ms01, ms10, sec01, sec10, min01, min10, hour01, hour10, day01, day10 = 0;

        //Declare time values per case

        int case01ms01, case01ms10, case01sec01, case01sec10, case01min01, case01min10, case01hour01, case01hour10, case01day01, case01day10 = 0;
        int case02ms01, case02ms10, case02sec01, case02sec10, case02min01, case02min10, case02hour01, case02hour10, case02day01, case02day10 = 0;
        int case03ms01, case03ms10, case03sec01, case03sec10, case03min01, case03min10, case03hour01, case03hour10, case03day01, case03day10 = 0;
        int case04ms01, case04ms10, case04sec01, case04sec10, case04min01, case04min10, case04hour01, case04hour10, case04day01, case04day10 = 0;
        int case05ms01, case05ms10, case05sec01, case05sec10, case05min01, case05min10, case05hour01, case05hour10, case05day01, case05day10 = 0;

        //Booleans 

        Boolean case01Reset;
        Boolean case02Reset;
        Boolean case03Reset;
        Boolean case04Reset;
        Boolean case05Reset;
        Boolean displayedTime;

        Boolean case01Display;
        Boolean case02Display;
        Boolean case03Display;
        Boolean case04Display;
        Boolean case05Display;
        Boolean mainDisplay;

        public int displayTime()
        {
            secBox0.Text = Convert.ToString(sec01);
            secBox1.Text = Convert.ToString(sec10);
            minBox0.Text = Convert.ToString(min01);
            minBox1.Text = Convert.ToString(min10);
            hourBox0.Text = Convert.ToString(hour01);
            hourBox1.Text = Convert.ToString(hour10);

            return 0;
        }

        public int displayReset()
        {

            if(case01Display == true)
            {

                case1TimeBox.Text = "";
                case1Box.Text = "";

            }

            if(case02Display == true)
            {
                case2TimeBox.Text = "";
                case2Box.Text = "";
            }

            if(case03Display == true)
            {
                case3TimeBox.Text = "";
                case3Box.Text = "";
            }

            if(case04Display == true)
            {
                case4TimeBox.Text = "";
                case4Box.Text = "";
            }

            if(case05Display == true)
            {
                case5TimeBox.Text = "";
                case5Box.Text = "";
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

            return 0;
        }


        public int resetTimes()
        {

            if(case01Reset == true)
            {
                case01ms01 = 0;
                case01ms10 = 0;
                case01sec01 = 0;
                case01sec10 = 0;
                case01min01 = 0;
                case01min10 = 0;
                case01hour01 = 0;
                case01hour10 = 0;

            }

            if(case02Reset == true)
            
            {

                case02ms01 = 0;
                case02ms10 = 0;
                case02sec01 = 0;
                case02sec10 = 0;
                case02min01 = 0;
                case02min10 = 0;
                case02hour01 = 0;
                case02hour10 = 0;

            }

            if(case03Reset == true)
            {

                case03ms01 = 0;
                case03ms10 = 0;
                case03sec01 = 0;
                case03sec10 = 0;
                case03min01 = 0;
                case03min10 = 0;
                case03hour01 = 0;
                case03hour10 = 0;

            }

            if(case04Reset == true)
            {

                case04ms01 = 0;
                case04ms10 = 0;
                case04sec01 = 0;
                case04sec10 = 0;
                case04min01 = 0;
                case04min10 = 0;
                case04hour01 = 0;
                case04hour10 = 0;
            }

            if(case05Reset == true)
            {

                case05ms01 = 0;
                case05ms10 = 0;
                case05sec01 = 0;
                case05sec10 = 0;
                case05min01 = 0;
                case05min10 = 0;
                case05hour01 = 0;
                case05hour10 = 0;
            }

            if(displayedTime == true)
            {
                ms01 = 0;
                ms10 = 0;
                sec01 = 0;
                sec10 = 0;
                min01 = 0;
                min10 = 0;
                hour01 = 0;
                hour10 = 0;

            }

            case01Reset = false;
            case02Reset = false;
            case03Reset = false;
            case04Reset = false;
            case05Reset = false;
            displayedTime = false;

            return 0;
        }



        //Function to save time

        public int saveTime()

        {
            if (caseRadio1.Checked == true)
            {
                timer1.Enabled = false;
                case1Btn.Text = "Start";
                //save the times 

                case01ms01 = ms01;
                case01ms10 = ms10;
                case01sec01 = sec01;
                case01sec10 = sec10;
                case01min01 = min01;
                case01min10 = min10;
                case01hour01 = hour01;
                case01hour10 = hour10;

                //display the time 

                case1TimeBox.Text = Convert.ToString(case01hour10 + case01hour01 + "hrs " + case01min10 + case01min01 + "mins " + case01sec10 + case01sec01 + "secs");


                //Enable the working btn


                caseRadio2.Enabled = true;
                caseRadio3.Enabled = true;
                caseRadio4.Enabled = true;
                caseRadio5.Enabled = true;

            }

            if (caseRadio2.Checked == true)
            {

                timer1.Enabled = false;
                case2Btn.Text = "Start";
                //save the times 

                case02ms01 = ms01;
                case02ms10 = ms10;
                case02sec01 = sec01;
                case02sec10 = sec10;
                case02min01 = min01;
                case02min10 = min10;
                case02hour01 = hour01;
                case02hour10 = hour10;

                //display the time 

                case2TimeBox.Text = Convert.ToString(case02hour10 + case02hour01 + "hrs " + case02min10 + case02min01 + "mins " + case02sec10 + case02sec01 + "secs");

                caseRadio1.Enabled = true;
                caseRadio3.Enabled = true;
                caseRadio4.Enabled = true;
                caseRadio5.Enabled = true;

            }

            if (caseRadio3.Checked == true)
            {

                timer1.Enabled = false;
                case3Btn.Text = "Start";
                //save the times 

                case03ms01 = ms01;
                case03ms10 = ms10;
                case03sec01 = sec01;
                case03sec10 = sec10;
                case03min01 = min01;
                case03min10 = min10;
                case03hour01 = hour01;
                case03hour10 = hour10;

                //display the time 

                case3TimeBox.Text = Convert.ToString(case03hour10 + case03hour01 + "hrs " + case03min10 + case03min01 + "mins " + case03sec10 + case03sec01 + "secs");

                caseRadio1.Enabled = true;
                caseRadio2.Enabled = true;
                caseRadio4.Enabled = true;
                caseRadio5.Enabled = true;

            }

            if (caseRadio4.Checked == true)
            {

                timer1.Enabled = false;
                case4Btn.Text = "Start";
                //save the times 

                case04ms01 = ms01;
                case04ms10 = ms10;
                case04sec01 = sec01;
                case04sec10 = sec10;
                case04min01 = min01;
                case04min10 = min10;
                case04hour01 = hour01;
                case04hour10 = hour10;

                //display the time 

                case4TimeBox.Text = Convert.ToString(case04hour10 + case04hour01 + "hrs " + case04min10 + case04min01 + "mins " + case04sec10 + case04sec01 + "secs");

                caseRadio1.Enabled = true;
                caseRadio2.Enabled = true;
                caseRadio3.Enabled = true;
                caseRadio5.Enabled = true;

            }

            if (caseRadio5.Checked == true)
            {

                timer1.Enabled = false;
                case5Btn.Text = "Start";
                //save the times 

                case05ms01 = ms01;
                case05ms10 = ms10;
                case05sec01 = sec01;
                case05sec10 = sec10;
                case05min01 = min01;
                case05min10 = min10;
                case05hour01 = hour01;
                case05hour10 = hour10;

                //display the time 

                case5TimeBox.Text = Convert.ToString(case05hour10 + case05hour01 + "hrs " + case05min10 + case05min01 + "mins " + case05sec10 + case05sec01 + "secs");

                caseRadio1.Enabled = true;
                caseRadio2.Enabled = true;
                caseRadio3.Enabled = true;
                caseRadio4.Enabled = true;

            }

            return 0;
        }
        
        public int loadTime()
        {
            if(caseRadio1.Checked == true)
            {
                ms01 = case01ms01;
                ms10 = case01ms10;
                sec01 = case01sec01;
                sec10 = case01sec10;
                min01 = case01min01;
                min10 = case01min10;
                hour01 = case01hour01;
                hour10 = case01hour10;
            }

            if(caseRadio2.Checked == true)
            {
                ms01 = case02ms01;
                ms10 = case02ms10;
                sec01 = case02sec01;
                sec10 = case02sec10;
                min01 = case02min01;
                min10 = case02min10;
                hour01 = case02hour01;
                hour10 = case02hour10;
            }

            if(caseRadio3.Checked == true)
            {
                ms01 = case03ms01;
                ms10 = case03ms10;
                sec01 = case03sec01;
                sec10 = case03sec10;
                min01 = case03min01;
                min10 = case03min10;
                hour01 = case03hour01;
                hour10 = case03hour10;
            }

            if(caseRadio4.Checked == true)
            {
                ms01 = case04ms01;
                ms10 = case04ms10;
                sec01 = case04sec01;
                sec10 = case04sec10;
                min01 = case04min01;
                min10 = case04min10;
                hour01 = case04hour01;
                hour10 = case04hour10;

            }

            if(caseRadio5.Checked == true)
            {
                ms01 = case05ms01;
                ms10 = case05ms10;
                sec01 = case05sec01;
                sec10 = case05sec10;
                min01 = case05min01;
                min10 = case05min10;
                hour01 = case05hour01;
                hour10 = case05hour10;
            }


            return 0;
        }
        public Form1()
        {
            InitializeComponent();

            case01Reset = false;
            case02Reset = false;
            case03Reset = false;
            case04Reset = false;
            case05Reset = false;

            case01Display = false;
            case02Display = false;
            case03Display = false;
            case04Display = false;
            case05Display = false;
            mainDisplay = false;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Start Button 


            //change the name of the Text of the button 
            if(startBtn.Text == "Start")
            {
                startBtn.Text = "Stop";
                if (caseRadio1.Checked == true)
                {
                    //Load the time 
                    loadTime();


                    timer1.Enabled = true;
                    case1Btn.Text = "Stop";

                    //Disable other buttons

                    caseRadio2.Enabled = false;
                    caseRadio3.Enabled = false;
                    caseRadio4.Enabled = false;
                    caseRadio5.Enabled = false;

                }

                if (caseRadio2.Checked == true)
                {

                    loadTime();

                    timer1.Enabled = true;
                    case2Btn.Text = "Stop";


                    caseRadio1.Enabled = false;
                    caseRadio3.Enabled = false;
                    caseRadio4.Enabled = false;
                    caseRadio5.Enabled = false;
                }

                if(caseRadio3.Checked == true)
                {

                    loadTime();

                    timer1.Enabled = true;
                    case3Btn.Text = "Stop";


                    caseRadio1.Enabled = false;
                    caseRadio2.Enabled = false;
                    caseRadio4.Enabled = false;
                    caseRadio5.Enabled = false;
                }

                if (caseRadio4.Checked == true)
                {

                    loadTime();

                    timer1.Enabled = true;
                    case4Btn.Text = "Stop";


                    caseRadio1.Enabled = false;
                    caseRadio2.Enabled = false;
                    caseRadio3.Enabled = false;
                    caseRadio5.Enabled = false;

                }

                if (caseRadio5.Checked == true)
                {


                    timer1.Enabled = true;
                    case5Btn.Text = "Stop";


                    caseRadio1.Enabled = false;
                    caseRadio2.Enabled = false;
                    caseRadio3.Enabled = false;
                    caseRadio4.Enabled = false;

                }

            }
            else if (startBtn.Text == "Stop")
            {
                startBtn.Text = "Start";
                if (caseRadio1.Checked == true)
                {
                    timer1.Enabled = false;
                    case1Btn.Text = "Start";
                    //save the times 


                    saveTime();

                }

                if (caseRadio2.Checked == true)
                {

                    timer1.Enabled = false;
                    case2Btn.Text = "Start";
                    //save the times 

                    saveTime();

                }

                if(caseRadio3.Checked == true)
                {

                    timer1.Enabled = false;
                    case3Btn.Text = "Start";
                    //save the times 

                    saveTime();

                }

                if (caseRadio4.Checked == true)
                {

                    timer1.Enabled = false;
                    case4Btn.Text = "Start";
                    //save the times 


                    saveTime();

                }

                if(caseRadio5.Checked == true)
                {

                    timer1.Enabled = false;
                    case5Btn.Text = "Start";
                    //save the times 


                    saveTime();

                }

            }

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Timer 1 Case

            sec01++;

            if(sec01 == 10 && sec10 != 5)
            {
                sec10++;
                sec01 = 0;
            }

            else if(sec01 == 10 && sec10 == 5)
            {
                min01++;
                sec01 = 0;
                sec10 = 0;
                
            }

            if( min01 == 10 && min10 != 5)
            {
                min10++;
                min01 = 0;
            }

            if(min01 == 10 && min10 == 5)
            {
                hour01++;
                min01 = 0;
                min10 = 0;
            }

            if(hour01 == 10 && hour10 != 5)
            {
                hour10++;
                hour01 = 0;
            }

            //millSecBox0.Text = Convert.ToString(ms01);
            //millSecBox1.Text = Convert.ToString(ms10);
            secBox0.Text = Convert.ToString(sec01);
            secBox1.Text = Convert.ToString(sec10);
            minBox0.Text = Convert.ToString(min01);
            minBox1.Text = Convert.ToString(min10);
            hourBox0.Text = Convert.ToString(hour01);
            hourBox1.Text = Convert.ToString(hour10);

        }

        private void resetAll_Click(object sender, EventArgs e)
        {

            case01Display = true;
            case02Display = true;
            case03Display = true;
            case04Display = true;
            case05Display = true;
            mainDisplay = true;


            caseRadio1.Enabled = true;
            caseRadio2.Enabled = true;
            caseRadio3.Enabled = true;
            caseRadio4.Enabled = true;
            caseRadio5.Enabled = true;

            case1Btn.Text = "Start";
            case2Btn.Text = "Start";
            case3Btn.Text = "Start";
            case4Btn.Text = "Start";
            case5Btn.Text = "Start";

            startBtn.Text = "Start";
            
            caseRadio1.Checked = true;
            timer1.Enabled = false;

            

            case01Reset = true;
            case02Reset = true;
            case03Reset = true;
            case04Reset = true;
            case05Reset = true;
            displayedTime = true;
            resetTimes();
            displayReset();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Main Reset btn

            if (caseRadio1.Checked == true)
            {

                if (startBtn.Text == "Stop")
                {
                    startBtn.Text = "Start";
                    case1Btn.Text = "Start";
                    timer1.Enabled = false;
                }
                
                case01Display = true;
                case01Reset = true;
                
                

            }

            if(caseRadio2.Checked == true)
            {
                if (startBtn.Text == "Stop")
                {
                    startBtn.Text = "Start";
                    case2Btn.Text = "Start";
                    timer1.Enabled = false;
                }

                case02Display = true;
                case02Reset = true;

            }

            if (caseRadio3.Checked == true)
            {
                if (startBtn.Text == "Stop")
                {
                    startBtn.Text = "Start";
                    case3Btn.Text = "Start";
                    timer1.Enabled = false;
                }

                case03Display = true;
                case03Reset = true;

            }

            if (caseRadio4.Checked == true)
            {

                if (startBtn.Text == "Stop")
                {
                    startBtn.Text = "Start";
                    case4Btn.Text = "Start";
                    timer1.Enabled = false;
                }

                case04Display = true;
                case04Reset = true;

            }

            if (caseRadio5.Checked == true)
            {

                if (startBtn.Text == "Stop")
                {
                    startBtn.Text = "Start";
                    case5Btn.Text = "Start";
                    timer1.Enabled = false;
                }

                case05Display = true;
                case05Reset = true;

            }

            mainDisplay = true;

            displayReset();
            resetTimes();

            caseRadio1.Enabled = true;
            caseRadio2.Enabled = true;
            caseRadio3.Enabled = true;
            caseRadio4.Enabled = true;
            caseRadio5.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Time box case 1

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
                startBtn.Text = "Stop";
                //Load the time 

                //loadTime();


                timer1.Enabled = true;
                case1Btn.Text = "Stop";

                //Disable other buttons

                caseRadio2.Enabled = false;
                caseRadio3.Enabled = false;
                caseRadio4.Enabled = false;
                caseRadio5.Enabled = false;
            }

            else if (startBtn.Text == "Stop" && caseRadio1.Checked == true)
            {

                startBtn.Text = "Start";

                timer1.Enabled = false;
                case1Btn.Text = "Start";
                //save the times 

                saveTime();


            }

            else if (startBtn.Text == "Stop" && caseRadio1.Checked == false)
            {
                saveTime();
                
                //Enable the 1st Radio btn and check it 

                caseRadio1.Enabled = true;
                caseRadio1.Checked = true;

                //Disable the rest of them 

                caseRadio2.Enabled = false;
                caseRadio3.Enabled = false;
                caseRadio4.Enabled = false;
                caseRadio5.Enabled = false;

                //Set the rest of the start buttons to 'Start'

                case1Btn.Text = "Stop";
                case2Btn.Text = "Start";
                case3Btn.Text = "Start";
                case4Btn.Text = "Start";
                case5Btn.Text = "Start";

                //loadTime();

                timer1.Enabled = true;   
                
            }

           
            
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
                startBtn.Text = "Stop";
                //Load the time No longer needed 

                //loadTime();


                timer1.Enabled = true;
                case2Btn.Text = "Stop";

                //Disable other buttons

                caseRadio1.Enabled = false;
                caseRadio3.Enabled = false;
                caseRadio4.Enabled = false;
                caseRadio5.Enabled = false;
            }

            else if (startBtn.Text == "Stop" && caseRadio2.Checked == true)
            {

                startBtn.Text = "Start";

                timer1.Enabled = false;
                case2Btn.Text = "Start";
                //save the times 

                saveTime();


            }

            else if (startBtn.Text == "Stop" && caseRadio2.Checked == false)
            {
                saveTime();

                //Enable the 1st Radio btn and check it 

                caseRadio2.Enabled = true;
                caseRadio2.Checked = true;

                //Disable the rest of them 

                caseRadio1.Enabled = false;
                caseRadio3.Enabled = false;
                caseRadio4.Enabled = false;
                caseRadio5.Enabled = false;

                //Set the rest of the start buttons to 'Start'

                case1Btn.Text = "Start";
                case2Btn.Text = "Stop";
                case3Btn.Text = "Start";
                case4Btn.Text = "Start";
                case5Btn.Text = "Start";

                //loadTime();

                timer1.Enabled = true;

            }
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
                startBtn.Text = "Stop";
                //Load the time 

                //loadTime();


                timer1.Enabled = true;
                case3Btn.Text = "Stop";

                //Disable other buttons

                caseRadio1.Enabled = false;
                caseRadio2.Enabled = false;
                caseRadio4.Enabled = false;
                caseRadio5.Enabled = false;
            }

            else if (startBtn.Text == "Stop" && caseRadio3.Checked == true)
            {

                startBtn.Text = "Start";

                timer1.Enabled = false;
                case3Btn.Text = "Start";
                //save the times 

                saveTime();


            }

            else if (startBtn.Text == "Stop" && caseRadio3.Checked == false)
            {
                saveTime();

                //Enable the 1st Radio btn and check it 

                caseRadio3.Enabled = true;
                caseRadio3.Checked = true;

                //Disable the rest of them 

                caseRadio1.Enabled = false;
                caseRadio2.Enabled = false;
                caseRadio4.Enabled = false;
                caseRadio5.Enabled = false;

                //Set the rest of the start buttons to 'Start'

                case1Btn.Text = "Start";
                case2Btn.Text = "Start";
                case3Btn.Text = "Stop";
                case4Btn.Text = "Start";
                case5Btn.Text = "Start";

                //loadTime();

                timer1.Enabled = true;

            }
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
                startBtn.Text = "Stop";
                //Load the time 

                //loadTime();


                timer1.Enabled = true;
                case4Btn.Text = "Stop";

                //Disable other buttons

                caseRadio1.Enabled = false;
                caseRadio2.Enabled = false;
                caseRadio3.Enabled = false;
                caseRadio5.Enabled = false;
            }

            else if (startBtn.Text == "Stop" && caseRadio4.Checked == true)
            {

                startBtn.Text = "Start";

                timer1.Enabled = false;
                case4Btn.Text = "Start";
                //save the times 

                saveTime();


            }

            else if (startBtn.Text == "Stop" && caseRadio4.Checked == false)
            {
                saveTime();

                //Enable the 1st Radio btn and check it 

                caseRadio4.Enabled = true;
                caseRadio4.Checked = true;

                //Disable the rest of them 

                caseRadio1.Enabled = false;
                caseRadio2.Enabled = false;
                caseRadio3.Enabled = false;
                caseRadio5.Enabled = false;

                //Set the rest of the start buttons to 'Start'

                case1Btn.Text = "Start";
                case2Btn.Text = "Start";
                case3Btn.Text = "Start";
                case4Btn.Text = "Stop";
                case5Btn.Text = "Start";

                //loadTime();

                timer1.Enabled = true;

            }
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
                startBtn.Text = "Stop";
                //Load the time 

                //loadTime();


                timer1.Enabled = true;
                case5Btn.Text = "Stop";

                //Disable other buttons

                caseRadio1.Enabled = false;
                caseRadio2.Enabled = false;
                caseRadio3.Enabled = false;
                caseRadio4.Enabled = false;
            }

            else if (startBtn.Text == "Stop" && caseRadio5.Checked == true)
            {

                startBtn.Text = "Start";

                timer1.Enabled = false;
                case5Btn.Text = "Start";
                //save the times 

                saveTime();


            }

            else if (startBtn.Text == "Stop" && caseRadio5.Checked == false)
            {
                saveTime();

                //Enable the 1st Radio btn and check it 

                caseRadio5.Enabled = true;
                caseRadio5.Checked = true;

                //Disable the rest of them 

                caseRadio1.Enabled = false;
                caseRadio2.Enabled = false;
                caseRadio3.Enabled = false;
                caseRadio4.Enabled = false;

                //Set the rest of the start buttons to 'Start'

                case1Btn.Text = "Start";
                case2Btn.Text = "Start";
                case3Btn.Text = "Start";
                case4Btn.Text = "Start";
                case5Btn.Text = "Stop";

                //loadTime();

                timer1.Enabled = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Reset btn 1 

            case01Display = true;

            case01Reset = true;
            if(caseRadio1.Checked == true)
            {
                displayedTime = true;
                mainDisplay = true;
            }

            displayReset();
            resetTimes();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Reset btn 2

            case02Display = true;
            case02Reset = true;

            if(caseRadio2.Checked == true)
            {
                displayedTime = true;
                mainDisplay = true;
            }
            
            displayReset();
            resetTimes();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Reset btn 3


            case03Display = true;
            case03Reset = true;

            if(caseRadio3.Checked == true)
            {
                displayedTime = true;
                mainDisplay = true;
            }

            displayReset();
            resetTimes();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Reset btn 4

            case04Display = true;
            case04Reset = true;

            if(caseRadio4.Checked == true)
            {
                displayedTime = true;
                mainDisplay = true;
            }

            displayReset();
            resetTimes();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Reset btn 5

            case05Display = true;
            case05Reset = true;

            if(caseRadio5.Checked == true)
            {
                displayedTime = true;
                mainDisplay = true;
            }

            displayReset();
            resetTimes();


        }

        private void caseRadio1_CheckedChanged(object sender, EventArgs e)
        {
            //Radio Case 01 btn 

            loadTime();
            displayTime();

        }

        private void caseRadio2_CheckedChanged(object sender, EventArgs e)
        {
            //Radio Case 02 btn 

            loadTime();
            displayTime();
        }

        private void caseRadio3_CheckedChanged(object sender, EventArgs e)
        {

            //Radio Case 03 btn 

            loadTime();
            displayTime();
        }

        private void caseRadio4_CheckedChanged(object sender, EventArgs e)
        {
            //Radio Case 04 btn 

            loadTime();
            displayTime();
        }

        private void caseRadio5_CheckedChanged(object sender, EventArgs e)
        {
            //Radio Case 05 btn 

            loadTime();
            displayTime();
        }
    }
}
