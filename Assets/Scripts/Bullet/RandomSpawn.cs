using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    const float startX = 35f;
    const float endX = -35f;
    const float startZ = 35f;
    const float endZ = -35f;

    float currentX = 0;
    float currentZ = 0;

    private void OnEnable()
    {
        // ������Ʈ�� Ȱ��ȭ�� ������ ���ο� ��ġ�� �̵��ϵ��� ����
        transform.position = GetRandomSpawnPoint();
    }

    private Vector3 GetRandomSpawnPoint()
    {
        float rndSpawn = Random.Range(-35f, 36f);
        float rndPattern = Random.Range(0, 4);

        switch (rndPattern)
        {
            case 0:
                currentX = startX;
                currentZ = rndSpawn;
                break;
            case 1:
                currentX = endX;
                currentZ = rndSpawn;
                break;
            case 2:
                currentX = rndSpawn; // -35 ~ 35
                currentZ = startZ; //35
                break;
            case 3:
                currentX = rndSpawn;
                currentZ = endZ; // -35 
                break;
        }

        return new Vector3(currentX, 1, currentZ);
    }
}
