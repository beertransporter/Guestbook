using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Guestbook.Resources.Shared;
using Guestbook.Models;

namespace Guestbook.Models
{
    //[Table("Maths")]
    public class GuestbookMath
    {
        [Key]
        public int Id { get; set; }

        [Display (Name ="FirstName")]
        [RegularExpression(@"[0-9]{0,9}", ErrorMessageResourceName = "IncorrectSymbol", ErrorMessageResourceType = typeof(ErrorRes))]
        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(ErrorRes))]
        [Range(-999999999,9999999999, ErrorMessageResourceName = "InvalidStringLenght", ErrorMessageResourceType = typeof(ErrorRes))]
        public int FirstNumber { get; set; }

        [Display(Name = "SecondName")]
        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(ErrorRes))]
        [Range(-999999999, 9999999999, ErrorMessageResourceName = "InvalidStringLenght", ErrorMessageResourceType = typeof(ErrorRes))]
        public int SecondNumber { get; set; }
        public int Total { get; set; }
        public int TypeId { get; set; }
        public GuestBookMathType MathTypes { get; set; }
    }
}