using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace CastlingNumbers
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Node _currentNode;
        public int Number { get;private set; }

        public void SetNumber(int number)
        {
            this.Number = number;
        }

        public void SetNode(Node node)
        {
            this._currentNode = node;    
        }


        private IEnumerator MoveThroughWaypoints(List<Vector2> waypoints, System.Action OnFinished = null)
        {
            int currentWaypointIndex = 0;
            float rotationSpeed = 5.0f;
            float moveSpeed = 10.0f;

            while (currentWaypointIndex < waypoints.Count)
            {
                Vector2 targetPosition = waypoints[currentWaypointIndex];

                while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
                {
                    Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
                    transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
                    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);

                    yield return null;
                }
                currentWaypointIndex++;
                yield return new WaitForSeconds(0.2f);              
            }
            OnFinished?.Invoke();
        }

        private void OnMouseDown()
        {
            List<Vector2> waypoints = GameLogicHandler.Instance.GetPath(_currentNode, out Node targetNode);
            //Debug.Log($"Move {waypoints.Count}");
            if(targetNode != null)
            {
                _currentNode.SetBall(null);

                SetNode(targetNode);
                targetNode.SetBall(this);

                StartCoroutine(MoveThroughWaypoints(waypoints, () =>
                {
                    Debug.Log("Finish move");
                }));

            }



        }
    }

}

