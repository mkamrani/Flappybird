using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null) // Check to see if a bird has passed the column
        {
            GameControl.instance.BirdScored();
        }
    }
}
