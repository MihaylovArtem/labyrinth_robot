using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class PlayerTest : MonoBehaviour {
	// Use this for initialization
	
	[Test]
	public void testVelocity () {
		var player = new PlayerScript ();

		player.BothPower = 50;
		player.LeftPower = 40;
		player.RightPower = 30;

		player.updateVelocityWithConnected (true);
		Assert.AreEqual (player.leftWheelSpeed, player.rightWheelSpeed);

		player.updateVelocityWithConnected (false);
		Assert.AreNotEqual (player.leftWheelSpeed, player.rightWheelSpeed);
	}
}
