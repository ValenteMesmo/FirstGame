using UnityEngine;
using System.Collections;

public class SpriteLooksOnSpeedDirection : MonoBehaviour {

    Rigidbody2D Body;
	// Use this for initialization
	void Start () {
        Body = GetComponentInParent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 v = Body.velocity;
        //TODO: rename my mathf
        var angle = UnityEngine.Mathf.Atan2(v.y, v.x) * UnityEngine.Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
