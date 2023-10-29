using AutoMapper;
using SwiftShip.BusinessLogic.Models;
using SwiftShip.Database.Entities;
using SwiftShip.Database.Enums;
using SwiftShip.Service;

namespace SwiftShip.BusinessLogic
{
    public class ParcelBusinessLogic : IParcelBusinessLogic
    {
        private readonly IParcelService _parcelService;
        private readonly IMapper _mapper;
        private readonly IStageBusinessLogic _stageBusinessLogic;

        public ParcelBusinessLogic(IParcelService parcelService, IMapper mapper, IStageBusinessLogic stageBusinessLogic)
        {
            _parcelService = parcelService;
            _mapper = mapper;
            _stageBusinessLogic = stageBusinessLogic;
        }

        public async Task<bool> AddAsync(BaseParcelModel parcelModel)
        {
            if(parcelModel.Id != null)
                throw new Exception("Cannot insert object with identifier");

            var mappedResult = _mapper.Map<Parcel>(parcelModel);
            parcelModel.StageType = StageType.Warehouse;
            var isInitialStage = _stageBusinessLogic.IsInitial(parcelModel.StageType);

            if(!isInitialStage)
            {
                throw new Exception("Cannot insert stage with wrong identifier");
            }

            mappedResult.StageHistory = new List<StageHistory>
            {
                new StageHistory
                {
                    Address =  parcelModel.Address,
                    StageId = (int)parcelModel.StageType,
                }
            };
            mappedResult.Identifier = Guid.NewGuid();

            await _parcelService.AddAsync(mappedResult);

            if (mappedResult?.Id != null)
                return true;

            return false;
        }

        public async Task<CustomerParcelModel> GetAsync(int id)
        {
            var result = await _parcelService.GetAsync(id);
            if (result == null)
                throw new Exception("Parcel not found");

            return _mapper.Map<CustomerParcelModel>(result);
        }

        public async Task<List<ParcelModel>> GetAllAsync()
        {
            var result = await _parcelService.GetAllAsync();

            return _mapper.Map<List<ParcelModel>>(result);
        }

        public async Task<bool> UpdateAsync(BaseParcelModel parcelModel)
        {
            if (parcelModel.Id == null)
                throw new ArgumentNullException("Cannot update object without identifier");

            //verify state
            var dbParcel = await _parcelService.GetAsync(parcelModel.Id.Value);
            if (dbParcel == null)
            {
                throw new Exception();
            }

             _mapper.Map(parcelModel, dbParcel);

            await _parcelService.UpdateAsync(dbParcel);

            return true;
        }
    }
}
