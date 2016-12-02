using System;
using System.IO;
using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Must;

public class FloorScript : MonoBehaviour {
	
    public GameObject Wall;

	public int [] [] mapArray;

    public int N;
    public int M;

    void Start() {
		setMapArrayFromFileName ("map.txt");
		createMap ();
	}

	public void setMapArrayFromFileName(string fileName) {
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
	}

	void createMap() {
		gameObject.transform.localScale = new Vector2 (N, M);
		gameObject.transform.position = new Vector2 (N / 2f, M / 2f);
		for (var i = 0; i < N; i++) {
			for (var j = 0; j < M; j++) {
				if (mapArray [i] [j] == 0) continue;
				GameObject wall = Instantiate (Wall);
				wall.transform.position = new Vector2 (j + 0.5f, i + 0.5f);
			}
		}
	}

    void Update() {

    }
}
