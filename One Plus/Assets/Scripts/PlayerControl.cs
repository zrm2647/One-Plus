using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    private float speed;
    private bool hasKey = false;

    // Use this for initialization
    void Start()
    {
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(axisX, axisY) * Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision col) {

        //Checks of "key" is collected 
        if (col.gameObject.CompareTag("Key")) {
            Destroy(col.gameObject);
            hasKey = true;
        }

        if (col.gameObject.CompareTag("Goal") && hasKey)
        {
            //Code to enter next level.
            //SceneManager.LoadScene([Level here]);
        }
    }
}