using _5hetgyak.Entities;
using _5hetgyak.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _5hetgyak
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<string> Currencies = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            //LoadCurr();
            RefreshData_7feladat();
            
        }

        private void RefreshData_7feladat()
        {
            Rates.Clear();
            Loadxml_5feladat(LoadMNB_feladat3_majd7esmodositas());
            Loaddata_6feladat();
        }
        private void Loadxml_5feladat(string result)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                var tempRate = new RateData();

                tempRate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                if (childElement == null) continue;
                tempRate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);

                if (unit != 0) tempRate.Value = value / unit;

                Rates.Add(tempRate);
            }


        }
        private string LoadMNB_feladat3_majd7esmodositas()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = comboBox1.SelectedItem.ToString(),
                startDate = dateTimePicker1.Value.ToString(),
                endDate = dateTimePicker2.Value.ToString()
            };

            var response = mnbService.GetExchangeRates(request);

            var result = response.GetExchangeRatesResult;
            dataGridView1.DataSource = Rates;

            return result.ToString();
        }

        private void Loaddata_6feladat()
        {
            chart1.DataSource = Rates;

            var series = chart1.Series[0];
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
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

        /*private void LoadCurr_8feladat()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetCurrenciesRequestBody();

            var response = mnbService.GetCurrencies(request);

            var result = response.GetCurrenciesResult;

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(result.ToString());

            foreach (XmlElement element in xml.DocumentElement.ChildNodes)
            {
                if (element.HasChildNodes)
                {
                    for (int i = 0; i < element.ChildNodes.Count; i++)
                    {
                        Currencies.Add(element.ChildNodes[i].InnerText);
                    }
                }
            }

            comboBox1.DataSource = Currencies;
            comboBox1.Text = "EUR";

        }
        */

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData_7feladat();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData_7feladat();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData_7feladat();
        }
    }
}
