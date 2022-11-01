using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabooBE.Contracts;
using TabooBE.Models.DBModels;
using TabooBE.Models.DTOs.Requests;

namespace TabooBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private IWordsService _wordsService;
        private IPendingWordsService _pendingWordsService;
        private readonly IMapper _mapper;

        public WordsController(IWordsService wordsService, IPendingWordsService pendingWordsService, IMapper mapper)
        {
            _wordsService = wordsService;
            _pendingWordsService = pendingWordsService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetRandomWord")]
        public IActionResult GetRandomWord()
        {
            var res = _wordsService.GetRandomModel();
            return Ok(res);
        }

        [HttpPost]
        [Route("AcceptPendingWord")]
        public IActionResult AcceptPendingWord(string pendingId)
        {
            var pendingWord = _pendingWordsService.GetById(pendingId);
            if (pendingWord == null)
                return NotFound("Word with the id not found");
            _pendingWordsService.RemovePendingWord(pendingId);
            var mappedModel = _mapper.Map<WordDBModel>(pendingWord);
            _wordsService.AddWord(mappedModel);
            return Ok();
        }

        [HttpPost]
        [Route("AddPendingWords")]
        public IActionResult AddPendingWords(WordDTO dto)
        {
            var existingWord = _wordsService.GetWordByHeadText(dto.MainWord);
            if (existingWord != null) 
                return BadRequest("Cannot add this word, as it already exists in the database");
            var mappedModel = _mapper.Map<PendingWordDBModel>(dto);
            var res = _pendingWordsService.AddPendingWord(mappedModel);
            return Ok(res);
        }

        [HttpPost]
        [Route("RemovePendingWord")]
        public IActionResult RemovePendingWord(string Id)
        {
            _pendingWordsService.RemovePendingWord(Id);
            return Ok();
        }
    }
}
