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

        public bool IsValidTransition(StageType from, StageType to)
        {
            var stageBasedOnExisting = StageRules[from];
            return stageBasedOnExisting.Contains(to);
        }

        public List<StageType> GetPossibleTransitions(StageType stageType)
        {
            return StageRules[stageType];
        }
    }
}
