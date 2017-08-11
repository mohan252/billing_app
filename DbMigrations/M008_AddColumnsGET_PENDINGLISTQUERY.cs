using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace DbMigrations
{
    [Migration(8)]
    public class M008_AddColumnsGET_PENDINGLISTQUERY : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("M008_AddColumnsGET_PENDINGLISTQUERY.sql");
        }
        public override void Down()
        {
            
        }
    }
}
