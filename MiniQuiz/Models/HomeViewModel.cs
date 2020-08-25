using MiniQuiz.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniQuiz.Models
{
    public class HomeIndexViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Enter your email to proceeed")]
        public string Email { get; set; }
    }

    public class HomeQuizViewModel
    {        
        public Questions Question { get; set; }
        
        [Required(ErrorMessage = "Please select the correct option to the question")]
        [Display(Name = "Select the correct option")]
        public int? ChosenOption { get; set; } 

        public List<Option> Options { get; set; }

        public int QuestionId { get; set; }
    }

    public class Option
    {
        public int Id { get; set; }

        public string OptionText { get; set; }
    }

    public class HomeResultViewModel
    {
        public List<Result> Results { get; set; }

        public string Email { get; set; }

        public int TotalCorrect { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public string CorrectOption { get; set; }

        public string ChosenOption { get; set; }

        public bool IsCorrect { get; set; }
    }
}
