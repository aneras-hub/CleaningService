using System;
using System.Collections.Generic;
using System.Linq;

namespace CleaningService
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public Employee() { }
        public Employee(int id, string name, string number, DateTime birthDate)
        {
            Id = id;
            EmployeeName = name;
            EmployeeNumber = number;
            BirthDate = birthDate;
        }
        public int GetOrdersCount()
        {
            return Orders.Count;
        }
        public double GetSalary()
        {
            return Orders.Sum(o => o.Price) * 0.4;
        }
        public static List<Employee> FilterByOrdersCount(List<Employee> employees, int minOrders)
        {
            return employees
                .Where(e => e.GetOrdersCount() >= minOrders)
                .ToList();
        }
        public int CompletedOrdersPerMonth
        {
            get
            {
                return Orders.Count(o =>
                    o.OrderDate.Month == DateTime.Now.Month &&
                    o.OrderDate.Year == DateTime.Now.Year);
            }
        }
        public double Salary
        {
            get
            {
                return Orders.Sum(o => o.Price * 0.4);
            }
        }
        public override string ToString()
        {
            return $"{EmployeeName} | Замовлень: {GetOrdersCount()} | Зарплата: {GetSalary()} грн";
        }
    }
}