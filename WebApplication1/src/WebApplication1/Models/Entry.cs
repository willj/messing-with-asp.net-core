using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Helpers;

namespace WebApplication1.Models
{
    public class Entry
    {
        public Entry()
        {
            this.EntryDate = GMT.Now;
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        public bool OptIn { get; set; }

        [BoolMustBeTrue(ErrorMessage = "You must agree to the terms.")]
        public bool AgreeTerms { get; set; }

        public DateTime EntryDate { get; set; }
        public string IpAddress { get; set; }
        private string userAgent;
        public string UserAgent
        {
            get { return this.userAgent; }
            set { this.userAgent = (!string.IsNullOrEmpty(value) && value.Length > 255) ? value.Substring(0, 255) : value; }
        }
    }
}
