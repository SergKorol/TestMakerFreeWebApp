using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFreeWebApp_Chapter_01.ViewModels;

namespace TestMakerFreeWebApp_Chapter_01.Controllers
{
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        [HttpGet("All/{quizId}")]
        public IActionResult All(int quizId)
        {
            var sampleResults = new List<ResultViewModel>
            {
                new ResultViewModel()
                {
                    Id = 1,
                    QuizId = quizId,
                    Text = "What do you value most in your life?",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                }
            };

            for (var i = 2; i <= 5; i++)
            {
                sampleResults.Add(new ResultViewModel()
                {
                    Id = i,
                    QuizId = quizId,
                    Text = $"Sample Question {i}",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            return new JsonResult(sampleResults, new JsonSerializerSettings() {Formatting = Formatting.Indented});
        }
    }
}