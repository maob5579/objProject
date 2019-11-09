using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MoodWcfService.Entities
{
    [DataContract]
    public class Restaurant_
    {
        [DataMember]
        public int RestaurantId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal AvgMood { get; set; }
        [DataMember]
        public decimal AvgPrice { get; set; }
        [DataMember]
        public decimal AvgExperience { get; set; }
    }
}