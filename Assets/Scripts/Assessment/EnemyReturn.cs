using UnityEngine;

public class EnemyReturn : MonoBehaviour
{
    private GameObject bases;
    // Start is called before the first frame update
    void Start()
    {
        bases = GameObject.Find("EnemyBase");
    }

    // Update is called once per frame
    void Update()
    {
        if ((bases.transform.position - transform.position).sqrMagnitude > .5f) {
            Vector3 v = ((bases.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity);
            v.y = 0;
            gameObject.GetComponent<Movement>().velocity += v * Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<Movement>().velocity = new Vector3();
        }
    }
}
