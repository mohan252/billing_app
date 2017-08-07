using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace DbMigrations
{
    [Migration(5)]
    public class M005_AddTotalBeforeTaxParam_SET_UPDATEBILLDATA : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("M005_AddTotalBeforeTaxParam_SET_UPDATEBILLDATA.sql");
        }
        public override void Down()
        {
            
        }
    }
}
