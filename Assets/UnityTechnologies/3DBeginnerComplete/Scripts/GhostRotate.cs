using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRotate : MonoBehaviour
{
    //Inspiration and credit go to the textbook, lecture slides and videos, and Chat GPT to help with debugging

    public GameObject player;
    private Vector3 _angles;
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;

        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(Vector3.forward, direction));

        //Checking the cross for a smoother rotation as discussed in class
        Vector3 cross_check = Vector3.Cross(Vector3.forward, direction);
        if (cross_check.y < 0.0f)
        {
            angle = -angle;
        }

        //Completing rotation as nevessary
        _angles.y = angle;
        transform.eulerAngles = _angles;
    }
}
