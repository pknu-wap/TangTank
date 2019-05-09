using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {
    public float destroyYPos;   // 미사일이 사라지는 지점
    public int bounceCount;

    void Update()
    {
        if (transform.position.y >= destroyYPos)
        {
            // 미사일을 제거
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if(bounceCount==0)
        {
            Debug.Log("삭제됩니다");

            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("삭제됩니다");
            if (other.gameObject.tag == "Tank")
            {
                gameObject.SetActive(false);
            }
            else if (other.gameObject.tag == "Ground" || other.gameObject.tag == "wall") 
            {
                Debug.Log(bounceCount);
               bounceCount--;
            }
        }



    }

}

