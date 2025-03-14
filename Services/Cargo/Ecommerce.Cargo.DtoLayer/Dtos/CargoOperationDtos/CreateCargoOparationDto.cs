namespace Ecommerce.Cargo.DtoLayer.Dtos.CargoOperationDtos
{
    public class CreateCargoOparationDto
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime operationDate { get; set; }
    }
}
