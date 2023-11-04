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
            // Ваш логіка конвертації тут. Наприклад, якщо value - це об'єкт з колекції, який ви хочете конвертувати в int,
            // ви можете використовувати Convert.ToInt32 або інші методи конвертації відповідно до вашого вхідного типу.

            // Приклад:
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
            // Логіка конвертації назад (якщо потрібно). Цей метод буде викликаний при зміні значення відображуваного елемента.
            // Наприклад, якщо ви хочете конвертувати int назад в вхідний тип об'єкта у колекції.
            // Зазвичай цей метод не потрібно реалізовувати, тому може бути пустим.

            // Приклад:
            // if (value != null)
            // {
            //     return YourConversionLogicBack(value);
            // }

            return null; // Значення за замовчуванням, якщо не вдається конвертувати назад.
        }
    }
}
