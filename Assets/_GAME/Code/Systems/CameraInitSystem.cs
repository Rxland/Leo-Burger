using _GAME.Code.Components;
using Leopotam.Ecs;

namespace _GAME.Code.Systems
{
    public class CameraInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private SceneData _sceneData;
        
        private EcsFilter<PlayerComponent> filter;
        
        public void Init()
        {
            EcsEntity camerantity = _ecsWorld.NewEntity();
            
            ref var playerComponent = ref filter.Get1(0);
            ref var cameraComponent = ref camerantity.Get<CameraComponent>();

            cameraComponent.Camera = _sceneData.Camera;
            cameraComponent.VirtualCamera = _sceneData.VirtualCamera;

            cameraComponent.VirtualCamera.Follow = playerComponent.Transform;
        }
    }
}