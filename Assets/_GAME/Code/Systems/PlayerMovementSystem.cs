using _GAME.Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace _GAME.Code.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputDataComponent, PlayerComponent> filter;

        public void Run()
        {
            ref var inputData = ref filter.Get1(0);
            ref var playerData = ref filter.Get2(0);
            
            
        }
    }
}