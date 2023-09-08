using UnityEngine;
using UnityEngine.UI;

namespace CastlingNumbers
{
    public class UIRules : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _backBtn;

        private void Start()
        {
            _backBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplayMainMenu(true);
            });
        }

        private void OnDestroy()
        {
            _backBtn.onClick.RemoveAllListeners();
        }
    }
}
