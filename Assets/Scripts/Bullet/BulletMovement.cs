using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : BaseMovement, IUpdatable
{
    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
        transform.LookAt(PlayerInfo.Instance.transform.position);
    }

    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }   

    public void OnUpdate()
    {
        SetMove(Vector3.forward);
    }

    public override void SetMove(Vector3 _value)
    {
        transform.Translate(_value * BulletInfo.Instance.BulletSpeed * Time.deltaTime);
    }
}
