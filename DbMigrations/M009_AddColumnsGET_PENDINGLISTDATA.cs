using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace DbMigrations
{
    [Migration(9)]
    public class M009_AddColumnsGET_PENDINGLISTDATA : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("M009_AddColumnsGET_PENDINGLISTDATA.sql");
        }
        public override void Down()
        {
            
        }
    }
}
