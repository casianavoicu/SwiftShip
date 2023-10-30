using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic.Utils
{
    public interface IStageHandler
    {
        List<StageType> GetStageOptions(StageType stageType);
        bool IsCurrentStageCorrectBasedOnPrevious(StageType existing, StageType current);
        bool IsInitial(StageType stageType);
    }
}
