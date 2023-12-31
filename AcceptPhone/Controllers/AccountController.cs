﻿using AcceptPhone.Models;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Windows.Forms;

namespace AcceptPhone.Controllers
{

    public class AccountController : Controller
    {
        // Acción para mostrar el formulario de registro
        public ActionResult Register()
        {
            return View();
        }

        // Acción para procesar el formulario de registro
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            // Aquí puedes agregar la lógica de registro, como guardar el usuario en la base de datos
            // y redirigirlo a una página de inicio de sesión o confirmación.
            

            string cs = "DataSource = localhost; InitialCatalog = Accephone";

            string SQL = "INSERT INTO Usuarios (IdUsuario, Correo , Clave )"
                + "VALUES (" + "1" + "," + model.Email + " , " + model.Password + " );";

            SqlConnection cone = new SqlConnection(cs);


            cone.Open();
            SqlCommand command = new SqlCommand(SQL, cone);
            SqlDataReader reader = command.ExecuteReader();
            MessageBox.Show(reader.Read().ToString());

            return RedirectToAction("Login", "Account"); // Redirige al usuario a la página de inicio de sesión
        }

        // Otras acciones, como Login, Logout, etc., pueden ir aquí
    }

}