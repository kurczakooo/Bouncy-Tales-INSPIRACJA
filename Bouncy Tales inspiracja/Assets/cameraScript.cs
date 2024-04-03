using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Rigidbody2D target;

    void FollowPlayer()
    {
        if (target != null)
        {
            this.gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.gameObject.transform.position.z);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // LateUpdate is called once per frame, after Update()
    void LateUpdate()
    {
        FollowPlayer();
    }
}
