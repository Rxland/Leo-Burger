using _GAME.Code.Components;
using _GAME.Code.Types;
using Leopotam.Ecs;
using UnityEngine;

namespace _GAME.Code.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputDataComponent, PlayerComponent, CameraComponent> filter;

        public void Run()
        {
            ref var inputData = ref filter.Get1(0);
            ref var playerData = ref filter.Get2(0);
            ref var cameraData = ref filter.Get3(0);

            if (inputData.MoveDirection == Vector2.zero)
            {
                playerData.Animator.SetBool(AnimationsNames.Run.ToString(), false);
                return;
            }
            
            Vector3 moveDirection = cameraData.Camera.transform.right * inputData.MoveDirection.x + cameraData.Camera.transform.forward * inputData.MoveDirection.y;
            moveDirection.y = 0f;
            
            playerData.CharacterController.Move(moveDirection * playerData.MoveSpeed * Time.deltaTime);
            playerData.Animator.SetBool(AnimationsNames.Run.ToString(), true);
        }
    }
}