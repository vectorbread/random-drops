using UnityEngine;

public class Chest : MonoBehaviour
{
    public Transform loot;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (IsOpen())
            {
                animator.SetTrigger("close");
                HideItem();
            }
            else
            {
                animator.SetTrigger("open");
            }
        }
    }

    bool IsOpen()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("ChestOpen");
    }

    void HideItem()
    {
        loot.gameObject.SetActive(false);
    }

    void ShowItem()
    {
        loot.gameObject.SetActive(true);
    }
}
