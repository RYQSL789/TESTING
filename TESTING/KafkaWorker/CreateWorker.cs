using Confluent.Kafka;

namespace TESTING.KafkaWorker
{
    public class CreateWorker : BackgroundService
    {
        private readonly ILogger<CreateWorker> _logger;
        private readonly string _host;
        private readonly string _topic;

        public CreateWorker(ILogger<CreateWorker> logger, string topic)
        {
            _logger = logger;
            _host = "localhost:9092";
            _topic = topic;

        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var config = new ProducerConfig { BootstrapServers = _host };
                using (var producer = new ProducerBuilder<string, string>(config).Build())
                {
                    int i = 0;
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        var result = producer.ProduceAsync(_topic,
                            new Message<string, string>
                            {
                                Key = $"KEY_{i}",
                                Value = Guid.NewGuid().ToString()
                            });
                        i++;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Task.CompletedTask;
        }
    }
}
