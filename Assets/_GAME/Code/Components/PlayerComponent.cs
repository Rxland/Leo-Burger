using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _GAME.Code.Components
{
    [Serializable]
    public struct PlayerComponent
    {
        public Transform Transform;
        public CharacterController CharacterController;
        public PlayerInput PlayerInput;
        [Space]
        
        public float MoveSpeed;
        public float RotationSpeed;
        [Space]
        
        public Transform TakenItemSpawnPoint;
        public List<GameObject> TakenItemsList;
        [Space]
        
        public float InteractionRange;
        public float InteracitonDelay;
        public float FireTimeInteracitonDelay;
    }
}