﻿namespace Lab9_CodeFirst.Models {
    public class CarModel {
        public int CarModelId { get; set; }
        public string CarModelName { get; set; }
        public virtual ICollection<Car>? Cars { get; set; }
    }
}
