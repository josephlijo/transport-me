using System.ComponentModel.DataAnnotations;

namespace TransportMe.API.Models
{
    public class TransportServiceDto
    {
        public int Id { get; set; }

        [Required]
        public int CityId { get; set; }

        public int TransportModeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
