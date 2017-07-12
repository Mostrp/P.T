using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float Speed;
    public float LifeTime;
    bool m_binited = false;
    bool m_bHit = false;
    Ray ray = new Ray();
    Vector3 direction = Vector3.zero;
    int layer = ~((1 << 8) + (1 << 9));
	// Use this for initializaaaawation
	void Start () {
	
	}
	
    public void Init(Vector3 dir)
    {
        direction = dir.normalized;
        transform.LookAt(transform.position + dir);
        m_binited = true;
        m_bHit = false;
        Destroy(this.gameObject, LifeTime);
    }

	// Update is called once per frame
	void FixedUpdate () {
        
	    if(m_binited)
        {
            if (m_bHit == false)
            {
                ray.origin = transform.position;
                ray.direction = direction.normalized;
                RaycastHit raycastHit;
                Physics.Raycast(ray, out raycastHit, Speed * Time.deltaTime, layer);
                if (raycastHit.collider  )
                {
                    if (raycastHit.collider.transform != transform)
                    {
                        m_bHit = true;
                    }

                }
            }
            else
            {
                Destroy(this.gameObject);
            }
            transform.position += Speed * direction * Time.deltaTime;
        }
	}
}
