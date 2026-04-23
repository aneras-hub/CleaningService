using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
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
            if (order != null)
                Orders.Add(order);
        }

        // Видалення замовлення
        public void RemoveOrder(Order order)
        {
            if (order != null)
                Orders.Remove(order);
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
        public double CalculateEmployeeSalary(string employee)
        {
            return Orders
                .Where(o => o.Employee == employee)
                .Sum(o => o.Price) * 0.4;
        }
        // Запис у XML
        public void WriteToFile(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xml.Serialize(fs, Orders);
            }
        }
        // Читання з XML
        public void ReadFromFile(string fileName)
        {
            if (!File.Exists(fileName)) return;

            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                Orders = (List<Order>)xml.Deserialize(fs);
            }
        }
        // Додаткові методи для збереження та завантаження
        public void Load(string path)
        {
            if (!File.Exists(path)) return;

            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                Orders = (List<Order>)xml.Deserialize(fs);
            }
        }
    }
}