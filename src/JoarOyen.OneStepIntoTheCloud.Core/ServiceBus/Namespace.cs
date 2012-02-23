using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace JoarOyen.OneStepIntoTheCloud.Core.ServiceBus
{
    public static class Namespace
    {
        private const string ServiceNamespace = "YOUR_NAMESPACE";
        private const string Issuer = "owner";
        private const string Key = "YOUR_SECRET";

        public static MessagingFactory CreateMessagingFactory()
        {
            var messagingFactorySettings = new MessagingFactorySettings();
            messagingFactorySettings.TokenProvider = TokenProvider.CreateSharedSecretTokenProvider(Issuer, Key);
            var serviceUri = ServiceBusEnvironment.CreateServiceUri("sb", ServiceNamespace, string.Empty);
            return MessagingFactory.Create(serviceUri, messagingFactorySettings);
        }
    }
}
