using Zenject;

namespace Assets.Source.Code
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameOverManager();
        }

        private void BindGameOverManager()
        {
            Container.BindInterfacesAndSelfTo<GameOverManager>()
                .AsSingle()
                .NonLazy();
        }
    }
}