using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class play_mode_test
{

    [Test]
    public void play_mode_test_direction_along_x_axis()
    {
        GameObject testObject = new GameObject();
        Movement movementScript = testObject.AddComponent<Movement>();
        movementScript.speed = 1f;
        Assert.AreEqual(1, movementScript.Calculate(1, 0, 1).x, 0.1f);
    }

    [Test]
    public void play_mode_test_direction_along_y_axis()
    {
        GameObject testObject = new GameObject();
        Movement movementScript = testObject.AddComponent<Movement>();
        movementScript.speed = 1f;
        Assert.AreEqual(1, movementScript.Calculate(0, 1, 1).z, 0.1f);
    }


}
