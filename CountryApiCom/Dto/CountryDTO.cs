using CityApiCom.Dto;
using System.ComponentModel.DataAnnotations;

namespace CityApiCom.Models
{
    public class CountryDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long Population { get; set; }
        [Required]
        public RegionDTO Region { get; set; }
    }
}
