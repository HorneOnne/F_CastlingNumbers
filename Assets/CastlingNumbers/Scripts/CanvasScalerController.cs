using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CastlingNumbers
{
    public class CanvasScalerController : MonoBehaviour
    {
        private CanvasScaler _canvasScaler;
        private int _baseWidth = 800;
        private void Awake()
        {
            if (_canvasScaler == null)
            {
                _canvasScaler = GetComponent<CanvasScaler>();
            }
            int screenWidth = Screen.width;
            int screenHeight = Screen.height;

            float scaler = (1.0f * screenWidth / _baseWidth);
            _canvasScaler.referenceResolution = new Vector2(screenWidth / scaler, screenHeight / scaler);
        }

    }

}

