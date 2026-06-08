using System;
using System.Collections.Generic;
using System.Linq;

namespace CleaningService
{
    public class OrderEmployee
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public void AddEmployee(Employee emp)
        {
            if (emp != null)
                Employees.Add(emp);
        }
        public void EditEmployee(int id, string newName, string newPhone, DateTime newBirthDate)
        {
            var emp = Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                emp.EmployeeName = newName;
                emp.EmployeeNumber = newPhone;
                emp.BirthDate = newBirthDate;
            }
        }
        public void RemoveEmployee(int id)
        {
            var emp = Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
                Employees.Remove(emp);
        }
        public List<Employee> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Employees;
            return Employees.Where(e =>
                    e.EmployeeName.Contains(query, StringComparison.OrdinalIgnoreCase) || // замінено на query
                    e.EmployeeNumber.Contains(query) // замінено на query
                ).ToList();
        }
        public List<Employee> GetTopEmployees()
        {
            return Employees
                .OrderByDescending(e => e.GetOrdersCount())
                .ToList();
        }
        public Employee GetMostBusyEmployee()
        {
            return Employees
                .OrderByDescending(e => e.GetOrdersCount())
                .FirstOrDefault();
        }
        public List<Employee> GetFreeEmployees()
        {
            return Employees
                .Where(e => e.GetOrdersCount() == 0)
                .ToList();
        }
        public List<Employee> SortByName()
        {
            return Employees
                .OrderBy(e => e.EmployeeName)
                .ToList();
        }
        public List<Employee> SortByOrdersCount()
        {
            return Employees
                .OrderByDescending(e => e.GetOrdersCount())
                .ToList();
        }
        public List<Employee> SortBySalary()
        {
            return Employees
                .OrderByDescending(e => e.GetSalary())
                .ToList();
        }
    }
}