using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoboticsTournamentWebsite.Models
{
    // https://developer.toornament.com/v2/doc/organizer_tournaments#post:tournaments
    public class TournamentInfo
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public TimeZoneInfo Timezone { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public string Discipline { get; set; } = "unified_robotics";
        [Required]
        public string ParticipantType { get; set; } = "teams";
        [Required]
        public string[] Platforms { get; set; } = new string[1] { "not_video_game" };

        public string Location { get; set; }
        public DateTime ScheduledStartDate { get; set; }
    }
}
