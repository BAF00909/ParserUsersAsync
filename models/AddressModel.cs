using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParserUsersAsync.models
{
    record AddressModel
    {
        [property: JsonPropertyName("street")] public string Street { get; set; }
        [property: JsonPropertyName("suite")] public string Suite { get; set; }
        [property: JsonPropertyName("city")] public string City { get; set; }
        [property: JsonPropertyName("zipcode")] public string ZipCode { get; set; }
        [property: JsonPropertyName("geo")] public GeoModel Geo { get; set; }
    }
}
