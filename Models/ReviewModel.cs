using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTauranter.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Display(Name = "Reviewer Name: ")]
        [Required(ErrorMessage="Reviewer Name is required!")]
        public string ReviewerName { get; set; }

        [Display(Name = "Restaurant Name: ")]
        [Required(ErrorMessage="Restaurant Name is required!")]
        public string RestaurantName { get; set; }

        [Display(Name = "Review: ")]
        [Required(ErrorMessage="Review is required!")]
        [MinLength(10, ErrorMessage = "Review must contain at least 10 characters!")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of visit: ")]
        [Required(ErrorMessage="Date is required!")]
        [CurrentDate(ErrorMessage = "Date must be before current date!")]
        public DateTime ReviewDate { get; set; } = DateTime.Now;

        [Display(Name = "Helpful: ")]
        public int Helpful { get; set; } = 0;

        [Display(Name = "Unhelpful: ")]
        public int Unhelpful { get; set; } = 0;

        [Display(Name = "Stars: ")]
        [Required(ErrorMessage="Rating is required!")]
        public int Stars { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
    
    public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if(dt < DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
    
}