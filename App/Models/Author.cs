using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace testCase.Models
{
    public class Author
    {
        [DataMember]
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [DataMember]
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
    }
}
