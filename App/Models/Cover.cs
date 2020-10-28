using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace testCase.Models
{
    [DataContract]
    public class Cover
    {
        [DataMember]
        [Required]
        public string Id { get; set; }
        [DataMember]
        [Required]
        public string CoverBase64String { get; set; }
    }
}
