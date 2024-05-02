using UnityEngine;

public class Observer : MonoBehaviour
{
    public LayerMask mask;
    
    public bool LaunchRay()
    {
        Vector3 direction = transform.position - transform.parent.transform.position;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 10f, mask);
        
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                return true;
            }
        }
        
        return false;
    }

#if UNITY_EDITOR && UNITY_PLAYMODE
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, EnemyGeneral.Instance.GetPlayer().position);
    }
#endif
}
