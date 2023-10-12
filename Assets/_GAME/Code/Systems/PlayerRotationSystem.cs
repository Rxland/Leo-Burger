using _GAME.Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace _GAME.Code.Systems
{
    public class PlayerRotationSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputDataComponent, PlayerComponent, CameraComponent> filter;
        
        public void Run()
        {
            ref var inputData = ref filter.Get1(0);
            ref var playerData = ref filter.Get2(0);
            ref var cameraData = ref filter.Get3(0);

            
            Vector3 inputDir = new Vector2(inputData.MoveDirection.x, inputData.MoveDirection.y);
            Vector3 moveDir = Vector2.zero;
            
            if (inputDir == Vector3.zero) return;
            
            moveDir = Vector3.zero;
            
            moveDir += cameraData.Camera.transform.right * inputDir.x;
            moveDir += cameraData.Camera.transform.forward * inputDir.y;
            
            Quaternion newRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            newRotation = Quaternion.Euler(0f, newRotation.eulerAngles.y, newRotation.eulerAngles.z);

            Quaternion fromRotation = playerData.Transform.transform.rotation;
            
            playerData.Transform.transform.rotation = Quaternion.Lerp(fromRotation, newRotation, playerData.RotationSpeed * Time.deltaTime);
        }
    }
}