using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>, IUpdatable
{
    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
    }

    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            ObjectPoolManager.Instance.SpawnFromPool("Bullet");
        }
    }

    public void SpawnRule()
    {
        for (int i = 0; i < BulletInfo.Instance.GetRandomValue(); i++)
        {
            ObjectPoolManager.Instance.SpawnFromPool("Bullet");
        }
    }

    private void GameOver()
    {
        if (PlayerInfo.Instance.Health <= 0)
        {
            Debug.Log("Dead");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
        }
    }

    public void OnUpdate()
    {
        GameOver();
    }
}
