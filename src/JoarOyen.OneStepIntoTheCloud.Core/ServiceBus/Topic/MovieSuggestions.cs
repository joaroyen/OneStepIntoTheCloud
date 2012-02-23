using System;
using JoarOyen.OneStepIntoTheCloud.Core.Model;
using Microsoft.ServiceBus.Messaging;

namespace JoarOyen.OneStepIntoTheCloud.Core.ServiceBus.Topic
{
    public class MovieSuggestions
    {
        public MovieSuggestions()
        {
            All = new SubscriptionAll();
        }

        private const string TopicPath = "moviesuggestions";

        public SubscriptionAll All { get; private set; }

        public void Send(Movie movie)
        {
            var messagingFactory = Namespace.CreateMessagingFactory();
            var topicClient = messagingFactory.CreateTopicClient(TopicPath);
            var brokeredMessage = new BrokeredMessage(movie);
            brokeredMessage.Properties.Add("Year", movie.Year);
            topicClient.Send(brokeredMessage);
            topicClient.Close();
        }

        public class SubscriptionAll
        {
            private const string SubscriptionName = "all";

            internal SubscriptionAll()
            {
            }

            public Movie Receive()
            {
                var messagingFactory = Namespace.CreateMessagingFactory();
                var subscriptionClient = messagingFactory.CreateSubscriptionClient(TopicPath, SubscriptionName);

                var brokeredMessage = subscriptionClient.Receive(TimeSpan.MaxValue);
                var movie = brokeredMessage.GetBody<Movie>();

                subscriptionClient.Complete(brokeredMessage.LockToken);
                subscriptionClient.Close();

                return movie;
            }
        }

    }
}
