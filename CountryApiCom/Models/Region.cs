using System.ComponentModel.DataAnnotations.Schema;

namespace CityApiCom.Models
{
    [Table("Regions")]
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
