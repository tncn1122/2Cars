using UnityEngine;

public class XOGo : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
        if (transform.position.y < -12.5)
            Destroy(gameObject);
    }

}
