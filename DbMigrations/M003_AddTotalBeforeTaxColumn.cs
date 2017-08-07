using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace DbMigrations.Scripts
{
    [Migration(3)]
    public class M003_AddTotalBeforeTaxColumn :Migration
    {
        public override void Up(){
            Execute.EmbeddedScript("M003_AddTotalBeforeTaxColumn.sql");
            Execute.Sql("EXEC [ADD_TOTALBEFORETAX_COLUMN]");
        }
        public override void Down()
        {
            
        }
    }
}
