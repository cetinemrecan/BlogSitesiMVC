using System.ComponentModel.DataAnnotations;

namespace BlogApi.DataAccessLAyer
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
