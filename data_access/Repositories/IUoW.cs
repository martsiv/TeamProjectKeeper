using data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Repositories
{
    public interface IUoW
    {
        IRepository<CashRegister> CashRegisterRepo { get; }
        IRepository<CashierShift> CashierShiftRepo { get; }
        IRepository<Category> CategoryRepo { get; }
        IRepository<Employee> EmployeeRepo { get; }
        IRepository<Hall> HallRepo { get; }
        IRepository<Order> OrderRepo { get; }
        IRepository<InternalOrder> InternalOrderRepo { get; }
        IRepository<DeliveryOrder> DeliveryOrderRepo { get; }
        IRepository<OrderDish> OrderDishRepo { get; }
        IRepository<OrderStatus> OrderStatusRepo { get; }
        IRepository<Payment> PaymentRepo { get; }
        IRepository<Dish> DishRepo { get; }
        IRepository<Subcategory> SubcategoryRepo { get; }
        IRepository<Table> TableRepo { get; }
        IRepository<WorkShift> WorkShiftRepo { get; }
        IRepository<WorkShiftEmployee> WorkShiftEmployeeRepo { get; }
        void Save();
    }
}
