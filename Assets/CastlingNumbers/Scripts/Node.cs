using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CastlingNumbers
{
    public class Node : MonoBehaviour
    {     
        [SerializeField] private Ball _ball;
        public int NumberNeedFill { get; private set; }

        public void SetBall(Ball ball)
        {
            this._ball = ball;
        }

        public void SetNumber(int number)
        {
            this.NumberNeedFill = number;
        }

        public bool IsEmtpy()
        {
            return _ball == null;
        }

        
    }

}

