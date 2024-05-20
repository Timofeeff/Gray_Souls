using UnityEngine;

public class ArrowTurret : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] arrows;
    private float cooldownTimer;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
            Attack();
    }

    private void Attack()
    {
        cooldownTimer = 0;

        arrows[FindFireball()].transform.position = firepoint.position;
        arrows[FindFireball()].GetComponent<ArrowProjectile>().ActivateProjectile();
    }

    private int FindFireball()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
