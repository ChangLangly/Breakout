using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksColor : MonoBehaviour
{
    public GameObject[] bricks;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bricks.Length; i++) 
        {
            Color[] colors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow };
            Color randomColor = colors[Random.Range(0, colors.Length)];
            Renderer brickMat = bricks[i].GetComponent<Renderer>();
            brickMat.material.SetColor("_Color", randomColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
