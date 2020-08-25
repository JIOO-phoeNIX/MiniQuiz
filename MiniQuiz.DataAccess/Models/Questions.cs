using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiniQuiz.DataAccess.Models
{
    /// <summary>
    /// The question table
    /// </summary>
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Question is required")]
        [Display(Name = "Question")]
        public string QuestionText { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        [Display(Name = "Select the correct option")]
        public int CorrectOption { get; set; }
    }
}
