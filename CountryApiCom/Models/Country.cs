using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityApiCom.Models
{
    [Table("Countries")]
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
