using UnityEngine;

public class Observer : MonoBehaviour
{
    public LayerMask mask;
    public bool LaunchRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, EnemyGeneral.Instance.GetPlayer().position - transform.position, 10f, mask);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }
        if (hit.collider != null && hit.collider.tag == "Player")
        {

            return true;
        }
        return false;
    }
    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawLine(transform.position, EnemyGeneral.Instance.GetPlayer().position);
    // }
}
