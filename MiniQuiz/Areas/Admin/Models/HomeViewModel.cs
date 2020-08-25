using MiniQuiz.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniQuiz.Areas.Admin.Models
{
    /// <summary>
    /// This ViewModel is used for the Index View. It contains a List of all the Questions.
    /// </summary>
    public class HomeIndexViewModel
    {
        /// <summary>
        /// Used to get or set all the Questions
        /// </summary>
        public List<Questions> AllQuestions { get; set; }
    }

    /// <summary>
    /// This ViewModel is used for the Create Question View. It holds all the details needed to create the Question.
    /// </summary>
    public class HomeCreateViewModel
    {
        [Required(ErrorMessage = "Question is required")]
        [Display(Name = "Question")]
        [DataType(DataType.MultilineText)]
        public string QuestionText { get; set; }

        [Required(ErrorMessage = "Option 1 is required")]
        [Display(Name = "Option 1 text")]
        public string Option1 { get; set; }

        [Required(ErrorMessage = "Option 2 is required")]
        [Display(Name = "Option 2 text")]
        public string Option2 { get; set; }

        [Required(ErrorMessage = "Option 3 is required")]
        [Display(Name = "Option 3 text")]
        public string Option3 { get; set; }

        [Required(ErrorMessage = "Option 4 is required")]
        [Display(Name = "Option 4 text")]
        public string Option4 { get; set; }

        [Required(ErrorMessage = "Please select the correct option to the question")]
        [Display(Name = "Select the correct option")]
        public int CorrectOption { get; set; }
        
        public IEnumerable<Option> Options { get; set; }
    }

    public class Option
    {
        public int Id { get; set; }

        public string OptionText { get; set; }       
    }

    /// <summary>
    /// This ViewModel is used for the View that is used to Edit a Question.
    /// </summary>
    public class HomeEditViewModel
    {
        [Required]
        public Questions Question { get; set; }
        
        public List<Option> Options { get; set; }

        [Required(ErrorMessage = "Option 1 is required")]
        [Display(Name = "Option 1 text")]
        public Options Option1 { get; set; }
        
        [Required(ErrorMessage = "Option 2 is required")]
        [Display(Name = "Option 2 text")]
        public Options Option2 { get; set; }
        
        [Required(ErrorMessage = "Option 3 is required")]
        [Display(Name = "Option 3 text")]
        public Options Option3 { get; set; }
        
        [Required(ErrorMessage = "Option 4 is required")]
        [Display(Name = "Option 4 text")]
        public Options Option4 { get; set; }
    }
}
