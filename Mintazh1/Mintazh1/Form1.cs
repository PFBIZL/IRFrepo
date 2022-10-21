using Mintazh1.NewFolder1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mintazh1
{
    public partial class Form1 : Form
    {
        List<OlympicResult> results = new List<OlympicResult>();
        public Form1()
        {
            InitializeComponent();
            Bem("Summer_olympic_Medals.csv");
            Evcsin();
            uj();
            
        }
        private void Bem(string FileName)
        {
            using(StreamReader sr = new StreamReader("Summer_olympic_Medals.csv",Encoding.Default))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(',');
                    var or  = new   OlympicResult();
                    {
                        or.Year = int.Parse(line[0]);
                        or.Country = line[3];
                        var medals = new int[3];
                        medals[0] = int.Parse(line[5]);
                        medals[1] = int.Parse(line[6]);
                        medals[2] = int.Parse(line[7]);
                        or.Medals = medals;
                        


                        
                    }
                }
            }
        }
        private void Evcsin()
        {
            var years = (from y in results
                         orderby y.Year
                         select y.Year).Distinct();
            comboBox1.DataSource = years.ToList();

        }

        private int Kim(OlympicResult or)
        {
            
            var betterc = 0;
            
            var szures =  from y in results
                          where y.Year == or.Year && y.Country != or.Country
                          select y;
            foreach (var r in szures)
            {
                if (r.Medals[0] > or.Medals[0])
                {
                    betterc++;
                }
                else if (r.Medals[0] == or.Medals[0])
                {
                    if (r.Medals[1] > or.Medals[1])
                    {
                        betterc++;
                    }
                    else if (r.Medals[1] == or.Medals[1])
                    {
                        betterc++;
                    }
                    if (r.Medals[2] > or.Medals[2])
                    {
                        betterc++;
                    }
                }
            }

            return betterc+1;

        }

        private void uj()
        {
            foreach (var s in results)
            {
                s.Position = Kim(s);
            }

        }




    }

    
}
