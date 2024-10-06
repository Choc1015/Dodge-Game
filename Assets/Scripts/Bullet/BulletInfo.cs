using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : Singleton<BulletInfo>
{
    public float BulletSpeed = 10;

    public int GetRandomValue()
    {
        // 0���� 99������ ������ �������� ���� (0~99)
        int randomValue = Random.Range(0, 100);

        // 0: 0 ��ȯ (1% Ȯ��)
        if (randomValue < 1)
        {
            return 0;
        }
        // 1~60: 1 ��ȯ (60% Ȯ��)
        else if (randomValue < 61)
        {
            return 1;
        }
        // 61~99: 2 ��ȯ (39% Ȯ��)
        else
        {
            return 2;
        }
    }
}
