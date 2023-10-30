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
        private readonly IStageHandler _stageBusinessLogic;
        private readonly IStageHistoryInitializer _stageHistoryInitializer;

        public ParcelBusinessLogic(IParcelService parcelService, 
            IMapper mapper, 
            IStageHandler stageBusinessLogic, 
            IStageHistoryInitializer stageHistoryInitializer)
        {
            _parcelService = parcelService;
            _mapper = mapper;
            _stageBusinessLogic = stageBusinessLogic;
            _stageHistoryInitializer = stageHistoryInitializer;
        }

        public async Task<bool> AddAsync(ParcelModel parcelModel)
        {
            if (parcelModel.Id != null)
                throw new Exception("Cannot insert object with identifier");

            var mappedResult = Map(parcelModel);

            var isInitialStage = _stageBusinessLogic.IsInitial(parcelModel.StageType);

            if (!isInitialStage)
            {
                throw new Exception("Cannot insert stage with wrong identifier");
            }

            await _parcelService.AddAsync(mappedResult);

            if (mappedResult?.Id != null)
                return true;

            return false;
        }

        private Parcel Map(ParcelModel parcelModel)
        {
            var mappedResult = _mapper.Map<Parcel>(parcelModel);

            mappedResult.StageHistory = _stageHistoryInitializer.CreateInitial(parcelModel.Address);

            mappedResult.Identifier = Guid.NewGuid();

            mappedResult.RegisteredDate = DateTime.UtcNow;

            return mappedResult;
        }

        public async Task<CustomerParcelModel> GetAsync(Guid id)
        {
            var result = await _parcelService.GetOrderedAsync(e => e.Identifier == id);
            if (result == null)
                throw new Exception("Parcel not found");

            return _mapper.Map<CustomerParcelModel>(result);
        }

        public async Task<List<ParcelModel>> GetAllAsync()
        {
            var result = await _parcelService.GetAllAsync();

            return _mapper.Map<List<ParcelModel>>(result);
        }

        public async Task<bool> UpdateAsync(ParcelModel parcelModel)
        {
            if (parcelModel.Id == null)
                throw new ArgumentNullException("Cannot update object without identifier");

            var dbParcel = await _parcelService.GetOrderedAsync(e => e.Id == parcelModel.Id.Value);
            
            if (dbParcel == null)
            {
                throw new Exception();
            }

             _mapper.Map(parcelModel, dbParcel);

            await _parcelService.UpdateAsync(dbParcel);

            return true;
        }

        public async Task RemoveAsync(int? id)
        {
            var dbParcel = await _parcelService.GetBaseAsync(id.Value);

            if (dbParcel == null)
            {
                throw new ArgumentNullException();
            }

            await _parcelService.RemoveAsync(dbParcel);
        }
    }
}
