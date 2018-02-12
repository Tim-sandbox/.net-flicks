﻿using AutoMapper;
using CoreTemplate.Accessors.Accessors.Base;
using CoreTemplate.Accessors.Database;
using CoreTemplate.Accessors.Interfaces;
using CoreTemplate.Accessors.Models.DTO;
using CoreTemplate.Accessors.Models.EF;
using CoreTemplate.Accessors.Models.EF.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoreTemplate.Accessors.Accessors
{
    public class MovieGenreAccessor : EntityAccessor<Entity>, IMovieGenreAccessor
    {
        public MovieGenreAccessor(CoreTemplateContext db) : base(db)
        {
        }

        public List<MovieGenreDTO> GetAllByMovie(int movieId)
        {
            var entities = _db.MovieGenres.Where(x => x.MovieId == movieId).ToList();

            var dtos = Mapper.Map<List<MovieGenreDTO>>(entities);

            return dtos;
        }

        public List<MovieGenreDTO> SaveAll(int movieId, List<int> genreIds)
        {
            var entities = _db.MovieGenres.Where(x => x.MovieId == movieId).ToList();

            //Ensure genre list exists to avoid null value errors
            genreIds = genreIds ?? new List<int>();

            //Create new entries from genre list
            var newGenreIds = genreIds.Except(entities.Select(x => x.GenreId));
            var newEntities = newGenreIds.Select(x => new MovieGenre { MovieId = movieId, GenreId = x }).ToList();
            entities.AddRange(newEntities);
            _db.MovieGenres.AddRange(newEntities);

            //Delete existing entries not in genre list
            var entitiesToRemove = entities.Where(x => !genreIds.Contains(x.GenreId));
            entities = entities.Except(entitiesToRemove).ToList();
            _db.MovieGenres.RemoveRange(entitiesToRemove);

            _db.SaveChanges();

            var dtos = Mapper.Map<List<MovieGenreDTO>>(entities);

            return dtos;
        }
    }
}