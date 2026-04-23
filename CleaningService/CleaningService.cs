using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningService
{
    public class CleaningService
    {
        public string CategoryService { get; set; }
        public string OtherService { get; set; }

        public CleaningService() { }

        public CleaningService(string categoryService, string otherService)
        {
            CategoryService = categoryService;
            OtherService = otherService;
        }

        public override string ToString()
        {
            return $"{CategoryService} ({OtherService})";
        }
    }
}
