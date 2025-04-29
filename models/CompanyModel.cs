using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParserUsersAsync.models
{
    record CompanyModel
    {
        [property: JsonPropertyName("name")] public string Name { get; set; }
        [property: JsonPropertyName("catchPhrase")] public string CatchPhrase { get; set; }
        [property: JsonPropertyName("bs")] public string Bs { get; set; }
    }
}
