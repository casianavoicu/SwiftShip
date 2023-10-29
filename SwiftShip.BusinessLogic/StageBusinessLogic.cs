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

        private readonly Dictionary<StageType, List<StageType>> StageOptions = new Dictionary<StageType, List<StageType>>()
        {
            { StageType.Warehouse, new List<StageType>() { StageType.Warehouse, StageType.InTransit} },
            { StageType.InTransit, new List<StageType>() { StageType.InTransit, StageType.Warehouse, StageType.Shipped } },
            { StageType.Shipped, new List<StageType>() { StageType.Shipped } },
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
           var stageBasedOnExisting = StageOptions[existing];
           return stageBasedOnExisting.Contains(current);
        }

        public List<StageType> GetStageOptions(StageType stageType)
        {
            return StageRules[stageType];
        }
    }
}
