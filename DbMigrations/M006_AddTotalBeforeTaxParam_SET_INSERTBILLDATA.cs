using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace DbMigrations
{
    [Migration(6)]
    public class M006_AddTotalBeforeTaxParam_SET_INSERTBILLDATA : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("M006_AddTotalBeforeTaxParam_SET_INSERTBILLDATA.sql");
        }
        public override void Down()
        {
            
        }
    }
}
