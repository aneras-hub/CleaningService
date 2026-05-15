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
        public List<Order> Orders { get; set; } = new List<Order>();

        // Додавання замовлення
        public void AddOrder(Order order)
        {
            Orders.Add(order);

            //автоматично додаємо працівнику
            if (order.Employee != null)
                order.Employee.Orders.Add(order);
        }

        // Видалення замовлення
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

        // Очистка всього списку
        public void ClearAll()
        {
            Orders.Clear();
        }

        // Відображення у ListBox
        public List<Order> GetAll()
        {
            return Orders;
        }

        // Сортування за ціною
        public List<Order> SortByPrice()
        {
            return Orders.OrderBy(o => o.Price).ToList();
        }

        // Сортування за площею
        public List<Order> SortByArea()
        {
            return Orders.OrderBy(o => o.RoomArea).ToList();
        }

        // Пошук за клієнтом
        public List<Order> FindByClient(string name)
        {
            return Orders
                .Where(o => o.FullNameClient.ToLower().Contains(name.ToLower()))
                .ToList();
        }

        // Фільтр за типом послуги
        public List<Order> FilterByStatus(string status)
        {
            return Orders
                .Where(o => o.PaymentStatus == status)
                .ToList();
        }
        // Загальний дохід
        public double GetTotalIncome()
        {
            return Orders.Sum(o => o.Price);
        }
        // Дохід за період
        public double GetRevenueByPeriod(DateTime start, DateTime end)
        {
            return Orders
                .Where(o => o.OrderDate >= start && o.OrderDate <= end)
                .Sum(o => o.Price);
        }
        // Зарплата працівника (40% від замовлень)
        public double CalculateEmployeeSalary(Employee emp)
        {
            return emp.GetSalary();
        }
        // Запис у JSON
        public void WriteToFile(string fileName)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    // Це налаштування виправляє помилку циклу:
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };

                string jsonString = JsonSerializer.Serialize(Orders, options);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні JSON: {ex.Message}");
            }
        }

        // Читання з JSON
        public void ReadFromFile(string fileName)
        {
            if (!File.Exists(fileName)) return;

            FileInfo info = new FileInfo(fileName);
            if (info.Length == 0) return;

            try
            {
                string jsonString = File.ReadAllText(fileName);
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };
                Orders = JsonSerializer.Deserialize<List<Order>>(jsonString, options) ?? new List<Order>();
                foreach (var order in Orders)
                {
                    if (order.Employee != null)
                    {
                        if (order.Employee.Orders == null)
                            order.Employee.Orders = new List<Order>();

                        order.Employee.Orders.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при читанні JSON: {ex.Message}");
            }
        }

        public void Load(string path)
        {
            ReadFromFile(path);
        }
    }
}