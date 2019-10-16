using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using simpsons_net_web_api.Modules;
using simpsons_net_web_api.Dependencies;
using System.Data.SqlClient;


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
                Photo = "",
            },

            new Character{
                FirstName = "Marjorie", 
                SecondName = "Jacqueline", 
                LastName = "Simpson",
                BirthDate = "18 de mayo",
                Age = 34, 
                Description = "Esposa de Homero, Madre de Bart, Lisa y Maggie",
                Photo = ""         
            },

            new Character
            {
                FirstName = "Bartolomeo",
                SecondName = "J.",
                LastName = "Simpson",
                BirthDate = "23 de febrero",
                Age = 10,
                Description = "Hijo mayor de la familia Simpson, hermano de Lisa y Maggie",
                Photo = "",
            },

            new Character
            {
                FirstName = "Lisa",
                SecondName = "Marie",
                LastName = "Simpson",
                BirthDate = "11 de mayo",
                Age = 8,
                Description = "Hija mayor de la familia Simpson, hermana menor de Bart y hemana mayor de Maggie",
                Photo = "",
            },

            new Character
            {
                FirstName = "Margaret",
                SecondName = "Evelyn",
                LastName = "Simpson",
                BirthDate = "12 de enero",
                Age = 1,
                Description = "Hija menor de la famila Simpson, hermana menor de Bart y Lisa",
                Photo = "",
            },

        };

        string connectionString = @"data source=LAPTOP-DD2A6LRV\SQLEXPRESS; initial catalog=db_simpsons; user id=simpsons; password=1234";


        [HttpGet("{id}")]
        public Character GetCharacter(int id)
        {
            return listOfCharacter[id];
        }

        [HttpGet]


        public List<Character> GetCharacterList(int id)
        {
            List<Character> characters = new List<Character>();
        
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from tbl_character", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Character character = new Character
                {
                    Id = reader.GetInt64(reader.GetOrdinal("id")),
                    FirstName = reader.GetString(reader.GetOrdinal("firstName")),
                    SecondName = reader.GetString(reader.GetOrdinal("secondName")),
                    LastName = reader.GetString(reader.GetOrdinal("lastName")),
                    Age = reader.GetInt32(reader.GetOrdinal("age")),
                    BirthDate = reader.GetString(reader.GetOrdinal("birthDate")),
                    Description = reader.GetString(reader.GetOrdinal("descp"))
                };
                characters.Add(character);
            }
            conn.Close();
            return characters;
        }

    }
}