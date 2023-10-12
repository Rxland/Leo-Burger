using System.Linq;
using _GAME.Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace _GAME.Code.Systems
{
    public class ItemsSpawnSystem : IEcsRunSystem
    {
        private EcsFilter<ItemsSpawnerComponent> filter;
        
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var spawnData = ref filter.Get1(i);
                
                if (spawnData.SpawnDelayFireTime < spawnData.SpawnDelay)
                {
                    spawnData.SpawnDelayFireTime += Time.deltaTime;
                }
                else
                {
                    if (spawnData.SpawnedItems.Count >= spawnData.MaxSpawendItems)
                        return;
                    
                    GameObject item = GameObject.Instantiate(spawnData.ItemToSpawnPrefab, spawnData.SpawnPoint);

                    if (spawnData.SpawnedItems.Count == 0)
                    {
                        item.transform.position = spawnData.SpawnPoint.position;
                    }
                    else
                    {
                        item.transform.position = spawnData.SpawnedItems.Last().transform.position + Vector3.up * spawnData.SpawnYOffset;
                    }
                    
                    spawnData.SpawnedItems.Add(item);
                    
                    spawnData.SpawnDelayFireTime = 0f;
                }
            }
        }
    }
}