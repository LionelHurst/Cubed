using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class ClickableBox : MonoBehaviour {

    public GameObject cubeDestruction;
    public List<GameObject> rows = new List<GameObject>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DesotryNow()
    {
        foreach(GameObject row in rows)
        {
            row.GetComponent<Row>().removeCube(this.gameObject);
        }
        Instantiate(cubeDestruction, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void setRow(GameObject row)
    {
        rows.Add(row);
    }

}
