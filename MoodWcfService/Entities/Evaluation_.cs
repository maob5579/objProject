using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MoodWcfService.Entities
{
    [DataContract]
    public class Evaluation_
    {
        [DataMember]
        public int EvaluationId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int RestaurantId { get; set; }
        [DataMember]
        public decimal MoodRating { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public int Experience { get; set; }
    }
}