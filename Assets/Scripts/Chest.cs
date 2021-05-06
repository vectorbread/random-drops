using UnityEngine;

public class Chest : MonoBehaviour
{
    public Transform loot;
    public WeightedRandomList<Transform> lootTable;

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
                ClearItem();
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

    void ClearItem()
    {
        if (loot.childCount > 0)
        {
            GameObject lastItem = loot.transform.GetChild(0).gameObject;
            Destroy(lastItem);
        }

        loot.transform.localScale = Vector3.zero;
        loot.gameObject.SetActive(false);
    }

    public void SpawnItem()
    {
        Transform item = lootTable.GetRandom();

        if (item != null)
        {
            Instantiate(item, loot);
            loot.gameObject.SetActive(true);
        }
    }
}
