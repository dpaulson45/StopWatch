using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch
{
    class ClassCaseVariables
    {
    
    public int ms01, ms10, sec01, sec10, min01, min10, hour01, hour10;
    public string CaseFile, CaseStringText, CurrentTimeString; 

    public string CurrentTimeStringSet()
    {

         CurrentTimeString = Convert.ToString(hour10 + hour01 + "hrs " + min10 + min01 + "mins " + sec10 + sec01 + "secs");
         return CurrentTimeString;
    }

    public int RestTimes()
    {

        ms01 = 0;
        ms10 = 0;
        sec01 = 0;
        sec10 = 0;
        min01 = 0;
        min10 = 0;
        hour01 = 0;
        hour10 = 0;

        CaseStringText = "";

        return 0; 
    }

    public void CheckForDataFiles(String CaseString)
    {
        if(!System.IO.File.Exists(CaseString))
        {
            System.IO.FileStream fs = System.IO.File.Create(CaseString);
            //Closing the file as well!!
            fs.Close();
        }
       
    }

    //Write the Data to a File 
    public void SaveMyShit(string CaseString)
    {

        //Open the file 
        System.IO.TextWriter myFile = new System.IO.StreamWriter(CaseString);

        try
        {
            myFile.WriteLine(sec01);
            myFile.WriteLine(sec10);
            myFile.WriteLine(min01);
            myFile.WriteLine(min10);
            myFile.WriteLine(hour01);
            myFile.WriteLine(hour10);
            myFile.WriteLine(CaseStringText);

        }

        finally
        {
            myFile.Close();
        }
    }

    public void ReadThatShit(string stuffandthings)
    {

        //Opening that file 

        System.IO.TextReader disFile = new System.IO.StreamReader(stuffandthings);

        try
        {
            string drugs01 = disFile.ReadLine();
            string drugs02 = disFile.ReadLine();
            string drugs03 = disFile.ReadLine();
            string drugs04 = disFile.ReadLine();
            string drugs05 = disFile.ReadLine();
            string drugs06 = disFile.ReadLine();
            string drugs07 = disFile.ReadLine();

            sec01 = Convert.ToInt32(drugs01);
            sec10 = Convert.ToInt32(drugs02);
            min01 = Convert.ToInt32(drugs03);
            min10 = Convert.ToInt32(drugs04);
            hour01 = Convert.ToInt32(drugs05);
            hour10 = Convert.ToInt32(drugs06);

            CaseStringText = drugs07;
        }

        //close the file
        finally
        {
            disFile.Close();
        }
    }

    }

}
