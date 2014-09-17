using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Places.Services.Models
{
    public class PlaceModel
    {
        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }
    }
}