using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary {
    public class AddressModel {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        //public string AddressFullDisplay => $"{Street}, {City}, {Country}  {ZipCode}";
    }
}
