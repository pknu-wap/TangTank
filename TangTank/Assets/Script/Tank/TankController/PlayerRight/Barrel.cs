using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    float smooth = 5.0f;
    private float zAngle = 180;
    private Quaternion Up = Quaternion.identity;

    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            Debug.Log("입력됬습니다");
            if (transform.localRotation.eulerAngles.z > 120)
            {
                zAngle--;
            }
            else
            {
                zAngle = 119;
            }
            Up.eulerAngles = new Vector3(0, 0, zAngle);
            
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Up, Time.deltaTime * smooth);

        }
        if (Input.GetKey(KeyCode.P))
        {
            Debug.Log("R 입력됬습니다");

            if (transform.localRotation.eulerAngles.z < 200)
            {
                zAngle++;
            }
            else
            {
                zAngle = 199;
            }
            Up.eulerAngles = new Vector3(0, 0, zAngle);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Up, Time.deltaTime * smooth);
        }


    }
}
