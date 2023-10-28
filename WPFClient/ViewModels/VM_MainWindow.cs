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
    [AddINotifyPropertyChangedInterface]

    public class VM_MainWindow
    {
        private readonly Dictionary<string, IPageViewModel>? _pageViewModels = new();
        public IPageViewModel? CurrentPageViewModel { get; set; }
        private UnitOfWork _unitOfWork;
        public VM_MainWindow(IDataModel pageViews)
        {
            _unitOfWork = new UnitOfWork();
            _pageViewModels["1"] = new VM_Login(_unitOfWork, "1");
            _pageViewModels["1"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].UoW = s.Value.UoW;
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
            };

            _pageViewModels["2"] = new VM_GeneralInfo("2");
            _pageViewModels["2"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].UoW = s.Value.UoW;
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
            };

            _pageViewModels["3"] = new VM_Orders("3");
            _pageViewModels["3"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].UoW = s.Value.UoW;
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
            };

            _pageViewModels["4"] = new VM_OrderMainView("4");
            _pageViewModels["4"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].UoW = s.Value.UoW;
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
            };

            _pageViewModels["5"] = new VM_OrderQuickCheck("5");
            _pageViewModels["5"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].UoW = s.Value.UoW;
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
            };

            _pageViewModels["6"] = new VM_Payment("6");
            _pageViewModels["6"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].UoW = s.Value.UoW;
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
            };

            CurrentPageViewModel = _pageViewModels["1"];
        }
    }
}
