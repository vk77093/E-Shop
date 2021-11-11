using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.ViewModels
{
    public class CustomerVM
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required]
        public string CustomerCity { get; set; }
        [Required]
        public string CustomerState { get; set; }
        [Required]
        public string CustomerCountry { get; set; }

    }
}
