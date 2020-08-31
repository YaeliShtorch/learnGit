﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    class Validations : ValidationAttribute
    {

        //public static ValidationResult CustUserNaneExist(string NewUser)
        //{


        //}
        public static ValidationResult BirthDateValid(DateTime date)
        {
            var dt = date;
            if (dt.Year <= DateTime.Now.Year - 18)

                return ValidationResult.Success;
            else
                return new ValidationResult("Not old enoughf");
        }
        public static ValidationResult BeforeDateValid(DateTime date)
        {
            var dt = date;
            if (dt <= DateTime.Now)

                return ValidationResult.Success;
            else
                return new ValidationResult("Not old enoughf");
        }
        public static ValidationResult IdOK(string id)
        {
            char[] digits = id.ToCharArray();
            int[] oneTwo = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int[] multiply = new int[9];
            int[] oneDigit = new int[9];
            for (int i = 0; i < 9; i++)
                multiply[i] = Convert.ToInt32(digits[i].ToString()) * oneTwo[i];
            for (int i = 0; i < 9; i++)
                oneDigit[i] = (int)(multiply[i] / 10) + multiply[i] % 10;
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += oneDigit[i];
            if (sum % 10 == 0)
                return ValidationResult.Success;
            else
                return new ValidationResult("Not valid");

        }
    }
}
