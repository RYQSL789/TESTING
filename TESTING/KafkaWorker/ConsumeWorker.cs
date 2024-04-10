using Confluent.Kafka;

namespace TESTING.KafkaWorker
{
    public class ConsumeWorker : BackgroundService
    {
        private readonly ILogger _log;
        private readonly string _host;
        private readonly string _topic;

        public ConsumeWorker(ILogger log, string topic)
        {
            _log = log;
            _host = "localhost:9092";
            _topic = topic;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _host,
                GroupId = $"{_topic}-group-0",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<string, string>(config).Build())
            {
                consumer.Subscribe(_topic);
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        var cr = consumer.Consume(stoppingToken);
                        _log.LogInformation($"Key: {cr.Message.Key} | Value: {cr.Message.Value}");
                    }
                    catch (OperationCanceledException oce)
                    {
                        continue;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
