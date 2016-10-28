using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Guestbook.Models
{
    public class GuestBookMathType
    {
        [Key]
        public int TypeId { get; set; }

        public string OperationType { get; set; }
        public ICollection<GuestbookMath> Maths { get; set; } 
    }
}