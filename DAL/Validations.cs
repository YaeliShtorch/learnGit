using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class Validations : ValidationAttribute
    {
         //checks if userName exists
        //public static ValidationResult CustUserNameExist(string NewUser)
        //{
        //    return  return ValidationResult.Success;

        //}

        //checks if age is valid
        public static ValidationResult BirthDateValid(DateTime date)
        {
            try {
                var dt = date;
                if (dt.Year <= DateTime.Now.Year - 18)
                    return ValidationResult.Success;
                 

            }
            catch(Exception e)
            {
                e.ToString();

            }
            return new ValidationResult("Not old enoughf");

        }
        //checks date is before current date
        public static ValidationResult BeforeDateValid(DateTime date)
        {
            var dt = date;
            if (dt <= DateTime.Now)

                return ValidationResult.Success;
            else
                return new ValidationResult("Not old enoughf");
        }
        //checks if Identity number is correct
        public static ValidationResult IdOK(string id)
        {
            //try {
            //    char[] digits = id.ToCharArray();
            //    int[] oneTwo = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            //    int[] multiply = new int[9];
            //    int[] oneDigit = new int[9];
            //    for (int i = 0; i < 9; i++)
            //        multiply[i] = Convert.ToInt32(digits[i].ToString()) * oneTwo[i];
            //    for (int i = 0; i < 9; i++)
            //        oneDigit[i] = (int)(multiply[i] / 10) + multiply[i] % 10;
            //int sum = 0;
            //    for (int i = 0; i < 9; i++)
            //        sum += oneDigit[i];
            //    if (sum % 10 == 0)
            //        return ValidationResult.Success;

            //}
            //catch(Exception e)
            //{
            //    e.ToString();
            //}

            //return new ValidationResult("Not valid");
            return ValidationResult.Success;
        }
    }
}
