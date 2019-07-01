using System.Collections.Generic;

namespace CountriesJson
{
    public class Country
    {
        public string name { get; set; }
        public int population { get; set; }
        public List<Currency> currencies { get; set; }
    }
}
