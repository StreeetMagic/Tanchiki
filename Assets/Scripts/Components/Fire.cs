using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public Transform launcher;
    public float cooldown = 0f;
    public float reload = 5f;
    public int damage = 25;
    public void Launch()
    {
        if (cooldown < 0)
        {
            var obj = Instantiate(bullet, launcher.position, launcher.rotation);
            obj.GetComponent<Bullet>().damage = damage;
            cooldown = reload;
        }
    }
    private void Update()
    {
        cooldown -= Time.deltaTime;
    }
}
