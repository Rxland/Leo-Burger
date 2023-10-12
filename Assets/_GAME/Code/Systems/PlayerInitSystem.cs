using _GAME.Code.Components;
using _GAME.Code.StaticData;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _GAME.Code.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private MainStaticData _mainStaticData;
        private SceneData _sceneData;

        public void Init()
        {
            EcsEntity playerEntity = _ecsWorld.NewEntity();

            ref var player = ref playerEntity.Get<PlayerComponent>();
        
            GameObject playerGO = Object.Instantiate(_mainStaticData.PlayerPrefab, _sceneData.PlayerSpawnPoint.position, Quaternion.identity);
            player.CharacterController = playerGO.GetComponent<CharacterController>();
            player.PlayerInput = playerGO.GetComponent<PlayerInput>();
            player.Transform = playerGO.transform;
            player.MoveSpeed = _mainStaticData.MoveSpeed;
            player.RotationSpeed = _mainStaticData.RotationSpeed;
        }
    }
}