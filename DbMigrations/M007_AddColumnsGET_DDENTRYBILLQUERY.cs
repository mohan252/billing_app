using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace DbMigrations
{
    [Migration(7)]
    public class M007_AddColumnsGET_DDENTRYBILLQUERY : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("M007_AddColumnsGET_DDENTRYBILLQUERY.sql");
        }

        public override void Down()
        {
            
        }
    }
}
