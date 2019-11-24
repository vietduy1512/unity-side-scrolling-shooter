using UnityEngine;
using System.Collections;

public class FollowingGameObject : MonoBehaviour {

	public Vector3 offset = new Vector3(0, 0.6f, 0);

	private Transform parent;

	// Use this for initialization
	void Start () {
		parent = GameObject.Find(gameObject.name).transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = parent.position + offset;
	}
}
