
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using pan_pets.core;

namespace pan_pets.api.Controllers {
    [Route ("api/[controller]")]
    public class PetsController : Controller {
        private IPetsRepository Repository { get; }

        public PetsController (IPetsRepository repository) {
            Repository = repository;
        }

        // GET api/pets
        [HttpGet]
        public List<Pet> Get () {
            return Repository.GetAll ();
        }

        // GET api/pets/guid-here-000-0000-0000
        [HttpGet ("{id}")]
        public Pet Get (string id) {
            return Repository.Get (id);
        }

        // POST api/Pets
        [HttpPost]
        public ValidationResult Post ([FromBody] Pet value) {
            if (value == null) {
                throw new ArgumentNullException ("value");
            }
            value.Id = Guid.NewGuid().ToString();
            return Repository.Save (value);
        }

        // PUT api/Pets/guid-here-0000-000-000
        [HttpPut ("{id}")]
        public ValidationResult Put (string id, [FromBody] Pet value) { 
            
            if (string.IsNullOrWhiteSpace(id)) {
                throw new ArgumentNullException ("id");
            }
            if (!Repository.HasId(id)) {
                throw new ArgumentException($"No pet with id {id} exists.");
            }
            if (value == null) {
                throw new ArgumentNullException ("value");
            }
            return Repository.Save(value);
        }
    }
}