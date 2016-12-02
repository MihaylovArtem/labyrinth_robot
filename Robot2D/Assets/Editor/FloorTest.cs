using System;
using NUnit.Framework;

public class FloorTest {
	[Test]
	public void testMapCreation() {
		var script = new FloorScript();
		script.setMapArrayFromFileName("map.txt");
		Assert.That(script.N == script.mapArray.Length);
		for (var i=0; i<script.mapArray.Length; i++) {
			Assert.That(script.M == script.mapArray[i].Length);
		}
	}
}
