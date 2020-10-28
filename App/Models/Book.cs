using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace testCase.Models
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public string Id {get; set;}
        
        [DataMember]
        [Required]
        [MaxLength(30)]
        public string Name {get; set;}
        
        [DataMember]
        [Required]
        [MinLength(1)]
        public List<Author> Authors { get; set; }
        
        [DataMember]
        [Required]
        [Range(0,10000)]
        public int NumberOfPages { get; set; }
        
        [DataMember]
        [Range(1800,2020)]
        public int PublishYear;

        [DataMember]
        [MaxLength(30)]
        public string Publisher { get; set; }
        
        [DataMember]
        [Required]
        [ISBN]
        public string ISBNNumber {get; set;}
        
        public string Cover {get; set;}
    }
}