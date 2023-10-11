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

        public void Init()
        {
            EcsEntity playerEntity = _ecsWorld.NewEntity();

            ref var player = ref playerEntity.Get<PlayerComponent>();
            ref var inputData = ref playerEntity.Get<PlayerInputDataComponent>();
        
            GameObject playerGO = Object.Instantiate(_mainStaticData.PlayerPrefab, _sceneData.PlayerSpawnPoint.position, Quaternion.identity);
            player.CharacterController = playerGO.GetComponent<CharacterController>();
        }
    }
}