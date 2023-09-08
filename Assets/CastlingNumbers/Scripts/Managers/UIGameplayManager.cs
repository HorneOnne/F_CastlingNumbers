using UnityEngine;

namespace CastlingNumbers
{
    public class UIGameplayManager : MonoBehaviour
    {
        public static UIGameplayManager Instance { get; private set; }

        public UIGameplay UIGameplay;
        public UIWin UIWin;
        public UIGameover UIGameover;
        public UILevels UILevels;


        private void Awake()
        {
            Instance = this;
        }


        private void Start()
        {
            CloseAll();
            DisplayGameplayMenu(true);
        }

        public void CloseAll()
        {
            DisplayGameplayMenu(false);
            DisplayWinMenu(false);
            DisplayGameoverMenu(false);
            DisplayLevelMenu(false);
        }


        public void DisplayGameplayMenu(bool isActive)
        {
            UIGameplay.DisplayCanvas(isActive);
        }

        public void DisplayWinMenu(bool isActive)
        {
            UIWin.DisplayCanvas(isActive);
        }


        public void DisplayGameoverMenu(bool isActive)
        {
            UIGameover.DisplayCanvas(isActive);
        }


        public void DisplayLevelMenu(bool isActive)
        {
            UILevels.DisplayCanvas(isActive);
        }
    }
}
