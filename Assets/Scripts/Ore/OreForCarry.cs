using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreForCarry : MonoBehaviour
{
    public Renderer renderer;
    public OreData data;
    public void Init(OreData _data)
    {
        data = _data;
        renderer.material.color = data.color;
    }

    public IEnumerator MoveToPos(Transform container)
    {
        Vector3 upward = transform.position + Vector3.up * 3f;
        while (Vector3.Distance(transform.position,upward)>0)
        {
            transform.position = Vector3.MoveTowards(transform.position, upward, Time.deltaTime*10);
            yield return null;
        }
        while (Vector3.Distance(transform.position,container.position)>0)
        {
            transform.position = Vector3.MoveTowards(transform.position, container.position, Time.deltaTime*10);
            transform.rotation = container.rotation;
            yield return null;
        }
        transform.SetParent(container);
        yield break;
    }
}
