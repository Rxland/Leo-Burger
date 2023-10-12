using System;
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
    private EcsSystems _fixedUpdateSystems;

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _updateSystems = new EcsSystems(_ecsWorld);
        _fixedUpdateSystems = new EcsSystems(_ecsWorld);
        RuntimeData runtimeData = new RuntimeData();


        _updateSystems
            .ConvertScene()
            .Add(new PlayerInitSystem())
            .Add(new CameraInitSystem())
            .Add(new PlayerInputSystem())
            .Add(new ItemsSpawnSystem())
            .Inject(_mainStaticData)
            .Inject(SceneData)
            .Inject(runtimeData);
        
        _fixedUpdateSystems
            .Add(new PlayerMovementSystem())
            .Add(new PlayerRotationSystem());
        
        _updateSystems.Init();
        _fixedUpdateSystems.Init();
    }
    
    private void Update()
    {
        _updateSystems?.Run();
    }

    private void FixedUpdate()
    {
        _fixedUpdateSystems?.Run();   
    }

    private void OnDestroy()
    {
        _updateSystems?.Destroy();
        _updateSystems = null;
        
        _fixedUpdateSystems?.Destroy();
        _fixedUpdateSystems = null;
        
        _ecsWorld?.Destroy();
        _ecsWorld = null;
    }
}
