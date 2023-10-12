using UnityEngine;
using UnityEngine.InputSystem;

namespace _GAME.Code.Components
{
    public struct PlayerComponent
    {
        public Transform Transform;
        public CharacterController CharacterController;
        public PlayerInput PlayerInput;
        
        public float MoveSpeed;
        public float RotationSpeed;
    }
}