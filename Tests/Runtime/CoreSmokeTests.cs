using NUnit.Framework;
using HTDA.Framework.Core.Diagnostics;
using HTDA.Framework.Core.Messaging;
using HTDA.Framework.Core.Primitives;

namespace HTDA.Framework.Core.Tests
{
    public class CoreSmokeTests
    {
        [Test]
        public void Result_Ok_IsOk()
        {
            var r = Result.Ok();
            Assert.IsTrue(r.IsOk);
        }

        [Test]
        public void Log_Sink_Default_NotNull()
        {
            Assert.IsNotNull(HTDALog.Sink);
        }

        [Test]
        public void EventBus_Publish_Receives()
        {
            var bus = new EventBus();
            int called = 0;

            bus.Subscribe<int>(_ => called++);
            bus.Publish(123);

            Assert.AreEqual(1, called);
        }
    }
}