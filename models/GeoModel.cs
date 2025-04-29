using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParserUsersAsync.models
{
    record GeoModel
    {
        [property: JsonPropertyName("lat")] public string Lat { get; set; }
        [property: JsonPropertyName("lng")] public string Lng { get; set; }

    }
}
