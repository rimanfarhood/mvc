using System.ComponentModel.DataAnnotations.Schema;


namespace MvcApp.Models
{
    public class SerialNumber
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item? Item { get; set; }
    }
}