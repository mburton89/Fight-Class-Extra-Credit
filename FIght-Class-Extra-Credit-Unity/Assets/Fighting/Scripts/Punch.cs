using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("OUCHIE");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OOF");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("sdfsdfaf");
    }
}
