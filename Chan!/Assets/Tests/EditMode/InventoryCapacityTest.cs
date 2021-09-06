using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using InventorySystem;

public class InventoryCapacityTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void InventoryCapacityTestSimplePasses()
    {
        Inventory inv = new Inventory(10, 5);

        Assert.AreEqual(5, inv.GetSlots.Count);

        Assert.AreEqual(10, inv.MaxCapacity);
    }
}
