using data_access.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WPFClient.Models;

namespace WPFClient.Help
{
    public class ConverterFromCollectionToNumber : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is IEnumerable<WorkShiftEmployeeModel>)
            {
                var collection = value as IEnumerable<WorkShiftEmployeeModel>;
                string res = collection
                    .Where(wse => wse.WorkShiftDate == DateTime.Now.Date)
                    .SelectMany(wse => wse.Orders)
                    .OfType<InternalOrderModel>()
                    .Count(io => io.OrderStatusId == 1)
                    .ToString();
                return res;
            }
            else if (value != null && value is IEnumerable<TableModel>)
            {
                var collection = value as IEnumerable<TableModel>;
                string res = collection
                    .SelectMany(t => t.InternalOrders)
                    .Count(io => io.OrderStatusId == 1)
                    .ToString();
                return res;
            }

            return 0; // Значення за замовчуванням, якщо value == null
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; // Значення за замовчуванням, якщо не вдається конвертувати назад.
        }
    }
}
