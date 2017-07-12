using UnityEngine;
using System.Collections;

public class TankMoveController : MonoBehaviour {
    public Transform Tank;
    public Transform Turrent;
    public float MoveSpeed = 5;
    public float RotateSpeed = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = Vector3.zero;
	    if(Input.GetKey(KeyCode.W))
        {
            forward += Tank.forward * Time.deltaTime * MoveSpeed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            forward -= Tank.forward * Time.deltaTime * MoveSpeed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            Tank.Rotate(Vector3.up, -Time.deltaTime * RotateSpeed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Tank.Rotate(Vector3.up, Time.deltaTime * RotateSpeed);
        }
        Tank.localPosition += forward;
	}
}
