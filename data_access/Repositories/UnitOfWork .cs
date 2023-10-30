using data_access.Data;
using data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Repositories
{
    public class UnitOfWork : IUoW, IDisposable
    {
        private static ApplicationContext context = new ApplicationContext();
        private IRepository<CashierShift>? cashierShiftRepo = null;
        private IRepository<CashRegister>? cashRegisterRepo = null;
        private IRepository<Category>? categoryRepo = null;
        private IRepository<Employee>? employeeRepo = null;
        private IRepository<Hall>? hallRepo = null;
        private IRepository<Order>? orderRepo = null;
        private IRepository<DeliveryOrder>? deliveryOrderRepo = null;
        private IRepository<InternalOrder>? internalOrderRepo = null;
        private IRepository<OrderDish>? orderDishRepo = null;
        private IRepository<OrderStatus>? orderStatusRepo = null;
        private IRepository<Payment>? paymentRepo = null;
        private IRepository<Dish>? dishRepo = null;
        private IRepository<Subcategory>? subcategoryRepo = null;
        private IRepository<Table>? tableRepo = null;
        private IRepository<WorkShift>? workShiftRepo = null;
        private IRepository<WorkShiftEmployee>? workShiftEmployeeRepo = null;
        public IRepository<CashierShift> CashierShiftRepo
        {
            get
            {

                if (this.cashierShiftRepo == null)
                {
                    this.cashierShiftRepo = new Repository<CashierShift>(context);
                }
                return cashierShiftRepo;
            }
        }
        public IRepository<CashRegister> CashRegisterRepo
        {
            get
            {

                if (this.cashRegisterRepo == null)
                {
                    this.cashRegisterRepo = new Repository<CashRegister>(context);
                }
                return cashRegisterRepo;
            }
        }
        public IRepository<Category> CategoryRepo
        {
            get
            {

                if (this.categoryRepo == null)
                {
                    this.categoryRepo = new Repository<Category>(context);
                }
                return categoryRepo;
            }
        }
        public IRepository<Employee> EmployeeRepo
        {
            get
            {

                if (this.employeeRepo == null)
                {
                    this.employeeRepo = new Repository<Employee>(context);
                }
                return employeeRepo;
            }
        }
        public IRepository<Hall> HallRepo
        {
            get
            {

                if (this.hallRepo == null)
                {
                    this.hallRepo = new Repository<Hall>(context);
                }
                return hallRepo;
            }
        }
        public IRepository<Order> OrderRepo
        {
            get
            {

                if (this.orderRepo == null)
                {
                    this.orderRepo = new Repository<Order>(context);
                }
                return orderRepo;
            }
        }
        public IRepository<OrderDish> OrderDishRepo
        {
            get
            {

                if (this.orderDishRepo == null)
                {
                    this.orderDishRepo = new Repository<OrderDish>(context);
                }
                return orderDishRepo;
            }
        }
        public IRepository<InternalOrder> InternalOrderRepo
        {
            get
            {

                if (this.internalOrderRepo == null)
                {
                    this.internalOrderRepo = new Repository<InternalOrder>(context);
                }
                return internalOrderRepo;
            }
        }
        public IRepository<DeliveryOrder> DeliveryOrderRepo
        {
            get
            {

                if (this.deliveryOrderRepo == null)
                {
                    this.deliveryOrderRepo = new Repository<DeliveryOrder>(context);
                }
                return deliveryOrderRepo;
            }
        }
        public IRepository<OrderStatus> OrderStatusRepo
        {
            get
            {

                if (this.orderStatusRepo == null)
                {
                    this.orderStatusRepo = new Repository<OrderStatus>(context);
                }
                return orderStatusRepo;
            }
        }
        public IRepository<Payment> PaymentRepo
        {
            get
            {

                if (this.paymentRepo == null)
                {
                    this.paymentRepo = new Repository<Payment>(context);
                }
                return paymentRepo;
            }
        }
        public IRepository<Dish> DishRepo
        {
            get
            {

                if (this.dishRepo == null)
                {
                    this.dishRepo = new Repository<Dish>(context);
                }
                return dishRepo;
            }
        }
        public IRepository<Subcategory> SubcategoryRepo
		{
            get
            {

                if (this.subcategoryRepo == null)
                {
                    this.subcategoryRepo = new Repository<Subcategory>(context);
                }
                return subcategoryRepo;
            }
        }
        public IRepository<Table> TableRepo
        {
            get
            {

                if (this.tableRepo == null)
                {
                    this.tableRepo = new Repository<Table>(context);
                }
                return tableRepo;
            }
        }
        public IRepository<WorkShift> WorkShiftRepo
        {
            get
            {

                if (this.workShiftRepo == null)
                {
                    this.workShiftRepo = new Repository<WorkShift>(context);
                }
                return workShiftRepo;
            }
        }
        public IRepository<WorkShiftEmployee> WorkShiftEmployeeRepo
        {
            get
            {

                if (this.workShiftEmployeeRepo == null)
                {
                    this.workShiftEmployeeRepo = new Repository<WorkShiftEmployee>(context);
                }
                return workShiftEmployeeRepo;
            }
        }
        public UnitOfWork() { }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
