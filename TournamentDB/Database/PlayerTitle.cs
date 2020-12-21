using System;

namespace IndrivoDataBase
{
    public class PlayerTitle :BaseEntity
    {
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public Guid TitleId { get; set; }
        public Title Title { get; set; }

    }
}