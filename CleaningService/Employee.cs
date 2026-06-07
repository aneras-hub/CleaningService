using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

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
            return Orders?.Count(o => o != null) ?? 0;
        }
        public double GetSalary()
        {
            return Orders?
                .Where(o => o != null && o.ExecutionStatus != "Скасовано")
                .Sum(o => o.Price * 0.4) ?? 0;
        }
        [JsonIgnore]
        public int CompletedOrdersPerMonth
        {
            get
            {
                return Orders?
                    .Where(o => o != null)
                    .Count(o =>
                        o.OrderDate.Month == DateTime.Now.Month &&
                        o.OrderDate.Year == DateTime.Now.Year) ?? 0;
            }
        }
        [JsonIgnore]
        public double Salary
        {
            get
            {
                return Orders?
                    .Where(o => o != null && o.ExecutionStatus != "Скасовано")
                    .Sum(o => o.Price * 0.3) ?? 0;
            }
        }
        public override string ToString()
        {
            return $"{EmployeeName} | Замовлень: {GetOrdersCount()} | Зарплата: {GetSalary()} грн";
        }
    }
}