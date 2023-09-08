using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CastlingNumbers
{
    public class UIGameplay : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _levelBtn;
        [SerializeField] private Button _replayBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _moveText;

        private void OnEnable()
        {
            Ball.OnBallMoveFinished += UpdateMoveText;
        }

        private void OnDisable()
        {
            Ball.OnBallMoveFinished -= UpdateMoveText;
        }


        private void Start()
        {
            _levelText.text = $"LEVEL {GameManager.Instance.PlayingLevelData.Level}";
            UpdateMoveText();

            _levelBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);
                UIGameplayManager.Instance.DisplayLevelMenu(true);
            });

            _replayBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                Loader.Load(Loader.Scene.GameplayScene);
            });
        }

        private void OnDestroy()
        {
            _levelBtn.onClick.RemoveAllListeners();
            _replayBtn.onClick.RemoveAllListeners();
        }

        private void UpdateMoveText()
        {
            _moveText.text = $"MOVE {GameLogicHandler.Instance.CurrentMove}/{GameLogicHandler.Instance.MaxMove}";
        }
    }
}
