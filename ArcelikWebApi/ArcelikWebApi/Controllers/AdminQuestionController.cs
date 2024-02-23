using ArcelikWebApi.Data;
using ArcelikWebApi.Models;
using ArcelikWebApi.Models.Quiz;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArcelikWebApi.Controllers
{
    [Route("api/[controller]")]
    public class AdminQuestionController : ControllerBase
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public AdminQuestionController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // POST api/values
        [HttpPost("postquestion")]
        public async Task<IActionResult> Post([FromBody] CreateQuestionDTO questionDTO)
        {
            var LastQuestionId = await _applicationDbContext.Questions
                                   .Select(q => q.QuestionID)
                                   .OrderByDescending(q => q)
                                   .FirstOrDefaultAsync();


            //This part uploads question to database
            var questions = new Questions
            {
                QuestionText = questionDTO.QuestionText,
                QuestionType = questionDTO.QuestionType,
            };

            //Add the new question to the context
            _applicationDbContext.Questions.Add(questions);

            // Save changes to the database
            await _applicationDbContext.SaveChangesAsync();


            //This part uploads choices to database
            switch (questionDTO.QuestionType)
            {
                case "MultipleChoiceAndAnswers":
                case "MultipleChoice":
                case "TrueFalse":
                case "Sorting":

                    foreach (var choice in questionDTO.Choices)
                    {
                        var choices = new Choices
                        {
                            QuestionID = LastQuestionId + 1,
                            ChoiceText = choice
                        };

                        //Add the new question to the context
                        _applicationDbContext.Choices.Add(choices);

                    }
                    // Save changes to the database
                    await _applicationDbContext.SaveChangesAsync();

                    break;

                default:

                    break;

            }


            //This part uploads answers to database
            switch (questionDTO.QuestionType)
            {
                //Correct answersın array şeklinde gelmesi gerekiyor.[ankara,istanbul] [1,2,3] [3,2,1] 10 11 12  121110
                //query yaparken tüm choicelere bakmasın sadece question id ile ilgili yerlere baksın
                case "Sorting":

                    int concatenatedAnswerIds = 0;

                    foreach (var answer in questionDTO.CorrectAnswers)
                    {
                        var answerid = await _applicationDbContext.Choices
                        .Where(c => c.ChoiceText == answer && c.QuestionID == LastQuestionId + 1)
                        .Select(c => c.ChoiceID)
                        .FirstOrDefaultAsync();

                        concatenatedAnswerIds = int.Parse(concatenatedAnswerIds.ToString() + answerid.ToString());
                    }
                    var correctSorting = new CorrectSorting
                    {
                        QuestionID = LastQuestionId + 1,
                        SortingOrder = concatenatedAnswerIds,
                        SortingScore = 10
                    };

                    _applicationDbContext.CorrectSorting.Add(correctSorting);

                    // Save changes to the database
                    await _applicationDbContext.SaveChangesAsync();

                    break;

                case "FillInTheBlank":

                    var correctText = new CorrectText
                    {
                        QuestionID = LastQuestionId + 1,
                        CorrectTextAnswer = questionDTO.CorrectAnswers[0],
                        TextScore = 10
                    };

                    _applicationDbContext.CorrectText.Add(correctText);
                    // Save changes to the database
                    await _applicationDbContext.SaveChangesAsync();

                    break;

                case "MultipleChoiceAndAnswers":
                case "MultipleChoice":
                case "TrueFalse":

                    foreach (var answer in questionDTO.CorrectAnswers)
                    {
                        var correctanswerid = await _applicationDbContext.Choices
                        .Where(c => c.ChoiceText == answer && c.QuestionID == LastQuestionId + 1)
                        .Select(c => c.ChoiceID)
                        .FirstOrDefaultAsync();

                        if (correctanswerid == 0)
                        {
                            continue;
                        }

                        var correctChoices = new CorrectChoices
                        {
                            QuestionID = LastQuestionId + 1,
                            ChoiceID = correctanswerid,
                            PartialScore = 10
                        };

                        //Add the new question to the context
                        _applicationDbContext.CorrectChoices.Add(correctChoices);

                    }
                    // Save changes to the database
                    await _applicationDbContext.SaveChangesAsync();

                    break;

            }

            return Ok(new { success = true, message = "New question added to database" });

        }


    }
}