using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CastlingNumbers
{
    public class UIMainMenu : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _startBtn;
        [SerializeField] private Button _optionsBtn;
        [SerializeField] private Button _rulesBtn;


        private void Start()
        {
            _startBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                Loader.Load(Loader.Scene.GameplayScene);            
            });

            _optionsBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplayOptionsMenu(true);             
            });

            _rulesBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplayRulesMenu(true);
            });
        }

        private void OnDestroy()
        {
            _startBtn.onClick.RemoveAllListeners();
            _optionsBtn.onClick.RemoveAllListeners();
            _rulesBtn.onClick.RemoveAllListeners();
        }

    }
}
