using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CastlingNumbers
{
    public class UIWin: CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _nextBtn;


        private void Start()
        {
            _nextBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                Loader.Load(Loader.Scene.GameplayScene);
            });

        }

        private void OnDestroy()
        {
            _nextBtn.onClick.RemoveAllListeners();
        }
    }
}
