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
        //For example:
        //IRepository<MyClass> MyClassRepo { get; }
        IRepository<Category> CategoryRepo { get; }
        IRepository<Employee> EmployeeRepo { get; }
        IRepository<Order> OrderRepo { get; }
        IRepository<OrderPosition> OrderPositionRepo { get; }
        IRepository<OrderStatus> OrderStatusRepo { get; }
        IRepository<Payment> PaymentRepo { get; }
        IRepository<Position> PositionRepo { get; }
        IRepository<Subcategory> SubcategoryRepo { get; }
        IRepository<Tabel> TabelRepo { get; }
        IRepository<WorkShift> WorkShiftRepo { get; }
        IRepository<WorkShiftEmployee> WorkShiftEmployeeRepo { get; }
        void Save();
    }
}
