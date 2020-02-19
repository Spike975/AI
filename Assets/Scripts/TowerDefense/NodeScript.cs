using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public int weight = 1;
    public GameObject[] around = new GameObject[4];
    private GameObject[] all = new GameObject[0];

    // Update is called once per frame
    void Update()
    {

        if(all.Length != GameObject.FindGameObjectsWithTag("Floor").Length)
        {
            all = GameObject.FindGameObjectsWithTag("Floor");
        }
        for (int i = 0; i < all.Length; i++)
        {
            if (all[i].transform.position.x - 1 == transform.position.x && all[i].transform.position.z == transform.position.z)
            {
                around[0] = all[i];
            }
            if (all[i].transform.position.x == transform.position.x && all[i].transform.position.z - 1 == transform.position.z)
            {
                around[1] = all[i];
            }
            if (all[i].transform.position.x + 1 == transform.position.x && all[i].transform.position.z == transform.position.z)
            {
                around[2] = all[i];
            }
            if (all[i].transform.position.x == transform.position.x && all[i].transform.position.z + 1 == transform.position.z)
            {
                around[3] = all[i];
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        for (int i = 0; i < around.Length; i++)
        {
            if (around[i] != null)
            {
                Gizmos.DrawLine(new Vector3(transform.position.x + .5f, transform.position.y + 1, transform.position.z - .5f), new Vector3(around[i].transform.position.x + .5f, around[i].transform.position.y + 1, around[i].transform.position.z - .5f));
            }
        }
    }
}
