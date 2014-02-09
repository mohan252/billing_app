using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Infragistics.Win;
using Dundas.Charting.Utilities;
using Dundas.Charting.WinControl;

namespace BillingApplication
{
    public partial class Reports : Form
    {
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // Avoid dialog processing of arrow keys
            if (keyData == Keys.Left || keyData == Keys.Right)
            {
                return false;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void dChart_Click(object sender, System.EventArgs e)
        {
            // Set input focus to the chart control
            dChart.Focus();

            // Set the selection start variable to that of the current position
            this.SelectionStart = dChart.ChartAreas["Default"].CursorX.Position;
        }

        private void ProcessSelect(System.Windows.Forms.KeyEventArgs e)
        {
            // Process keyboard keys
            if (e.KeyCode == Keys.Right)
            {
                // Make sure the selection start value is assigned
                if (this.SelectionStart == double.NaN)
                    this.SelectionStart = dChart.ChartAreas["Default"].CursorX.Position;

                // Set the new cursor position 
                dChart.ChartAreas["Default"].CursorX.Position += dChart.ChartAreas["Default"].CursorX.Interval;
            }
            else if (e.KeyCode == Keys.Left)
            {
                // Make sure the selection start value is assigned
                if (this.SelectionStart == double.NaN)
                    this.SelectionStart = dChart.ChartAreas["Default"].CursorX.Position;

                // Set the new cursor position 
                dChart.ChartAreas["Default"].CursorX.Position -= dChart.ChartAreas["Default"].CursorX.Interval;
            }

            // If the cursor is outside the view, set the view
            // so that the cursor can be seen
            SetView();


            dChart.ChartAreas["Default"].CursorX.SelectionStart = this.SelectionStart;
            dChart.ChartAreas["Default"].CursorX.SelectionEnd = dChart.ChartAreas["Default"].CursorX.Position;
        }

        private void SetView()
        {
            // Keep the cursor from leaving the max and min axis points
            if (dChart.ChartAreas["Default"].CursorX.Position < 0)
                dChart.ChartAreas["Default"].CursorX.Position = 0;

            else if (dChart.ChartAreas["Default"].CursorX.Position > 75)
                dChart.ChartAreas["Default"].CursorX.Position = 75;


            // Move the view to keep the cursor visible
            if (dChart.ChartAreas["Default"].CursorX.Position < dChart.ChartAreas["Default"].AxisX.View.Position)
                dChart.ChartAreas["Default"].AxisX.View.Position = dChart.ChartAreas["Default"].CursorX.Position;

            else if ((dChart.ChartAreas["Default"].CursorX.Position >
                (dChart.ChartAreas["Default"].AxisX.View.Position + dChart.ChartAreas["Default"].AxisX.View.Size)))
            {
                dChart.ChartAreas["Default"].AxisX.View.Position =
                    (dChart.ChartAreas["Default"].CursorX.Position - dChart.ChartAreas["Default"].AxisX.View.Size);
            }
        }

        private void ProcessScroll(System.Windows.Forms.KeyEventArgs e)
        {
            // Process keyboard keys
            if (e.KeyCode == Keys.Right)
                // set the new cursor position 
                dChart.ChartAreas["Default"].CursorX.Position += dChart.ChartAreas["Default"].CursorX.Interval;

            else if (e.KeyCode == Keys.Left)
                // Set the new cursor position 
                dChart.ChartAreas["Default"].CursorX.Position -= dChart.ChartAreas["Default"].CursorX.Interval;

            // If the cursor is outside the view, set the view
            // so that the cursor can be seen
            SetView();


            // Set the selection start variable in case shift arrows are selected
            this.SelectionStart = dChart.ChartAreas["Default"].CursorX.Position;

            // Reset the old selection start and end
            dChart.ChartAreas["Default"].CursorX.SelectionStart = double.NaN;
            dChart.ChartAreas["Default"].CursorX.SelectionEnd = double.NaN;
        }

        private void dChart_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Left))
            {
                // If the key event is shifted, process as a selection
                if (e.Shift)
                    ProcessSelect(e);
                else // Process as a scroll
                    ProcessScroll(e);
            }

            // On enter, zoom the selection
            else if (e.KeyCode == Keys.Enter)
            {
                double start, end;

                if (dChart.ChartAreas["Default"].CursorX.SelectionStart > dChart.ChartAreas["Default"].CursorX.SelectionEnd)
                {
                    start = dChart.ChartAreas["Default"].CursorX.SelectionEnd;
                    end = dChart.ChartAreas["Default"].CursorX.SelectionStart;
                }
                else
                {
                    end = dChart.ChartAreas["Default"].CursorX.SelectionEnd;
                    start = dChart.ChartAreas["Default"].CursorX.SelectionStart;
                }

                // Return if no selection actually made
                if (start == end)
                    return;

                // Zoom the selection
                dChart.ChartAreas["Default"].AxisX.View.Zoom(start, (end - start), DateTimeIntervalType.Number, true);

                // Reset selection values
                this.SelectionStart = dChart.ChartAreas["Default"].CursorX.Position;
                dChart.ChartAreas["Default"].CursorX.SelectionStart = double.NaN;
                dChart.ChartAreas["Default"].CursorX.SelectionEnd = double.NaN;

            }

            else if (e.KeyCode == Keys.Back)
            {
                // Reset zoom back to previous view state
                dChart.ChartAreas["Default"].AxisX.View.ZoomReset(1);

                // Reset selection values
                this.SelectionStart = dChart.ChartAreas["Default"].CursorX.Position;
                dChart.ChartAreas["Default"].CursorX.SelectionStart = double.NaN;
                dChart.ChartAreas["Default"].CursorX.SelectionEnd = double.NaN;
            }

        }

    }
}
