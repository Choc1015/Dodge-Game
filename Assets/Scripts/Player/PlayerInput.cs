using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IUpdatable
{
    BaseMovement Movement;

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
        Movement = GetComponent<BaseMovement>();
    }

    public void OnUpdate()
    {
        playerController();
    }

    void playerController()
    {
        float xAxis = Input.GetAxisRaw("Horizontal"); // Input
        float zAxis = Input.GetAxisRaw("Vertical"); // Input
        Vector3 axisVector = new Vector3(xAxis,0,zAxis);

        Movement.SetMove(axisVector);
    }
}
