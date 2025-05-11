using UnityEngine;
using UnityEngine.Rendering;

public class Outline : MonoBehaviour
{
    public Material[] materials;

    void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            collision.GetComponent<SpriteRenderer>().material = materials[0];
        }
        catch {}
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        try
        {
            collision.GetComponent<SpriteRenderer>().material = materials[1];
        }
        catch {}
    }
}
