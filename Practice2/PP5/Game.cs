using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP5
{
    //name,platform,release_date,summary,meta_score,user_review

    public class Game
    {
        public string name { get; set; }
        public string platform { get; set; }
        public string release_date { get; set; }
        public string summary { get; set; }
        public string meta_score { get; set; }
        public  string user_review { get; set; }

        public Game()
        {
            name = "";
            platform = "";
            release_date = "";
            summary = "";
            meta_score = "";
            user_review = "";
        }
        public Game(string data)
        {
            var file = data.Split(',');
            name = file[0];
            platform = file[1];
            release_date = file[2];
            summary = file[3];
            meta_score = file[4];
            user_review = file[5];


        }
        public override string ToString()
        {
            return $"{name}";
        }

    }
}
