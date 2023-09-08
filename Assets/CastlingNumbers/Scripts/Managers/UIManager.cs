using UnityEngine;

namespace CastlingNumbers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        public UIMainMenu UIMainMenu;
        public UIOptions UIOptions;
        public UIRules UIRules;
        public UILevels UILevels;


 
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            CloseAll();
            DisplayMainMenu(true);
        }

        public void CloseAll()
        {
            DisplayMainMenu(false);
            DisplayOptionsMenu(false);
            DisplayRulesMenu(false);
            DisplayLevelMenu(false);
        }

        public void DisplayMainMenu(bool isActive)
        {
            UIMainMenu.DisplayCanvas(isActive);
        }


        public void DisplayOptionsMenu(bool isActive)
        {
            UIOptions.DisplayCanvas(isActive);
        }

        public void DisplayRulesMenu(bool isActive)
        {
            UIRules.DisplayCanvas(isActive);
        }

        public void DisplayLevelMenu(bool isActive)
        {
            UILevels.DisplayCanvas(isActive);
        }

    }
}
