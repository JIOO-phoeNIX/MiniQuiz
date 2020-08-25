using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniQuiz.DataAccess.Models;
using MiniQuiz.DataAccess.Repositories.Abstract;
using MiniQuiz.Models;

namespace MiniQuiz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersRepository usersRepository;
        private readonly IOptionsRepository optionsRepository;
        private readonly IQuestionsRepository questionsRepository;
        private readonly IUserAnswersRepository userAnswersRepository;

        public HomeController(ILogger<HomeController> logger, IUsersRepository usersRepository, IOptionsRepository optionsRepository,
            IQuestionsRepository questionsRepository, IUserAnswersRepository userAnswersRepository)
        {
            _logger = logger;
            this.usersRepository = usersRepository;
            this.optionsRepository = optionsRepository;
            this.questionsRepository = questionsRepository;
            this.userAnswersRepository = userAnswersRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeIndexViewModel data)
        {
            if (ModelState.IsValid)
            {
                var user = await usersRepository.GetByEmail(data.Email);

                if (user == null)
                {
                    Users userToCreate = new Users
                    {
                        Email = data.Email
                    };

                    var createdUser = await usersRepository.Create(userToCreate);
                    return RedirectToAction("Quiz", new { id = createdUser.UserId });
                }
                else
                {
                    return RedirectToAction("Quiz", new { id = user.UserId });
                }
            }

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Quiz(int? id)
        {
            var user = await usersRepository.Get(id);
            if (user == null)
                return RedirectToAction("Index");

            var allUserAnswers = userAnswersRepository.GetByUserId(id);
            var allQuestions = questionsRepository.GetAll();

            if (allUserAnswers.Count < allQuestions.Count)
            {
                var questionOptions = optionsRepository.GetByQuestionId(allQuestions[allUserAnswers.Count].QuestionId);
                HomeQuizViewModel viewModel = new HomeQuizViewModel
                {
                    Question = allQuestions[allUserAnswers.Count],
                    Options = new List<Option>
                    {
                        new Option{Id = 1, OptionText = questionOptions[0].OptionText },
                        new Option{Id = 2, OptionText = questionOptions[1].OptionText },
                        new Option{Id = 3, OptionText = questionOptions[2].OptionText },
                        new Option{Id = 4, OptionText = questionOptions[3].OptionText }
                    },
                    QuestionId = allQuestions[allUserAnswers.Count].QuestionId
                };
                ViewBag.QuestionNumber = allUserAnswers.Count + 1;
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Result", new { id });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Quiz(int? id, HomeQuizViewModel data)
        {
            if (ModelState.IsValid)
            {
                var userAnswer = new UserAnswers
                {
                    OptionChosen = data.ChosenOption,
                    UserId = id,
                    QuestionId = data.QuestionId
                };

                await userAnswersRepository.Create(userAnswer);

                return RedirectToAction("Quiz", new { id });
            }

            var allUserAnswers = userAnswersRepository.GetByUserId(id);
            var allQuestions = questionsRepository.GetAll();
            var questionOptions = optionsRepository.GetByQuestionId(allQuestions[allUserAnswers.Count].QuestionId);

            data.Question = allQuestions[allUserAnswers.Count];
            data.Options = new List<Option>
            {
                new Option{Id = 1, OptionText = questionOptions[0].OptionText },
                new Option{Id = 2, OptionText = questionOptions[1].OptionText },
                new Option{Id = 3, OptionText = questionOptions[2].OptionText },
                new Option{Id = 4, OptionText = questionOptions[3].OptionText }
            };
            data.QuestionId = allQuestions[allUserAnswers.Count].QuestionId;
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Result(int? id)
        {
            var user = await usersRepository.Get(id);
            if (user == null)
                return RedirectToAction("Index");

            var allQUestions = questionsRepository.GetAll();         
            var allUserAnswers = userAnswersRepository.GetByUserId(id);

            if (allQUestions.Count == 0)
                return RedirectToAction("Index");

            if (allQUestions.Count != allUserAnswers.Count)
                return RedirectToAction("Quiz", new { id });

            var resultList = new List<Result>();

            for (int i = 0; i < allQUestions.Count; i++)
            {
                var optionList = optionsRepository.GetByQuestionId(allQUestions[i].QuestionId);
                resultList.Add(new Result
                {
                    QuestionText = allQUestions[i].QuestionText,
                    CorrectOption = optionList[allQUestions[i].CorrectOption - 1].OptionText,
                    ChosenOption = optionList[allUserAnswers[i].OptionChosen.Value - 1].OptionText,
                    IsCorrect = allQUestions[i].CorrectOption == allUserAnswers[i].OptionChosen.Value,
                    Id = i + 1
                });
            }

            var totalCorrect = 0;
            foreach (var result in resultList)
            {
                if (result.IsCorrect)
                    totalCorrect++;
            }

            var viewModel = new HomeResultViewModel
            {
                Results = resultList,
                Email = user.Email,
                TotalCorrect = totalCorrect
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
