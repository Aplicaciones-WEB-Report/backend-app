using Jobsy.Recruiter.Domain.Model.Aggregates;
using Jobsy.Recruiter.Domain.Model.Commands.EvaluationCommands;
using Jobsy.Recruiter.Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jobsy.Recruiter.Interfaces.Rest.Controllers;

 [ApiController]
    [Route("api/[controller]")]
    public class EvaluationsController : ControllerBase
    {
        private readonly IEvaluationCommandRepository _commandRepository;
        private readonly IEvaluationQueryRepository _queryRepository;

        public EvaluationsController(IEvaluationCommandRepository commandRepository, IEvaluationQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evaluation = await _queryRepository.GetByIdAsync(id);
            if (evaluation == null) return NotFound();
            return Ok(evaluation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEvaluationCommand command)
        {
            var evaluation = new Evaluation()
            {
                InterviewId = command.InterviewId,
                CandidateId = command.CandidateId,
                Rating = command.Rating,
                Comments = command.Comments,
                EvaluationDate = command.EvaluationDate
            };

            var result = await _commandRepository.AddAsync(evaluation);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEvaluationCommand command)
        {
            var evaluation = await _queryRepository.GetByIdAsync(id);
            if (evaluation == null) return NotFound();

            evaluation.Rating = command.Rating;
            evaluation.Comments = command.Comments;
            evaluation.EvaluationDate = command.EvaluationDate;
            evaluation.Auditoria.UpdatedAt = DateTime.UtcNow;

            await _commandRepository.UpdateAsync(evaluation);
            return Ok(evaluation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var evaluation = await _queryRepository.GetByIdAsync(id);
            if (evaluation == null) return NotFound();

            await _commandRepository.DeleteAsync(evaluation);
            return NoContent();
        }
    }
