using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEx01.Model.Models
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        public int ID { set; get; }

        public string Message { set; get; }

        public string StrackTrace { set; get; }

        public DateTime CreatedDate { set; get; }
        public string StackTrace { get; set; }
    }
}
