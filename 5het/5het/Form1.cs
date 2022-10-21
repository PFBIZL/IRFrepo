using _5het.Entities;
using _5het.MNBServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace _5het
{
    
    public partial class Form1 : Form
    {
        MNBArfolyamServiceSoapClient mnbservices = new MNBArfolyamServiceSoapClient();
        BindingList<RateData> Rates = new BindingList<RateData>();
        XmlDocument xml = new XmlDocument();
        
        public Form1()
        {
            InitializeComponent();

            RefreshData();
            
            
           
        }

        private void harmas()
        {
            var request = new GetExchangeRatesRequestBody()
            {
                //currencyNames = "EUR",
                //startDate = "2020.01.01",
                //endDate = "2020-06-30"
                currencyNames = comboBox1.SelectedItem.ToString(),
                startDate = dateTimePicker1.Value.ToString(),
                endDate = dateTimePicker2.Value.ToString(),
            };
            var response = mnbservices.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            xml.LoadXml(result);

        }

        private void otos()
        {
            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData();
                Rates.Add(rate);

                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                {
                    rate.Value = value / unit;
                }

            }

        }

        private void hatos()
        {
            var series = chart1.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chart1.Legends[0];
            legend.Enabled = false;

            var chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;


        }

        private void RefreshData()
        {
            Rates.Clear();
            harmas();
            dataGridView1.DataSource = Rates;
            otos();
            hatos();
            chart1.DataSource = Rates;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
