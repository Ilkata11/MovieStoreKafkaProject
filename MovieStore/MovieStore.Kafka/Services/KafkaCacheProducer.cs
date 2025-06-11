using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using MovieStore.DL.Interfaces;
using MovieStore.Models.Models;

namespace MovieStore.Kafka.Services
{
    public class KafkaCacheProducer
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IProducer<Null, string> _producer;
        private readonly string _topic = "movie-cache-topic";

        public KafkaCacheProducer(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task PublishMoviesPeriodicallyAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var movies = await _movieRepository.GetAllAsync();
                foreach (var movie in movies)
                {
                    var json = JsonSerializer.Serialize(movie);
                    await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = json });
                }

                Console.WriteLine("Published movies to Kafka topic.");
                await Task.Delay(10000, cancellationToken); // На всеки 10 сек
            }
        }
    }
}
