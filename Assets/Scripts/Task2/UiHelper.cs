using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Task2
{
    public class UiHelper : MonoBehaviour
    {
        public string TextToShow;

        [SerializeField]
        protected GameObject HelpPanel;

        [SerializeField] protected Text TheText;

        private void Start()
        {
            TheText.text = TextToShow;
            if (!HelpPanel.activeInHierarchy)
                HelpPanel.SetActive(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
                HelpPanel.SetActive(false);
        }
    }
}
