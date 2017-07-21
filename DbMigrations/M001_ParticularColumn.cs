using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace DbMigrations
{
    [Migration(1)]
    public class M001_ParticularColumn : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("1.sql");
            Execute.Sql("exec [dbo].[ADD_PARTICULAR_COLUMNS];");
        }
        public override void Down()
        {
            Execute.Sql("drop PROCEDURE [dbo].[ADD_PARTICULAR_COLUMNS]");
        }
    }
}
