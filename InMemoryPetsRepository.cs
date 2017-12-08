using System;
using System.Collections.Generic;
using System.Linq;
using pan_pets.core;

namespace pan_pets.api {
    public class InMemoryPetsRepository : IPetsRepository {

        private Dictionary<string, Pet> _pets = new Dictionary<string, Pet> ();

        public InMemoryPetsRepository () {
            SeedPetsData ();
        }

        private void SeedPetsData () {
            var id = "d2838acb-2a29-42fe-9c38-cda9ec5cfd82";
            _pets.Add (id, new Pet { Type = PetType.Dog, Id = id, Name = "Tank" });
            id = "9cdeecd3-9ff9-44f7-b330-69236f2d046d";
            _pets.Add (id, new Pet { Type = PetType.Dog, Id = id, Name = "Owen" });
            id = "736dd077-f65f-47bb-ad5e-7677b4f4bf56";
            _pets.Add (id, new Pet { Type = PetType.Dog, Id = id, Name = "Bert" });
            id = "7c1d518c-fd4b-4283-973f-4d3ccc8d3bc9";
            _pets.Add (id, new Pet { Type = PetType.Cat, Id = id, Name = "Wall-E" });
            id = "0aea7d8d-9fe2-4180-ae60-21d89e22b36d";
            _pets.Add (id, new Pet { Type = PetType.Pig, Id = id, Name = "Wendell" });
            id = "ea4952a9-c2ab-45d4-9952-32d59d71c5a9";
            _pets.Add (id, new Pet { Type = PetType.Pig, Id = id, Name = "Ginger" });
        }

        public Pet Get (string id) {
            try
            {
                return _pets[id];
            } catch(KeyNotFoundException) {
                throw new PetNotFoundException();
            }
            
        }
        
        public List<Pet> GetAll () {
            return _pets.Values.ToList ();
        }

        public ValidationResult Save (Pet pet) {
            var validationResult = pet.Validate ();
            if (!validationResult.IsValid) {
                return validationResult;
            }
            _pets[pet.Id] = pet;
            return new ValidationResult { PetId = pet.Id };
        }

        public bool HasId(string id)
        {
            return _pets.ContainsKey(id);
        }
    }
}