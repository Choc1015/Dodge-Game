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

        // 이동 방향으로 레이캐스트를 수행
        if (!Physics.Raycast(transform.position, playerMove, out RaycastHit hit, PlayerInfo.Instance.MoveSpeed * Time.fixedDeltaTime + 0.1f))
        {
            // 장애물이 없으면 이동
            rigid.MovePosition(newPosition);
        }
        else
        {
            // 충돌 지점까지 안전하게 이동 (벽에 끼지 않도록 약간 떨어진 위치로 이동)
            Vector3 safePosition = hit.point - playerMove * 0.5f;
            rigid.MovePosition(safePosition);
        }
    }
    
}
