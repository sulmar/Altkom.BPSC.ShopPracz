using System;
using Altkom.BPSC.ShopPracz.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Altkom.BPSC.ShopPracz.UnitTests
{
    [TestClass]
    public class MachineStateUnitTests
    {
        [TestMethod]
        public void LampTest()
        {
            var lamp = new Lamp();

            Assert.AreEqual(LampState.Off, lamp.State);

            lamp.Switch();

            Assert.AreEqual(LampState.On, lamp.State);

            lamp.Switch();

            lamp.Stop();

            Assert.AreEqual(LampState.Off, lamp.State);

        }
    }
}
