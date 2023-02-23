using System.ComponentModel.DataAnnotations.Schema;

namespace Lab9_CodeFirst.Models {
    public class Car {
        public int CarID { get; set; }
        public string Name { get; set; }
        [ForeignKey("CarModelId")]
        public int CarModelId { get; set; }
        public virtual CarModel? CarModel { get; set; }
    }
}
