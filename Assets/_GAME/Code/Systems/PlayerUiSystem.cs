using _GAME.Code.Components;
using Leopotam.Ecs;

namespace _GAME.Code.Systems
{
    public class PlayerUiSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerUiComponent, CameraComponent> filter;

        public void Run()
        {
            ref var playerUiComponent = ref filter.Get1(0);
            ref var cameraComponent = ref filter.Get2(0);
            
            playerUiComponent.Transform.forward = cameraComponent.Camera.transform.forward;
        }
    }
}