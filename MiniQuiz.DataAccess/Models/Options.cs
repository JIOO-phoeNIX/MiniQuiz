using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiniQuiz.DataAccess.Models
{
    /// <summary>
    /// This table stores the Options to the Questions
    /// </summary>
    public class Options
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OptionsId { get; set; }

        [Required(ErrorMessage = "Option text is required")]
        public string OptionText { get; set; }

        [Required]
        public int QuestionId { get; set; }
    }
}
