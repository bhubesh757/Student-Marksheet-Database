using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentInformation
{
    class Marking
    {
        private double Average;
        private string Level;
        //I put the underscore _, in order to follow the naming conventions you followed in your example.
        public double _Average
        {
            get { return Average; }
            set { Average = value; }
        }
        public string _Level
        {
            get { return Level; }
            set { Level = value; }
        }
        public void Calculation(string[] Mark)
        {
           
            for (int i = 0; i < Mark.Length; i++)
            {
                try
                {
                    Average += Convert.ToDouble(Mark[i]);
                }
                catch 
                {
                  
                }
            }

            Average /= Mark.Length;
            Average = Math.Round(Average, 1);
            //Detecting the level.
            if (Average >= 90 && Average <= 100)
            {
                Level = "4+";
            }
            if (Average >= 85 && Average < 90)
            {
                Level = "4";
            }
            if (Average >= 80 && Average < 85)
            {
                Level = "3+";
            }
            if (Average >= 75 && Average < 80)
            {
                Level = "3";
            }
            if (Average >= 70 && Average < 75)
            {
                Level = "2+";
            }
            if (Average >= 60 && Average < 70)
            {
                Level = "2";
            }
            if (Average >= 50 && Average < 60)
            {
                Level = "1+";
            }
            if (Average < 50)
            {
                Level = "1";
            }

        }


    }
}
