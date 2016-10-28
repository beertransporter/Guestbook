using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Guestbook.Models
{
    public class GuestbookContext : DbContext
    {
        public GuestbookContext()
            : base("NewGuestbook")
        {
            
        }
        public DbSet<GuestbookEntry> Entries { get; set; }
        public DbSet<GuestbookMath> Maths { get; set; }
        public DbSet<GuestBookMathType> MathTypes { get; set; }
    }
}