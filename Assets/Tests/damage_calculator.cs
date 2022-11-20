using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{


    public class damage_calculator
    {
        [Test]
        public void set_damage_to_half_with_50_percent_mitigation()
        {
            // ACT
            int finalDamage = DamageCalculator.CalculateDamage(10, 0.5f);

            // Assert
            Assert.AreEqual(expected: 5, actual: finalDamage);
        }

        [Test]
        public void calculate_2_damage_from_10_with_80_percent_mitigation()
        {
            // ACT
            int finalDamage = DamageCalculator.CalculateDamage(10, 0.8f);

            // Assert
            Assert.AreEqual(expected: 2, actual: finalDamage);
        }

        [Test]
        public void Destroy_Enemy_Upon_Health_Depletion_Full_Attack()
        {
            GameObject testObject = new GameObject();
            Enemy enemyScript = testObject.AddComponent<Enemy>();
            enemyScript.health = 100;
            enemyScript.TestDie(50);
            enemyScript.TestDie(60);

            Assert.IsFalse(testObject.activeSelf);
        }

        [Test]
        public void Destroy_Enemy_Upon_Health_Depletion_Negative()
        {
            GameObject testObject = new GameObject();
            Enemy enemyScript = testObject.AddComponent<Enemy>();
            enemyScript.health = 1;
            enemyScript.TestDie(-50);
            enemyScript.TestDie(-60);

            Assert.IsTrue(testObject.activeSelf);
        }

        [Test]
        public void Destroy_Enemy_Upon_Health_Depletion()
        {
            GameObject testObject = new GameObject();
            Enemy enemyScript = testObject.AddComponent<Enemy>();
            enemyScript.health = 100;
            enemyScript.TestDie(50);
            enemyScript.TestDie(50);

            Assert.IsFalse(testObject.activeSelf);
        }

        [Test]
        public void Destroy_Enemy_Upon_Health_Depletion_Float()
        {
            GameObject testObject = new GameObject();
            Enemy enemyScript = testObject.AddComponent<Enemy>();
            enemyScript.health = 99;
            enemyScript.TestDie(50);
            enemyScript.TestDie(50);

            Assert.IsFalse(testObject.activeSelf);
        }

        [Test]
        public void Playert_live_count()
        {
            Assert.AreEqual(0, PlayerStats.Lives);
        }

        [Test]
        public void Playert_Money_count()
        {
            Assert.AreEqual(0, PlayerStats.Money);
        }
    }

}