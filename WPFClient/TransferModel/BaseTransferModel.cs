﻿using data_access.Entities;
using data_access.Repositories;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Models;

namespace WPFClient.TransferModel
{
    [AddINotifyPropertyChangedInterface]
    public class BaseTransferModel
    {
        public List<string> PreviousPages { get; set; } = new List<string>();
        public string PageNumber { get; set; }
        public UnitOfWork UoW { get; set; }
        public EmployeeModel CurrentEmployee { get; set; }
        public OrderModel? CurrentOrder { get; set; }
        public WorkShiftEmployeeModel? CurrentWorkShiftEmployee { get; set; }
        public CashierShiftModel? CurrentCashierShift { get; set; }
        public ObservableCollection<EmployeeModel> Employees = new ObservableCollection<EmployeeModel>();
        public ObservableCollection<WorkShiftEmployeeModel> WorkShiftEmployees = new ObservableCollection<WorkShiftEmployeeModel>();

        public BaseTransferModel()
        {
        }
    }
}
