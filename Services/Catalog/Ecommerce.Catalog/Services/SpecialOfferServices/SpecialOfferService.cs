using AutoMapper;
using Ecommerce.Catalog.Dtos.CategoryDtos;
using Ecommerce.Catalog.Dtos.SpecialOfferDtos;
using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Settings;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

namespace Ecommerce.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
        private readonly IMapper _mapper;
        public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto SpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(SpecialOfferDto);
            await _specialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _specialOfferCollection.Find(x => true).ToListAsync();
            return (_mapper.Map<List<ResultSpecialOfferDto>>(values));
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var values = await _specialOfferCollection.Find<SpecialOffer>(x => x.SpecialOfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDto>(values);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto SpecialOfferDto)
        {
            var values = _mapper.Map<SpecialOffer>(SpecialOfferDto);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == SpecialOfferDto.SpecialOfferId, values);
        }
    }
}
