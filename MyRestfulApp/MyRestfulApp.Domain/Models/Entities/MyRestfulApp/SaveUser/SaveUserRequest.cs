﻿namespace MyRestfulApp.Domain.Models.Entities.MyRestfulApp.SaveUser
{
    public  class SaveUserRequest
    {
        public string Nombre{ get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
