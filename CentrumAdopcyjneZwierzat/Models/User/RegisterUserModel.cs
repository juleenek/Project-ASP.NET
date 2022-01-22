
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.Models.User
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "Podaj swój login.")]
        [StringLength(20, ErrorMessage = "Nazwa użytkownika musi zawierać {2}-{1} znaków", MinimumLength = 6)]
        [RegularExpression("[a-zA-Z0-9]*[^!@%~?:;#$%^&*()/\"']*",
            ErrorMessage = "Login może składać się z wielkich i małych liter oraz cyfr.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane.")]
        [StringLength(40, ErrorMessage = "Imię musi składać się przynajmniej z {2} znaków", MinimumLength = 3)]
        [RegularExpression("[a-zA-Z-]*[^!@%~?:;#$%^&*()/\"0-9']*",
            ErrorMessage = "Imię może składać się z wielkich i małych liter.")]
        [DisplayName("Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        [StringLength(40, ErrorMessage = "Nazwisko musi składać się przynajmniej z {2} znaków", MinimumLength = 2)]
        [RegularExpression("[a-zA-Z-]*[^!@%~?:;#$%^&*()/\"0-9']*",
            ErrorMessage = "Nazwisko może składać się z wielkich i małych liter.")]
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail jest wymagany.")]
        [EmailAddress(ErrorMessage = "Proszę wprowadzić e-mail w poprawnym formacie")]
        [DisplayName("Adres E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Phone]
        [Required(ErrorMessage = "Numer telefonu jest wymagany.")]
        [RegularExpression(@"([0-9]{9})$",
            ErrorMessage = "Numer telefonu musi być zapisany w formacie 9 znaków 0-9")]
        [DisplayName("Numer telefonu")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Data urodzenia jest wymagana.")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format daty.")]
        [DisplayName("Data urodzenia")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany.")]
        [StringLength(255, ErrorMessage = "Za krótki adres zamieszkania.", MinimumLength = 3)]
        [DisplayName("Adres")]
        public string StreetAddress { get; set; }

        [Required]
        [DataType(DataType.PostalCode, ErrorMessage = "Nieprawidłowy kodu pocztowego")]
        [StringLength(10, ErrorMessage = "Za krótki kod pocztowy.", MinimumLength = 4)]
        [DisplayName("Kod pocztowy")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Za krótka nazwa miasta.", MinimumLength = 2)]
        [DisplayName("Nazwa miasta")]
        public string City { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Hasło oraz powtórzone hasło są różne.")]
        public string ConfirmPassword { get; set; }
    }
}
