using System.ComponentModel.DataAnnotations;

namespace TransportMe.API.Models
{
    public class TransportServiceDto
    {
        public string CityName { get; set; }

        public string TransportMode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
