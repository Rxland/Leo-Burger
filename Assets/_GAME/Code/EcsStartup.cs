using _GAME.Code;
using _GAME.Code.StaticData;
using _GAME.Code.Systems;
using Leopotam.Ecs;
using UnityEngine;

public class EcsStartup : MonoBehaviour
{
    [SerializeField] private MainStaticData _mainStaticData;
    public SceneData SceneData;
    private EcsWorld _ecsWorld;
    
    private EcsSystems _initSystems;
    private EcsSystems _updateSystems;

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _initSystems = new EcsSystems(_ecsWorld);
        _updateSystems = new EcsSystems(_ecsWorld);
        RuntimeData runtimeData = new RuntimeData();

        _initSystems
            .Add(new CameraInitSystem())
            .Inject(SceneData)
            .Init();

        _updateSystems
            .Add(new PlayerInitSystem())
            .Add(new PlayerInputSystem())
            .Add(new PlayerMovementSystem())
            .Inject(_mainStaticData)
            .Inject(SceneData)
            .Inject(runtimeData);
        
        _updateSystems.Init();
    }


    private void Update()
    {
        _updateSystems?.Run();
    }

    private void OnDestroy()
    {
        _initSystems?.Destroy();
        _initSystems = null;
        _updateSystems?.Destroy();
        _updateSystems = null;
        _ecsWorld?.Destroy();
        _ecsWorld = null;
    }
}
