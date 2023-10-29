using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic
{
    public interface IStageBusinessLogic
    {
        List<StageType> GetStageOptions(StageType stageType);
        Dictionary<StageType, List<StageType>> GetStages();
        bool IsCurrentStageCorrectBasedOnPrevious(StageType existing, StageType current);
        bool IsInitial(StageType stageType);
    }
}
