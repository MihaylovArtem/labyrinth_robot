using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions.Must;

public class FloorScript : MonoBehaviour {

	public GameObject Player;
	public PlayerScript playerScript;
	public UIScript uiScript;
	public GameObject canvas;

	public GameObject startPrefab;
	public GameObject finishPrefab;

    public GameObject Wall;

	public int [] [] mapArray;
	public int [] [] newMapArray;

	public int leftSpeed;
	public int rightSpeed;

	public const int width = 15;
	public int newN, newM;

    public int N,M;

	public bool isFindingPath = false;

	void Start() {
		setMapArrayFromFileName ("map.txt");
		createMap ();
		startFinding ();
	}

	public void setMapArrayFromFileName(String fileName) {
		TextReader reader = File.OpenText (fileName);

		var line = reader.ReadLine ();
		var bits = line.Split (' ');
		N = int.Parse (bits [0]);
		M = int.Parse (bits [1]);

		mapArray = new int[N] [];
		for (var i = 0; i < N; i++) {
			mapArray [i] = new int [M];
		}

		for (var i = 0; i < N; i++) {
			line = reader.ReadLine ();
			bits = line.Split (' ');
			for (var j = 0; j < M; j++) {
				var coor = int.Parse (bits [j]);
				mapArray [i] [j] = coor;
			}
		}
		newN = N / width;
		newM = M / width;
		newMapArray = new int [newN] [];
		for (var i = 0; i < newN; i++) {
			newMapArray [i] = new int [newM];
		}

		for (var i = 0; i < newN; i++) {
			for (var j = 0; j < newM; j++) {
				newMapArray [i] [j] = mapArray [i*width][j*width];
			}
		}
	}

	void startFinding() {
		isFindingPath = true;
		uiScript.enabled = false;
		canvas.transform.localScale = Vector3.zero;
		moveForward ();
	}

	void FixedUpdate() {
		if (isFindingPath) {
			playerScript.LeftPower = leftSpeed;
			playerScript.RightPower = rightSpeed;
		}
	}
		
	void createMap() {
		gameObject.transform.localScale = new Vector2 (N, M);
		gameObject.transform.position = new Vector2 (N / 2f, M / 2f);
		for (var i = 0; i < N; i++) {
			for (var j = 0; j < M; j++) {
				if (mapArray [i] [j] == 0) continue;
				GameObject wall = Instantiate (Wall);
				wall.transform.position = new Vector2 (i + 0.5f, M - (j + 0.5f));
			}
		}
		var start = Instantiate (startPrefab) as GameObject;
		var finish = Instantiate(finishPrefab) as GameObject;

		start.transform.position = new Vector2 (22.5f, 22.5f);
		finish.transform.position = new Vector2(N - 22.5f, M - 22.5f);
	}

	public void moveForward() {
		leftSpeed = 100;
		rightSpeed = 20;
	}
}
