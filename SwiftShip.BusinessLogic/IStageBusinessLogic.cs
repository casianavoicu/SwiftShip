using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic
{
    public interface IStageBusinessLogic
    {
        Dictionary<StageType, List<StageType>> GetStages();
        bool IsCurrentStageCorrectBasedOnPrevious(StageType existing, StageType current);
        bool IsInitial(StageType stageType);
    }
}
