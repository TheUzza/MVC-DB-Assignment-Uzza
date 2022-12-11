using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Models
{
    public class Person
    {
        public Person(string name, string phonenumber, string city)
        {

            this.Name = name;
            this.PhoneNumber = phonenumber;
            this.City = city;

        }
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        [Display(Name = "Phone no.")]
        public string PhoneNumber { get; set; }

    }
}

