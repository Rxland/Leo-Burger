using _GAME.Code.Components;
using _GAME.Code.StaticData;
using Leopotam.Ecs;
using UnityEngine;

namespace _GAME.Code.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private MainStaticData _mainStaticData;
        private SceneData _sceneData;

        private EcsFilter<PlayerComponent> filter;
        
        public void Init()
        {
            GameObject playerGo = GameObject.Instantiate(_mainStaticData.PlayerPrefab, _sceneData.PlayerSpawnPoint.position, Quaternion.identity);
            
            EcsEntity camerantity = _ecsWorld.NewEntity();
            
            ref var cameraComponent = ref camerantity.Get<CameraComponent>();
            
            cameraComponent.Camera = _sceneData.Camera;
            cameraComponent.VirtualCamera = _sceneData.VirtualCamera;
            
            cameraComponent.VirtualCamera.Follow = playerGo.transform;
        }
    }
}