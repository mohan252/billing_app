using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.Drawing.Printing;
using System.Collections;
using BillingApplication.Models;

namespace BillingApplication
{
    public partial class Delivery : Form
    {
        CheckBoxOnHeader_CreationFilter aCheckBoxOnHeader_CreationFilter = new CheckBoxOnHeader_CreationFilter();
        DAL dalObj = new DAL();
        List<DeliveryEntity> deliveryData = new List<DeliveryEntity>();
        public Delivery()
        {
            InitializeComponent();
        }

        private void Delivery_Load(object sender, EventArgs e)
        {
            var deliveryDate = Common.NextBusinessDay();
            billDate.Value = deliveryDate;
            LoadData(deliveryDate);
        }

        private void LoadData(DateTime deliveryDate)
        {
            deliveryData = DeliveryItemsDataContext.GetDeliveryItems(deliveryDate);
            this.gridDelivery.DataSource = deliveryData;
            gridDelivery.DisplayLayout.Bands[0].Columns["MERCHANTNAME"].Tag = CheckState.Checked;
            this.gridDelivery.CreationFilter = aCheckBoxOnHeader_CreationFilter;
            this.gridDelivery.DisplayLayout.Override.DefaultRowHeight = 25;
            gridDelivery.Height = 750;

            var checkColumn = gridDelivery.DisplayLayout.Bands[0].Columns["ISSELECTED"];
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;

            gridDelivery.DisplayLayout.Bands[0].Columns["MERCHANTNAME"].Width = 200;
            gridDelivery.DisplayLayout.Bands[0].Columns["PARTY"].Width = 300;
            gridDelivery.DisplayLayout.Bands[0].Columns["INVOICE"].Width = 150;
            gridDelivery.DisplayLayout.Bands[0].Columns["PARTICULARS"].Width = 400;
            for (int i = 0; i < gridDelivery.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                var column = gridDelivery.DisplayLayout.Bands[0].Columns[i];
                if (column.Header.Caption == "IsSelected")
                {
                    column.Header.Caption = "";
                }
            }
        }

        List<DeliveryEntity> deliveryItemsToBePrinted = new List<DeliveryEntity>();
        IEnumerator items;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            var deliveryItemsToBePrinted = deliveryData.Where(d => d.IsSelected);
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom",600, 600);
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            items = deliveryData.Where(d => d.IsSelected).GetEnumerator();
            if (items.MoveNext())
            {
                pd.Print();
            }
        }

        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var item = items.Current;
            Common.PrintDelivery(e.Graphics, item as DeliveryEntity);
            e.HasMorePages = items.MoveNext();
        }

        private void billDate_ValueChanged(object sender, EventArgs e)
        {
            LoadData(billDate.Value);
        }

        /*
            IEnumerator items;

            public void StartPrint()
            {
               PrintDocument pd = new PrintDocument();
               pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
               items = GetEnumerator();
               if (items.MoveNext())
               {
                   pd.Print();
               }
            }

            private void pd_PrintPage(object sender, PrintPageEventArgs ev)
            {
                const int neededHeight = 200;
                int line =0;
                // this will be called multiple times, so keep track where you are...
                // do your drawings, calculating how much space you have left on one page
                bool more = true;
                do
                {
                    // draw your bars for item, handle multilple columns if needed
                    var item = items.Current;
                    line++;
                    // in the ev.MarginBouds the width and height of this page is available
                    // you use that to see if a next row will fit
                    if ((line * neededHeight) < ev.MarginBounds.Height )
                    {
                        break;
                    }
                    more = items.MoveNext();
                } while (more)
                // stop if there are no more items in your Iterator
                ev.HasMorePages = more;
            }
         */
    }
}
