using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();
    public static PointManager Instance;
    void Awake()
    {
        points = GetComponentsInChildren<Transform>().ToList();
        points.RemoveAt(0);
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
