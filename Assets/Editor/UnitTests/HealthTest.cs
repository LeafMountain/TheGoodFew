using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthTest {

    private Health CreateTestableHealth () {
        return new GameObject ().AddComponent<Health> ();
    }

    [Test]
    public void HealthTestSimplePasses () {
        Health health = CreateTestableHealth();

        health.Heal (1000);
        Assert.AreEqual (health.MaxHealth, health.CurrentHealth);
    }

    [Test]
	public void TestMinMax(){
        Health health = CreateTestableHealth();
		
		health.Damage (1000, false);
        Assert.AreEqual (0, health.CurrentHealth);
		health.Heal (1000);
        Assert.AreEqual (health.MaxHealth, health.CurrentHealth);
		
	}

    [Test]
    public void TestHeal () {
        Health health = CreateTestableHealth();
		int healAmount = 5;

		//Testing positive heal
		health.Damage (1000, false);
        Assert.AreEqual (0, health.CurrentHealth);
		health.Heal (healAmount);
        Assert.AreEqual (healAmount, health.CurrentHealth);

		//Testing negative heal
		health.Damage (1000, false);
        Assert.AreEqual (0, health.CurrentHealth);
		health.Heal (-healAmount);
        Assert.AreEqual (0, health.CurrentHealth);
    }

    [Test]
	public void TestPhysicalDamage(){
		Health health = CreateTestableHealth();
		int dmgAmount = 5;

		health.Damage (dmgAmount, false);
        Assert.AreEqual ((dmgAmount - health.Def > 0) ? dmgAmount - health.Def : 1, health.CurrentHealth);
	}

    [Test]
	public void TestMagicalDamage(){
        Health health = CreateTestableHealth();
		int dmgAmount = 5;

		health.Damage (dmgAmount, true);
        Assert.AreEqual ((dmgAmount - health.Res > 0) ? health.MaxHealth - (dmgAmount - health.Res) : 1, health.CurrentHealth);

	}

    [Test]
	public void TestSetup(){
        Health health = CreateTestableHealth();
		int maxHealth = 10;
		int def = 100;
		int res = 1000; 

		health.SetupHealth(maxHealth, def, res);
		Assert.AreEqual(maxHealth, health.MaxHealth);
		Assert.AreEqual(def, health.Def);
		Assert.AreEqual(res, health.Res);
		

	}
}