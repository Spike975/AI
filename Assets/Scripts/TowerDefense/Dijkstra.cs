using System.Collections.Generic;
using UnityEngine;


public class Dijkstar : MonoBehaviour
{
    struct Node
    {
        public GameObject cur;
        public GameObject prev;
        public int f;
        public static bool operator== (Node other)
        {
            if (cur == other.cur && )
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Node other)
        {

        }
    }
    
    private Node[] open;
    private Node[] close;
    private GameObject[] path;

    private void Start()
    {
        GameObject temp = GameObject.Find("Start");
        open = new Node[50];
        close = new Node[temp.GetComponent<BlockBuilder>().x * temp.GetComponent<BlockBuilder>().y];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            int openLength = 0;
            int closeLength = 0;
            open[0].cur = GameObject.Find("Spawn(Clone)");
            open[0].prev = null;
            open[0].f = 0;
            openLength++;

            for (int i = 0; i < close.Length; i++)
            {
                Node temp = open[0];
                close[closeLength] = open[closeLength];
                open[0] = new Node();
                openLength--;
                closeLength++;
                if (temp.cur.GetComponent<NodeScript>().around[0] != null)
                {
                    bool better = false;
                    for (int x = 0; x < closeLength; x++)
                    {
                        if (close[x].cur == temp.cur.GetComponent<NodeScript>().around[0] && close[x].f > temp.cur.GetComponent<NodeScript>().weight + temp.f)
                        {
                            better = true;
                            close[x].f = temp.cur.GetComponent<NodeScript>().weight + temp.f;
                            close[x].prev = temp.cur;
                            break;
                        }
                    }
                    for (int x = 0; x < openLength; x++)
                    {
                        if (open[x].cur == temp.cur.GetComponent<NodeScript>().around[0] && close[x].f > temp.cur.GetComponent<NodeScript>().weight + temp.f)
                        {
                            better = true;
                            open[x].f = temp.cur.GetComponent<NodeScript>().weight + temp.f;
                            open[x].prev = temp.cur;
                            break;
                        }
                    }
                    if (!better) {
                        open[openLength].cur = temp.cur.GetComponent<NodeScript>().around[0];
                        open[openLength].prev = temp.cur;
                        open[openLength].f += temp.cur.GetComponent<NodeScript>().weight + temp.f;
                        openLength++;
                    }
                }
                if (temp.cur.GetComponent<NodeScript>().around[1] != null)
                {
                    bool better = false;
                    for (int x = 0; x < closeLength; x++)
                    {
                        if (close[x].cur == temp.cur.GetComponent<NodeScript>().around[1] && close[x].f > temp.cur.GetComponent<NodeScript>().weight + temp.f)
                        {
                            better = true;
                            close[x].f = temp.cur.GetComponent<NodeScript>().weight + temp.f;
                            close[x].prev = temp.cur;
                            break;
                        }
                    }
                    for (int x = 0; x < openLength; x++)
                    {
                        if (open[x].cur == temp.cur.GetComponent<NodeScript>().around[1] && close[x].f > temp.cur.GetComponent<NodeScript>().weight + temp.f)
                        {
                            better = true;
                            open[x].f = temp.cur.GetComponent<NodeScript>().weight + temp.f;
                            open[x].prev = temp.cur;
                            break;
                        }
                    }
                    if (!better)
                    {
                        open[openLength].cur = temp.cur.GetComponent<NodeScript>().around[1];
                        open[openLength].prev = temp.cur;
                        open[openLength].f += temp.cur.GetComponent<NodeScript>().weight + temp.f;
                        openLength++;
                    }
                }
                if (temp.cur.GetComponent<NodeScript>().around[2] != null)
                {
                    bool better = false;
                    for (int x = 0; x < closeLength; x++)
                    {
                        if (close[x].cur == temp.cur.GetComponent<NodeScript>().around[2] && close[x].f > temp.cur.GetComponent<NodeScript>().weight + temp.f)
                        {
                            better = true;
                            close[x].f = temp.cur.GetComponent<NodeScript>().weight + temp.f;
                            close[x].prev = temp.cur;
                            break;
                        }
                    }
                    for (int x = 0; x < openLength; x++)
                    {
                        if (open[x].cur == temp.cur.GetComponent<NodeScript>().around[2] && close[x].f > temp.cur.GetComponent<NodeScript>().weight + temp.f)
                        {
                            better = true;
                            open[x].f = temp.cur.GetComponent<NodeScript>().weight + temp.f;
                            open[x].prev = temp.cur;
                            break;
                        }
                    }
                    if (!better)
                    {
                        open[openLength].cur = temp.cur.GetComponent<NodeScript>().around[2];
                        open[openLength].prev = temp.cur;
                        open[openLength].f += temp.cur.GetComponent<NodeScript>().weight + temp.f;
                        openLength++;
                    }
                }
                if (temp.cur.GetComponent<NodeScript>().around[3] != null)
                {
                    bool better = false;
                    for (int x = 0; x < closeLength; x++)
                    {
                        if (close[x].cur == temp.cur.GetComponent<NodeScript>().around[3] && close[x].f > temp.cur.GetComponent<NodeScript>().weight + temp.f)
                        {
                            better = true;
                            close[x].f = temp.cur.GetComponent<NodeScript>().weight + temp.f;
                            close[x].prev = temp.cur;
                            break;
                        }
                    }
                    for (int x = 0; x < openLength; x++)
                    {
                        if (open[x].cur == temp.cur.GetComponent<NodeScript>().around[3] && close[x].f > temp.cur.GetComponent<NodeScript>().weight + temp.f)
                        {
                            better = true;
                            open[x].f = temp.cur.GetComponent<NodeScript>().weight + temp.f;
                            open[x].prev = temp.cur;
                            break;
                        }
                    }
                    if (!better)
                    {
                        open[openLength].cur = temp.cur.GetComponent<NodeScript>().around[3];
                        open[openLength].prev = temp.cur;
                        open[openLength].f += temp.cur.GetComponent<NodeScript>().weight + temp.f;
                        openLength++;
                    }
                }
                for (int x = 0; x < openLength; x++)
                {
                    if (open[x] == new Node())
                    {

                    }
                }
            }
            int place;
            for (int i = 0; i < close.Length; i++)
            {
                if (close[i].cur == GameObject.Find("End(Clone)"))
                {
                    place = i;
                    break;
                }
            }

        }
    }
}