using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Collider2D))]
public class LauchCollidingRigidBodies : MonoBehaviour
{
    private List<Rigidbody2D> RigidbodyHandlers = new List<Rigidbody2D>();

    BoxCollider2D BoxCollider2D;
    float originalSizeY;

    void Start()
    {
        BoxCollider2D = GetComponents<BoxCollider2D>().FirstOrDefault(f => f.isTrigger);
        originalSizeY = BoxCollider2D.size.y;
        DelayExecution(asdsadasdasd, 2f);
    }

    void asdsadasdasd()
    {
        BoxCollider2D.size = new Vector2(BoxCollider2D.size.x, originalSizeY);
        RigidbodyHandlers.Clear();
        DelayExecution(asdsadasdasd, 2f);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        var body = col.gameObject.GetComponent<Rigidbody2D>();
        if (!RigidbodyHandlers.Contains(body) && onCooldown == false)
        {
            BoxCollider2D.size = new Vector2(BoxCollider2D.size.x, BoxCollider2D.size.y + 1.5f);
            RigidbodyHandlers.Add(body);
        }
    }

    public int BodiesCount { get { return RigidbodyHandlers.Count; } }

    private bool onCooldown;
    public void Launch(float force)
    {
        if (onCooldown == false)
        {
            onCooldown = true;
            foreach (var item in RigidbodyHandlers)
            {
                item.AddForce(new Vector2(0, force));
            }
            DelayExecution(() => onCooldown = false, 0.5f);
        }
    }
}
