﻿using DotNetFlicks.Accessors.Models.EF;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DotNetFlicks.Accessors.Database
{
    public static class SeedingExtensions
    {
        public static void SeedGenres(this ModelBuilder builder)
        {
            var genres = JsonConvert.DeserializeObject<List<Genre>>(File.ReadAllText(@"Config" + Path.DirectorySeparatorChar + "SeedData" + Path.DirectorySeparatorChar + "genres.json"));

            foreach (var genre in genres)
            {
                builder.Entity<Genre>().HasData(genre);
            }
        }

        public static void SeedDepartments(this ModelBuilder builder)
        {
            var departments = JsonConvert.DeserializeObject<List<Department>>(File.ReadAllText(@"Config" + Path.DirectorySeparatorChar + "SeedData" + Path.DirectorySeparatorChar + "departments.json"));

            foreach (var department in departments)
            {
                builder.Entity<Department>().HasData(department);
            }
        }

        public static void SeedPeople(this ModelBuilder builder)
        {
            var people = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(@"Config" + Path.DirectorySeparatorChar + "SeedData" + Path.DirectorySeparatorChar + "people.json"));

            foreach (var person in people)
            {
                builder.Entity<Person>().HasData(person);
            }
        }

        public static void SeedMovies(this ModelBuilder builder)
        {
            var movies = JsonConvert.DeserializeObject<List<Movie>>(File.ReadAllText(@"Config" + Path.DirectorySeparatorChar + "SeedData" + Path.DirectorySeparatorChar + "movies.json"));

            foreach (var movie in movies)
            {
                builder.Entity<Movie>().HasData(movie);
            }
        }

        public static void SeedMovieGenres(this ModelBuilder builder)
        {
            var movieGenres = JsonConvert.DeserializeObject<List<MovieGenre>>(File.ReadAllText(@"Config" + Path.DirectorySeparatorChar + "SeedData" + Path.DirectorySeparatorChar + "movieGenres.json"));
            var id = 1;

            foreach (var movieGenre in movieGenres)
            {
                movieGenre.Id = id++;
                builder.Entity<MovieGenre>().HasData(movieGenre);
            }
        }

        public static void SeedCastMembers(this ModelBuilder builder)
        {
            var castMembers = JsonConvert.DeserializeObject<List<CastMember>>(File.ReadAllText(@"Config" + Path.DirectorySeparatorChar + "SeedData" + Path.DirectorySeparatorChar + "castMembers.json"));
            var id = 1;

            foreach (var castMember in castMembers)
            {
                castMember.Id = id++;
                builder.Entity<CastMember>().HasData(castMember);
            }
        }

        public static void SeedCrewMembers(this ModelBuilder builder)
        {
            var crewMembers = JsonConvert.DeserializeObject<List<CrewMember>>(File.ReadAllText(@"Config" + Path.DirectorySeparatorChar + "SeedData" + Path.DirectorySeparatorChar + "crewMembers.json"));
            var id = 1;

            foreach (var crewMember in crewMembers)
            {
                crewMember.Id = id++;
                builder.Entity<CrewMember>().HasData(crewMember);
            }
        }
    }
}