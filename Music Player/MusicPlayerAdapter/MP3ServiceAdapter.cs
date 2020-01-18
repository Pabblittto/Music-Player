using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player
{
    class MP3ServiceAdapter : IPlayerAdapter
    {
        WaveOutEvent player;
        Mp3FileReader reader;

        public MP3ServiceAdapter()
        {
            player = new WaveOutEvent();
        }

        public TimeSpan Load(string filePath)
        {
            reader = new Mp3FileReader(filePath);
            player.Init(reader);
            return reader.TotalTime;
        }

        public void Pause()
        {
            player.Pause();
        }

        public void Play()
        {
            player.Play();
        }

        public void SetCertainSecond(int Seconds)
        {
            reader.CurrentTime = TimeSpan.FromSeconds(Seconds);
            player.Stop();
            player.Init(reader);
            player.Play();
        }

        public void SetVolume(float volume)
        {
            player.Volume = volume;
        }

        public void Stop()
        {
            player.Stop();
        }
    }
}
