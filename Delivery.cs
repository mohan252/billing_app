using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BillingApplication
{
    public partial class Delivery : Form
    {
        DAL dalObj = new DAL();
        public Delivery()
        {
            InitializeComponent();
        }

        private void Delivery_Load(object sender, EventArgs e)
        {
            var deliveryData = dalObj.GetDeliveryItems(null);
            this.gridDelivery.DataSource = deliveryData;
            this.gridDelivery.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.gridDelivery.DisplayLayout.Override.DefaultRowHeight = 25;
            gridDelivery.DisplayLayout.Bands[0].Columns["MERCHANTNAME"].Width = 200;
            gridDelivery.DisplayLayout.Bands[0].Columns["PARTY"].Width = 300;
            gridDelivery.DisplayLayout.Bands[0].Columns["INVOICE"].Width = 150;
            gridDelivery.DisplayLayout.Bands[0].Columns["PARTICULARS"].Width = 400;
        }
    }
}
