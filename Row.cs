using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour {

    private int size = 1;
    public TextMesh end1;
    public TextMesh end2;
    private string name = "";

    public List<GameObject> cubes = new List<GameObject>();

    void Awake()
    {

    }

    public void populate(int size)
    {
        this.size = size;
        
        end1.transform.localPosition = new Vector3(-(size / 2), end1.transform.localPosition.y, end1.transform.localPosition.z);
        end2.transform.localPosition = new Vector3((size / 2), end2.transform.localPosition.y, end2.transform.localPosition.z);
    }

	// Update is called once per frame
	void Update () {
        
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public void addCube(GameObject cube)
    {
        cubes.Add(cube);
        cube.GetComponent<ClickableBox>().setRow(this.gameObject);
    }

    public void removeCube(GameObject cube)
    {
        List<GameObject> tempcubes = new List<GameObject>(cubes);
        cubes[cubes.IndexOf(cube)] = null;

        int first = GetFirst(cubes);
        int tempfirst = GetFirst(tempcubes);
        int last = GetLast(cubes);
        int templast = GetLast(tempcubes);

        if (tempfirst != first)
            end1.transform.localPosition = new Vector3(end1.transform.localPosition.x + (first - tempfirst), end1.transform.localPosition.y, end1.transform.localPosition.z);

        if (templast != last)
            end2.transform.localPosition = new Vector3(end2.transform.localPosition.x - (templast - last), end2.transform.localPosition.y, end2.transform.localPosition.z);

        if (IsEmpty())
        {
            end1.GetComponent<MeshRenderer>().enabled = false;
            end2.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private bool IsEmpty()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            if (cubes[i] != null)
            {
                return false;
            }
        }

        return true;
    }

    private int GetFirst(List<GameObject> t)
    {
        for(int i = 0; i < t.Count; i++)
        {
            if (t[i] != null)
            {
                return i;
            }
        }

        return -1;
    }

    private int GetLast(List<GameObject> t)
    {
        for (int i = t.Count - 1; i >= 0; i--)
        {
            if (t[i] != null)
            {
                return i;
            }
        }

        return -1;
    }
}
