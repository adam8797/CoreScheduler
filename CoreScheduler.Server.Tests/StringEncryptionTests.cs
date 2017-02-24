using CoreScheduler.Server.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreScheduler.Tests.Server
{
    [TestClass]
    public class StringEncryptionTests
    {
        const string Key = "Mary Had A Little Lamb";
        const string Value = "Super duper secret message that nobody should be able to read";

        [TestMethod]
        public void TestRoundtrip()
        {
            var enc = StringEncryption.SimpleEncryptWithPassword(Value, Key);
            Assert.AreNotEqual(Value, enc);
            Assert.AreEqual(Value, StringEncryption.SimpleDecryptWithPassword(enc, Key));
        }

        [TestMethod]
        public void TestRoundtripInvalidPassword()
        {
            var enc = StringEncryption.SimpleEncryptWithPassword(Value, Key);
            Assert.AreNotEqual(Value, enc);
            var dec = StringEncryption.SimpleDecryptWithPassword(enc, "Not the right password");
            Assert.AreNotEqual(Value, dec);
        }

        [TestMethod]
        public void TestRandomness()
        {
            var enc =  StringEncryption.SimpleEncryptWithPassword(Value, Key);
            var enc1 = StringEncryption.SimpleEncryptWithPassword(Value, Key);
            var enc2 = StringEncryption.SimpleEncryptWithPassword(Value, Key);
            var enc3 = StringEncryption.SimpleEncryptWithPassword(Value, Key);

            Assert.AreNotEqual(Value, enc);
            Assert.AreNotEqual(Value, enc1);
            Assert.AreNotEqual(Value, enc2);
            Assert.AreNotEqual(Value, enc3);

            CollectionAssert.AllItemsAreUnique(new [] { enc, enc1, enc2, enc3 });
        }
    }
}
