using System.Collections.Generic;

namespace CleaningService
{
    public class AppData
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}