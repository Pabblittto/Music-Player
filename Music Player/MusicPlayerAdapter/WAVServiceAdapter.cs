using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player
{
    class WAVServiceAdapter : IPlayerAdapter
    {
        WaveOutEvent player;
        WaveFileReader reader;

        public WAVServiceAdapter()
        {
            player = new WaveOutEvent();

        }

        public TimeSpan Load(string filepath)
        {
            reader = new WaveFileReader(filepath);
            player.Init(reader);
            return reader.TotalTime;
        }


        public void Play()
        {
            player.Play();
        }

        public void Pause()
        {
            player.Pause();
        }

        public void Stop()
        {
            player.Stop();
        }

        /// <summary>
        /// Volume is between 0 and 1.0
        /// </summary>
        /// <param name="volume"></param>
        public void SetVolume(float volume)
        {
            player.Volume = volume;
        }

        public void SetCertainSecond(int Seconds)
        {
            reader.CurrentTime = TimeSpan.FromSeconds(Seconds);
            player.Stop();
            player.Init(reader);
            player.Play();
        }





    }
}
