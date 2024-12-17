using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.EntityLayer.Concrete
{
    public class CarCategory
    {
        public int CarCategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public string CategoryDescription { get; set; }
        public List<Car> Cars { get; set; }
    }
}
