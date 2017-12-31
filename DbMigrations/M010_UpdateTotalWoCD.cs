using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace DbMigrations
{
    [Migration(10)]
    public class M010_UpdateTotalWoCD : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"update b
                            set b.TOTALWOCD = round( b.BALANCE - (b.BALANCE * bd.VALUE / 100) , 2)
                            --select b.BALANCE,bd.value, round( b.BALANCE - (b.BALANCE * bd.VALUE / 100) , 2) 
                            from bills b
                            inner join BILLDISCOUNTS bd on b.BILLNO = bd.BILLNO and b.ADDRESS = bd.ADDRESS
                            where bd.NAME = 'Pinning Less'");
        }

        public override void Down()
        {
            
        }
    }
}
