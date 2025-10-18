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
        // Try to get Animator automatically from the popupUI
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
            ShowPopup();
            popupShown = true;
        }

        if (!completeLevel && popupShown)
        {
            HidePopup();
            popupShown = false;
        }
    }

    public void ShowPopup()
    {
        if (popupUI == null)
        {
            Debug.LogWarning("Popup UI not assigned in the Inspector!");
            return;
        }

        popupUI.SetActive(true);

        // Trigger LevelComplete animation if Animator exists
        if (popupAnimator != null)
        {
            popupAnimator.SetTrigger("LevelComplete");
        }

        Debug.Log("Level Completed Popup Shown!");
    }

    public void HidePopup()
    {
        if (popupUI != null)
            popupUI.SetActive(false);
    }
}
