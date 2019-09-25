using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations
{
    [Migration(11)]
    public class M011_AddDebitNoteAndItemsTable : Migration
    {
        public override void Down()
        {            
        }

        public override void Up()
        {
            Execute.EmbeddedScript("M011_CreateDebitNoteTable.sql");
            Execute.EmbeddedScript("M011_CreateDebitNoteItemsTable.sql");
        }
    }
}
