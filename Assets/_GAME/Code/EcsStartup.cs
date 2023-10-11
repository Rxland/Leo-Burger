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
    private EcsSystems _systems;

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _systems = new EcsSystems(_ecsWorld);
        RuntimeData runtimeData = new RuntimeData();

        _systems
            .Add(new PlayerInitSystem())
            .Inject(_mainStaticData)
            .Inject(SceneData)
            .Inject(runtimeData)
            .Init();
        
        _systems.Add(new )
    }


    private void Update()
    {
        _systems?.Run();
    }

    private void OnDestroy()
    {
        _systems?.Destroy();
        _systems = null;
        _ecsWorld?.Destroy();
        _ecsWorld = null;
    }
}
