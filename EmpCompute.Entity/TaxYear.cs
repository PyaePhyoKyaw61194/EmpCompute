using System.ComponentModel.DataAnnotations.Schema;

namespace EmpCompute.Entity
{

    [Table("taxyear")]
    public class TaxYear
    {
        public int Id { get; set; }
        public string YearOfTax { get; set; }
    }
}

