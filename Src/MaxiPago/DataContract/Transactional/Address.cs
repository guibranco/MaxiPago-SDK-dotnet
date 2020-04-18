using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    public class Address
    {

        [XmlElement("name")]
        public string Name { get; set; }
        public bool ShouldSerializeName() { return !string.IsNullOrEmpty(Name); }

        [XmlElement("address")]
        public string Address1 { get; set; }
        public bool ShouldSerializeAddress1() { return !string.IsNullOrEmpty(Address1); }

        [XmlElement("address2")]
        public string Address2 { get; set; }
        public bool ShouldSerializeAddress2() { return !string.IsNullOrEmpty(Address2); }

        [XmlElement("city")]
        public string City { get; set; }
        public bool ShouldSerializeCity() { return !string.IsNullOrEmpty(City); }

        [XmlElement("state")]
        public string State { get; set; }
        public bool ShouldSerializeState() { return !string.IsNullOrEmpty(State); }

        [XmlElement("postalcode")]
        public string Postalcode { get; set; }
        public bool ShouldSerializePostalcode() { return !string.IsNullOrEmpty(Postalcode); }

        [XmlElement("country")]
        public string Country { get; set; }
        public bool ShouldSerializeCountry() { return !string.IsNullOrEmpty(Country); }

        [XmlElement("phone")]
        public string Phone { get; set; }
        public bool ShouldSerializePhone() { return !string.IsNullOrEmpty(Phone); }

        [XmlElement("email")]
        public string Email { get; set; }
        public bool ShouldSerializeEmail() { return !string.IsNullOrEmpty(Email); }

    }
}
