﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=2.0.50727.42.
// 

namespace BillingApplication
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ReportConfiguration
    {

        private Report[] reportField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Report")]
        public Report[] Report
        {
            get
            {
                return this.reportField;
            }
            set
            {
                this.reportField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ChartType
    {

        private Filter[] filtersField;

        private ChartType chartType1Field;

        private ChartType parentField;

        private Query queryField;

        private Data dataField;

        private object tagField;

        private ChartTypeName nameField;

        private string descriptionField;

        private bool showXAxisLabelField;

        private bool showXAxisLabelFieldSpecified;

        private bool showYAxisLabelField;

        private bool showYAxisLabelFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Filter", IsNullable = false)]
        public Filter[] Filters
        {
            get
            {
                return this.filtersField;
            }
            set
            {
                this.filtersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChartType", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ChartType ChartType1
        {
            get
            {
                return this.chartType1Field;
            }
            set
            {
                this.chartType1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ChartType Parent
        {
            get
            {
                return this.parentField;
            }
            set
            {
                this.parentField = value;
            }
        }

        /// <remarks/>
        public Query Query
        {
            get
            {
                return this.queryField;
            }
            set
            {
                this.queryField = value;
            }
        }

        /// <remarks/>
        public Data Data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object Tag
        {
            get
            {
                return this.tagField;
            }
            set
            {
                this.tagField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ChartTypeName Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ShowXAxisLabel
        {
            get
            {
                return this.showXAxisLabelField;
            }
            set
            {
                this.showXAxisLabelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ShowXAxisLabelSpecified
        {
            get
            {
                return this.showXAxisLabelFieldSpecified;
            }
            set
            {
                this.showXAxisLabelFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ShowYAxisLabel
        {
            get
            {
                return this.showYAxisLabelField;
            }
            set
            {
                this.showYAxisLabelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ShowYAxisLabelSpecified
        {
            get
            {
                return this.showYAxisLabelFieldSpecified;
            }
            set
            {
                this.showYAxisLabelFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum ChartTypeName
    {

        /// <remarks/>
        BarChart,

        /// <remarks/>
        PieChart,

        /// <remarks/>
        LineChart,

        /// <remarks/>
        DataGrid,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Report
    {

        private ChartType[] chartTypeField;

        private Data dataField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChartType", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ChartType[] ChartType
        {
            get
            {
                return this.chartTypeField;
            }
            set
            {
                this.chartTypeField = value;
            }
        }

        /// <remarks/>
        public Data Data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Filters
    {

        private Filter[] filterField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Filter")]
        public Filter[] Filter
        {
            get
            {
                return this.filterField;
            }
            set
            {
                this.filterField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Query
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Filter
    {

        private Query[] queryField;

        private string nameField;

        private FilterFilterValueType filterValueTypeField;

        private string filterValueQueryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Query")]
        public Query[] Query
        {
            get
            {
                return this.queryField;
            }
            set
            {
                this.queryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public FilterFilterValueType FilterValueType
        {
            get
            {
                return this.filterValueTypeField;
            }
            set
            {
                this.filterValueTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FilterValueQuery
        {
            get
            {
                return this.filterValueQueryField;
            }
            set
            {
                this.filterValueQueryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum FilterFilterValueType
    {

        /// <remarks/>
        List,

        /// <remarks/>
        Query,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Data
    {

        private Query queryField;

        private string filterDescriptionField;

        /// <remarks/>
        public Query Query
        {
            get
            {
                return this.queryField;
            }
            set
            {
                this.queryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FilterDescription
        {
            get
            {
                return this.filterDescriptionField;
            }
            set
            {
                this.filterDescriptionField = value;
            }
        }
    }
}