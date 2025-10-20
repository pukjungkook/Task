using UnityEngine;

public class LevelCompletedPopup : MonoBehaviour
{
    [Header("Popup Settings")]
    [Tooltip("Check this in the Inspector to force the popup to appear (for testing).")]
    public bool completeLevel = false;

    [Header("Popup UI Reference")]
    public GameObject popupUI;

    private bool popupShown = false;
    private Animator popupAnimator;

    void Awake()
    {
        if (popupUI != null)
        {
            popupAnimator = popupUI.GetComponent<Animator>();
            if (popupAnimator == null)
            {
                Debug.LogWarning("No Animator found on the Popup UI! Animation will not play.");
            }
        }
    }

    void Start()
    {
        if (popupUI != null)
            popupUI.SetActive(false);
    }

    void Update()
    {
        if (completeLevel && !popupShown)
        {
            PlayLevelCompleteAnimation();
            popupShown = true;
        }

        if (!completeLevel && popupShown)
        {
            HidePopup();
            popupShown = false;
        }
    }

    private void PlayLevelCompleteAnimation()
    {
        if (popupUI == null)
        {
            Debug.LogWarning("Popup UI not assigned in the Inspector!");
            return;
        }


        popupUI.SetActive(true);

        if (popupAnimator != null)
        {
            popupAnimator.Play("LevelCompleted", 0, 0f); 
        }
        else
        {
            Debug.LogWarning("No Animator found to play LevelCompleted animation!");
        }

        Debug.Log("Level Completed animation played!");
    }

    public void HidePopup()
    {
        if (popupUI != null)
            popupUI.SetActive(false);
    }
}
