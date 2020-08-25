using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniQuiz.Areas.Admin.Models;
using MiniQuiz.DataAccess.Models;
using MiniQuiz.DataAccess.Repositories.Abstract;

namespace MiniQuiz.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IQuestionsRepository questionsRepository;
        private readonly IOptionsRepository optionsRepository;
        private readonly IUserAnswersRepository userAnswersRepository;

        public HomeController(IQuestionsRepository questionsRepository, IOptionsRepository optionsRepository,
            IUserAnswersRepository userAnswersRepository)
        {
            this.questionsRepository = questionsRepository;
            this.optionsRepository = optionsRepository;
            this.userAnswersRepository = userAnswersRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                AllQuestions = questionsRepository.GetAll()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new HomeCreateViewModel
            {
                Options = new List<Option>
                {
                    new Option{ Id = 1, OptionText = "Option 1" },
                    new Option{ Id = 2, OptionText = "Option 2" },
                    new Option{ Id = 3, OptionText = "Option 3" },
                    new Option{ Id = 4, OptionText = "Option 4" }
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(HomeCreateViewModel data)
        {
            var allQUestions = questionsRepository.GetAll(); //Get all the Question(s) 

            //Only 10 Questions are allowed at a time
            if (allQUestions.Count >= 10)
            {
                ModelState.AddModelError("", "Oops only 10 questions can be added at the moment");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    //Create the Question Object that is used to Create the Question in the database
                    var question = new Questions
                    {
                        QuestionText = data.QuestionText,
                        CorrectOption = data.CorrectOption
                    };

                    var createdQuestion = await questionsRepository.Create(question);//Create the Question

                    //A list containing the options that will be stored in the database
                    List<Options> optionsList = new List<Options>();

                    //Create a list that stores all the Options the User Created for the Question
                    List<string> optionText = new List<string>
                    {
                        data.Option1,
                        data.Option2,
                        data.Option3,
                        data.Option4
                    };

                    //Add items to the Option list
                    for (int i = 0; i < 4; i++)
                    {
                        optionsList.Add(
                            new Options
                            {
                                OptionText = optionText[i],
                                QuestionId = createdQuestion.QuestionId
                            });
                    }

                    await optionsRepository.Create(optionsList);//Create the Options

                    return RedirectToAction("Index");
                }
            }

            //Error occured while creating, create and return the Option list again
            data.Options = new List<Option>
            {
                new Option{ Id = 1, OptionText = "Option 1" },
                new Option{ Id = 2, OptionText = "Option 2" },
                new Option{ Id = 3, OptionText = "Option 3" },
                new Option{ Id = 4, OptionText = "Option 4" }
            };
            ModelState.AddModelError("", "Error occured while creating please create again");
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return View("QuestionNotFound");

            var question = await questionsRepository.Get(id);//Get the Question

            //redirect to error page if the Question doesn't exist
            if (question == null)
                return View("QuestionNotFound");

            var optionsList = optionsRepository.GetByQuestionId(id);

            var viewModel = new HomeEditViewModel
            {
                Question = question,
                Options = new List<Option>
                {
                    new Option{ Id = 1, OptionText = optionsList[0].OptionText},
                    new Option{ Id = 2, OptionText = optionsList[1].OptionText},
                    new Option{ Id = 3, OptionText = optionsList[2].OptionText},
                    new Option{ Id = 4, OptionText = optionsList[3].OptionText}
                },
                Option1 = optionsList[0],
                Option2 = optionsList[1],
                Option3 = optionsList[2],
                Option4 = optionsList[3]
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HomeEditViewModel data)
        {
            if (ModelState.IsValid)
            {
                await questionsRepository.Update(new Questions
                {
                    CorrectOption = data.Question.CorrectOption,
                    QuestionId = data.Question.QuestionId,
                    QuestionText = data.Question.QuestionText
                });

                List<Options> optionsToUpdate = new List<Options>
                {
                    new Options {OptionsId = data.Option1.OptionsId, OptionText = data.Option1.OptionText, QuestionId = data.Option1.QuestionId},
                    new Options {OptionsId = data.Option2.OptionsId, OptionText = data.Option2.OptionText, QuestionId = data.Option2.QuestionId},
                    new Options {OptionsId = data.Option3.OptionsId, OptionText = data.Option3.OptionText, QuestionId = data.Option3.QuestionId},
                    new Options {OptionsId = data.Option4.OptionsId, OptionText = data.Option4.OptionText, QuestionId = data.Option4.QuestionId}
                };

                optionsRepository.Update(optionsToUpdate);

                return RedirectToAction("Index");
            }

            var optionsList = optionsRepository.GetByQuestionId(data.Question.QuestionId);
            data.Options = new List<Option>
            {
                new Option{ Id = 1, OptionText = optionsList[0].OptionText},
                new Option{ Id = 2, OptionText = optionsList[1].OptionText},
                new Option{ Id = 3, OptionText = optionsList[2].OptionText},
                new Option{ Id = 4, OptionText = optionsList[3].OptionText}
            };

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return View("QuestionNotFound");

            var question = await questionsRepository.Get(id);

            if (question == null)
                return View("QuestionNotFound");

            await questionsRepository.Delete(id);
            await optionsRepository.DeleteByQuestionId(id);
            await userAnswersRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
