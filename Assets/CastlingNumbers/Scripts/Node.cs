using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CastlingNumbers
{
    public class Node : MonoBehaviour
    {     
        [SerializeField] private Ball _ball;
        [SerializeField] private TextMeshPro _numberText;

        public int NumberNeedFill { get; private set; }


        #region Properties
        public Ball Ball { get { return _ball; } }
        #endregion

        public void SetBall(Ball ball)
        {
            this._ball = ball;
        }

        public void SetNumber(int number)
        {
            this.NumberNeedFill = number;
            _numberText.text = $"{number}";
        }

        public bool IsEmtpy()
        {
            return _ball == null;
        }

        
    }

}

