using AutoMapper;
using SwiftShip.BusinessLogic.Models;
using SwiftShip.Database.Entities;
using SwiftShip.Database.Enums;
using SwiftShip.Service;

namespace SwiftShip.BusinessLogic
{
    public class ParcelStageHistoryBusinessLogic : IParcelStageHistoryBusinessLogic
    {
        private readonly IParcelService _parcelService;
        private readonly IMapper _mapper;
        private readonly IStageBusinessLogic _stageBusinessLogic;
        private readonly IStageService _stageService;

        public ParcelStageHistoryBusinessLogic(IParcelService parcelService, IMapper mapper,
            IStageService stageService, IStageBusinessLogic stageBusinessLogic)
        {
            _parcelService = parcelService;
            _mapper = mapper;
            _stageService = stageService;
            _stageBusinessLogic = stageBusinessLogic;
        }

        public async Task<List<ParcelStageModel>> GetAllAsync()
        {
            var dbParcels = await _parcelService.GetAllAsync();

            var mapped = _mapper.Map<List<ParcelStageModel>>(dbParcels);

            return mapped;
        }

        public async Task<bool> AddAsync(ParcelStageModel parcelStageModel)
        {
            var dbParcel = await _parcelService.GetExtendedAsync(parcelStageModel.Id);

            if(dbParcel == null)
                throw new ArgumentNullException();

            var currentStageHistory = dbParcel.StageHistory.OrderByDescending(x => x.CreatedDate).First();
            var currentStage = (StageType)currentStageHistory.StageId;

            var nextStage = _stageBusinessLogic
                .IsCurrentStageCorrectBasedOnPrevious(currentStage, 
                parcelStageModel.Stage);

            if (nextStage == false)
                throw new Exception();

            if (currentStage == parcelStageModel.Stage)
            {
                _mapper.Map(parcelStageModel, currentStageHistory);
                currentStageHistory.CreatedDate = DateTime.UtcNow;
                await _stageService.UpdateAsync(currentStageHistory!);
            }
            else
            {
                var mappedStage = _mapper.Map<StageHistory>(parcelStageModel);
                mappedStage.CreatedDate = DateTime.UtcNow;
                await _stageService.AddStage(mappedStage);
            }
            return true;
        }
    }
}
