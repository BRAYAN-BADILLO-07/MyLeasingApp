using System.ComponentModel.DataAnnotations;

namespace MyLeasingApp.Web.Data.Entities
{
    public class Lessee
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characteres.")]
        public string Document { get; set; } = null!;

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(80, ErrorMessage = "The {0} field can not have more than {1} characteres.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(80, ErrorMessage = "The {0} field can not have more than {1} characteres.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characteres.")]
        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; } = null!;

        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characteres.")]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; } = null!;

        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characteres.")]
        public string Address { get; set; } = null!;

        [Display(Name = "Lessee Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Lessee Name")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public ICollection<Contract> Contracts { get; set; }
    }
}
