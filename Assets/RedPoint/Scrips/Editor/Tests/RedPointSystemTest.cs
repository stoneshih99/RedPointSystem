using NUnit.Framework;
using RedPoint.Scrips.Example;
using RedPoint.Scrips.Example.Models;

namespace RedPoint.Scrips.Editor.Tests
{
    public class RedPointSystemTest
    {
        [Test]
        public void RedPointTest()
        {
            var system = new RedPointSystem(RedPointTreeMapExample.Create(typeof(ERedPointMainNode)));

            // ========================================================
            // Buddy
            // ========================================================
            var node = system.Find(ERedPointBuddyMessage.Read);
            node.NumCount = 1;
            Assert.AreEqual(1, node.TotalNumCount());
            
            node = system.Find(ERedPointBuddyMessage.Unread);
            node.NumCount = 1;
            Assert.AreEqual(1, node.TotalNumCount());
            
            var parentNode = system.Find(ERedPointBuddy.Message);
            Assert.AreEqual(2, parentNode.TotalNumCount());

            node = system.Find(ERedPointBuddy.Buddies);
            Assert.AreEqual(0, node.TotalNumCount());
            node.NumCount = 1;

            parentNode = system.Find(ERedPointMainNode.Buddy);
            Assert.AreEqual(3, parentNode.TotalNumCount());

            // ========================================================
            // Mail
            // ========================================================
            parentNode = system.Find(ERedPointMainNode.Mail);
            Assert.AreEqual(0, parentNode.TotalNumCount());
            
            node = system.Find(ERedPointEmail.Read);
            node.NumCount = 1;
            Assert.AreEqual(1, node.TotalNumCount());
            Assert.AreEqual(1, parentNode.TotalNumCount());


            node = system.Find(ERedPointEmail.Unread);
            node.NumCount = 1;
            Assert.AreEqual(1, node.TotalNumCount());
            Assert.AreEqual(2, parentNode.TotalNumCount());
            
            
            // ========================================================
            // root
            // ========================================================
            Assert.AreEqual(5, system.Root.TotalNumCount());
            
        }
    }
}