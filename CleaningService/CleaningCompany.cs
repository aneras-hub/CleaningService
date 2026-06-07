using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Windows.Forms;

namespace CleaningService
{
    public class CleaningCompany
    {
        [JsonIgnore]
        public List<Order> Orders { get; set; } = new List<Order>();
        public void AddOrder(Order order)
        {
            if (order == null)
                return;
            Orders.Add(order);
            if (order.Employee != null)
                order.Employee.Orders.Add(order);
        }
        public void RemoveOrder(Order order)
        {
            if (order != null)
            {
                Orders.Remove(order);

                if (order.Employee != null)
                {
                    order.Employee.Orders.Remove(order);
                }
            }
        }
        public void ClearAll()
        {
            foreach (var order in Orders)
            {
                if (order.Employee != null)
                    order.Employee.Orders.Remove(order);
            }

            Orders.Clear();
        }
        public List<Order> GetAll()
        {
            return Orders;
        }
        public List<Order> SortByPrice()
        {
            return Orders.OrderBy(o => o.Price).ToList();
        }
        public List<Order> SortByArea()
        {
            return Orders.OrderBy(o => o.RoomArea).ToList();
        }
        public List<Order> FindByClient(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Orders;
            return Orders
                .Where(o => o.FullNameClient.ToLower().Contains(name.ToLower()))
                .ToList();
        }
        public List<Order> FilterByStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return Orders;

                return Orders
                .Where(o => o.PaymentStatus == status)
                .ToList();
        }
        public double GetTotalIncome()
        {
            return Orders.Sum(o => o.Price);
        }
        public double GetRevenueByPeriod(DateTime start, DateTime end)
        {
            return Orders
                .Where(o => o.OrderDate >= start && o.OrderDate <= end)
                .Sum(o => o.Price);
        }
        public double CalculateEmployeeSalary(Employee emp)
        {
            if (emp == null)
                return 0;
            return emp.GetSalary();
        }
        public void WriteToFile(string fileName, OrderEmployee employeeManager)
        {
            try
            {
                var data = new AppData
                {
                    Orders = Orders,
                    Employees = employeeManager.Employees
                };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };

                string jsonString = JsonSerializer.Serialize(data, options);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні JSON: {ex.Message}");
            }
        }

        public void ReadFromFile(string fileName, OrderEmployee employeeManager)
        {
            if (!File.Exists(fileName)) return;

            try
            {
                string jsonString = File.ReadAllText(fileName);

                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };

                var data = JsonSerializer.Deserialize<AppData>(jsonString, options);

                Orders = data?.Orders ?? new List<Order>();
                employeeManager.Employees = data?.Employees ?? new List<Employee>();

                foreach (var emp in employeeManager.Employees)
                    emp.Orders = new List<Order>();

                foreach (var order in Orders)
                {
                    order.Services ??= new List<CleaningService>();
                    order.Price = order.CalculatePrice();

                    var realEmployee = employeeManager.Employees
                        .FirstOrDefault(e => e.Id == order.Employee?.Id);

                    if (realEmployee != null)
                    {
                        order.Employee = realEmployee;
                        realEmployee.Orders.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при читанні JSON: {ex.Message}");
            }
        }
    }
}