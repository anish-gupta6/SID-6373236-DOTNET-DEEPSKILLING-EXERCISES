using Confluent.Kafka;

Console.Write("Enter your name: ");
string username = Console.ReadLine();

string topic = "chat-app";
var producerConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };
var consumerConfig = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = $"group-{Guid.NewGuid()}", // Unique group for each client
    AutoOffsetReset = AutoOffsetReset.Earliest
};

// Start the consumer in background
_ = Task.Run(() =>
{
    using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
    consumer.Subscribe(topic);

    try
    {
        while (true)
        {
            var cr = consumer.Consume();
            if (!cr.Value.StartsWith($"{username}:"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(cr.Value);
                Console.ResetColor();
            }
        }
    }
    catch (OperationCanceledException) { }
});

// Producer loop
using var producer = new ProducerBuilder<Null, string>(producerConfig).Build();

while (true)
{
    Console.Write("you: ");
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input)) break;

    string message = $"{username}: {input}";
    await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
}
