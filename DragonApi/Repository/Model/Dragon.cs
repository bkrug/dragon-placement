using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Model
{
    [Table("Dragon")]
    public class Dragon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int HasFire { get; set; }
        public int HasFlight { get; set; }
    }
}
