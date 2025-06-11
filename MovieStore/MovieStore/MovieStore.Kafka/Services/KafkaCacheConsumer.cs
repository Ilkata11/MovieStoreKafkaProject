using Confluent.Kafka;
using MovieStore.Models.Models;
using System;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MovieStore.Kafka.Services
{
    public class KafkaCacheConsumer
    {
        private readonly ConcurrentDictionary<int, Movie> _cache = new();
        private readonly string _topic = "movie-cache-topic";
        private readonly IConsumer<Null, string> _consumer;

        public KafkaCacheConsumer()
        {
            var config = new ConsumerConfig
            {
                GroupId = "movie-cache-consumer-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<Null, string>(config).Build();
            _consumer.Subscribe(_topic);
        }

        public async Task StartConsumingAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var result = _consumer.Consume(cancellationToken);
                        if (result?.Message?.Value != null)
                        {
                            try
                            {
                                var movie = JsonSerializer.Deserialize<Movie>(result.Message.Value);
                                if (movie != null)
                                {
                                    _cache[movie.Id] = movie;
                                    Console.WriteLine($"[Kafka] Cached movie: {movie.Title}");
                                }
                            }
                            catch (JsonException ex)
                            {
                                Console.WriteLine($"[Kafka] JSON Error: {ex.Message}");
                            }
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    _consumer.Close();
                    Console.WriteLine("[Kafka] Consumer stopped.");
                }
            }, cancellationToken);
        }

        public List<Movie> GetCachedMovies()
        {
            return new List<Movie>(_cache.Values);
        }
    }
}
