using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Models;

namespace WPFClient.TransferModel
{
    public class GeneralInfoTM : BaseTransferModel
    {
        public List<EmployeeModel> employees = new List<EmployeeModel>();
        public EmployeeModel CurrentEmployee { get; set; }

    }
}
