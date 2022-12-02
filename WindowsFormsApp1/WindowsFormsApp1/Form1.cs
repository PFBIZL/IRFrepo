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
using System.Xml;
using WindowsFormsApp1.Abstravt;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Product> _products = new List<Product>();
        public Form1()
        {
            InitializeComponent();
            Loadxml();
            DPporduct();
        }

        private string Getxml(string g)
        {
            using(var sr = new StreamReader(g,Encoding.Default))
            {
                var xml = sr.ReadToEnd();
                return xml;
            }
        }

        private void Loadxml()
        {
            var xml = new XmlDocument();
            xml.LoadXml(Getxml("Menu"));

            var name = xml.DocumentElement.SelectSingleNode("Name").InnerText;
            var description = xml.DocumentElement.SelectSingleNode("descroption").InnerText;
            var calories = xml.DocumentElement.SelectSingleNode("calories").InnerText;
            var type = xml.DocumentElement.SelectSingleNode("Type").InnerText;

            if (type == "food")
            {
                var p = new Food();
                p.Title = name;
                p.Description = description;
                p.Calories = int.Parse(calories);
            }
            else
            {
                var p = new Drink();
                p.Title = name;
                p.Calories = int.Parse(calories);

                _products.Add(p);
            };

    
            


        }

        private void DPporduct()
        {
            var topposition = 0;
            var rendez = from x in _products
                         orderby x.Title
                         select x;
            foreach (var p in _products)
            {
                p.Left = 0;
                p.Top = topposition;
                Controls.Add(p);
                topposition = p.Height;
            }
        }


    }

}
