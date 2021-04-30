using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace DefaultNamespace
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] int startingBalance = 150;
        [SerializeField] int currentBalance;
        [SerializeField] TextMeshProUGUI displayBalance;
        public int CurrentBalance { get { return currentBalance; } }

        void Awake()
        {
            currentBalance = startingBalance;
            UpdateDisplay();
        }

        public void Deposit(int amount)
        {
            currentBalance += Mathf.Abs(amount);
            UpdateDisplay();
        }

        public void Withdraw(int amount)
        {
            currentBalance -= Mathf.Abs(amount);
            UpdateDisplay();
            if(currentBalance < 0)
            {
                //Lose the game;
                ReloadScene();
            }
        }

        void ReloadScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
        
        void UpdateDisplay()
        {
            displayBalance.text = "Gold: " + currentBalance;
        }



    }
}