using FormelOne.Models;
using FormelOne.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormelOne
{
    /// <summary>
    /// Implementing IDisposable so i have to create a Dispose function
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork()
        {
            this.context = new MyContext();
            Drivers = new DriverRepostiory(context);
            Seasons = new SeasonRepository(context);
            RacePoints = new RacePointRepository(context);
            Races = new RaceRepository(context);
            Teams = new TeamRepository(context);
        }

        public MyContext context;

        public DriverRepostiory Drivers;

        public SeasonRepository Seasons;

        public RacePointRepository RacePoints;

        public RaceRepository Races;

        public TeamRepository Teams;

        /// <summary>
        /// Throw it out of the memory
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }

        /// <summary>
        /// This will store the changes to the database
        /// </summary>
        /// <returns>
        /// Amount of changes
        /// </returns>
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}