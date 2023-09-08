using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CastlingNumbers
{
    public class UIGameover : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _menuBtn;
        [SerializeField] private Button _replayBtn;
        

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _recordText;

        // Cached
        private GameManager _gameManager;


        private void OnEnable()
        {
            GameplayManager.OnGameOver += LoadScore;
            GameplayManager.OnGameOver += LoadBest;
        }

        private void OnDisable()
        {
            GameplayManager.OnGameOver -= LoadScore;
            GameplayManager.OnGameOver -= LoadBest;
        }

        private void Start()
        {
            _gameManager = GameManager.Instance;
            LoadScore();
            LoadBest();

            _replayBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                Loader.Load(Loader.Scene.GameplayScene);
            });

            _menuBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                Loader.Load(Loader.Scene.MenuScene);
            });
        }

        private void OnDestroy()
        {
            _replayBtn.onClick.RemoveAllListeners();
            _menuBtn.onClick.RemoveAllListeners();
        }

        private void LoadScore()
        {
            _scoreText.text = $"{_gameManager.Score}";
        }

        private void LoadBest()
        {
            _gameManager.SetBestScore(_gameManager.Score);
            _recordText.text = $"RECORD {_gameManager.BestScore}";
        }
    }
}
