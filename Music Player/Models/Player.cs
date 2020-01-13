using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    class Player
    {
        private Player instance;
        IPlayerAdapter musicPlayer;
        MP3ServiceAdapter MP3ServiceAdapter = new MP3ServiceAdapter();
        WAVServiceAdapter WAVServiceAdapter = new WAVServiceAdapter();
        Song nowPlaying;

        private Player()
        {

        }

        public Player getInstance()
        {
            if (instance == null)
                instance = new Player();
            return instance;
        }

        public void SetSong(Song song)
        {
            nowPlaying = song;
           string extension = Path.GetExtension(song.path);
            switch (extension)
            {
                case "wav":
                    {
                        musicPlayer = WAVServiceAdapter;
                        break;
                    }
                case "mp3":
                    {
                        musicPlayer = MP3ServiceAdapter;
                        break;
                    }
                default:
                    throw new Exception("This kind of file can not be served");
            }

            musicPlayer.Load(song.path);
        }

        public void Play() => musicPlayer.Play();
        
        public void Pause() => musicPlayer.Pause();

        public void Stop() => musicPlayer.Stop();

        public void setCertainMoment(int second) => musicPlayer.SetCertainSecond(second);




    }
}
