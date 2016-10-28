using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Guestbook.Models
{
    public class InicializingDB : DropCreateDatabaseIfModelChanges<GuestbookContext>
       // DropCreateDatabaseIfModelChanges<GuestbookContext> //DropCreateDatabaseAlways<GuestbookContext>
    {
        //protected override void Seed(GuestbookContext context)
        //{
            

        //    base.Seed(context);
        //}
    }


}