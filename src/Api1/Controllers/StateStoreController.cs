using Api1.Models;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateStoreController : ControllerBase
    {
        private readonly DaprClient _dapr;
        private readonly ILogger<StateStoreController> _logger;

        public StateStoreController(
            DaprClient dapr,
            ILogger<StateStoreController> logger)
        {
            _dapr = dapr;
            _logger = logger;
        }

        /// <summary>
        /// ״̬�洢
        /// </summary>
        [HttpPost]
        public async void Post()
        {
            await _dapr.SaveStateAsync("statestore", "student", new Student
            {
                Name = "����",
                Age = 50
            });
        }


        [HttpGet]
        public async Task<Student> Get()
        {
            return await _dapr.GetStateAsync<Student>("statestore", "student");
        }
    }

}