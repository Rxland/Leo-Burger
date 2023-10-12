using System;
using System.Collections.Generic;
using UnityEngine;

namespace _GAME.Code.Components
{
    [Serializable]
    public struct PutItemsComponent
    {
        public Interaction Interaction;
        [Space]

        public Transform ItemsPutPoint;
        public List<GameObject> ItemsList;
    }
}