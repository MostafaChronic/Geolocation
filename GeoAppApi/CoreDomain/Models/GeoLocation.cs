using CoreDomain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreDomain.Models
{
    public class GeoLocation : BaseEntity<Guid>
    {

        public GeoLocation()
        {
            Id = Guid.NewGuid();
        }
        public double FirstLong { get; set; }
        public double FirstLat { get; set; }
        public double SecLong { get; set; }
        public double SecLat { get; set; }
        public double FinalDistance { get; set; }
        public string UserId { get; set; }
        public DateTime RequestDate { get; set; }


        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("UserId")]
        public AppUser AppUser { get; set; }

    }
}
