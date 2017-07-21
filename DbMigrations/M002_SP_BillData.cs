using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace DbMigrations
{
    [Migration(2)]
    public class M002_SP_BillData : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("2.Get_BillData.sql");
            Execute.EmbeddedScript("3.Set_InsertBillData.sql");
            Execute.EmbeddedScript("4.Set_UpdateBillData.sql");
            Execute.EmbeddedScript("5.SetNewAccountingYears.sql");
        }
        public override void Down()
        {
            
        }
    }
}
