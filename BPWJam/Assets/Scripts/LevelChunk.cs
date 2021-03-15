using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChunk : MonoBehaviour
{
    private float velocity;
    //public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * velocity * Time.deltaTime);

        if (transform.position.x >= 200.0f || transform.position.x <= -200.0f) { Destroy(gameObject); }
    }


    public void SetVelocity(float v) => velocity = v;
}
