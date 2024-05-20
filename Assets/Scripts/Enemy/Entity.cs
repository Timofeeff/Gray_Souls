using UnityEngine;

public class Entity : MonoBehaviour
{
    protected int Lives;

    protected bool isDie;
    public bool IsDie => isDie;

    public virtual void GetDamage()
    {
        Lives--;
        if (Lives < 1)
        {
            isDie = true;
            Die();
        }            
    }

    public virtual bool GetIsDie()
    {
        return isDie;
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
