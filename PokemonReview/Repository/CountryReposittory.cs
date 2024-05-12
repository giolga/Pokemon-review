﻿using AutoMapper;
using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository
{
    public class CountryReposittory : ICountryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CountryReposittory(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c =>  c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Country> GetOwnersFromCountry(int countryId)
        {
            //(ICollection<Country>) added later!
            return (ICollection<Country>)_context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }
    }
}