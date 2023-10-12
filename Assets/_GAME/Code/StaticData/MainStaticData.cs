using UnityEngine;

namespace _GAME.Code.StaticData
{
    [CreateAssetMenu(fileName = "Main Static Data", menuName = "Static Data/Main Static Data")]
    public class MainStaticData : ScriptableObject
    {
        public GameObject PlayerPrefab;
        
        public float MoveSpeed;
        public float RotationSpeed;
    }
}