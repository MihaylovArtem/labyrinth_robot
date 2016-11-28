using System;
using System.IO;
using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Must;

public class FloorScript : MonoBehaviour {
    public GameObject Wall;
    public int N;
    public int M;
    void Start() {
	    TextReader reader = File.OpenText("map.txt");
	        var line = reader.ReadLine();
	        Console.WriteLine(line);
	        var bits = line.Split(' ');
	        N = int.Parse(bits[0]);
	        M = int.Parse(bits[1]);
            gameObject.transform.localScale = new Vector2(N,M);
	        gameObject.transform.position = new Vector2(N/2f, M/2f);
	        //Camera.main.transform.position = new Vector3(N/2f, 10f, M/2f);
	        //Camera.main.fieldOfView = Math.Max(N, M)*4/3f; 
	        for (var i = 0; i < N; i++)
	        {
	            line = reader.ReadLine();
	            bits = line.Split(' ');
	            for (var j = 0; j < M; j++)
	            {
	                var coor = int.Parse(bits[j]);
	                if (coor == 0) continue;
                    GameObject wall = Instantiate(Wall);
	                wall.transform.position = new Vector2(j + 0.5f, i + 0.5f);
	            }
	        }
	}

    void Update() {

    }
}
