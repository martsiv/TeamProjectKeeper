﻿using data_access.Entities;
using data_access.Repositories;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFClient.Commands;

namespace WPFClient.Models
{
    [AddINotifyPropertyChangedInterface]
    public class HallModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TableModel> Tables { get; set; } = new HashSet<TableModel>();
    }
}
