﻿using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {

	private const int bufferFrames = 100;
	private MyKeyFrame[] keyFrames = new MyKeyFrame [bufferFrames];

	private Rigidbody rb;
	private GameManager gm;

	void Awake () {
		gm = GameObject.FindObjectOfType<GameManager>();
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
		
	// Update is called once per frame
	void Update () {
		if (gm.recording) {
			Record ();
		}
		else PlayBack ();
	}

	void PlayBack () {
		rb.isKinematic = true;
		int frame = Time.frameCount % bufferFrames;
		print ("reading frame " + frame);
		transform.position = keyFrames [frame].position;
		transform.rotation = keyFrames [frame].rotation;
	}

	void Record () {
		rb.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		print ("Writing frame " + frame);
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation);
	}
}

/// <summary>
/// A structure for storing time, rotation and position.
/// </summary>
public class MyKeyFrame {
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame ( float time, Vector3 pos, Quaternion rot) {
		frameTime = time;
		position = pos;
		rotation = rot;
	}
}