using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
  [SerializeField] TankSpawner _tankSpawner;
  [SerializeField] private GameObject _startButton;
  [SerializeField] private TextMeshProUGUI _easyBotsText;
  [SerializeField] private TextMeshProUGUI _hardBotsText;

  [field: SerializeField] public int MinBotsCount { get; private set; }
  [field: SerializeField] public int MaxBotsCount { get; private set; }

  public int EasyBotsCount { get; private set; }
  public int HardBotsCount { get; private set; }

  private void Awake()
  {
    Time.timeScale = 0;
  }

  private void Update()
  {
    if ((EasyBotsCount + HardBotsCount) >= MinBotsCount && (EasyBotsCount + HardBotsCount) <= MaxBotsCount)
    {
      _startButton.SetActive(true);
    }
    else
    {
      _startButton.SetActive(false);
    }

    _easyBotsText.text = EasyBotsCount.ToString();
    _hardBotsText.text = HardBotsCount.ToString();
  }

  public void StartGame()
  {
    Time.timeScale = 1;
    
    for (int i = 0; i < EasyBotsCount; i++)
    {
      _tankSpawner.SpawnTank<AIEasy>();
    }
    
    for (int i = 0; i < HardBotsCount; i++)
    {
      _tankSpawner.SpawnTank<AIHard>();
    }

    gameObject.SetActive(false);
  }

  public void AddEasyBot()
  {
    if (EasyBotsCount == MaxBotsCount)
      return;

    EasyBotsCount++;
  }

  public void AddHardBot()
  {
    if (HardBotsCount == MaxBotsCount)
      return;

    HardBotsCount++;
  }

  public void RemoveEasyBot()
  {
    if (EasyBotsCount == 0)
      return;

    EasyBotsCount--;
  }

  public void RemoveHardBot()
  {
    if (HardBotsCount == 0)
      return;

    HardBotsCount--;
  }
}