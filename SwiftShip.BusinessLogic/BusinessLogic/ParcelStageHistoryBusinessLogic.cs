using AutoMapper;
using SwiftShip.BusinessLogic.Models;
using SwiftShip.BusinessLogic.Utils;
using SwiftShip.Database.Entities;
using SwiftShip.Database.Enums;
using SwiftShip.Service;

namespace SwiftShip.BusinessLogic.BusinessLogic
{
    sealed internal class ParcelStageHistoryBusinessLogic : IParcelStageHistoryBusinessLogic
    {
        private readonly IParcelService _parcelService;
        private readonly IMapper _mapper;
        private readonly IStageHandler _stageBusinessLogic;
        private readonly IStageService _stageService;

        public ParcelStageHistoryBusinessLogic(IParcelService parcelService, IMapper mapper,
            IStageService stageService, IStageHandler stageBusinessLogic)
        {
            _parcelService = parcelService;
            _mapper = mapper;
            _stageService = stageService;
            _stageBusinessLogic = stageBusinessLogic;
        }

        public async Task<bool> AddAsync(ParcelStageModel parcelStageModel)
        {
            var dbParcel = await _parcelService.GetExtendedAsync(parcelStageModel.Id);

            if (dbParcel == null)
            {
                throw new Exception("Parcel not found");
            }

            var currentStageHistory = dbParcel.StageHistory.OrderByDescending(x => x.CreatedDate).First();
            var currentStage = (StageType)currentStageHistory.StageId;

            var isValid = _stageBusinessLogic 
                .IsValidTransition(currentStage,
                parcelStageModel.Stage);

            if (isValid == false)
                throw new Exception();

            var mappedStage = _mapper.Map<StageHistory>(parcelStageModel);
            mappedStage.CreatedDate = DateTime.UtcNow;
            await _stageService.AddStage(mappedStage);

            return true;
        }
    }
}
