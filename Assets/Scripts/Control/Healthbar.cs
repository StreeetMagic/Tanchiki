using System;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Transform bar;
    private float scaleX;
    private float posX;
    private float maxHP;
    private float currentHP;
    
    private void Start()
    {
         Init(health.health);
    }
    
    private void Update()
    {
        SetHP(health.health); 
    }

    public void Init(float initHP)
    {
        maxHP = initHP;
        bar.localPosition = Vector3.zero;
        bar.localScale = Vector3.one;
    }

    public void SetHP(int hp)
    {
        currentHP = hp / maxHP;
        bar.localScale = new Vector3(currentHP, 1, 1);
        bar.localPosition = new Vector3(0 - ((1 - currentHP) / 2), 0, 0);
    }
}
