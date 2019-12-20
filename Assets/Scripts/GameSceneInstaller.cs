namespace Intermarum.Bootstrap.Installers
{
    using System;
    using Zenject;
    using UnityEngine;


    using Intermarum.Tools.ChibiGenerator;

    using Articy.Unity;

    /// <summary>
    /// Installer to set up Game Scene with settings.
    /// </summary>
    public class GameSceneInstaller : MonoInstaller
    {
        

        public override void InstallBindings()
        {

            UnityEngine.Debug.Log("InstallBindings - GameSceneInstaller");
            Container.Bind<ICubismPartsController>().To<CubismPartsController>().AsSingle();               
        }

        [Serializable]
        public class GameSceneSettings
        {

        }
    }
}
