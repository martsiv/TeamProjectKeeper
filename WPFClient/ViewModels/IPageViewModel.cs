using data_access.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Help;
using WPFClient.TransferModel;

namespace WPFClient.ViewModels
{

    public interface IPageViewModel
    {
        event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public UnitOfWork UoW { get; set; }
        public BaseTransferModel TransferModel { get; set; }
        string PageId { get; set; }
        string Title { get; set; }
    }
}
