using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public float Speed { get; set; }
    public float Distance { get; set; }


    private void FixedUpdate()
    {
        if (transform.position.x < Distance)
            transform.Translate(new Vector3(Speed/10f,0,0));
        else { this.gameObject.SetActive(false); }
    }
}
