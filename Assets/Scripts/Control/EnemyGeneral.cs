using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneral : MonoBehaviour
{
    public static EnemyGeneral Instance;
    [SerializeField]
    private List<EnemyTankController> squad = new List<EnemyTankController>();
    [SerializeField]
    private TankController player;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetTankToSquad(EnemyTankController tank)
    {
        squad.Add(tank);
    }
    public void SetPlayerTank(TankController tank)
    {
        player = tank;
    }
    public Transform GetPlayer()
    {
        return player.transform;
    }
}
