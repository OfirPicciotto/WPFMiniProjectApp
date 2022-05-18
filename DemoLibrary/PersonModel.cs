using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DemoLibrary {
    public class PersonModel {
        BindingList<AddressModel> addresses = new BindingList<AddressModel>();
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public AddressModel Address { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public string FullInfoDisplay => $"{FirstName} {LastName}, {Street}, {City}, {Country}  {ZipCode}";

    }
}
