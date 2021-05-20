using DTO;
using Interfaces.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Synchroniser
{
    internal sealed class Synchroniser : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ICharacterService _characterService;

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public Synchroniser(ILogger<Synchroniser> logger,
                        IHostApplicationLifetime appLifetime,
                        IHttpClientFactory clientFactory,
                        ICharacterService characterService
                        )
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _clientFactory = clientFactory;
            _characterService = characterService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}");

            _appLifetime.ApplicationStarted.Register(() =>
             {
                 Task.Run(async () =>
                 {
                     try
                     {
                         await GetCharacters();
                     }
                     catch (Exception ex)
                     {
                         _logger.LogError(ex, "Unhandled exception!");
                     }
                     finally
                     {
                         // Stop the application once the work is done
                         _appLifetime.StopApplication();
                     }
                 });
             });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task GetCharacters()
        {
            await _characterService.Clean();
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://rickandmortyapi.com/");

            string next = "api/character/?status=alive";
            int currentPage = 0;

            while (string.IsNullOrEmpty(next) == false)
            {
                currentPage++;
                
                var request = new HttpRequestMessage(HttpMethod.Get, next);
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var info = await ReadAndSave(response);
                    next = string.IsNullOrEmpty(info.Next) ? string.Empty : new Uri(info.Next).PathAndQuery;
                    _logger.LogInformation("Retrieved page {0} of {1}", currentPage, info.Pages);
                }
                else
                {
                    _logger.LogWarning("Unable to retrieve character data. Status code was {0}.", response.StatusCode);
                }
            }
            _logger.LogInformation("FINISHED >> Total characters in database: {0}.", await _characterService.CountAsync());
        }

        private async Task<ResponseInfo> ReadAndSave(HttpResponseMessage response)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonSerializer.DeserializeAsync
                    <ApiResponse<Character>>(responseStream, _jsonOptions);

            await _characterService.AddRangeAsync(responseData.Results);

            var cnt = await _characterService.CountAsync();

            return responseData.Info;
        }
    }
}
