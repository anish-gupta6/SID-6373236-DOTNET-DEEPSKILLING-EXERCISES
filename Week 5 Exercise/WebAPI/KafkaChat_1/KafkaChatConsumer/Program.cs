using Confluent.Kafka;

Console.WriteLine("Kafka Chat Consumer");

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "chat-consumer-group",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

string topic = "chat-app";

using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
consumer.Subscribe(topic);

while (true)
{
    var cr = consumer.Consume();
    Console.WriteLine($"Received: {cr.Value}");
}
