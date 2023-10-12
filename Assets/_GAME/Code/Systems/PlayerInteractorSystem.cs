using System.Linq;
using _GAME.Code.Components;
using _GAME.Code.Types;
using Leopotam.Ecs;
using UnityEngine;

namespace _GAME.Code.Systems
{
    public class PlayerInteractorSystem : IEcsRunSystem
    {
        private EcsFilter<ItemsSpawnerComponent, PlayerComponent, PutItemsComponent, PlayerUiComponent> filter;

        private ItemsSpawnerComponent _itemsSpawnerComponent;
        private PlayerComponent _playerComponent;
        private PutItemsComponent _putItemsComponent;
        private PlayerUiComponent _playerUiComponent;
        
        public void Run()
        {
            ref var itemsSpawnerComponent = ref filter.Get1(0);
            ref var playerComponent = ref filter.Get2(0);
            ref var putItemsComponent = ref filter.Get3(0);
            ref var playerUiComponent = ref filter.Get4(0);

            _itemsSpawnerComponent = itemsSpawnerComponent;
            _playerComponent = playerComponent;
            _putItemsComponent = putItemsComponent;
            _playerUiComponent = playerUiComponent;
            
            
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

                                    TakeItems();
                                        
                                    break;
                                case InteractionType.PutItems:

                                    PutItems();
                                    
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

        private void TakeItems()
        {
            if (_itemsSpawnerComponent.SpawnedItems.Count == 0) return;
                                    
            GameObject item = _itemsSpawnerComponent.SpawnedItems.Last();

            item.transform.SetParent(_playerComponent.Transform);
                                    
            if (_playerComponent.TakenItemsList.Count == 0)
            {
                item.transform.position = _playerComponent.TakenItemSpawnPoint.transform.position;
            }
            else
            {
                item.transform.position = _playerComponent.TakenItemsList.Last().transform.position + Vector3.up * _itemsSpawnerComponent.SpawnYOffset;
            }
                                    
            _playerComponent.TakenItemsList.Add(item);
            _itemsSpawnerComponent.SpawnedItems.Remove(item);
                                    
            _playerUiComponent.ItemsAmountText.text = _playerComponent.TakenItemsList.Count.ToString();
        }

        private void PutItems()
        {
            if (_playerComponent.TakenItemsList.Count == 0) return;
                                    
            GameObject putItem = _playerComponent.TakenItemsList.Last();
            putItem.transform.SetParent(null);
                                    
            if (_putItemsComponent.ItemsList.Count == 0)
            {
                putItem.transform.position = _putItemsComponent.ItemsPutPoint.transform.position;
            }
            else
            {
                putItem.transform.position = _putItemsComponent.ItemsList.Last().transform.position + Vector3.up * _itemsSpawnerComponent.SpawnYOffset;
            }
                                    
            _putItemsComponent.ItemsList.Add(putItem);
            _playerComponent.TakenItemsList.Remove(putItem);
                                    
            _playerUiComponent.ItemsAmountText.text = _playerComponent.TakenItemsList.Count.ToString();
        }
    }
}