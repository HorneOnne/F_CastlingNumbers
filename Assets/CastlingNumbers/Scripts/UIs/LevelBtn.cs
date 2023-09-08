using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CastlingNumbers
{
    public class LevelBtn : MonoBehaviour
    {
        [SerializeField] private Button _levelBtn;
        [SerializeField] private Image _lockImage;
        [SerializeField] private TextMeshProUGUI _levelText;

        [Header("Data")]
        public LevelData LevelData;

        private void Start()
        {
            _levelBtn.onClick.AddListener(() =>
            {
                if (LevelData.IsLocking == false)
                {
                    GameManager.Instance.PlayingLevelData = LevelData;
                    Loader.Load(Loader.Scene.GameplayScene);

                    SoundManager.Instance.PlaySound(SoundType.Button, false);
                }
            });
        }


        private void OnDestroy()
        {
            _levelBtn.onClick.RemoveAllListeners();
        }



        public void LoadLevelDataState()
        {
            if (LevelData == null) return;
            if (LevelData.IsLocking)
            {
                _levelText.text = "";
                _lockImage.enabled = true;
            }
            else
            {
                _levelText.text = LevelData.Level.ToString();
                _lockImage.enabled = false;
            }
        }
    }
}
