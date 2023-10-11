using _GAME.Code.Components;
using Leopotam.Ecs;

namespace _GAME.Code.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputDataComponent> filter;
        
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var inputData = ref filter.Get1(i);
                
                inputData.MoveDirection
            }
        }
    }
}