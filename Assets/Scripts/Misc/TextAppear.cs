using UnityEngine;
using TMPro;

public class TextAppear : MonoBehaviour
{
    private Animator animator;
    private TMP_Text text;
    private void Start()
    {
        animator = GetComponent<Animator>();
        text = GetComponentInChildren<TMP_Text>();
    }
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            text.transform.gameObject.SetActive(true);
        }
    }
}
