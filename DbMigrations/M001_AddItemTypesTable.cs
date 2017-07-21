using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BillingApplication.DatabaseMigrations
{
    [Migration(1)]
    public class M001_AddItemTypesTable : Migration
    {
        public override void Up()
        {
            Create.Table("ITEMTYPE")
                .WithColumn("NAME").AsAnsiString(250);
        }

        public override void Down()
        {
            Delete.Table("ITEMTYPE");
        }
    }
}
