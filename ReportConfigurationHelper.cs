using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Dundas.Charting.Utilities;

namespace BillingApplication
{
    public partial class Reports : Form
    {
        static ChartType diplayingChartTypeConfigObj = null;
        string selectedChart = "";
        Dundas.Charting.WinControl.Chart dChart = null;
        UltraGrid UGrid = null;
        int lblFilterYPos = 25;
        int filterYPos = 0;
        private void BuildReportsTabs()
        {
            foreach (Report report in reportConfigObj.Report)
            {
                TabPage page = new TabPage(report.Name);
                page.Tag = report;
                tabReport.TabPages.Add(page);
            }
        }
        private DataTable ModifyLineData(DataTable dt)
        {
            string[] months = new string[] { "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "Jan", "Feb", "Mar" };
            if (dt.Columns.Contains("PARTY"))
                dt.Columns.Remove("PARTY");
            DataTable rsltTb = dt.Clone();
            DataRow[] rows = null;
            for (int i = 0; i < months.Length; i++)
            {
                rows = dt.Select("month = '" + months[i] + "'");
                if (rows != null && rows.Length > 0)
                {
                    rsltTb.Rows.Add(rows[0].ItemArray);
                    rows = null;
                }
            }
            return rsltTb;
        }
        private UltraGrid CreateGrid()
        {
            UltraGrid uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            ((System.ComponentModel.ISupportInitialize)(uGrid)).BeginInit();
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            uGrid.DisplayLayout.Appearance = appearance1;
            uGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            uGrid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            uGrid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            uGrid.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            uGrid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            uGrid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            uGrid.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            uGrid.DisplayLayout.MaxColScrollRegions = 1;
            uGrid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            uGrid.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            uGrid.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            uGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            uGrid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            uGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            uGrid.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            uGrid.DisplayLayout.Override.CellAppearance = appearance8;
            uGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            uGrid.DisplayLayout.Override.CellPadding = 0;
            uGrid.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            uGrid.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            uGrid.DisplayLayout.Override.HeaderAppearance = appearance10;
            uGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            uGrid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            uGrid.DisplayLayout.Override.RowAppearance = appearance11;
            uGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            uGrid.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            uGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            uGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            uGrid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            uGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            uGrid.Location = new System.Drawing.Point(154, 37);
            uGrid.Name = "UGrid";
            uGrid.Size = new System.Drawing.Size(165, 52);
            uGrid.TabIndex = 2;
            uGrid.Text = "ultraGrid1";
            uGrid.Visible = false;
            ((System.ComponentModel.ISupportInitialize)(uGrid)).EndInit();
            return uGrid;
        }
        private Dundas.Charting.WinControl.Chart CreateDundasChart()
        {
            Dundas.Charting.WinControl.Chart dChart = new Dundas.Charting.WinControl.Chart();
            Dundas.Charting.WinControl.ChartArea chartArea1 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend1 = new Dundas.Charting.WinControl.Legend();
            ((System.ComponentModel.ISupportInitialize)(dChart)).BeginInit();
            chartArea1.Name = "Default";
            dChart.ChartAreas.Add(chartArea1);
            dChart.Location = new System.Drawing.Point(605, 31);
            dChart.Name = "dChart";
            //dChart.Palette = Dundas.Charting.WinControl.ChartColorPalette.Pastel;
            dChart.Size = new System.Drawing.Size(34, 21);
            dChart.TabIndex = 5;
            dChart.Text = "dChart";
            dChart.Visible = true;
            dChart.Palette = Dundas.Charting.WinControl.ChartColorPalette.SemiTransparent;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Light = Dundas.Charting.WinControl.LightStyle.Realistic;
            chartArea1.Area3DStyle.WallWidth = 10;
            chartArea1.Area3DStyle.XAngle = 10;
            chartArea1.Area3DStyle.YAngle = 10;
            ((System.ComponentModel.ISupportInitialize)(dChart)).EndInit();
            return dChart;
        }
        private void ShowSupplementalPieChart(Dundas.Charting.WinControl.Chart dChart)
        {
            if (dChart.Series[0].Points.Count > 2)
            {
                // PieCollectedDataHelper is a helper class found in the samples Utilities folder. 
                PieCollectedDataHelper pieHelper = new PieCollectedDataHelper(dChart);

                // Set the percentage of the total series values. This value determines 
                // if the data point value is a "small" value and should be shown as collected.
                pieHelper.CollectedPercentage = 1;

                // Indicates if small segments should be shown as one "collected" segment in 
                // the original series.
                pieHelper.ShowCollectedDataAsOneSlice = false;

                // Size ratio between the original and supplemental chart areas.
                // Value of 1.0f indicates that same area size will be used.
                pieHelper.SupplementedAreaSizeRatio = 0.75f;

                // Set position in relative coordinates ( 0,0 - top left corner; 100,100 - bottom right corner)
                // where original and supplemental pie charts should be placed.
                pieHelper.ChartAreaPosition = new System.Drawing.RectangleF(5f, 5f, 90f, 90f);

                // Show supplemental pie for the "Default" series
                pieHelper.ShowSmallSegmentsAsSupplementalPie(dChart.Series[0].Name);
                //dChart.Series[series.Name]["PieLabelStyle"] = "Outside";
            }
        }
        private void GetChartAttributes(Dundas.Charting.WinControl.Chart dChart)
        {
            System.Collections.Specialized.StringCollection attrs = new StringCollection();
            int i = 0;
            try
            {
                while (dChart.Series[0][i] != null)
                {
                    attrs.Add(dChart.Series[0][i++]);
                }
            }
            catch { }
        }
        private void EnableScableBreak(Dundas.Charting.WinControl.Chart dChart)
        {
            // Enable scale breaks
            dChart.ChartAreas[0].AxisX.ScaleBreakStyle.Enabled = true;

            // Set the scale break type
            dChart.ChartAreas[0].AxisX.ScaleBreakStyle.BreakLineType = Dundas.Charting.WinControl.BreakLineType.Wave;

            // Set the spacing gap between the lines of the scale break (as a percentage of y-axis)
            dChart.ChartAreas[0].AxisX.ScaleBreakStyle.Spacing = 2;

            // Set the line width of the scale break
            dChart.ChartAreas[0].AxisX.ScaleBreakStyle.LineWidth = 2;

            // Set the color of the scale break
            dChart.ChartAreas[0].AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.Red;

            // Show scale break if more than 25% of the chart is empty space
            dChart.ChartAreas[0].AxisX.ScaleBreakStyle.CollapsibleSpaceThreshold = 10;

            // If all data points are significantly far from zero, 
            // the Chart will calculate the scale minimum value
            dChart.ChartAreas[0].AxisX.ScaleBreakStyle.StartFromZero = Dundas.Charting.WinControl.AutoBool.False;// Dundas.Charting.WinControl.AutoBool.Auto;
        }
        private string GetCurrencyFormat(object value)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("hi-IN");
            string amt1 = String.Format(culture, "{0:c}", value);
            amt1 = "Rs " + amt1.Substring(2);
            return amt1;
        }
        private void BuildChart(string chartSelected, string sqlQuery, string filterText)
        {
            DataTable dt = dalObj.GetQueryData(sqlQuery, runningYear, currAccYear);
            if (chartSelected == Convert.ToString(ChartTypeName.LineChart))
            {
                dChart = CreateDundasChart();
                Dundas.Charting.WinControl.Series series = new Dundas.Charting.WinControl.Series();
                series.XValueType = Dundas.Charting.WinControl.ChartValueTypes.String;
                if (dt.Columns[0].DataType == typeof(string))
                {
                    dChart.ChartAreas[0].AxisX.Interval = 1;
                    dt = ModifyLineData(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Dundas.Charting.WinControl.DataPoint point = new Dundas.Charting.WinControl.DataPoint();
                        point.AxisLabel = Convert.ToString(dr[0]);
                        point.SetValueY(0, Convert.ToDouble(dr[1]));
                        point.Label = GetCurrencyFormat(dr[1]);
                        series.Points.Add(point);
                    }
                }
                else
                {
                    dChart.ChartAreas[0].AxisY.Interval = 1;
                    foreach (DataRow dr in dt.Rows)
                        series.Points.AddXY(Convert.ToDouble(dr[0]), Convert.ToDouble(dr[1]));
                }
                series.Type = Dundas.Charting.WinControl.SeriesChartType.Line;
                series.MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Circle;
                series.MarkerSize = 10;
                series.MarkerColor = System.Drawing.Color.Black;
                dChart.Series.Add(series);
                dChart.ChartAreas[0].AxisX.Title = dt.Columns[0].ColumnName;
                dChart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                dChart.ChartAreas[0].AxisY.Title = dt.Columns[1].ColumnName;
                dChart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                dChart.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
            else if (chartSelected == Convert.ToString(ChartTypeName.PieChart))
            {
                dChart = CreateDundasChart();
                Dundas.Charting.WinControl.Series series = new Dundas.Charting.WinControl.Series();
                foreach (DataRow dr in dt.Rows)
                {
                    Dundas.Charting.WinControl.DataPoint point = new Dundas.Charting.WinControl.DataPoint();
                    point.SetValueY(dr[1]);
                    point.LegendText = Convert.ToString(dr[0]);
                    point.ToolTip = Convert.ToString(dr[0]) + ",Amount : " + Convert.ToString(dr[1]);
                    //point.Label = Convert.ToString(dr[0]) + " : " + "#PERCENT";
                    point.Label = "#PERCENT";
                    series.Points.Add(point);
                }
                series.Type = Dundas.Charting.WinControl.SeriesChartType.Pie;
                dChart.Series.Clear();
                dChart.Series.Add(series);
                ShowSupplementalPieChart(dChart);
            }
            else if (chartSelected == Convert.ToString(ChartTypeName.BarChart))
            {
                dChart = CreateDundasChart();
                Dundas.Charting.WinControl.Series series = new Dundas.Charting.WinControl.Series();
                foreach (DataRow dr in dt.Rows)
                {
                    string label = "";
                    Dundas.Charting.WinControl.DataPoint point = new Dundas.Charting.WinControl.DataPoint();
                    point.SetValueXY(dr[0], dr[1]);
                    if (dr.Table.Columns.Count > 2 && dr.Table.Columns[2].ColumnName.StartsWith("TOOLTIP:"))
                        label = Convert.ToString(dr[1]) + " : " + dr.Table.Columns[2].ColumnName.Replace("TOOLTIP:", "") + " = " + Convert.ToString(dr[2]);
                    else
                    {
                        if (dr.Table.Columns[1].ColumnName == "BALANCE" ||
                            dr.Table.Columns[1].ColumnName == "TURNOVER" ||
                            dr.Table.Columns[1].ColumnName == "AMOUNT")
                            label = GetCurrencyFormat(dr[1]);
                        else
                            label = Convert.ToString(dr[1]);
                    }
                    point.Label = label;
                    point.LabelBackColor = System.Drawing.Color.Transparent;
                    point.ToolTip = label;
                    series.Points.Add(point);
                }
                series.Type = Dundas.Charting.WinControl.SeriesChartType.Bar;
                dChart.Series.Add(series);
                dChart.Legends[0].Enabled = false;
                dChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                //if(dt.Rows.Count < 25)
                dChart.ChartAreas[0].AxisX.Interval = 1;
                dChart.ChartAreas[0].AxisX.Title = dt.Columns[0].ColumnName;
                dChart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                dChart.ChartAreas[0].AxisY.Title = dt.Columns[1].ColumnName;
                dChart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            }
            EnableScableBreak(dChart);
            //dChart.MouseDown += new MouseEventHandler(dChart_MouseDown);
            dChart.Click += new EventHandler(dChart_Click);
            dChart.MouseMove += new MouseEventHandler(dChart_MouseMove);

            dChart.ChartAreas["Default"].CursorX.UserEnabled = true;
            dChart.ChartAreas["Default"].CursorX.UserSelection = true;

            dChart.ChartAreas["Default"].CursorY.UserEnabled = true;
            dChart.ChartAreas["Default"].CursorY.UserSelection = true;
            // Set automatic zooming

            dChart.ChartAreas["Default"].AxisX.View.Zoomable = true;
            dChart.ChartAreas["Default"].AxisY.View.Zoomable = true;

            // Set automatic scrolling 
            dChart.ChartAreas["Default"].CursorX.AutoScroll = true;
            dChart.ChartAreas["Default"].CursorY.AutoScroll = true;
            //Add the chart to panel
            Panel chartPanel = new Panel();
            chartPanel.AutoScroll = true;
            chartPanel.Controls.Add(dChart);
            tabReport.SelectedTab.Controls.Clear();
            tabReport.SelectedTab.Controls.Add(chartPanel);
            chartPanel.Dock = DockStyle.Fill;
            dChart.Dock = DockStyle.Fill;
            //Set Fitler Text label
            lblFilterText.Text = AddSpace(25, GetFilterText(filterText));
        }
        private string GetFilterText(string filterText)
        {
            if (filterText.Contains("[QueryStart]"))
            {
                string query = filterText.Substring(filterText.IndexOf("[QueryStart]") + 12);
                query = query.Substring(0, query.IndexOf("[QueryEnd]"));
                string queryVal = GetCurrencyFormat(dalObj.GetScalarData(query, runningYear, currAccYear));
                filterText = filterText.Replace("[QueryStart]" + query + "[QueryEnd]", queryVal);
            }
            return filterText;
        }
        private void dChart_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Dundas.Charting.WinControl.Chart dChart = (Dundas.Charting.WinControl.Chart)sender;
            // Call Hit Test Method
            Dundas.Charting.WinControl.HitTestResult result = dChart.HitTest(e.X, e.Y);

            // Reset Data Point Attributes
            foreach (Dundas.Charting.WinControl.DataPoint point in dChart.Series[0].Points)
            {
                point.BackGradientEndColor = System.Drawing.Color.Black;
                point.BackHatchStyle = Dundas.Charting.WinControl.ChartHatchStyle.None;
                point.BorderWidth = 1;
            }

            // If a Data Point or a Legend item is selected.
            if
            (result.ChartElementType == Dundas.Charting.WinControl.ChartElementType.DataPoint ||
                result.ChartElementType == Dundas.Charting.WinControl.ChartElementType.LegendItem)
            {
                // Set cursor type 
                this.Cursor = Cursors.Hand;

                // Find selected data point
                Dundas.Charting.WinControl.DataPoint point = dChart.Series[0].Points[result.PointIndex];

                // Set End Gradient Color to White
                point.BackGradientEndColor = System.Drawing.Color.White;

                // Set selected hatch style
                point.BackHatchStyle = Dundas.Charting.WinControl.ChartHatchStyle.Percent25;

                // Increase border width
                point.BorderWidth = 2;
            }
            else
            {
                // Set default cursor
                this.Cursor = Cursors.Default;
            }

        }
        void dChart_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Dundas.Charting.WinControl.Chart dChart = (Dundas.Charting.WinControl.Chart)sender;
            // Call Hit Test Method
            Dundas.Charting.WinControl.HitTestResult result = dChart.HitTest(me.X, me.Y);
            if (result.ChartElementType != Dundas.Charting.WinControl.ChartElementType.DataPoint)
            {
                // Set default cursor
                this.Cursor = Cursors.Default;
                return;
            }
            Dundas.Charting.WinControl.DataPoint dataPt = dChart.Series[0].Points[result.PointIndex];
            if (dataPt.AxisLabel != "")
                PopulateChart(dataPt.AxisLabel);
            else
                PopulateChart(Convert.ToString(dataPt.XValue));
            // Set default cursor
            this.Cursor = Cursors.Default;
        }
        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Infragistics.Win.UltraWinGrid.UltraCombo box = (Infragistics.Win.UltraWinGrid.UltraCombo)sender;
            if (box.SelectedRow != null)
            {
                string chartSelected = "";
                Report report = (Report)tabReport.SelectedTab.Tag;
                if (report.ChartType.Length == 1)
                    chartSelected = Convert.ToString(report.ChartType[0].Name);
                else
                    chartSelected = selectedChart;
                string sqlQuery = box.SelectedRow.Cells["FilterValueQuery"].Text;
                string filterText = "Selected Fitler : " + box.SelectedRow.Cells[0].Text;
                BuildChart(chartSelected, sqlQuery, filterText);
                diplayingChartTypeConfigObj = report.ChartType[0];
                //Storing the currently displaying object in the config object
                setTag("CHART", dChart, diplayingChartTypeConfigObj);
                setTag("FILTERTEXT", filterText, diplayingChartTypeConfigObj);
            }
            Cursor.Current = Cursors.Default;
        }
        private void DataButton_Clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BillingApplication.Data dataGridConfigObj = (BillingApplication.Data)((Button)sender).Tag;
            BuildGrid(dataGridConfigObj.Query.Value, dataGridConfigObj.FilterDescription);
            ClearFilters(true);
            Cursor.Current = Cursors.Default;
        }
        private void BuildGrid(string sqlQuery, string filterText)
        {
            DataTable dt = dalObj.GetQueryData(sqlQuery, runningYear, currAccYear);
            UGrid = CreateGrid();
            UGrid.Visible = true;
            tabReport.SelectedTab.Controls.Clear();
            tabReport.SelectedTab.Controls.Add(UGrid);
            UGrid.Dock = DockStyle.Fill;
            UGrid.DataSource = dt;
            UGrid.DataBind();
            UGrid.DisplayLayout.Override.DefaultRowHeight = 25;
            UGrid.DisplayLayout.Bands[0].Columns[0].Width = 250;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultracol in UGrid.DisplayLayout.Bands[0].Columns)
            {
                if (ultracol.DataType == typeof(double) || ultracol.DataType == typeof(int) ||
                    ultracol.DataType == typeof(float) || ultracol.DataType == typeof(decimal))
                    ultracol.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True;
            }
            //Set Fitler Text label
            lblFilterText.Text = AddSpace(25, GetFilterText(filterText));
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            selectedChart = btn.Text;
            Report report = (Report)tabReport.SelectedTab.Tag;
            InitializeFilters((ChartType)btn.Tag, report);
        }
        private void SetRadioButtons(Report report)
        {
            lblFilterText.Controls.Clear();
            radioPanel.Controls.Clear();
            int radiobtnXPos = 10;
            foreach (ChartType chart in report.ChartType)
            {
                RadioButton btn = new RadioButton();
                btn.Text = Convert.ToString(chart.Name);
                btn.Tag = chart;
                btn.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
                radioPanel.Controls.Add(btn);
                btn.Location = new System.Drawing.Point(radiobtnXPos, 5);
                radiobtnXPos += (Convert.ToString(chart.Name).Length * 15);
            }
            splitContainer1.Panel1.Controls.Add(radioPanel);
            if (radioPanel.Controls != null && radioPanel.Controls.Count > 0)
                radioPanel.Height = 30;
            else
                radioPanel.Height = 0;
        }
        private void InitializeFilters(ChartType configCharType, Report report)
        {
            if (configCharType.Filters != null)
            {
                Dictionary<string, DataTable> configFilters = GetFilters(configCharType);
                PopulateFilters(configFilters, configCharType.Name, report.Data.Query.Value, report.Data);
            }
            else
            {
                ClearFilters(false);
                if (report.Data != null)
                    SetDataButton(report.Data, 10);
                if (configCharType.Name == ChartTypeName.DataGrid)
                {
                    BuildGrid(configCharType.Data.Query.Value, configCharType.Description);
                    setTag("CHART", UGrid, configCharType);
                    setTag("FILTERTEXT", configCharType.Description, configCharType);
                }
                else
                {
                    BuildChart(Convert.ToString(configCharType.Name), configCharType.Query.Value, configCharType.Description);
                    setTag("CHART", dChart, configCharType);
                    setTag("FILTERTEXT", configCharType.Description, configCharType);
                }
                lblFilterText.BringToFront();
            }
            Reports.diplayingChartTypeConfigObj = configCharType;
        }
        private string AddSpace(int noOfSpaces, string text)
        {
            int j = noOfSpaces;
            while (j > 0)
            {
                text += " ";
                j--;
            }
            return text;
        }
        private void SetDataButton(BillingApplication.Data dataGridConfigObj, int xpos)
        {
            Button dataButton = new Button();
            dataButton.Text = "&Data";
            dataButton.Tag = dataGridConfigObj;
            dataButton.Click += new EventHandler(DataButton_Clicked);
            SetFilterLabel(dataButton);
        }
        private void SetFilterLabel(Button dataButton)
        {
            lblFilterText.Text = AddSpace(25, lblFilterText.Text);
            lblFilterText.Width = lblFilterText.Text.Length * 10; // dataButton.Width;
            lblFilterText.Font = new System.Drawing.Font("Arial", 15);
            dataButton.Font = new System.Drawing.Font("Arial", 10);
            lblFilterText.Controls.Add(dataButton);
            dataButton.Dock = DockStyle.Right;
            dataButton.BringToFront();
        }
        private void ClearFilters(bool isDataGridView)
        {
            //splitContainer1.Panel1.Controls.Clear();
            filterPanel.Controls.Clear();
            splitContainer1.Panel1.Controls.Remove(lblFilterText);
            lblFilterText.Controls.Clear();
            lblFilterText.Location = new System.Drawing.Point(10, lblFilterYPos);
            //lblFilterText.Width = 500;
            splitContainer1.Panel1.Controls.Add(lblFilterText);
            if (isDataGridView)
            {
                Button exportDataBtn = new Button();
                exportDataBtn.Text = "&Export";
                exportDataBtn.Click += new EventHandler(exportDataBtn_Click);
                SetFilterLabel(exportDataBtn);
                lblFilterText.BringToFront();
            }
        }
        private void exportDataBtn_Click(object sender, EventArgs e)
        {
            string currDate = "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year;
            this.saveFileDialog.FileName = tabReport.SelectedTab.Text + currDate + ".xls";
            this.saveFileDialog.Filter = "Excel files(*.xls)|*.xls";
            if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
                this.ultraGridExcelExporter.Export(UGrid, saveFileDialog.FileName);
        }
        private void PopulateChart(string key)
        {
            if (diplayingChartTypeConfigObj.ChartType1 != null)
            {
                PopulateChart(diplayingChartTypeConfigObj.ChartType1, key);
                diplayingChartTypeConfigObj = diplayingChartTypeConfigObj.ChartType1;
            }
        }
        private void PopulateChart(ChartType configChart, string key)
        {
            string sqlQuery, descr;
            if (configChart.Name == ChartTypeName.BarChart || configChart.Name == ChartTypeName.LineChart)
                sqlQuery = configChart.Query.Value;
            else
                sqlQuery = configChart.Data.Query.Value;
            if (configChart.Parent.Parent == null)
            {
                sqlQuery = sqlQuery.Replace("$KEY1", key);
                descr = configChart.Description.Replace("$KEY1", key);
            }
            else
            {
                string key1 = Convert.ToString(getTag("KEY", configChart.Parent));
                sqlQuery = sqlQuery.Replace("$KEY1", key1);
                sqlQuery = sqlQuery.Replace("$KEY2", key);
                descr = configChart.Description.Replace("$KEY2", key);
                descr = descr.Replace("$KEY1", key1);
            }
            if (configChart.Name == ChartTypeName.BarChart || configChart.Name == ChartTypeName.LineChart)
            {
                BuildChart(Convert.ToString(configChart.Name), sqlQuery, descr);
                setTag("CHART", dChart, configChart);
                setTag("FILTERTEXT", descr, configChart);
            }
            else
            {
                BuildGrid(sqlQuery, descr);
                setTag("CHART", UGrid, configChart);
                setTag("FILTERTEXT", descr, configChart);
            }
            setTag("KEY", key, configChart);
            Report report = (Report)tabReport.SelectedTab.Tag;
            radioPanel.Visible = false;
            filterPanel.Visible = false;
            //If second/third level control is diplayed, then the filter text should be in split container
            //so remove from filter panel(as filter panel is hidden now) and splitecontainer panel 1 
            filterPanel.Controls.Remove(lblFilterText);
            splitContainer1.Panel1.Controls.Add(lblFilterText);
            lblFilterText.Location = new System.Drawing.Point(10, lblFilterYPos);
            lblFilterText.BringToFront();
        }
        private object getTag(object key, object configChart)
        {
            ChartType configChart1 = (ChartType)configChart;
            System.Collections.Hashtable ht = (System.Collections.Hashtable)configChart1.Tag;
            return ht[key];
        }
        private void setTag(object key, object val, ChartType configChart)
        {
            if (configChart.Tag == null)
            {
                System.Collections.Hashtable ht = new System.Collections.Hashtable();
                ht.Add(key, val);
                configChart.Tag = ht;
            }
            else
            {
                System.Collections.Hashtable ht = (System.Collections.Hashtable)configChart.Tag;
                ht[key] = val;
            }
        }
        private void GoBack()
        {
            if (diplayingChartTypeConfigObj.Parent != null)
            {
                ChartType configChart = diplayingChartTypeConfigObj.Parent;
                Control ctrl = (Control)getTag("CHART", configChart);
                string filterText = (string)getTag("FILTERTEXT", configChart);
                //Add the chart to panel
                Panel chartPanel = new Panel();
                chartPanel.AutoScroll = true;
                chartPanel.Controls.Add(ctrl);
                tabReport.SelectedTab.Controls.Clear();
                tabReport.SelectedTab.Controls.Add(chartPanel);
                chartPanel.Dock = DockStyle.Fill;
                ctrl.Dock = DockStyle.Fill;
                lblFilterText.Text = AddSpace(25, GetFilterText(filterText));
                diplayingChartTypeConfigObj = configChart;
                //If this chart is at the top level, then set radio buttons and filters
                if (diplayingChartTypeConfigObj.Parent == null)
                {
                    radioPanel.Visible = true;
                    filterPanel.Visible = true;
                    //If second/third level control is diplayed, then the filter text should be in splitcontainer
                    //so remove from splitecontainer panel 1 and add it back to filter panel
                    splitContainer1.Panel1.Controls.Remove(lblFilterText);
                    lblFilterText.Location = new System.Drawing.Point(10, lblFilterYPos);
                    filterPanel.Controls.Add(lblFilterText);
                }
            }
        }
        private void PopulateFilters(Dictionary<string, DataTable> filters, ChartTypeName chartTypeEnum, string dataQuery, BillingApplication.Data dataGridConfigObj)
        {
            filterPanel.Controls.Clear();
            lblFilterText.Controls.Clear();
            int xStartPos = 10;
            int xpos = xStartPos;
            foreach (string key in filters.Keys)
            {
                Label labelObj = new Label();
                labelObj.Text = key;
                labelObj.Width = key.Length * 10;

                Infragistics.Win.UltraWinGrid.UltraCombo comboObj = new Infragistics.Win.UltraWinGrid.UltraCombo();
                comboObj.Tag = chartTypeEnum;
                comboObj.DataSource = filters[key];
                comboObj.DisplayMember = "FilterValue";
                comboObj.ValueMember = "FilterValueQuery";
                comboObj.DataBind();
                comboObj.DisplayLayout.Bands[0].Columns["FilterValueQuery"].Hidden = true;
                comboObj.ValueChanged += new EventHandler(comboBox_SelectedValueChanged);
                labelObj.Location = new System.Drawing.Point(xpos, filterYPos);
                comboObj.Location = new System.Drawing.Point(xpos + (key.Length * 10), filterYPos);
                filterPanel.Controls.Add(labelObj);
                filterPanel.Controls.Add(comboObj);
                //Set the first value of fisrt filter selected to show the initial chart
                if (xpos == xStartPos)
                    comboObj.SelectedRow = comboObj.Rows[0]; //comboBox_SelectedValueChanged(comboObj, null);
                xpos += 300;
            }
            //Set data button
            SetDataButton(dataGridConfigObj, xpos);
            //Set filter text label
            filterPanel.Controls.Add(lblFilterText);
            lblFilterText.Location = new System.Drawing.Point(10, lblFilterYPos);
            //lblFilterText.Width = 500;
            splitContainer1.Panel1.Controls.Add(filterPanel);
            filterPanel.Visible = true;
            filterPanel.BringToFront();
            filterPanel.Dock = DockStyle.Fill;
        }
        public Dictionary<string, DataTable> GetFilters(ChartType chartType)
        {
            Dictionary<string, DataTable> filters = new Dictionary<string, DataTable>();
            for (int i = 0; i < chartType.Filters.Length; i++)
            {
                Filter filter = chartType.Filters[i];
                DataTable filterDt = new DataTable("Filter");
                filterDt.Columns.Add("FilterValue", typeof(string));
                filterDt.Columns.Add("FilterValueQuery", typeof(string));
                if (filter.FilterValueType == FilterFilterValueType.List)
                {
                    foreach (Query query in filter.Query)
                    {
                        DataRow dr = filterDt.NewRow();
                        dr["FilterValue"] = query.Name;
                        dr["FilterValueQuery"] = query.Value;
                        filterDt.Rows.Add(dr);
                    }
                }
                else if (filter.FilterValueType == FilterFilterValueType.Query)
                {
                    DataTable filterValues = dalObj.GetQueryData(filter.FilterValueQuery, runningYear, currAccYear);
                    foreach (DataRow row in filterValues.Rows)
                    {
                        DataRow dr = filterDt.NewRow();
                        dr["FilterValue"] = Convert.ToString(row[0]);
                        dr["FilterValueQuery"] = filter.Query[0].Value.Replace("$VALUE", Convert.ToString(row[0]));
                        filterDt.Rows.Add(dr);
                    }
                }
                filters.Add(filter.Name, filterDt);
            }
            return filters;
        }
    }
}
