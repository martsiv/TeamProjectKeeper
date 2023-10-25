using data_access.Repositories;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFClient.Commands;
using WPFClient.Help;
using WPFClient.TransferModel;

namespace WPFClient.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VM_Login : IPageViewModel
    {
        public BaseTransferModel TransferModel { get; set; }
        public LoginTM loginTM;
        private ICommand? _goToGeneralInfo;

        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }


        public VM_Login(string pageIndex = "1")
        {
            //loadBookingsCmd = new((o) => LoadBookings());

            PageId = pageIndex;
            Title = "ViewLogin";

            loginTM = new LoginTM() { PageNumber = "2", employees = new() { new() { Id = 1, Name = "Vasya", PinCode = 567 } }, CurrentEmployee = new() { Id = 2, Name = "Petya", PinCode = 523 } };

        }
        public ICommand GoToGeneralInfo
        {
            get
            {
                return _goToGeneralInfo ??= new RelayCommand(x =>
                {
                    loginTM.PageNumber = "2";
                    ViewChanged?.Raise(this, loginTM);
                });
            }
        }

        private IUoW unitOfWork = new UnitOfWork();

        //private readonly RelayCommand loadBookingsCmd;
        //public ICommand LoadBookingsCmd => loadBookingsCmd;
        //public void LoadBookings()
        //{
        //    var res = unitOfWork.BookingRepo.Get();
        //    bookings.Clear();
        //    foreach (var item in res)
        //        bookings.Add(item);
        //}
    }
}
