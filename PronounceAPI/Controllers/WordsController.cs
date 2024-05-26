using Microsoft.AspNetCore.Mvc;
using PronounceAPI.Models;
using PronounceAPI.Services;

namespace PronounceAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly WordsService _wordsService;

        public WordsController(WordsService wordsService) => _wordsService = wordsService;

        [HttpGet]
        public async Task<List<Word>> Get() => await _wordsService.GetAsync();

        [HttpGet("{baseWord}")]
        public async Task<ActionResult<Word>> Get(string baseWord)
        {
            var word = await _wordsService.GetAsync(baseWord);

            if (word is null)
            {
                return NotFound();
            }

            return word;
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(Word newWord)
        //{
        //    await _wordsService.CreateAsync(newWord);

        //    return CreatedAtAction(nameof(Get), new { id = newWord.Id }, newWord);
        //}

        //[HttpPut("{id:length(24)}")]
        //public async Task<IActionResult> Update(string id, Word updatedWord)
        //{
        //    var word = await _wordsService.GetAsync(id);

        //    if (word is null)
        //    {
        //        return NotFound();
        //    }

        //    updatedWord.Id = word.Id;

        //    await _wordsService.UpdateAsync(id, updatedWord);

        //    return NoContent();
        //}

        //[HttpDelete("{id:length(24)}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var word = await _wordsService.GetAsync(id);

        //    if (word is null)
        //    {
        //        return NotFound();
        //    }

        //    await _wordsService.RemoveAsync(id);

        //    return NoContent();
        //}
    }
}
