using _GAME.Code.Components;
using Leopotam.Ecs;

namespace _GAME.Code.Systems
{
    public class CameraInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private SceneData _sceneData;
        
        public void Init()
        {
            EcsEntity camerantity = _ecsWorld.NewEntity();
            
            ref var cameraComponent = ref camerantity.Get<CameraComponent>();

            cameraComponent.Camera = _sceneData.Camera;
        }
    }
}