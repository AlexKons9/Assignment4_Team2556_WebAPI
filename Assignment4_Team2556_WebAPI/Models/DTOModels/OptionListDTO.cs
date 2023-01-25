using System.ComponentModel.DataAnnotations;


namespace Assignment4_Team2556_WebAPI.Models.DTOModels
{
    public class OptionListDTO
    {
        public int QuestionId { get; set; }
        [Display(Name = "Option 1 Description")]
        [DataType(DataType.MultilineText)]
   
        public string Description1 { get; set; }
        
        [Display(Name = "Option 2 Description")]
        [DataType(DataType.MultilineText)]
  
        public string Description2 { get; set; }

        [Display(Name = "Option 3 Description")]
        [DataType(DataType.MultilineText)]
  
        public string Description3 { get; set; }

        [Display(Name = "Option 4 Description")]
        [DataType(DataType.MultilineText)]

        public string Description4 { get; set; }
        [Display(Name = "Correct Answer")]
        public int CorrectAnswer { get; set; }

    }
}
