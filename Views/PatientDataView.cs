using System.ComponentModel.DataAnnotations;

namespace PatientDemo.Views
{
    public class PatientDataView
    {
        public PatientDataView() {
            this.Id = 1;
            this.FirstName = String.Empty;
            this.LastName = String.Empty;
            this.DOB = DateTime.Now;
            this.Gender = String.Empty;
            this.RefProvider = new ProviderView();
        }
        [Required(ErrorMessage = "Patient Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(10, ErrorMessage = "Gender cannot exceed 10 characters.")]
        public string Gender { get; set; }
        public ProviderView RefProvider { get; set; }
    }
}
