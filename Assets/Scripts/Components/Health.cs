using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    public void SetDamage(int damage)
    {
        if (damage < health)
        {
            health -= damage;
        }
        else
        {
            health = 0;
            
            Destroy(gameObject);
        }
    }
}
