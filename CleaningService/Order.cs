using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningService
{
    public class Order : IComparable<Order>
    {
        public DateTime OrderDate { get; set; }
        public string FullNameClient { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double RoomArea { get; set; }
        public List<CleaningService> Services { get; set; }
        public string Employee { get; set; }
        public string PaymentStatus { get; set; }
        public double Price { get; set; }
        public string TimeSlot { get; set; } 

        public Order()
        {
            Services = new List<CleaningService>();
        }

        public Order(DateTime orderDate, string fullNameClient, string phoneNumber,
            string address, double roomArea,
            List<CleaningService> services, string employee, string paymentStatus, string timeSlot)
        {
            OrderDate = orderDate;
            FullNameClient = fullNameClient;
            PhoneNumber = phoneNumber;
            Address = address;
            RoomArea = roomArea;
            Services = services ?? new List<CleaningService>();
            Employee = employee;
            PaymentStatus = paymentStatus;

            Price = CalculatePrice();
            TimeSlot = timeSlot;
        }

        public double CalculatePrice()
        {
            if (Services == null || Services.Count == 0)
                return 0;

            string mainService = Services[0].CategoryService;
            double total = 0;

            //Основні послуги (comboBox1)
            switch (mainService)
            {
                case "Генеральне прибирання":
                    total = 60 * RoomArea;
                    break;

                case "Підтримувальне прибирання":
                    total = 30 * RoomArea;
                    break;

                case "Прибирання після ремонту":
                    total = 100 * RoomArea;
                    break;

                case "Прибирання будинку":
                    total = 80 * RoomArea;
                    break;

                case "Прибирання котеджу":
                    total = 90 * RoomArea;
                    break;

                case "Прибирання офісу":
                    total = 50 * RoomArea;
                    break;

                case "Прибирання ресторану":
                    total = 70 * RoomArea;
                    break;

                case "Прибирання магазинів":
                    total = 55 * RoomArea;
                    break;

                default:
                    total = 40 * RoomArea;
                    break;
            }

            //Додаткові послуги (comboBox3)
            foreach (var service in Services)
            {
                switch (service.OtherService)
                {
                    case "Миття вікон":
                        total += 500;
                        break;

                    case "Хімчистка диванів":
                        total += 800;
                        break;

                    case "Полірування паркету":
                        total += 600;
                        break;

                    case "Хімчистка килимів":
                        total += 700;
                        break;

                    case "Чистка м’яких крісел та стільців":
                        total += 400;
                        break;
                }
            }
            return total;
        }

        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"{FullNameClient} | {RoomArea} м² | {Price} грн | {PaymentStatus}";
        }
    }
}