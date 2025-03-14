using Ecommerce.Cargo.BusinessLayer.Abstract;
using Ecommerce.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using Ecommerce.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOparationDto createCargoOparationDto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Barcode = createCargoOparationDto.Barcode,
                operationDate = createCargoOparationDto.operationDate,
                Description = createCargoOparationDto.Description
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Cargo Operation Added");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Cargo Operation Deleted");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var values = _cargoOperationService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = updateCargoOperationDto.Barcode,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Description = updateCargoOperationDto.Description,
                operationDate = updateCargoOperationDto.operationDate,
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Cargo Operation Updated");
        }
    }
}
