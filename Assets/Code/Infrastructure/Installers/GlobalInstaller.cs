using System;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInput();
            BindSceneLoader();
        }

        private void BindSceneLoader()
        {
            Container.Bind<SceneLoader>().AsSingle();
        }

        private void BindInput()
        {
            Container.BindInterfacesAndSelfTo<StandaloneInput>().AsSingle();
        }

        
    }
}