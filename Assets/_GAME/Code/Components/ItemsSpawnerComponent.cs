using System;
using System.Collections.Generic;
using UnityEngine;

namespace _GAME.Code.Components
{
    [Serializable]
    public struct ItemsSpawnerComponent
    {
        public Collider InteractionZone;
        public bool CanInteract;
        [Space]
        
        public GameObject ItemToSpawnPrefab;
        public Transform SpawnPoint;
        [Space] 
        
        public int MaxSpawendItems;
        public float SpawnDelay;
        public float SpawnDelayFireTime;
        [Space]
        
        public float SpawnYOffset;
        public List<GameObject> SpawnedItems;
    }
}