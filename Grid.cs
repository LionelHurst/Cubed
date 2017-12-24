using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class Grid : MonoBehaviour {
    GameObject[,,] tiles;

    public Camera minimapCamera;
    public TextAsset level;
    //public BlockType[] blockTypes;
    public int mapSizeX = 5;
    public int mapSizeY = 5;
    public int mapSizeZ = 5;
    public GameObject block;
    public GameObject row;
    //public GameObject gridBlock;

    private void Awake()
    {
        GenerateGridVisual();
        AssignCubes();
    }

    // Use this for initialization
    void Start () {
        minimapCamera.orthographicSize = (mapSizeX + mapSizeY + mapSizeZ) / 3;
	}
	
	// Update is called once per frame
	void Update () {
        /*if (LeanTouch.Fingers.Count > 0)
        {
            if (LeanTouch.GetFingers(true)[0].IsActive)
            {
                float rotX = Input.GetAxis("Mouse X") * rotateAmount * Mathf.Deg2Rad;
                //float rotY = Input.GetAxis("Mouse Y") * rotateAmount * Mathf.Deg2Rad;

                transform.Rotate(Vector3.up, -rotX);
                transform.Rotate(Vector3.right, rotY);
            }
        }*/
    }

    void GenerateGridVisual()
    {
        tiles = new GameObject[mapSizeX, mapSizeY, mapSizeZ];
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                for (int z = 0; z < mapSizeZ; z++)
                {
                    tiles[x, y, z] = (GameObject)Instantiate(block, new Vector3(x - (mapSizeX / 2), y - (mapSizeY / 2), z - (mapSizeZ / 2)), Quaternion.identity);
                    tiles[x, y, z].transform.parent = transform;
                }   
            }
        }
    }

    void AssignCubes()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                for (int z = 0; z < mapSizeZ; z++)
                {
                    if (x == 0)
                    {
                        GameObject r = (GameObject)Instantiate(row, new Vector3(-0.5f, y - (mapSizeY / 2), z - (mapSizeZ / 2) + 0.33f), Quaternion.identity);
                        r.GetComponent<Row>().populate(mapSizeX);
                        for (int count = 0; count < mapSizeX; count++)
                            r.GetComponent<Row>().addCube(tiles[count, y, z]);
                    }

                    if (y == 0)
                    {
                        GameObject r = (GameObject)Instantiate(row, new Vector3(x - (mapSizeX / 2), -0.5f, z - (mapSizeZ / 2) + 0.33f), Quaternion.Euler(0, 0, -90f));
                        r.GetComponent<Row>().populate(mapSizeY);
                        for (int count = mapSizeY - 1; count >= 0; count--)
                            r.GetComponent<Row>().addCube(tiles[x, count, z]);
                    }

                    if (z == 0)
                    {
                        GameObject r = (GameObject)Instantiate(row, new Vector3(x - (mapSizeX / 2) - 0.33f, y - (mapSizeY / 2), -0.5f), Quaternion.Euler(0, -90f, 0));
                        r.GetComponent<Row>().populate(mapSizeZ);
                        for (int count = 0; count < mapSizeZ; count++)
                            r.GetComponent<Row>().addCube(tiles[x, y, count]);
                    }
                }
            }
        }
    }
}
