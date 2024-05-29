﻿using APITEST.Data;
using APITEST.Interfaces;
using APITEST.Model;
using Microsoft.EntityFrameworkCore;

namespace APITEST.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(a => a.Id.Equals(ownerId)).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();
            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon
            };
            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon
            };
            _context.Add(pokemonCategory);
            _context.Add(pokemon);
            return Save();
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(predicate => predicate.Id == id).FirstOrDefault();    
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p  => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
           var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);
           if (review.Count() <= 0)
                return 0;
           return ((decimal)review.Sum(r => r.Rating)/ review.Count());
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).Include(a=> a.Reviews).ToList();
        }

        public bool PokemonExists(int pokeid)
        {
           return _context != null && _context.Pokemon.Any(p => p.Id == pokeid);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }
    }
}
