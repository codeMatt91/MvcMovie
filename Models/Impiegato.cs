using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Impiegato
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo Name è obligatorio")]
        [MoreThanOneWordValidation]
        public string FullName { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Il campo City è obligatorio")]
        public string City { get; set; }
        [EmailAddress(ErrorMessage ="Email errata")]
        public string EmailAddress { get; set; }
        public string? PersonalWebSite { get; set; }
        public string? Photo { get; set; }
        public string AlternateText { get; set; }
    }
}
