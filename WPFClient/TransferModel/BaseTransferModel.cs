using data_access.Entities;
using data_access.Repositories;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Models;

namespace WPFClient.TransferModel
{
    public class BaseTransferModel
    {
        public string PreviousPage { get; set; }
        public string PageNumber { get; set; }
        public UnitOfWork UoW { get; set; }
        public EmployeeModel CurrentEmployee { get; set; }
        public OrderModel CurrentOrder { get; set; }
        public BaseTransferModel()
        {
            
        }
    }
}
