using learn_v2.Models;
using Microsoft.AspNetCore.Mvc;


namespace learn_v2.Controllers
{
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        private readonly PlayerRepository playerRepository;
        public PlayerController(PlayerRepository _playerRepository)
        {
            playerRepository = _playerRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(playerRepository.GetPlayerList());
        }
        [HttpGet("{id}")]
        public IActionResult PlayerDetail(int id)
        {
            return Ok(playerRepository.GetPlayer(id));
        }
        [HttpGet("CreatePlayer/{name}")]
        public IActionResult CreatePlayer(string name)
        {
            return Ok(playerRepository.CreatePlayer(name));
        }
    }
}
