using UnityEngine;

public class Trees : MonoBehaviour
{
    private GameObject forest;
    private GameObject storage;
    public int wood;
    private float pickup;
    // Start is called before the first frame update
    void Start()
    {
        wood = 0;
        pickup = 0;
        forest = GameObject.Find("Forest");
        storage = GameObject.Find("Storage");
    }

    // Update is called once per frame
    void Update()
    {
        if (storage.GetComponent<Storage>().building < storage.GetComponent<Storage>().buildCap)
        {

        }
        else
        {
            gameObject.GetComponent<Movement>().velocity = new Vector3();
            gameObject.GetComponent<TownsFolk>().current = gameObject.GetComponent<TownsFolk>().last;
            gameObject.GetComponent<TownsFolk>().last = 0;
            gameObject.GetComponent<Trees>().enabled = false;
        }
    }
}
