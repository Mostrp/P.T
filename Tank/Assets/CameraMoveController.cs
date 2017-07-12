using UnityEngine;
using System.Collections;

public class CameraMoveController : MonoBehaviour {
    public Transform Target;
    public Vector3 LookVec;
    Camera cam;
	// Use this for initialization
	void Start () {
        //cam = this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = Target.localPosition + LookVec;
        transform.LookAt(Target);
	}
}
