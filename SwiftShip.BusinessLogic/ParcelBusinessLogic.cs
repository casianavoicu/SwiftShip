using AutoMapper;
using SwiftShip.BusinessLogic.Models;
using SwiftShip.Database.Entities;
using SwiftShip.Service;

namespace SwiftShip.BusinessLogic
{
    public class ParcelBusinessLogic : IParcelBusinessLogic
    {
        private readonly IParcelService _parcelService;
        private readonly IMapper _mapper;

        public ParcelBusinessLogic(IParcelService parcelService, IMapper mapper)
        {
            _parcelService = parcelService;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(ParcelModel parcelModel)
        {
            if(parcelModel.Id != null)
                throw new Exception("Cannot insert object with identifier");

            var mappedResult = _mapper.Map<Parcel>(parcelModel);
            //verify state
            await _parcelService.AddAsync(mappedResult);

            if (mappedResult.Id != null)
                return true;

            return false;
        }

        public async Task<CustomerParcelModel> GetAsync(string id)
        {
            var result = await _parcelService.GetAsync(id);
            if (result == null)
                throw new Exception("Parcel not found");

            return _mapper.Map<CustomerParcelModel>(result);
        }

        public async Task<List<CustomerParcelModel>> GetAllAsync()
        {
            var result = await _parcelService.GetAllAsync();

            return _mapper.Map<List<CustomerParcelModel>>(result);
        }

        public async Task<bool> UpdateAsync(ParcelModel parcelModel)
        {
            if (parcelModel.Id == null)
                throw new ArgumentNullException("Cannot update object without identifier");

            //verify state
            var mappedResult = _mapper.Map<Parcel>(parcelModel);

            await _parcelService.UpdateAsync(mappedResult);

            if (mappedResult.Id != null)
                return true;

            return false;
        }
    }
}
