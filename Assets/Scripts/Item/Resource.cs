using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public ItemData itemToGive;
    public int quantityPerHit = 1; //한번 때릴때마다 나오는 자원의 양. 여러 자원을 주고 싶다면 이 양을 늘리면 됨
    public int capacity;

    public void Gather(Vector3 hitPoint, Vector3 hitNormal)
    {
        for(int i = 0; i < quantityPerHit; i++)
        {
            if (capacity <= 0) break;
            capacity--;
            Instantiate(itemToGive.dropPrefab, hitPoint + Vector3.up, Quaternion.LookRotation(hitNormal, Vector3.up));
        }
    }
}
