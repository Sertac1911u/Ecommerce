using Ecommerce.Cargo.DataAccessLayer.Abstract;
using Ecommerce.Cargo.DataAccessLayer.Concrete;
using Ecommerce.Cargo.DataAccessLayer.Repositories;
using Ecommerce.Cargo.EntityLayer.Concrete;

namespace Ecommerce.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>,ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContext context) : base(context) { }
    }
}
