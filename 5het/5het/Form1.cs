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

namespace _5het
{
    
    public partial class Form1 : Form
    {
        MNBArfolyamServiceSoapClient mnbservices = new MNBArfolyamServiceSoapClient();
        BindingList<RateData> Rates = new BindingList<RateData>();

        public Form1()
        {
            InitializeComponent();
            harmas();
            dataGridView1.DataSource = Rates;
            
           
        }

        private void harmas()
        {
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020.01.01",
                endDate = "2020-06-30"
            };
            var response = mnbservices.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;

        }

        
    }
}
