using System;
using System.Collections.Generic;
using System.Linq;

namespace CleaningService
{
    public class OrderEmployee
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();

        //ДОДАТИ
        public void AddEmployee(Employee emp)
        {
            if (emp != null)
                Employees.Add(emp);
        }

        //РЕДАГУВАТИ
        public void EditEmployee(int id, string newName, string newPhone)
        {
            var emp = Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                emp.EmployeeName = newName;
                emp.EmployeeNumber = newPhone;
            }
        }

        // ❌ ВИДАЛИТИ
        public void RemoveEmployee(int id)
        {
            var emp = Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
                Employees.Remove(emp);
        }

        // 🔍 ЗНАЙТИ
        public List<Employee> Search(string query)
        {
            return Employees.Where(e =>
                    e.EmployeeName.Contains(query, StringComparison.OrdinalIgnoreCase) || // замінено на query
                    e.EmployeeNumber.Contains(query) // замінено на query
                ).ToList();
        }

        // 📊 ТОП працівники
        public List<Employee> GetTopEmployees()
        {
            return Employees
                .OrderByDescending(e => e.GetOrdersCount())
                .ToList();
        }
        // 🔥 найзайнятіший
        public Employee GetMostBusyEmployee()
        {
            return Employees
                .OrderByDescending(e => e.GetOrdersCount())
                .FirstOrDefault();
        }

        // 🔥 вільні🆕 Вільні працівники
        public List<Employee> GetFreeEmployees()
        {
            return Employees
                .Where(e => e.GetOrdersCount() == 0)
                .ToList();
        }
    }
}