using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEx01.Model.Models
{
    [Table("Footers")]
    public class Footer
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(50)]
        public string ID { set; get; }

        [Required]//The Required attribute can be applied to one or more properties in an entity class.
        public string Content { set; get; }
    }
}
