using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions.Must;

public class FloorScript : MonoBehaviour {

	public GameObject Player;
	public PlayerScript playerScript;

    public GameObject Wall;

	public int [] [] mapArray;
	public int [] [] newMapArray;

	public const int width = 15;
	public int newN, newM;

    public int N,M;

	public Directions playerDirection;
	public Point playerPosition;

	void Start() {
		setMapArrayFromFileName ("map.txt");
		createMap ();
		playerPosition = new Point (1, 19);
	}

	public enum Directions {
		Up,
		Down,
		Left,
		Right,
		Moving
	}

	public struct Point {
		public int x;
		public int y;

		public Point(int x, int y) {
			this.x = x;
			this.y = y;
		}
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

		String st = "";

		for (var i = 0; i < newN; i++) {
			for (var j = 0; j < newM; j++) {
				newMapArray [i] [j] = mapArray [i*width][j*width];
				st += newMapArray [i] [j] + " ";
			}
			Debug.Log (st);
			st = "";
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
	}

    void Update() {
		if (playerScript.isTurning) {
			//Debug.Log ("turning...");
			return;
		}
		if (getFree () == 0) {
			//playerScript.rotateLeft ();
			//Debug.Log ("left");
		} else {
			playerScript.moveForward ();
			//Debug.Log ("forward");
		}
    }

	Directions getPlayerDirection() {
		if (AboutEqual (Player.transform.rotation.eulerAngles.z, 0.0)) {
			return Directions.Up;
		}
		if (AboutEqual (Player.transform.rotation.eulerAngles.z, 90.0)) {
			return Directions.Left;
		}
		if (AboutEqual (Player.transform.rotation.eulerAngles.z, 180.0)) {
			return Directions.Down;
		}
		if (AboutEqual (Player.transform.rotation.eulerAngles.z, 270.0)) {
			return Directions.Right;
		}
		return Directions.Moving;
	}

	int getFree () {
		int free = 0;
		switch (playerDirection) {
			case Directions.Up:
				for (var i = 1; i < 7;i++) {
				if (mapArray[playerPosition.x][playerPosition.y + i] == 1) {
					//Debug.Log (playerPosition.x + " " + (newN - (playerPosition.y + i)) + " " + mapArray [playerPosition.x] [playerPosition.y + i]);
						return free;
					} else {
						free++;
					}
				}
				break;
			case Directions.Down:
				for (var i = 1; i < 7; i++) {
				if (mapArray [playerPosition.x] [playerPosition.y - i] == 1) {
						return free;
					} else {
						free++;
					}
				}
				break;
			case Directions.Left:
				for (var i = 1; i < 7; i++) {
					if (mapArray [playerPosition.x + 1] [playerPosition.y] == 1) {
						return free;
					} else {
						free++;
					}
				}
				break;
			case Directions.Right:
				for (var i = 1; i < 7; i++) {
					if (mapArray [playerPosition.x - i] [playerPosition.y] == 1) {
						return free;
					} else {
						free++;
					}
				}
				break;
		}
		return 0;
	}

	public static bool AboutEqual (double x, double y) {
		double epsilon = Math.Max (Math.Abs (x), Math.Abs (y)) * 0.5E-1;
		return Math.Abs (x - y) <= epsilon;
	}
}
