using EducationCenter6.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter6.Common.Objects
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public RoleEnum Role { get; set; }

        public int Position { get; set; }

        public int Age { get; set; }


        public int GetAge(DateTime dateOfBirth)
        {
            int age = 0;
            var currentYear = DateTime.Now.Year;
            var yearOfBirth = dateOfBirth.Year;
            age = currentYear - yearOfBirth;
            return age;
        }
        /// <summary>
        /// tinh tuoi du ngay thang nam sinh nhap vao
        /// </summary>
        /// <param name="dateOfBirth">Chuoi ngay thang nam sinh</param>
        /// <returns>Tuoi (age)</returns>
        public int GetAgeFromString(string dateOfBirth = "30/05/1983")
        {
            int age = 0;
            try
            {
                //Step 1: Lay nam hien tai
                var currentYear = DateTime.Now.Year;

                //Step 2: Ep kieu nam cho du lieu dau vao
                var dateOfBirth2 = DateTime.Parse(dateOfBirth);
                var yearOfBirth = dateOfBirth2.Year;
                age = currentYear - yearOfBirth;

                //TODO: Coi lai nha may cha noi
                string stringNumber = "123";
                int number = int.Parse(stringNumber);
                float numberFloat = 123.45F;
                double numberDouble = 123.45D;
                decimal numberDecimal = 3.141628m;

                var tempString = stringNumber + ". Sinh ngay " + dateOfBirth;    
                var numberInt = (int)numberFloat;
            }
            catch (Exception ex)
            {

            }
            
            return age;
        }

        public string GetNameFromFullName(string fullName)
        {
            string name = "";
            //var length = fullName.Length;
            //int stopIndex = 0;
            //for (int i = length - 1; i > 0; i--) {
            //    var charInString = fullName[i];
            //    if (charInString == ' ')
            //    {
            //        stopIndex = i;
            //        break;
            //    }
            //}
            //name = fullName.Substring(stopIndex, length - stopIndex - 1);

            var arraySubstring = fullName.Split(' ');
            if (arraySubstring.Length > 0) { 
                name = arraySubstring[arraySubstring.Length - 1];
            }
            return name;
        }
    }
}
