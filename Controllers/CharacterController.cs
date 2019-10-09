using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using simpsons_net_web_api.Modules;
using simpsons_net_web_api.Dependencies;

namespace simpsons_net_web_api.Controllers
{
    [Route("simpsons/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CharacterController : Character
    {
        List<Character> listOfCharacter => new List<Character>
        {
            new Character
            {
                FirstName = "Homero",
                SecondName = "Jay",
                LastName = "Simpson",
                BirthDate = "12 de mayo",
                Age = 36,
                Description ="Esposo de Marge, Padre de la familia",
                Photo = "https://vignette.wikia.nocookie.net/lossimpson/images/b/bd/Homer_Simpson.png/revision/latest?cb=20100522180809&path-prefix=es",
            },

            new Character{
                FirstName = "Marjorie", 
                SecondName = "Jacqueline", 
                LastName = "Simpson",
                BirthDate = "18 de mayo",
                Age = 34, 
                Description = "Esposa de Homero, Madre de Bart, Lisa y Maggie",
                Photo = "https://vignette.wikia.nocookie.net/lossimpson/images/0/0b/Marge_Simpson.png/revision/latest?cb=20090415001251&path-prefix=es"         
            },

            new Character
            {
                FirstName = "Bartolomeo",
                SecondName = "J.",
                LastName = "Simpson",
                BirthDate = "23 de febrero",
                Age = 10,
                Description = "Hijo mayor de la familia Simpson, hermano de Lisa y Maggie",
                Photo = "https://upload.wikimedia.org/wikipedia/en/a/aa/Bart_Simpson_200px.png",
            },

            new Character
            {
                FirstName = "Lisa",
                SecondName = "Marie",
                LastName = "Simpson",
                BirthDate = "11 de mayo",
                Age = 8,
                Description = "Hija mayor de la familia Simpson, hermana menor de Bart y hemana mayor de Maggie",
                Photo = "https://upload.wikimedia.org/wikipedia/en/e/ec/Lisa_Simpson.png",
            },

            new Character
            {
                FirstName = "Margaret",
                SecondName = "Evelyn",
                LastName = "Simpson",
                BirthDate = "12 de enero",
                Age = 1,
                Description = "Hija menor de la famila Simpson, hermana menor de Bart y Lisa",
                Photo = "https://upload.wikimedia.org/wikipedia/en/9/9d/Maggie_Simpson.png",
            },

        };

        [HttpGet("{id}")]
        public Character GetCharacter(int id)
        {
            return listOfCharacter[id];
        }

        [HttpGet]

        public List<Character> GetCharacterList(int id)
        {
            return listOfCharacter;
        }
    }
}