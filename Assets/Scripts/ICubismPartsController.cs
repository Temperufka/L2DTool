namespace Intermarum.Tools.ChibiGenerator
{
    using global::Core.Gameplay.Info;
    using Live2D.Cubism.Core;
    using System.Collections.Generic;
    public interface ICubismPartsController
    {
        void DisablePartsOpacity(CubismModel cubismModel, List<string> cubismParts);
      
        void DisablePartsOpacity(CubismModel cubismModel, List<CubismPartsId> cubismPartsIds);
        void EnablePartsOpacity(CubismModel cubismModel, List<string> cubismParts);
        void SetupPartOpacity(CubismModel cubismModel, string partId, int opacity);
        void EnablePartOpacity(CubismModel cubismModel, string partId);
        void DisablePartOpacity(CubismModel cubismModel, string partId);
    }
}
