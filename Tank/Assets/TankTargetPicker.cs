using UnityEngine;
using System.Collections;

public class TankTargetPicker : MonoBehaviour {
    public Camera Cam;
    Vector3 PickPos;
    Ray ray;
    RaycastHit hit;
    Quaternion rot;
    public Transform TankTurrent;
    public Transform Port;
    public LineRenderer render;
    public Transform ShootTarget;
    int layer = ~((1 << 8) + (1 << 9));
	// Use this for initialization
	void Start () {
        rot = TankTurrent.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit))
        {
            PickPos = hit.point;
            PickPos.y = Port.position.y;
            ShootTarget.position = PickPos;
        }
        Vector3 dir = (PickPos - Port.position).normalized;
        ray = new Ray(Port.position, dir);
        if(Physics.Raycast(ray,out hit,1000,layer))
        {
            render.SetPosition(0, Port.position);
            render.SetPosition(1, hit.point);
        }
        else
        {
            render.SetPosition(0, Port.position);
            render.SetPosition(1, (PickPos - Port.position).normalized * 1000f + Port.position);
        }
        TankTurrent.forward = dir;
	}
}
