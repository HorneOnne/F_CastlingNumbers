using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

namespace CastlingNumbers
{
    public class Ball : MonoBehaviour
    {
        public static event System.Action OnBallMoveFinished;

        [SerializeField] private Node _currentNode;
        [SerializeField] private TextMeshPro _numberText;
        public int Number { get;private set; }
        public Node Node { get { return _currentNode; } }

        public void SetNumber(int number)
        {
            this.Number = number;
            _numberText.text = $"{number}";
        }

        public void SetNode(Node node)
        {
            this._currentNode = node;    
        }


        private IEnumerator MoveThroughWaypoints(List<Vector2> waypoints, System.Action OnFinished = null)
        {
            int currentWaypointIndex = 0;
            float moveSpeed = 10.0f;

            while (currentWaypointIndex < waypoints.Count)
            {
                Vector2 targetPosition = waypoints[currentWaypointIndex];

                while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
                {
                    Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
                    transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
                    yield return null;
                }
                currentWaypointIndex++;
                yield return null;              
            }

            transform.position = waypoints[currentWaypointIndex - 1];
            OnFinished?.Invoke();
        }

        private void OnMouseDown()
        {
            if (GameplayManager.Instance.CurrentState != GameplayManager.GameState.PLAYING) return;
            if (GameLogicHandler.Instance.CanMoveBall == false) return; 

            List<Vector2> waypoints = GameLogicHandler.Instance.GetPath(_currentNode, out Node targetNode);
            if(targetNode != null)
            {
                SoundManager.Instance.PlaySound(SoundType.Hit, false);

                GameLogicHandler.Instance.CanMoveBall = false;
                _currentNode.SetBall(null);

                SetNode(targetNode);
                targetNode.SetBall(this);

                StartCoroutine(MoveThroughWaypoints(waypoints, () =>
                {
                    GameLogicHandler.Instance.CurrentMove++;
                    OnBallMoveFinished?.Invoke();
                }));
            }
            else
            {
                SoundManager.Instance.PlaySound(SoundType.HitEnemy, false);
            }


        }
    }

}

