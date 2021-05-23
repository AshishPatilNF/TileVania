using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickContainer : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType<PickContainer>().Length > 1)
            Destroy(this.gameObject);
    }
}
