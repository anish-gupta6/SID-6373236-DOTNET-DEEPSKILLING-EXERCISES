using Confluent.Kafka;

Console.WriteLine("Kafka Chat Producer (Type message and press Enter)");
var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
string topic = "chat-app";

using var producer = new ProducerBuilder<Null, string>(config).Build();
while (true)
{
    Console.Write("You: ");
    var message = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(message)) break;

    var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
    Console.WriteLine($"Sent: {result.Value}");
}
