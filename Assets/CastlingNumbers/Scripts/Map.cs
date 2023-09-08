using System.Collections.Generic;
using UnityEngine;

namespace CastlingNumbers
{
    public class Map : MonoBehaviour
    {
        public int MaxMove;
        public List<Node> Nodes;
        public List<Path> Paths;
        public List<SpawnBallNode> DefaultBalls;



        [System.Serializable]
        public class SpawnBallNode
        {
            public Node Node;
            public int BallNumber;
        }
    }

}

