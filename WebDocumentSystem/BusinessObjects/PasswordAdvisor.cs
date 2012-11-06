using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessObjects
{
    public enum PasswordScore
    {
        Blank,
        VeryWeak,
        Weak,
        Medium,
        Strong,
        VeryStrong
    }

    public class PasswordAdvisor
    {
        public static PasswordScore CheckStrength(string password)
        {
            int score = 1;

            if (password.Length < 1)
                return PasswordScore.Blank;
            if (password.Length < 4)
                return PasswordScore.VeryWeak;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"\d+").Success)
                score++;
            if (Regex.Match(password, @"[a-z]").Success &&
                Regex.Match(password, @"[A-Z]").Success)
                score++;
            if (Regex.Match(password, @".[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]").Success)
                score++;

            return (PasswordScore)score;
        }
    }
}
