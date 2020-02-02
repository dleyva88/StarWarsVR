using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = .01f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 25.0f * Time.smoothDeltaTime;
    }

    //void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.layer != LayerMask.NameToLayer("Enemy"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
