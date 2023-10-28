using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic
{
    public class StageBusinessLogic : IStageBusinessLogic
    {
        private readonly Dictionary<StageType, List<StageType>> StageRules = new Dictionary<StageType, List<StageType>>()
        {
            { StageType.Warehouse, new List<StageType>() { StageType.InTransit} },
            { StageType.InTransit, new List<StageType>() { StageType.Warehouse, StageType.Shipped } },
            { StageType.Shipped, new List<StageType>()},
        };

        public Dictionary<StageType, List<StageType>> GetStages()
        {
            return StageRules;
        }

        public bool IsInitial(StageType stageType)
        { 
            return stageType == StageType.Warehouse;
        }

        public bool IsCurrentStageCorrectBasedOnPrevious(StageType existing, StageType current)
        {
           var stageBasedOnExisting = StageRules[existing];
           return stageBasedOnExisting.Contains(current);
        }
    }
}
