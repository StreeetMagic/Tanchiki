using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TankSpawner : MonoBehaviour
{
  [SerializeField] private List<Transform> _tankSpawnPoints;
  [SerializeField] private Transform _lastPlayerTransform;

  [SerializeField] private AIEasy _tankPrefabEasy;
  [SerializeField] private AIHard _tankPrefabHard;

  public void SpawnTank<T>() where T : AI
  {
    Vector3 position = _tankSpawnPoints[Random.Range(0, _tankSpawnPoints.Count)].position;

    if (typeof(T) == typeof(AIEasy))
    {
      AIEasy easyTank = Instantiate(_tankPrefabEasy, position, Quaternion.identity);
      easyTank.LastPlayerPosition = _lastPlayerTransform;
    }
    else if (typeof(T) == typeof(AIHard))
    {
      AIHard hardTank = Instantiate(_tankPrefabHard, position, Quaternion.identity);
      hardTank.LastPlayerPosition = _lastPlayerTransform;
    }
  }
}