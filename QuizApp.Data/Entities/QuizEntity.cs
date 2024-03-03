using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Entities
{
    public class QuizEntity:BaseEntity
    {
        public string QuizText { get; set; }

        public string Description { get; set;}

        public List<QuestionEntity> Questions { get; set; }



    }
}
