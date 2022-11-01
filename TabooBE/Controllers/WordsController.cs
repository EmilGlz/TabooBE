using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabooBE.Contracts;

namespace TabooBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private IWordsService _wordsService;
        private IPendingWordsService _pendingWordsService;

        public WordsController(IWordsService wordsService, IPendingWordsService pendingWordsService)
        {
            _wordsService = wordsService;
            _pendingWordsService = pendingWordsService;
        }

        public IActionResult AddWord()
        {
            return Ok();
        }

        public IActionResult GetRandomWord()
        {
            return Ok();
        }
    }
}
