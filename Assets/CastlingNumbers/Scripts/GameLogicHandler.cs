using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace CastlingNumbers
{
    public class GameLogicHandler : MonoBehaviour
    {
        public static GameLogicHandler Instance { get; private set; }

        public List<Node> Nodes;
        public List<Path> Paths;


        [Header("Prefabs")]
        [SerializeField] private Ball _ballPrefab;


        private void Awake()
        {
            Instance = this;
        }


        private void Start()
        {
            SpawnBall(Nodes[0]);
            SpawnBall(Nodes[2]);
        }

        private Ball SpawnBall(Node node)
        {
            Ball ball = Instantiate(_ballPrefab, node.transform.position, Quaternion.identity);
            node.SetBall(ball);
            ball.SetNode(node);

            return ball;
        }


        public List<Vector2> GetPath(Node fromNode, out Node targetNode)
        {
            List<Vector2> waypoints = new List<Vector2>();

            foreach (var path in Paths)
            {
                if (path.FromNode == fromNode && path.ToNode.IsEmtpy())
                {
                    foreach (var movepath in path.Waypoints)
                    {
                        waypoints.Add(movepath.position);                         
                    }
                    targetNode = path.ToNode;
                    return waypoints;
                }
            }

            foreach (var path in Paths)
            {
                if (path.ToNode == fromNode && path.FromNode.IsEmtpy())
                {
                    for(int i = path.Waypoints.Count - 1; i >= 0; i--)
                    {
                        waypoints.Add(path.Waypoints[i].position);
                    }
                    targetNode = path.FromNode;
                    return waypoints;
                }
            }


            targetNode = null;
            return waypoints;
        }

        public List<Vector2> GetPath(Node fromNode, Node toNode)
        {
            List<Vector2> waypoints = new List<Vector2>();

            foreach (var path in Paths)
            {
                if (path.FromNode == fromNode && path.ToNode == toNode)
                {
                    if (path.ToNode.IsEmtpy())
                    {
                        foreach (var movepath in path.Waypoints)
                        {
                            waypoints.Add(movepath.position);
                        }

                        return waypoints;
                    }

                }
            }
            return waypoints;
        }
    }

    [System.Serializable]
    public class Path
    {
        public Node FromNode;
        public Node ToNode;

        public List<Transform> Waypoints;
    }

    [System.Serializable]
    public class Waypoints
    {
        //List<Transform>
    }

}

