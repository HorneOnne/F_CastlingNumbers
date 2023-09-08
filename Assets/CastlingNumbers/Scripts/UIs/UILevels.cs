using UnityEngine;
using UnityEngine.UI;

namespace CastlingNumbers
{

    public class UILevels : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _backBtn;

        [Header("Others")]
        [SerializeField] private LevelBtn _levelBtnPrefab;
        [SerializeField] private Transform _levelBtnsRoot;


        private void Start()
        {
            LoadLevels();

            _backBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                UIGameplayManager.Instance.DisplayLevelMenu(false);
            });
        }

        private void OnDestroy()
        {
            _backBtn.onClick.RemoveAllListeners();
        }

        private void LoadLevels()
        {
            for (int i = 0; i < GameManager.Instance.LevelsData.Count; i++)
            {
                LevelBtn levelBtn = Instantiate(_levelBtnPrefab, _levelBtnsRoot);
                levelBtn.LevelData = GameManager.Instance.LevelsData[i];
                levelBtn.LoadLevelDataState();
            }
        }
    }
}
