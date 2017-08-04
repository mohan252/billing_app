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
            deliveryData = dalObj.GetDeliveryItems(deliveryDate);
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
                if (column.Header.Caption != "IsSelected")
                    column.CellActivation = Activation.NoEdit;
                else
                {
                    column.Header.Caption = "";
                }
            }
        }

        public class CheckBoxOnHeader_CreationFilter : IUIElementCreationFilter
        {
            // This event will fire when the CheckBox is clicked. 
            public delegate void HeaderCheckBoxClickedHandler(object sender, HeaderCheckBoxEventArgs e);
            public event HeaderCheckBoxClickedHandler _CLICKED;

            public CheckBoxOnHeader_CreationFilter()
            {
                _CLICKED += new HeaderCheckBoxClickedHandler(aCheckBoxOnHeader_CreationFilter_HeaderCheckBoxClicked);
            }

            private void aCheckBoxOnHeader_CreationFilter_HeaderCheckBoxClicked(object sender, CheckBoxOnHeader_CreationFilter.HeaderCheckBoxEventArgs e)
            {
                // Check to see if the column is of type boolean.  If it is, set all the cells in that column to
                // whatever value the header checkbox is.
                if (e.Header.Column.DataType == typeof(bool))
                {
                    foreach (UltraGridRow aRow in e.Rows)
                    {
                        aRow.Cells[e.Header.Column.Index].Value = (e.CurrentCheckState == CheckState.Checked);
                    }
                }
            }

            // EventArgs used for the HeaderCheckBoxClicked event. This event has to pass in the CheckState and the ColumnHeader
            #region HeaderCheckBoxEventArgs
            public class HeaderCheckBoxEventArgs : EventArgs
            {
                private Infragistics.Win.UltraWinGrid.ColumnHeader mvarColumnHeader;
                private CheckState mvarCheckState;
                private RowsCollection mvarRowsCollection;

                public HeaderCheckBoxEventArgs(Infragistics.Win.UltraWinGrid.ColumnHeader hdrColumnHeader, CheckState chkCheckState, RowsCollection Rows)
                {
                    mvarColumnHeader = hdrColumnHeader;
                    mvarCheckState = chkCheckState;
                    mvarRowsCollection = Rows;
                }

                // Expose the rows collection for the specific row island that the header belongs to
                public RowsCollection Rows
                {
                    get
                    {
                        return mvarRowsCollection;
                    }
                }

                public Infragistics.Win.UltraWinGrid.ColumnHeader Header
                {
                    get
                    {
                        return mvarColumnHeader;
                    }
                }

                public CheckState CurrentCheckState
                {
                    get
                    {
                        return mvarCheckState;
                    }
                    set
                    {
                        mvarCheckState = value;
                    }
                }
            }
            #endregion

            private void aCheckBoxUIElement_ElementClick(Object sender, Infragistics.Win.UIElementEventArgs e)
            {
                // Get the CheckBoxUIElement that was clicked
                CheckBoxUIElement aCheckBoxUIElement = (CheckBoxUIElement)e.Element;

                // Get the Header associated with this particular element
                Infragistics.Win.UltraWinGrid.ColumnHeader aColumnHeader = (Infragistics.Win.UltraWinGrid.ColumnHeader)aCheckBoxUIElement.GetAncestor(typeof(HeaderUIElement)).GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                // Set the Tag on the Header to the new CheckState
                aColumnHeader.Tag = aCheckBoxUIElement.CheckState;

                // So that we can apply various changes only to the relevant Rows collection that the header belongs to
                HeaderUIElement aHeaderUIElement = aCheckBoxUIElement.GetAncestor(typeof(HeaderUIElement)) as HeaderUIElement;
                RowsCollection hRows = aHeaderUIElement.GetContext(typeof(RowsCollection)) as RowsCollection;

                // Raise an event so the programmer can do something when the CheckState changes
                if (_CLICKED != null)
                    _CLICKED(this, new HeaderCheckBoxEventArgs(aColumnHeader, aCheckBoxUIElement.CheckState, hRows));
            }

            public bool BeforeCreateChildElements(Infragistics.Win.UIElement parent)  // Implements Infragistics.Win.IUIElementCreationFilter.BeforeCreateChildElements
            {
                // Don't need to do anything here
                return false;
            }

            public void AfterCreateChildElements(Infragistics.Win.UIElement parent) // Implements Infragistics.Win.IUIElementCreationFilter.AfterCreateChildElements
            {
                // Check for the HeaderUIElement
                if (parent is HeaderUIElement)
                {
                    // Get the HeaderBase object from the HeaderUIElement
                    Infragistics.Win.UltraWinGrid.HeaderBase aHeader = ((HeaderUIElement)parent).Header;

                    // Only put the checkbox into headers whose DataType is boolean
                    if (aHeader.Column.DataType == typeof(bool))
                    {
                        TextUIElement aTextUIElement;
                        CheckBoxUIElement aCheckBoxUIElement = (CheckBoxUIElement)parent.GetDescendant(typeof(CheckBoxUIElement));

                        // Since the grid sometimes re-uses UIElements, we need to check to make sure 
                        // the header does not already have a CheckBoxUIElement attached to it.
                        // If it does, we just get a reference to the existing CheckBoxUIElement,
                        // and reset its properties.
                        if (aCheckBoxUIElement == null)
                        {
                            //Create a New CheckBoxUIElement
                            aCheckBoxUIElement = new CheckBoxUIElement(parent);
                        }

                        // Get the TextUIElement - this is where the text for the 
                        // Header is displayed. We need this so we can push it to the right
                        // in order to make room for the CheckBox
                        aTextUIElement = (TextUIElement)parent.GetDescendant(typeof(TextUIElement));

                        // Sanity check
                        if (aTextUIElement == null)
                            return;

                        // Get the Header and see if the Tag has been set. If the Tag is 
                        // set, we will assume it's the stored CheckState. This has to be
                        // done in order to maintain the CheckState when the grid repaints and
                        // UIElement are destroyed and recreated. 
                        Infragistics.Win.UltraWinGrid.ColumnHeader aColumnHeader =
                            (Infragistics.Win.UltraWinGrid.ColumnHeader)aCheckBoxUIElement.GetAncestor(typeof(HeaderUIElement))
                            .GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                        if (aColumnHeader.Tag == null)
                            //If the tag was nothing, this is probably the first time this 
                            //Header is being displayed, so default to Indeterminate
                            aColumnHeader.Tag = CheckState.Checked;
                        else
                            aCheckBoxUIElement.CheckState = (CheckState)aColumnHeader.Tag;

                        // Hook the ElementClick of the CheckBoxUIElement
                        aCheckBoxUIElement.ElementClick += new UIElementEventHandler(aCheckBoxUIElement_ElementClick);

                        // Add the CheckBoxUIElement to the HeaderUIElement
                        parent.ChildElements.Add(aCheckBoxUIElement);

                        // Position the CheckBoxUIElement. The number 3 here is used for 3
                        // pixels of padding between the CheckBox and the edge of the Header.
                        // The CheckBox is shifted down slightly so it is centered in the header.
                        aCheckBoxUIElement.Rect = new Rectangle(parent.Rect.X + 3, parent.Rect.Y + ((parent.Rect.Height - aCheckBoxUIElement.CheckSize.Height) / 2), aCheckBoxUIElement.CheckSize.Width, aCheckBoxUIElement.CheckSize.Height);

                        // Push the TextUIElement to the right a little to make 
                        // room for the CheckBox. 3 pixels of padding are used again. 
                        aTextUIElement.Rect = new Rectangle(aCheckBoxUIElement.Rect.Right + 3, aTextUIElement.Rect.Y, parent.Rect.Width - (aCheckBoxUIElement.Rect.Right - parent.Rect.X), aTextUIElement.Rect.Height);
                    }
                    else
                    {
                        // If the column is not a boolean column, we do not want to have a checkbox in it
                        // Since UIElements can be reused by the grid, there is a chance that one of the
                        // HeaderUIElements that we added a checkbox to for a boolean column header
                        // will be reused in a column that is not boolean.  In this case, we must remove
                        // the checkbox so that it will not appear in an inappropriate column header.
                        CheckBoxUIElement aCheckBoxUIElement = (CheckBoxUIElement)parent.GetDescendant(typeof(CheckBoxUIElement));

                        if (aCheckBoxUIElement != null)
                        {
                            parent.ChildElements.Remove(aCheckBoxUIElement);
                            aCheckBoxUIElement.Dispose();
                        }
                    }
                }
            }
        }
        List<DeliveryEntity> deliveryItemsToBePrinted = new List<DeliveryEntity>();
        IEnumerator items;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            var deliveryItemsToBePrinted = deliveryData.Where(d => d.IsSelected);
            PrintDocument pd = new PrintDocument();
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
