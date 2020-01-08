using Abc.Zerio.Core;

namespace Abc.Zerio
{
    public class ZerioServerConfiguration : ZerioConfiguration
    {
        public int SessionCount { get; set; }

        public ZerioServerConfiguration()
        {
            SessionCount = 2;
        }

        internal override InternalZerioConfiguration ToInternalConfiguration()
        {
            var configuration = base.ToInternalConfiguration();
            
            configuration.SessionCount = SessionCount;
            configuration.SendingCompletionQueueSize *= SessionCount;
            configuration.ReceivingCompletionQueueSize *= SessionCount;
            configuration.RequestProcessingEngineRingBufferSize *= SessionCount;

            return configuration;
        }
    }
}