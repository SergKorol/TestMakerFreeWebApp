using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFreeWebApp_Chapter_01.ViewModels;

namespace TestMakerFreeWebApp_Chapter_01.Controllers
{
    [Route("api/[controller]")]
    public class AnswerController : Controller
    {
        [HttpGet("All/{questionId}")]
        public IActionResult All(int questionId)
        {
            var sampleAnswers = new List<AnswerViewModel>
            {
                new AnswerViewModel()
                {
                    Id = 1,
                    QuestionId = questionId,
                    Text = "Friends and family",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                }
            };

            for (var i = 2; i <= 5; i++)
            {
                sampleAnswers.Add(new AnswerViewModel()
                {
                    Id = i,
                    QuestionId = questionId,
                    Text = $"Sample Answer {i}",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            return new JsonResult(
                sampleAnswers,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
    }
}