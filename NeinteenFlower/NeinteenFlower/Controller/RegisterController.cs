using NeinteenFlower.Factory;
using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class RegisterController
    {
        RegisterHandler handler = new RegisterHandler();
        public RegisterController() { }

        public string Register(string email, string password, string name, string birthDate, 
                               bool isMale, bool isFemale, string phoneNumber, string address)
        {
            bool isEmailExist = handler.CheckEmailExist(email);

            string emailValidationResult = this.CheckEmail(email, isEmailExist);
            string passwordValidationResult = this.CheckPassword(password);
            string nameValidationResult = this.CheckName(name);
            string ageValidationResult = this.CheckAge(birthDate);
            string genderValidationResult = this.CheckGender(isMale, isFemale);
            string phoneNumberValidationResult = this.CheckPhoneNumber(phoneNumber);
            string addressValidationResult = this.CheckAddress(address);

            if(emailValidationResult != "")
            {
                return emailValidationResult;
            }
            else if (passwordValidationResult != "")
            {
                return passwordValidationResult;
            }
            else if (nameValidationResult != "")
            {
                return nameValidationResult;
            }
            else if (ageValidationResult != "")
            {
                return ageValidationResult;
            }
            else if (genderValidationResult != "")
            {
                return genderValidationResult;
            }
            else if(phoneNumberValidationResult != "")
            {
                return phoneNumberValidationResult;
            }
            else if(addressValidationResult != "")
            {
                return addressValidationResult;
            }

            //Register
            handler.InsertMember(
                MemberFactory.shared.makeMember(
                    email, password, name, this.GenerateCorrectBirthdateFormat(birthDate),
                    this.GenerateGenderFormat(isMale, isFemale), phoneNumber, address
                )
            );

            return "";
        }

        public string CheckEmail(string email, bool isEmailExist)
        {
            if (email.Length == 0)
            {
                return "Email cannot be empty.";
            }
            else if (!email.EndsWith(".com"))
            {
                return "Email must end with '.com'.";
            }
            else if (!email.Contains("@"))
            {
                return "Email must include at least 1 '@'.";
            }
            else if (!email.Contains("."))
            {
                return "Email must include at least 1 '.'.";
            }
            else if (email.StartsWith("@"))
            {
                return "Email must not start with '@'.";
            }
            else if (email.StartsWith("."))
            {
                return "Email must not start with '.'.";
            }
            else if (isEmailExist)
            {
                return "Email already exist.";
            }
            for (var i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    if (email[i + 1] == '.')
                    {
                        return "'.' must not be after '@'.";
                    }
                }
            }

            return "";
        }

        public string CheckPassword(string password)
        {
            if(password.Length < 3 || password.Length > 20)
            {
                return "Password must be at least 3 characters and maximum of 20 characters.";
            }
            return "";
        }

        public string CheckName(string name)
        {
            if (name.Length < 3 || name.Length > 20)
            {
                return "Name must be at least 3 characters and maximum of 20 characters.";
            }

            for(int i=0;i<name.Length;i++)
            {
                if(name[i] >= '0' && name[i] <= '9')
                {
                    return "Name must be letter.";
                }
            }

            return "";
        }

        public string CheckAge(string birthDate)
        {
            if(birthDate.Equals(""))
            {
                return "Please fill your birthdate.";
            }

            var dateSplit = birthDate.Split('-');
            int day = -1,
                month = -1,
                year = -1;

            try
            {
                day = Int32.Parse(dateSplit[2]);
                month = Int32.Parse(dateSplit[1]);
                year = Int32.Parse(dateSplit[0]);
            }
            catch
            {
                day = -1;
                month = -1;
                year = -1;
            }

            if(day == -1 || month == -1 || year == -1)
            {
                return "Please fill with valid birthdate.";
            }

            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var currentYear = Int32.Parse(currentDate.Split('-')[2]);
            var currentMonth = Int32.Parse(currentDate.Split('-')[1]);
            var currentDay = Int32.Parse(currentDate.Split('-')[0]);

            if ((currentYear - year) == 17 && currentMonth == month && day > currentDay)
            {
                return "You must be at least 17 years old.";
            }
            else if ((currentYear - year) == 17 && currentMonth < month)
            {
                return "You must be at least 17 years old.";
            }
            else if ((currentYear - year) < 17)
            {
                return "You must be at least 17 years old.";
            }
            return "";
        }

        public string CheckGender(bool isMale, bool isFemale)
        {
            if(!isMale && !isFemale)
            {
                return "Please choose your gender.";
            }
            return "";
        }
        public string CheckPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Equals(""))
            {
                return "Please fill your phone number.";
            }
            for(int i=0;i<phoneNumber.Length;i++)
            {
                if(phoneNumber[i] < '0' || phoneNumber[i] > '9')
                {
                    return "Phone number must be numeric";
                }
            }
            return "";
        }
        public string CheckAddress(string address)
        {
            if (address.Equals(""))
            {
                return "Please fill your address.";
            }
            else if (!address.Contains("Street"))
            {
                return "Address must contain the word Street.";
            }
            return "";
        }

        public string GenerateCorrectBirthdateFormat(string birthDate)
        {
            var dateSplit = birthDate.Split('-');

            string correctFormat = dateSplit[2] + "-" + dateSplit[1] + "-" + dateSplit[0];
            return correctFormat;
        }

        public string GenerateGenderFormat(bool isMale, bool isFemale)
        {
            if(isMale && !isFemale)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }
    }
}