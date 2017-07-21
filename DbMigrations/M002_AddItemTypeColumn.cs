﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace DbMigrations
{
    [Migration(2)]
    public class M002_ParticularColumn : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("2.sql");
            Execute.Sql("exec [dbo].[ADD_PARTICULAR_COLUMNS];");
        }
        public override void Down()
        {
            Execute.Sql("drop PROCEDURE [dbo].[ADD_PARTICULAR_COLUMNS]");
        }
    }
}
