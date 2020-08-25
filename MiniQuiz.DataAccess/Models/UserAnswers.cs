using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiniQuiz.DataAccess.Models
{
    /// <summary>
    /// This table stores the details of each question i.e the option chosen for each question answered
    /// </summary>
    public class UserAnswers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAnswerId { get; set; }

        [Required]
        public int? UserId { get; set; }

        [Required]
        public int? QuestionId { get; set; }

        [Required]
        public int? OptionChosen { get; set; }
    }
}
