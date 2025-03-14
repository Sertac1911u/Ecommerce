using Ecommerce.Cargo.DataAccessLayer.Abstract;
using Ecommerce.Cargo.DataAccessLayer.Concrete;
using Ecommerce.Cargo.DataAccessLayer.Repositories;
using Ecommerce.Cargo.EntityLayer.Concrete;

namespace Ecommerce.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoDetailDal : GenericRepository<CargoDetail>,ICargoDetailDal 
    {
        public EfCargoDetailDal(CargoContext context) : base(context) { }
    }
}
