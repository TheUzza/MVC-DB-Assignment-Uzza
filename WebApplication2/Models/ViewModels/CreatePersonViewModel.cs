using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PeopleApp.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Display(Name = "Name")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "PhoneNumber")]
        [Required]
        public string? PhoneNumber { get; set; }
        [Display(Name = "City")]
        [Required]
        public string? CityName { get; set; }

        public List<string> CityList {

            get
            {
                return new List<string>
                {
                    "Karlskrona",
                    "Kirunna",
                    "Boden",
                    "Borås",
                    "Gävle",
                    "Umeå",
                    "Lund",
                    "JönKöping",
                    "Norrköping",
                    "Helsihgborg",
                    "Linköping",
                    "Örebro",
                    "Västerås",
                    "Växjö",
                    "Upplands",
                    "Väsby",
                    "Sollentuna",
                    "Södertälje",
                    "Uppsala",
                    "Malmö",
                    "Göteborg",
                    "Stockholm"
                };
            }
        
        
        }

    }
}
