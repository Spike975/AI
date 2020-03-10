using UnityEngine;

public class TownsFolk : MonoBehaviour
{
    public GameObject mine;
    public GameObject storage;
    public GameObject farm;
    public GameObject forest;
    public GameObject guardHouse;
    public GameObject townHouse;

    public float pickUp;
    private float gathered;

    private float mines;
    private float food;
    private float materials;



    // Start is called before the first frame update
    void Start()
    {
        mines = 0;
        food = 0;
        materials = 0;
        gathered = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Town").GetComponent<Town>().health >= 200)
        {
            if (GameObject.Find("Storage").GetComponent<Storage>().mine < 100)
            {
                //Working on everything
            }
        }
        else
        {
            if (materials <= 10)
            {
                if ((townHouse.transform.position - transform.position).sqrMagnitude > .5f)
                {
                    //Moving shadkfjhslfkjn
                }
            }
            else
            {
                if ((forest.transform.position - transform.position).sqrMagnitude > .5f)
                {
                    gameObject.GetComponent<Movement>().velocity += ((forest.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity) * Time.deltaTime;
                }
                else
                {
                    if ((Time.time - gathered) > pickUp)
                    {
                        gathered = Time.time;
                        materials++;
                    }
                }
            }
        }
    }
}
