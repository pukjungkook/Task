using UnityEngine;
using System.Collections;

public class PopupController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

   
    public void OnCloseButtonClicked()
    {
        if (animator != null)
        {
            animator.SetTrigger("Hide"); 
            StartCoroutine(DisableAfterAnimation()); 
        }
    }

    private IEnumerator DisableAfterAnimation()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
         yield return null;

  
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("WindowPopupClose") &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }

 
        gameObject.SetActive(false);
    }
}



