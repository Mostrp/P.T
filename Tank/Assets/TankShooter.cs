using UnityEngine;
using System.Collections;

public class TankShooter : MonoBehaviour {
    public Transform Target;
    public Transform Port;
    public GameObject BulletPfb;
    public float ShootCoolDown = 1;
    private float m_fShootCurCoolDown = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(m_fShootCurCoolDown > 0)
        {
            m_fShootCurCoolDown -= Time.deltaTime;
        }
        if (m_fShootCurCoolDown <= 0 && Input.GetMouseButton(0))
        {
            Vector3 dir = Target.position - Port.position;
            GameObject go = GameObject.Instantiate(BulletPfb);
            bullet bull = go.GetComponent<bullet>();
            bull.transform.position = Port.position;
            bull.Init(dir);
            m_fShootCurCoolDown = ShootCoolDown;
        }
	}
}
