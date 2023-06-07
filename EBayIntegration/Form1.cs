using eBayAPIIntegration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using Newtonsoft.Json;
using eBayAPIIntegration.Contracts;
using eBayAPIIntegration.APIParams;

namespace EBayIntegration
{
    public partial class Form1 : Form
    {
        TokenInfo globalTokenInfo;
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("microsoft-edge:https://developer.ebay.com/api-docs/buy/static/ref-buy-browse-filters.html");
        }

        private async void LoadData()
        {
            GetUserToken info = new GetUserToken();
            var tokenInfo = await info.GetAccessToken(ConfigurationSettings.AppSettings["TokenURL"],
                                ConfigurationSettings.AppSettings["ClientID"],
                                ConfigurationSettings.AppSettings["ClientSecret"]);

            MessageBox.Show("Token Generated. API is ready to use.");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            txtOffset.Text = "0";
            txtLimit.Text = "100";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
             searchItems();
        }

        private async void searchItems()
        {
            string q_value = string.Empty;
            if (checkBox1.Checked)
            {
                string temp = txtQString.Text;
                temp = temp.Replace(",", "%20");
                q_value = temp;    
            }
            else
            {
                string temp = string.Empty;
                temp = txtQString.Text;
                q_value = string.Format("({0})", temp);
            }
            
            if(string.IsNullOrEmpty(txtLimit.Text))
            {
                MessageBox.Show("Limit cannot be empty");
                return;
            }
            int limit = int.Parse(txtLimit.Text);
            if (string.IsNullOrEmpty(txtOffset.Text))
            {
                MessageBox.Show("Offset cannot be empty");
                return;
            }
            int offset = int.Parse(txtOffset.Text);

            List<ItemSummary> items = new List<ItemSummary>();
            ItemInfo data = null;
            int total = 0;

            // This block gets API data, it is fetching all pages since limit cannot exceed 200 at one time
            do
            {
                string URL = ConfigurationSettings.AppSettings["SearchURL"];
                Filter filter = MakeFilter();
                GetItems orders = new GetItems(ConfigurationSettings.AppSettings["affiliateCampaignId"],
                                               ConfigurationSettings.AppSettings["affiliateReferenceId"],
                                               ConfigurationSettings.AppSettings["country"],
                                               ConfigurationSettings.AppSettings["zip"],
                                               ConfigurationSettings.AppSettings["deviceId"]);
                string s_data = await orders.SearchItems(URL, q_value, limit, offset, filter, false);
                data = JsonConvert.DeserializeObject<ItemInfo>(s_data);
                if(data == null)
                {
                    FileWriter.WriteError(s_data);
                    break;
                }
                
                if (data.itemSummaries != null)
                {
                    FileWriter.WriteResponse(s_data);
                    total += data.itemSummaries.Count;
                    items.AddRange(data.itemSummaries);
                    offset += limit;
                }
                else
                {
                    FileWriter.WriteError(s_data);
                    txtResult.Text = "";
                    break;
                }
            }
            while (total < data.total);
            string output = JsonConvert.SerializeObject(items);
            txtResult.Text = output;
        }

        /// <summary>
        /// This method is being used for creating filters for eBay search API
        /// documentation can be find here: https://developer.ebay.com/api-docs/buy/static/ref-buy-browse-filters.html
        /// </summary>
        /// <returns></returns>
        private Filter MakeFilter()
        {
            Filter filter = new Filter();

            //filter.LowerBoundBidCount = 0;
            //filter.UpperBoundBidCount = 10;
            //filter.BuyingOptions = new BuyingOptions()
            //{
            //    Auction = true,
            //    BestOffer = false,
            //    ClassifiedAd = true,
            //    FixedPrice = true
            //};
            //filter.CharityOnly = false;
            //filter.ConditionIds = new List<int>() { };
            filter.Condition = new Condition() { New = true };
            //filter.LastSoldDateFrom = null;
            //filter.LastSoldDateTo = DateTime.Now.AddDays(20);
            //filter.FreeShipping = true;
            //filter.PaymentByCreditCardOnly = true;
            filter.ItemLocationCountry = "US";
            //filter.PickupCountry = "US";
            //filter.PickupPostalCode = "123";
            //filter.PickupRadius = 25;
            //filter.PickupRadiusUnit = "km";
            //filter.EnableDeliveryOptions = true;
            //filter.ExcludeCategoryIds = new List<int>() { 1, 2, 3, 4, 5 };
            //filter.ExcludeSellers = new List<string>() { "1", "2", "3" };
            //filter.DeliveryCountry = "US";
            //filter.DeliveryPostalCode = "123";
            //filter.ItemEndDateFrom = DateTime.Now;
            //filter.ItemEndDateTo = DateTime.Now.AddDays(20);
            //filter.ItemStartDateFrom = DateTime.Now;
            //filter.ItemStartDateTo = DateTime.Now.AddDays(20);
            //filter.LowerBoundPrice = 10;
            //filter.UpperBoundPrice = 20;
            //filter.PriceCurrency = "USD";
            //filter.QualifiedPrograms = "AUTHENTICITY_GUARANTEE";
            //filter.ReturnsAccepted = true;
            //filter.SearchInDescription = true;
            //filter.SellerAccountTypes = "INDIVIDUAL";
            //filter.Sellers = new List<string>() { "123", "123", "123" };
            //filter.GuaranteedDeliveryInDays = 3;
            return filter;
        }

        private void txtLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtOffset_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
