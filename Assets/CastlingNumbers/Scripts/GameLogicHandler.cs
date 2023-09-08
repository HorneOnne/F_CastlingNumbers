using System.Collections.Generic;
using UnityEngine;

namespace CastlingNumbers
{
    public class GameLogicHandler : MonoBehaviour
    {
        public static GameLogicHandler Instance { get; private set; }

        //public List<Node> Nodes;
        //public List<Path> Paths;
        [SerializeField] private Map _map;

        [Header("Prefabs")]
        [SerializeField] private Ball _ballPrefab;

        private List<Ball> balls = new List<Ball>();
        public bool CanMoveBall { get; set; } = true;

        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            Ball.OnBallMoveFinished += BallMoveFinishedHandler;
        }

        private void OnDisable()
        {
            Ball.OnBallMoveFinished -= BallMoveFinishedHandler;
        }


        private void Start()
        {
            for (int i = 0; i < _map.Nodes.Count; i++)
            {
                _map.Nodes[i].SetNumber(i + 1);
            }

            foreach (var defaultBall in _map.DefaultBalls)
            {
                Ball ball = SpawnBall(defaultBall.Node, defaultBall.BallNumber);
                balls.Add(ball);
            }
        }

        private Ball SpawnBall(Node node, int number)
        {
            Ball ball = Instantiate(_ballPrefab, node.transform.position, Quaternion.identity);
            node.SetBall(ball);
            ball.SetNode(node);
            ball.SetNumber(number);

            return ball;
        }


        private void BallMoveFinishedHandler()
        {
            bool isWin = IsWinning();
            Debug.Log(isWin);
        }

        public bool IsWinning()
        {
            CanMoveBall = true;
            bool canWin = true;
            foreach (var ball in balls)
            {
                if (ball.Node.NumberNeedFill != ball.Number)
                {
                    canWin = false;
                    return canWin;
                }
            }
            return canWin;
        }

        public List<Vector2> GetPath(Node fromNode, out Node targetNode)
        {
            List<Vector2> waypoints = new List<Vector2>();

            foreach (var path in _map.Paths)
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

            foreach (var path in _map.Paths)
            {
                if (path.ToNode == fromNode && path.FromNode.IsEmtpy())
                {
                    for (int i = path.Waypoints.Count - 1; i >= 0; i--)
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

            foreach (var path in _map.Paths)
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

