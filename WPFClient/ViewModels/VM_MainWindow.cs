using data_access.Repositories;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.TransferModel;

namespace WPFClient.ViewModels
{
    enum UserControlsEnum { Login = 1, GeneralInfo, Orders, Order, QuickOrder, Payment }
    [AddINotifyPropertyChangedInterface]

    public class VM_MainWindow
    {
        private readonly Dictionary<string, IPageViewModel>? _pageViewModels = new();
        public IPageViewModel? CurrentPageViewModel { get; set; }
        private UnitOfWork _unitOfWork;
        public VM_MainWindow(IDataModel pageViews)
        {
            _unitOfWork = new UnitOfWork();
            _pageViewModels[$"{UserControlsEnum.Login}"] = new VM_Login(_unitOfWork, $"{UserControlsEnum.Login}");
            _pageViewModels[$"{UserControlsEnum.Login}"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].UoW = s.Value.UoW;
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
            };

            _pageViewModels[$"{UserControlsEnum.GeneralInfo}"] = new VM_GeneralInfo($"{UserControlsEnum.GeneralInfo}");
            _pageViewModels[$"{UserControlsEnum.GeneralInfo}"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].UoW = s.Value.UoW;
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
            };

            _pageViewModels[$"{UserControlsEnum.Orders}"] = new VM_Orders($"{UserControlsEnum.Orders}");
            _pageViewModels[$"{UserControlsEnum.Orders}"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].UoW = s.Value.UoW;
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
            };

            _pageViewModels[$"{UserControlsEnum.Order}"] = new VM_OrderMainView($"{UserControlsEnum.Order}");
            _pageViewModels[$"{UserControlsEnum.Order}"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].UoW = s.Value.UoW;
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
            };

            _pageViewModels[$"{UserControlsEnum.QuickOrder}"] = new VM_OrderQuickCheck($"{UserControlsEnum.QuickOrder}");
            _pageViewModels[$"{UserControlsEnum.QuickOrder}"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].UoW = s.Value.UoW;
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
            };

            _pageViewModels[$"{UserControlsEnum.Payment}"] = new VM_Payment($"{UserControlsEnum.Payment}");
            _pageViewModels[$"{UserControlsEnum.Payment}"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].UoW = s.Value.UoW;
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
            };

            CurrentPageViewModel = _pageViewModels[$"{UserControlsEnum.Login}"];
        }
    }
}
