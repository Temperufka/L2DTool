namespace Intermarum.Tools.ChibiGenerator
{
    using global::Core.Gameplay.Info;
    using Live2D.Cubism.Core;
    using System.Collections.Generic;
    using UnityEngine;

    public enum CubismPartType
    {
        Undefined = 0,
        Clothes = 1,
        Hairs = 2,
        Expression = 3
    }
    public class CubismPartsController : ICubismPartsController
    {
        private const char PartsSeparator = ';';
        public void DisablePartsOpacity(CubismModel cubismModel, List<string> cubismParts)
        {
            for (var i = 0; i < cubismParts.Count; i++)
            {
                cubismModel.Parts.FindById(cubismParts[i]).Opacity = 0;
            }
        }

       

        public void EnablePartsOpacity(CubismModel cubismModel, List<string> cubismParts)
        {
            for (var i = 0; i < cubismParts.Count; i++)
            {
                cubismModel.Parts.FindById(cubismParts[i]).Opacity = 1;
            }
        }

        public void EnablePartOpacity(CubismModel cubismModel, string partId)
        {
            try
            {
                var parts = partId.Split(PartsSeparator);

                foreach (var item in parts)
                {
                    cubismModel.Parts.FindById(item.Trim()).Opacity = 1;
                }

            }
            catch
            {
                Debug.Log("cubism part not found: " + partId);
            }
        }

        public void DisablePartOpacity(CubismModel cubismModel, string partId)
        {
            try
            {
                var parts = partId.Split(PartsSeparator);

                foreach (var item in parts)
                {
                    cubismModel.Parts.FindById(item.Trim()).Opacity = 0;
                }
            }
            catch
            {
                Debug.Log("cubism part not found: " + partId);
            }
        }

        public void DisablePartsOpacity(CubismModel cubismModel, List<CubismPartsId> cubismPartsIds)
        {
            foreach (var item in cubismPartsIds)
            {
                DisablePartOpacity(cubismModel, item.PartsIds);
            }
        }
        public void SetupPartOpacity(CubismModel cubismModel, string partId, int opacity)
        {
            try
            {
                var parts = partId.Split(PartsSeparator);

                foreach (var item in parts)
                {
                    cubismModel.Parts.FindById(item.Trim()).Opacity = opacity;
                }
            }
            catch
            {
                Debug.Log("cubism part not found: " + partId);
            }
        }
    }
}
