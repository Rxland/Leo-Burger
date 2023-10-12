using System.Linq;
using _GAME.Code.Components;
using _GAME.Code.Types;
using Leopotam.Ecs;
using UnityEngine;

namespace _GAME.Code.Systems
{
    public class PlayerInteractorSystem : IEcsRunSystem
    {
        private EcsFilter<ItemsSpawnerComponent, PlayerComponent, PutItemsComponent> filter;
        
        public void Run()
        {
            ref var itemsSpawnerComponent = ref filter.Get1(0);
            ref var playerComponent = ref filter.Get2(0);
            ref var putItemsComponent = ref filter.Get3(0);
                
            Collider[] colliders = Physics.OverlapSphere(playerComponent.Transform.position, playerComponent.InteractionRange);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Interaction interaction))
                {
                        if (playerComponent.FireTimeInteracitonDelay >= playerComponent.InteracitonDelay)
                        {
                            switch (interaction.InteractionType)
                            {
                                case InteractionType.TakeItems:
                                    if (itemsSpawnerComponent.SpawnedItems.Count == 0) continue;
                                    
                                    GameObject item = itemsSpawnerComponent.SpawnedItems.Last();

                                    item.transform.SetParent(playerComponent.Transform);
                                    
                                    if (playerComponent.TakenItemsList.Count == 0)
                                    {
                                        item.transform.position = playerComponent.TakenItemSpawnPoint.transform.position;
                                    }
                                    else
                                    {
                                        item.transform.position = playerComponent.TakenItemsList.Last().transform.position + Vector3.up * itemsSpawnerComponent.SpawnYOffset;
                                    }
                                    
                                    playerComponent.TakenItemsList.Add(item);
                                    itemsSpawnerComponent.SpawnedItems.Remove(item);
                                        
                                    break;
                                case InteractionType.PutItems:
                                    if (playerComponent.TakenItemsList.Count == 0) continue;
                                    
                                    GameObject putItem = playerComponent.TakenItemsList.Last();
                                    putItem.transform.SetParent(null);
                                    
                                    if (putItemsComponent.ItemsList.Count == 0)
                                    {
                                        putItem.transform.position = putItemsComponent.ItemsPutPoint.transform.position;
                                    }
                                    else
                                    {
                                        putItem.transform.position = putItemsComponent.ItemsList.Last().transform.position + Vector3.up * itemsSpawnerComponent.SpawnYOffset;
                                    }
                                    
                                    putItemsComponent.ItemsList.Add(putItem);
                                    playerComponent.TakenItemsList.Remove(putItem);
                                    
                                    break;
                            }
                            playerComponent.FireTimeInteracitonDelay = 0f;
                        }
                        else
                        {
                            playerComponent.FireTimeInteracitonDelay += Time.deltaTime;
                        }
                }
            }
        }
    }
}