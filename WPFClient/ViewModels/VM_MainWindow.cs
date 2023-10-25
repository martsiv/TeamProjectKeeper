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
        public VM_MainWindow(IDataModel pageViews)
        {
            _pageViewModels["1"] = new VM_Login("1") {  TransferModel = new LoginTM() { employees = new() { new() { Id = 1, Name = "Vasya", PinCode = 567 } }, CurrentEmployee = new() { Id = 2, Name = "Petya", PinCode = 523 } } };
            _pageViewModels["1"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
                //pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["2"] = new VM_GeneralInfo("2");
            _pageViewModels["2"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
                //pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["3"] = new VM_OrdersByWaiters("3");
            _pageViewModels["3"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
                //pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["4"] = new VM_OrdersByHalls("4");
            _pageViewModels["4"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
                //pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["5"] = new VM_OrdersByAllTables("5");
            _pageViewModels["5"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
                //pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["6"] = new VM_OrderMainView("6");
            _pageViewModels["6"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
                //pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["7"] = new VM_OrderQuickCheck("7");
            _pageViewModels["7"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
                //pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["8"] = new VM_Payment("8");
            _pageViewModels["8"].ViewChanged += (o, s) =>
            {
                _pageViewModels[s.Value.PageNumber].TransferModel = s.Value;
                CurrentPageViewModel = _pageViewModels[s.Value.PageNumber];
                //pageViews.Data = "Data: " + s.Value.ToString();
            };

            CurrentPageViewModel = _pageViewModels["1"];
        }
    }
}
