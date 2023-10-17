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
        // For example
        //private IRepository<MyClass>? myClassRepo = null;
        private IRepository<Category>? categoryRepo = null;
        private IRepository<Employee>? employeeRepo = null;
        private IRepository<Order>? orderRepo = null;
        private IRepository<OrderPosition>? orderPositionRepo = null;
        private IRepository<OrderStatus>? orderStatusRepo = null;
        private IRepository<Payment>? paymentRepo = null;
        private IRepository<PaymentType>? paymentTypeRepo = null;
        private IRepository<Position>? positionRepo = null;
        private IRepository<Service>? serviceRepo = null;
        private IRepository<Tabel>? tabelRepo = null;
        private IRepository<WorkShift>? workShiftRepo = null;
        private IRepository<WorkShiftEmployee>? workShiftEmployeeRepo = null;

        //public IRepository<MyClass> MyClassRepo
        //{
        //    get
        //    {
        //        if (this.myClassRepo == null)
        //        {
        //            this.myClassRepo = new Repository<MyClass>(context);
        //        }
        //        return myClassRepo;
        //    }
        //}
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
        public IRepository<PaymentType> PaymentTypeRepo
        {
            get
            {

                if (this.paymentTypeRepo == null)
                {
                    this.paymentTypeRepo = new Repository<PaymentType>(context);
                }
                return paymentTypeRepo;
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
        public IRepository<Service> ServiceRepo
        {
            get
            {

                if (this.serviceRepo == null)
                {
                    this.serviceRepo = new Repository<Service>(context);
                }
                return serviceRepo;
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
