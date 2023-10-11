using _GAME.Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace _GAME.Code.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputDataComponent, PlayerComponent> filter;
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var inputData = ref filter.Get1(i);
                ref var playerData = ref filter.Get2(i);
                
                inputData.MoveDirection = playerData.PlayerInput.actions["Movement"].ReadValue<Vector2>();
            }
        }
    }
}