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
        private IRepository<Category>? categoryRepo = null;
        private IRepository<Employee>? employeeRepo = null;
        private IRepository<Order>? orderRepo = null;
        private IRepository<DeliveryOrder>? deliveryOrderRepo = null;
        private IRepository<InternalOrder>? internalOrderRepo = null;
        private IRepository<OrderPosition>? orderPositionRepo = null;
        private IRepository<OrderStatus>? orderStatusRepo = null;
        private IRepository<Payment>? paymentRepo = null;
        private IRepository<Position>? positionRepo = null;
        private IRepository<Subcategory>? subcategoryRepo = null;
        private IRepository<Tabel>? tabelRepo = null;
        private IRepository<WorkShift>? workShiftRepo = null;
        private IRepository<WorkShiftEmployee>? workShiftEmployeeRepo = null;
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
        public IRepository<OrderPosition> OrderPositionRepo
        {
            get
            {

                if (this.orderPositionRepo == null)
                {
                    this.orderPositionRepo = new Repository<OrderPosition>(context);
                }
                return orderPositionRepo;
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
        public IRepository<Position> PositionRepo
        {
            get
            {

                if (this.positionRepo == null)
                {
                    this.positionRepo = new Repository<Position>(context);
                }
                return positionRepo;
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
        public IRepository<Tabel> TabelRepo
        {
            get
            {

                if (this.tabelRepo == null)
                {
                    this.tabelRepo = new Repository<Tabel>(context);
                }
                return tabelRepo;
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
