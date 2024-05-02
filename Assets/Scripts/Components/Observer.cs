using UnityEngine;

public class Observer : MonoBehaviour
{
    public LayerMask mask;
    
    public bool LaunchRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, EnemyGeneral.Instance.GetPlayer().position - transform.position, 10f, mask);
        
        if (hit.collider != null)
        {
            Debug.LogWarning(hit.collider.name);
            
            if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Debug.LogWarning("Kek");
                
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
