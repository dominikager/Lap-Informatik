using FormelOne.Models;

namespace FormelOne.Repository
{
    /// <summary>
    /// The SeasonRepository extends the BaseRepository
    /// </summary>
    public class SeasonRepository : BaseRepository<Season>
    {
        public SeasonRepository(MyContext context) : base(context)
        {
        }
    }
}