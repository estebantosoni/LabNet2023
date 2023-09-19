using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTO
{
    public class EmployeesDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo Nombre debe contener solo letras.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo Apellido debe contener solo letras.")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "El campo Titulo no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo Titulo debe contener solo letras.")]
        public string Title { get; set; }

        [DataType(DataType.Date, ErrorMessage = "El campo Fecha de contratacion debe ser una fecha válida.")]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? HireDate { get; set; }

        [StringLength(50, ErrorMessage = "El campo Ciudad no puede tener más de 30 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo Ciudad debe contener solo letras.")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "El campo Pais no puede tener más de 30 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo Pais debe contener solo letras.")]
        public string Country { get; set; }

        [RegularExpression(@"^\(\d{1,3}\) \d{3}-\d{4}$", ErrorMessage = "El campo Teléfono debe tener el formato (123) 456-7890.")]
        [DisplayFormat(DataFormatString = "({0:###}) ###-####")]
        public string HomePhone { get; set; }

    }
}
