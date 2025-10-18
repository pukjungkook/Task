using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject settingsPopup;

    private Animator settingsPopupAnimator;

    private void Awake()
    {
        
        if (settingsPopup != null)
            settingsPopupAnimator = settingsPopup.GetComponent<Animator>();
    }

    public void OnSettingsButtonClicked()
    {
        if (settingsPopup == null) return;

       
        settingsPopup.SetActive(true);

        
        if (settingsPopupAnimator != null)
            settingsPopupAnimator.SetTrigger("Show");
    }
}


