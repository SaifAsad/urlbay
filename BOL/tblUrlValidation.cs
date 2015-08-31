using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BOL
{
    public class UniqueUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LinkHubDBEntities db = new LinkHubDBEntities();
            string urlValue = value.ToString();
            //look for the value in the database, if found update count
            int count = db.tbl_Url.Where(x => x.Url == urlValue).ToList().Count();
            if (count != 0)
                return new ValidationResult("Url Already Exist");
            return ValidationResult.Success;
        }
    }
    public class tbl_UrlValidation
    {
        [Required]
        public string UrlTitle { get; set; }

        [Required]
        [Url]
        [UniqueUrl]
        public string Url { get; set; }

        [Required]
        public string UrlDesc { get; set; }
    }

    [MetadataType(typeof(tbl_UrlValidation))]
    public partial class tbl_Url
    {        
      
    }
}
