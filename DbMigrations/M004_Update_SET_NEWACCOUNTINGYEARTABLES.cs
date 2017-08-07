using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace DbMigrations
{
    [Migration(4)]
    public class M004_Update_SET_NEWACCOUNTINGYEARTABLES : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("M004_AddTotalBeforeTax_SET_NEWACCOUNTINGYEARTABLES.sql");
        }
        public override void Down()
        {
            
        }
    }
}
