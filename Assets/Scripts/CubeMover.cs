using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public float Speed { get; set; }
    public float Distance { get; set; }


    private void FixedUpdate()
    {
        if (transform.localPosition.x < Distance)
            transform.Translate(Speed*Time.fixedDeltaTime,0,0);
        else { this.gameObject.SetActive(false); }
    }
}
