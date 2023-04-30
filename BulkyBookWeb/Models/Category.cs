using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name value is required!")]
        public string Name { get; set; }

        // To display the name of a property in errors and messages  we can use this attribute
        [DisplayName("Display Order")]
        [Range(0,100,ErrorMessage = "Between 1 and 100!")]
        public uint DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
