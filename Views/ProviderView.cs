using System.ComponentModel.DataAnnotations;

namespace PatientDemo.Views
{
    public class ProviderView
    {
        public ProviderView()
        {
            this.ProviderId = 123;
            this.FirstName = String.Empty;
        }

        public int ProviderId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string FirstName { get; set; }
        
    }
}
