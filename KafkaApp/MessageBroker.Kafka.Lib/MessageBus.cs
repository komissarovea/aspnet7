using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Confluent.Kafka;
// using Confluent.Kafka.Serialization;

namespace MessageBroker.Kafka.Lib
{
    public sealed class MessageBus : IDisposable
    {
        private readonly IProducer<Null, string> _producer;

        private readonly IDictionary<string, string> _producerConfig;
        private readonly IDictionary<string, string> _consumerConfig;

        public MessageBus() : this("localhost") { }

        public MessageBus(string host)
        {
            _producerConfig = new Dictionary<string, string> { { "bootstrap.servers", host } };
            _consumerConfig = new Dictionary<string, string>
            {
                { "group.id", "custom-group"},
                { "bootstrap.servers", host }
            };

            _producer = new ProducerBuilder<Null, string>(_producerConfig.ToList()).Build();
                //new Producer<Null, string>(_producerConfig, null, new StringSerializer(Encoding.UTF8));
        }

        public void SendMessage(string topic, string message)
        {
            _producer.ProduceAsync(topic, new Message<Null, string>() { Value = message });
        }

        public void SubscribeOnTopic<T>(string topic, Action<T> action, CancellationToken cancellationToken) where T : class
        {
            using (var consumer = new ConsumerBuilder<Null, string>(_consumerConfig.ToList()).Build())
            //new Consumer<Null, string>(_consumerConfig, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Assign(new List<TopicPartitionOffset> { new TopicPartitionOffset(topic, 0, -1) });

                while (!cancellationToken.IsCancellationRequested)
                {
                    var result = consumer.Consume();
                    if (result != null)
                    {
                        action((result.Message.Value as T)!);
                    }
                }
            }
        }

        public void Dispose()
        {
            _producer?.Dispose();
        }
    }
}