using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class MoneyHandler : MonoBehaviour
    {
        public static int MoneyCount { get; private set; }
        private static TextMeshProUGUI _text;
        private static GameObject _gameOverScreenContainer;

        private void Awake()
        {
            MoneyCount = 0;
            _text = GetComponent<TextMeshProUGUI>();
            _gameOverScreenContainer = GameObject.Find("GameOverScreenContainer");
        }

        public static void AddMoney()
        {
            MoneyCount++;
            _text.SetText($"Money: {MoneyCount}");
            if (MoneyCount >= Spawner.MoneyCount)
            {
                _gameOverScreenContainer.GetComponent<GameOver>().Victory();
            }
        }
    }
}
