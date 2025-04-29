using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParserUsersAsync.models
{
    record UserModel
    {
        [property: JsonPropertyName("id")] public int Id { get; set; }
        [property: JsonPropertyName("name")] public string Name { get; set; }
        [property: JsonPropertyName("username")] public string userName { get; set; }
        [property: JsonPropertyName("email")] public string Email { get; set; }
        [property: JsonPropertyName("phone")] public string Phone { get; set; }
        [property: JsonPropertyName("website")] public string WebSite { get; set; }
        [property: JsonPropertyName("address")] public AddressModel Address { get; set; }
        [property: JsonPropertyName("company")] public CompanyModel Company { get; set; }
    }
}
