using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic.Utils
{
    public interface IStageHandler
    {
        List<StageType> GetPossibleTransitions(StageType stageType);
        bool IsValidTransition(StageType from, StageType to);
        bool IsInitial(StageType stageType);
    }
}
