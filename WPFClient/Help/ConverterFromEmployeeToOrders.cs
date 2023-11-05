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
    public class ConverterFromEmployeeToOrders : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is IEnumerable<WorkShiftEmployeeModel>)
            {
                var collection = value as IEnumerable<WorkShiftEmployeeModel>;
                var res = collection
                    .Where(wse => wse.TimeTo == null && wse.WorkShiftDate == DateTime.Now.Date)
                    .SelectMany(wse => wse.Orders).ToList();
                return res;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return null; // Значення за замовчуванням, якщо не вдається конвертувати назад.
        }
    }
}
