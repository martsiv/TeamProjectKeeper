using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.TransferModel
{
    public abstract class BaseTransferModel
    {
        public virtual string PageNumber { get; set; }
        public BaseTransferModel()
        {
            
        }
    }
}
