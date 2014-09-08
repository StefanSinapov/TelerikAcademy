namespace Cars.Models.Projections
{
    using System;
    using System.Collections.Generic;

    public class SearchResultProjection
    {
        public SearchResultProjection()
        {
           
        }

        public string Model { get; set; }

        public string ManufacturerName { get; set; }

        public int Year { get; set; }

        public Decimal Price { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public string DealerName { get; set; }

        public IEnumerable<string> Cities { get; set; }
    }
}