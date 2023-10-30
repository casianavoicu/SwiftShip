using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic.Utils
{
    sealed internal class StageHandler : IStageHandler
    {
        private readonly Dictionary<StageType, List<StageType>> StageRules = new Dictionary<StageType, List<StageType>>()
        {
            { StageType.Warehouse, new List<StageType>() { StageType.InTransit} },
            { StageType.InTransit, new List<StageType>() { StageType.Warehouse, StageType.Shipped } },
            { StageType.Shipped, new List<StageType>()},
        };

        public bool IsInitial(StageType stageType)
        {
            return stageType == StageType.Warehouse;
        }

        public bool IsCurrentStageCorrectBasedOnPrevious(StageType existing, StageType current)
        {
            var stageBasedOnExisting = StageRules[existing];
            return stageBasedOnExisting.Contains(current);
        }

        public List<StageType> GetStageOptions(StageType stageType)
        {
            return StageRules[stageType];
        }
    }
}
