using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_spawn : MonoBehaviour
{
    public BoxCollider2D collider;
    float randomPosX;
    float randomPosY;
    public void CreateTarget()
    {
            Vector2 colliderPos = collider.transform.position;
            randomPosX = Random.Range(colliderPos.x - collider.size.x / 2, colliderPos.x + collider.size.x / 2);
            randomPosY = Random.Range(colliderPos.y - collider.size.y / 2, colliderPos.y + collider.size.y / 2);
            transform.position = new Vector2(randomPosX , randomPosY);
        Debug.Log(transform.position);
    }

}
