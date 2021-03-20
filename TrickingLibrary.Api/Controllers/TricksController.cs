using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrickingLibrary.Api.Models;
using TrickingLibrary.Data;

namespace TrickingLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/tricks")]
    public class TricksController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public TricksController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        // /api/tricks
        [HttpGet]
        public IEnumerable<Trick> All() => _ctx.Tricks.ToList();

        // /api/tricks/{id}
        [HttpGet("{id}")]
        public Trick Get(int id) => _ctx.Tricks.FirstOrDefault(x => x.Id.Equals(id));

        [HttpGet("{trickId}")]
        public IEnumerable<Submission> GetSub(int trickId) =>
            _ctx.Submissions.Where(x => x.TrickId.Equals(trickId)).ToList();

        // /api/tricks
        [HttpPost]
        public async Task<Trick> Create([FromBody] Trick trick)
        {
            _ctx.Add(trick);
            await _ctx.SaveChangesAsync();
            return trick;
        }

        // /api/tricks
        [HttpPut]
        public async Task<Trick> Update([FromBody] Trick trick)
        {
            if (trick.Id == 0)
            {
                return null;
            }

            _ctx.Add(trick);
            await _ctx.SaveChangesAsync();
            return trick;
        }

        // /api/tricks/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}