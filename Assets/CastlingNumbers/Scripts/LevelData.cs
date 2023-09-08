using UnityEngine;

namespace CastlingNumbers
{
    [CreateAssetMenu()]
    public class LevelData : ScriptableObject
    {
        [Header("Level")]
        public int Level;
        public bool IsLocking;

        [Header("Camera zoom")]
        public float OrthographicCameraSize = 5;
        public Vector2 CameraOffset;

        [Header("Others")]
        public Map MapPrefab;
    }

}

