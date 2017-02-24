using System;
using System.Collections.Generic;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreScheduler.Tests.Server
{
    [TestClass]
    public class UtilityTests
    {
        [TestMethod]
        public void TestDictionaryPacker()
        {
            // Set basic test object
            var model = new ScriptJobOptions()
            {
                Context = new ContextOptions()
                {
                    ConnectionStrings = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
                    Credentials = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
                    Enable = true,
                    EventsEnable = true,
                },
                ConsoleStreaming = Guid.NewGuid().ToString(),
                DllReferences = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
                EmailOnFinish = "example@example.com",
                ScriptId = Guid.NewGuid().ToString(),
                ScriptReferences = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() }
            };

            // Pack it
            var packed = new Dictionary<string, object>();
            packed.Pack(model);

            var jobOptions = packed.Unpack<JobOptions>();
            Assert.AreEqual(model.ConsoleStreaming, jobOptions.ConsoleStreaming);
            Assert.AreEqual(model.EmailOnFinish, jobOptions.EmailOnFinish);

            var scriptJobOptions = packed.Unpack<ScriptJobOptions>();
            AssertEx.PropertyValuesAreEquals(model, scriptJobOptions);
        }
    }
}
