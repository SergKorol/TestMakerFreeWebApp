using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFreeWebApp_Chapter_01.ViewModels;

namespace TestMakerFreeWebApp_Chapter_01.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        // GET
        [HttpGet("Latest/{num}")]
        public IActionResult Latest(int num = 10)
        {
            var sampleQuizzes = new List<QuizViewModel>
            {
                new QuizViewModel()
                {
                    Id = 1,
                    Title = "Which Shingeki No Kyojin character are you?",
                    Description = "Anime-related personality test",
                    CreatedData = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                }
            };


            for (var i = 2; i <= num; i++)
            {
                sampleQuizzes.Add(new QuizViewModel()
                {
                    Id = i,
                    Title = $"Sample Quiz {i}",
                    Description = "This is a sample quiz",
                    CreatedData = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }
            return new JsonResult(
                sampleQuizzes,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                }
            );
        }
        
        [HttpGet("ByTitle/{num:int?}")]
        public IActionResult ByTitle(int num = 10)
        {
            var sampleQuizzes = ((JsonResult) Latest(num)).Value as List<QuizViewModel>;
            
            return new JsonResult(
                (sampleQuizzes ?? throw new InvalidOperationException()).OrderBy(t => t.Title),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                }
                );
        }
        
        [HttpGet("Random/{num:int?}")]
        public IActionResult Random(int num = 10)
        {
            var sampleQuizzes = ((JsonResult) Latest(num)).Value as List<QuizViewModel>;
            
            return new JsonResult(
                (sampleQuizzes ?? throw new InvalidOperationException()).OrderBy(t => Guid.NewGuid()),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                }
            );
        }
    }
}