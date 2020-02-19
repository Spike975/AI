using UnityEngine;

public class BlockBuilder : MonoBehaviour
{
    public int x;
    public int y;
    public Vector3 start;
    public GameObject target;
    public GameObject spawn;
    public GameObject end;
    // Update is called once per frame
    void Start()
    {
        for (int i = 0; i < x; i++)
        {
            for (int k = 0; k < y; k++)
            {
                if (i == 0 && k == 0)
                {
                    Instantiate(spawn, start, Quaternion.LookRotation(new Vector3()));
                }
                else if (i == x - 1 && k == y - 1)
                {
                    Instantiate(end, new Vector3(start.x + i, start.y, start.z + k), Quaternion.LookRotation(new Vector3()));
                }
                else
                {
                    Instantiate(target, new Vector3(start.x + i, start.y, start.z + k), Quaternion.LookRotation(new Vector3()));
                }
            }
        }

    }
}
