using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseMovement, IFixedUpdatable
{
    Vector3 playerMove;
    Rigidbody rigid;

    public override void SetMove(Vector3 _value)
    {
        playerMove = new Vector3(_value.x, 0, _value.z);
        playerMove = playerMove.normalized;
    }

    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
    }

    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void OnFixedUpdate()
    {
        WallCheckMove();
    }

    

    private void WallCheckMove()
    {
        Vector3 newPosition = transform.position + playerMove * PlayerInfo.Instance.MoveSpeed * Time.fixedDeltaTime;

        // �̵� �������� ����ĳ��Ʈ�� ����
        if (!Physics.Raycast(transform.position, playerMove, out RaycastHit hit, PlayerInfo.Instance.MoveSpeed * Time.fixedDeltaTime + 0.1f))
        {
            // ��ֹ��� ������ �̵�
            rigid.MovePosition(newPosition);
        }
        else
        {
            // �浹 �������� �����ϰ� �̵� (���� ���� �ʵ��� �ణ ������ ��ġ�� �̵�)
            Vector3 safePosition = hit.point - playerMove * 0.5f;
            rigid.MovePosition(safePosition);
        }
    }
    
}
