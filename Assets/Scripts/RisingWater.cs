using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    [SerializeField]
    float waterSpeed = 0.4f;

    void Update()
    {
        transform.Translate(new Vector2(0, waterSpeed * Time.deltaTime));
    }
}
