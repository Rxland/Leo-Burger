using _GAME.Code;
using _GAME.Code.StaticData;
using _GAME.Code.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EcsStartup : MonoBehaviour
{
    [SerializeField] private MainStaticData _mainStaticData;
    public SceneData SceneData;
    private EcsWorld _ecsWorld;
    
    private EcsSystems _updateSystems;

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _updateSystems = new EcsSystems(_ecsWorld);
        RuntimeData runtimeData = new RuntimeData();
        

        _updateSystems
            .Add(new PlayerInitSystem())
            .ConvertScene()
            .Add(new PlayerInputSystem())
            .Add(new ItemsSpawnSystem())
            .Add(new PlayerMovementSystem())
            .Add(new PlayerRotationSystem())
            .Add(new PlayerInteractorSystem())
            
            .Inject(_mainStaticData)
            .Inject(SceneData)
            .Inject(runtimeData)
            .Init();
    }
    
    private void Update()
    {
        _updateSystems?.Run();
    }
    
    private void OnDestroy()
    {
        _updateSystems?.Destroy();
        _updateSystems = null;

        _ecsWorld?.Destroy();
        _ecsWorld = null;
    }
}
