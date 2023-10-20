﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.ViewModels
{
    public interface IDataModel
    {
        string Data { get; set; }
        string? Reverse();
    }
}
