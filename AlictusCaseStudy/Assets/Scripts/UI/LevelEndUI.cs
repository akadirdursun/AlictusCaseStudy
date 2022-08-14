using UnityEngine;
using UnityEngine.SceneManagement;

namespace Abdulkadir
{
    public class LevelEndUI : MonoBehaviour
    {
        [SerializeField] private GameObject levelEndUI;

        #region MonoBehaviour METHODS
        private void OnEnable()
        {
            StaticEvents.onLevelCompleted += OnLevelCompleted;
        }

        private void OnDisable()
        {
            StaticEvents.onLevelCompleted -= OnLevelCompleted;
        }
        #endregion

        #region EVENT LISTENERS
        public void OnContinueButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnLevelCompleted()
        {
            levelEndUI.SetActive(true);
        }
        #endregion
    }
}